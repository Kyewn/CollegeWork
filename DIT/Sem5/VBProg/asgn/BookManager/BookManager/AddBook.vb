Imports System.Data.SqlClient
Imports System.IO

Public Class AddBook
    Dim MyDataAdp As New SqlDataAdapter
    Dim dtbExistingCategories As New DataTable
    Dim dtbExistingISBN As New DataTable
    Dim tableCategory As New DataTable
    Dim msgResult As Integer
    Dim ms As MemoryStream
    Dim arrBookImage() As Byte
    Dim sql As String
    Dim cmd As SqlCommand
    Dim MyCn As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    ' Other variables
    Dim intCategoryCount As Integer

    Private Sub AddBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtRetailPrice.Text = FormatCurrency(0, 2)
            Dim idx As Integer
            MyCn.Open()
            MyDataAdp = New SqlDataAdapter("SELECT * FROM Category", MyCn)
            MyDataAdp.Fill(tableCategory)
            For idx = 0 To tableCategory.Rows.Count - 1
                cobCategory.Items.Add(tableCategory.Rows(idx)(1).ToString())
            Next
            cobCategory.SelectedIndex = 0

            ' Get current number of categories
            intCategoryCount = cobCategory.Items.Count
        Catch argEx As ArgumentOutOfRangeException
            MessageBox.Show("Unable to load available categories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MyCn.Close()
    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        Dim dlgAddCategory As New DialogAddCategory
        Dim strCategoryList As New List(Of String)

        'Pass existing entries in cobCategory to dlgAddCategory
        For i As Integer = 0 To cobCategory.Items.Count - 1
            strCategoryList.Add(cobCategory.Items(i).ToString())
        Next
        dlgAddCategory.strCategories = strCategoryList

        ' Open DialogAddCategory and get user input
        If dlgAddCategory.ShowDialog() = DialogResult.OK Then
            cobCategory.Items.Add(dlgAddCategory.categoryName)
            cobCategory.SelectedIndex = cobCategory.Items.Count - 1
            ' Remove previously added but unused entry
            If cobCategory.Items.Count > intCategoryCount + 1 Then
                cobCategory.Items.RemoveAt(cobCategory.Items.Count - 2)
            End If
        End If
    End Sub

    Private Sub btnBrowseImages_Click(sender As Object, e As EventArgs) Handles btnBrowseImages.Click
        Dim dlgOpenFile As New OpenFileDialog

        If dlgOpenFile.ShowDialog() = DialogResult.OK Then
            Try
                picBookCover.Image = Image.FromFile(dlgOpenFile.FileName)
            Catch ex As Exception
                MessageBox.Show("You must select an image file", "Error Occured", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        ms = New MemoryStream()
        picBookCover.Image.Save(ms, picBookCover.Image.RawFormat)
        arrBookImage = ms.GetBuffer()
        ms.Close()
        Try
            MyCn.Open()
            dtbExistingISBN.Clear()
            sql = "SELECT * FROM Book WHERE IsbnNumber = @isbnNumber"
            cmd = New SqlCommand(sql, MyCn)
            cmd.Parameters.Add(New SqlParameter("@isbnNumber", SqlDbType.VarChar, 13)).Value = txtISBN.Text.Trim()
            MyDataAdp = New SqlDataAdapter(cmd)
            MyDataAdp.Fill(dtbExistingISBN)

            If String.IsNullOrEmpty(txtTitle.Text) Or String.IsNullOrEmpty(txtAuthor.Text) Or
                String.IsNullOrEmpty(txtPublisher.Text) Or String.IsNullOrEmpty(txtISBN.Text) Then
                lblErrorMessage.Text = "Please fill in all input fields!"
                lblErrorMessage.Visible = True
                If (String.IsNullOrEmpty(txtTitle.Text)) Then
                    txtTitle.Focus()
                ElseIf (String.IsNullOrEmpty(txtAuthor.Text)) Then
                    txtAuthor.Focus()
                ElseIf (String.IsNullOrEmpty(txtPublisher.Text)) Then
                    txtPublisher.Focus()
                ElseIf (String.IsNullOrEmpty(txtISBN.Text)) Then
                    txtISBN.Focus()
                End If
            ElseIf txtISBN.Text.Length < 13 Then
                lblErrorMessage.Text = "ISBN number is not a 13-character numeric code!"
                lblErrorMessage.Visible = True
                txtISBN.Focus()
                txtISBN.SelectAll()
            ElseIf dtbExistingISBN.Rows.Count() <> 0 Then
                lblErrorMessage.Text = "A book already exists with the specified ISBN number!"
                lblErrorMessage.Visible = True
                txtISBN.Focus()
                txtISBN.SelectAll()
            ElseIf FormatNumber(txtRetailPrice.Text, 2) >= 1000 Then
                lblErrorMessage.Text = "Retail price cannot be greater than " & FormatCurrency(999.99, 2) + "!"
                lblErrorMessage.Visible = True
                txtRetailPrice.Focus()
            Else
                lblErrorMessage.Text = ""
                lblErrorMessage.Visible = False

                'Show confirmation box
                Dim intConfirm As Integer = MessageBox.Show("Are you sure about adding this book " & vbCr & "into the database?",
                                                            "Add Book Confirmation", MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question)
                If (intConfirm = DialogResult.Yes) Then
                    sql = "SELECT * FROM Category WHERE UPPER(CategoryName) = @categoryName"
                    cmd = New SqlCommand(sql, MyCn)
                    cmd.Parameters.Add(New SqlParameter("@categoryName", SqlDbType.VarChar, 30)).Value = cobCategory.SelectedItem.ToString.ToUpper
                    MyDataAdp = New SqlDataAdapter(cmd)
                    MyDataAdp.Fill(dtbExistingCategories)

                    'If category does not exist in database
                    If (dtbExistingCategories.Rows.Count = 0) Then
                        ' Add new category into Category table in database
                        sql = "INSERT INTO Category (CategoryName)
                               VALUES (@categoryName)"
                        cmd = New SqlCommand(sql, MyCn)
                        cmd.Parameters.Add(New SqlParameter("categoryName", SqlDbType.VarChar, 30)).Value = cobCategory.SelectedItem.ToString
                        cmd.ExecuteNonQuery()
                    End If

                    Dim intResult As Integer
                    sql = "INSERT INTO Book (IsbnNumber, Title, Author, CategoryId, Publisher, PublicationDate, RetailPrice, BookPicture)
                           VALUES (@isbn, @title, @author, @category, @publisher, @pubDate, @retail, @bookpic)"
                    cmd = New SqlCommand(sql, MyCn)
                    cmd.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text.Trim()
                    cmd.Parameters.Add(New SqlParameter("@title", SqlDbType.VarChar, 150)).Value = txtTitle.Text.Trim()
                    cmd.Parameters.Add(New SqlParameter("@author", SqlDbType.VarChar, 100)).Value = txtAuthor.Text.Trim()
                    cmd.Parameters.Add(New SqlParameter("@category", SqlDbType.Int)).Value = cobCategory.SelectedIndex + 1
                    cmd.Parameters.Add(New SqlParameter("@publisher", SqlDbType.VarChar, 50)).Value = txtPublisher.Text.Trim()
                    cmd.Parameters.Add(New SqlParameter("@pubDate", SqlDbType.Date)).Value = datePicker.Text
                    cmd.Parameters.Add(New SqlParameter("@retail", SqlDbType.Decimal, 5, 2)).Value = CDec(txtRetailPrice.Text)
                    cmd.Parameters.Add(New SqlParameter("@bookpic", SqlDbType.Image)).Value = arrBookImage

                    intResult = cmd.ExecuteNonQuery()
                    If (intResult > 0) Then
                        MessageBox.Show("Successfully added book." & vbCr & "Check your new records in the " & ControlChars.Quote & "Dashboard" & ControlChars.Quote & ".",
                                        "Add book success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                        'Clear the Saved Data
                        cobCategory.Items.Clear()
                        tableCategory.Clear()
                        Dim idx As Integer
                        MyDataAdp = New SqlDataAdapter("SELECT * FROM Category", MyCn)
                        MyDataAdp.Fill(tableCategory)
                        For idx = 0 To tableCategory.Rows.Count - 1
                            cobCategory.Items.Add(tableCategory.Rows(idx)(1).ToString())
                        Next
                        cobCategory.SelectedIndex = 0

                        resetForm()
                    Else
                        MessageBox.Show("An unexpected error occured, and the book was not added." & ControlChars.Quote &
                                    "Please try again later.", "Add book failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                End If
            End If
            MyCn.Close()
        Catch ex As Exception
            MessageBox.Show("An unexpected error occured during the add book process." & vbCr &
                            "Please try again later.", "Unexpected errpr",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        msgResult = MessageBox.Show("Are you sure?" & vbCr & "Caution: All inputs will be discarded!", "Cancel confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If msgResult = DialogResult.Yes Then
            MyCn.Open()
            cobCategory.Items.Clear()
            tableCategory.Clear()
            Dim idx As Integer
            MyDataAdp = New SqlDataAdapter("SELECT * FROM Category", MyCn)
            MyDataAdp.Fill(tableCategory)
            For idx = 0 To tableCategory.Rows.Count - 1
                cobCategory.Items.Add(tableCategory.Rows(idx)(1).ToString())
            Next
            cobCategory.SelectedIndex = 0

            resetForm()
            MyCn.Close()
        End If
    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged
        txtTitle.Text = validateText(txtTitle.Text, 150)
        txtTitle.SelectionStart = txtTitle.Text.Length 'Ensure caret stays at the right end
        lblErrorMessage.Text = ""
        lblErrorMessage.Visible = False
    End Sub

    Private Sub txtAuthor_TextChanged(sender As Object, e As EventArgs) Handles txtAuthor.TextChanged
        txtAuthor.Text = validateText(txtAuthor.Text, 100)
        txtAuthor.SelectionStart = txtAuthor.Text.Length 'Ensure caret stays at the right end
        lblErrorMessage.Text = ""
        lblErrorMessage.Visible = False
    End Sub

    Private Sub txtPublisher_TextChanged(sender As Object, e As EventArgs) Handles txtPublisher.TextChanged
        txtPublisher.Text = validateText(txtPublisher.Text, 50)
        txtPublisher.SelectionStart = txtPublisher.Text.Length 'Ensure caret stays at the right end
        lblErrorMessage.Text = ""
        lblErrorMessage.Visible = False
    End Sub

    Private Sub txtISBN_TextChanged(sender As Object, e As EventArgs) Handles txtISBN.TextChanged
        txtISBN.Text = validateText(validateNumber(txtISBN.Text, False, 0), 13).Trim()
        txtISBN.SelectionStart = txtISBN.Text.Length 'Ensure caret stays at the right end
        lblErrorMessage.Text = ""
        lblErrorMessage.Visible = False
    End Sub

    Private Sub txtRetailPrice_TextChanged(sender As Object, e As EventArgs) Handles txtRetailPrice.TextChanged
        txtRetailPrice.Text = validateNumber(txtRetailPrice.Text, True, 2)
    End Sub

    Private Sub txtRetailPrice_Enter(sender As Object, e As EventArgs) Handles txtRetailPrice.Enter
        txtRetailPrice.Text = FormatNumber(txtRetailPrice.Text, 2)
    End Sub

    Private Sub txtRetailPrice_Leave(sender As Object, e As EventArgs) Handles txtRetailPrice.Leave
        'Try block to prevent empty input or invalid inputs caused by dots 
        Try
            txtRetailPrice.Text = FormatCurrency(txtRetailPrice.Text, 2)
        Catch
            'If empty or invalid input, reset to default value
            txtRetailPrice.Text = FormatCurrency(0, 2)
        End Try
    End Sub

    Private Sub txtRetailPrice_Click(sender As Object, e As EventArgs) Handles txtRetailPrice.Click
        txtRetailPrice.SelectAll() 'Select all text
    End Sub

    Private Sub resetForm()
        txtTitle.Clear()
        txtAuthor.Clear()
        txtPublisher.Clear()
        datePicker.Value = DateAndTime.Today
        txtISBN.Clear()
        txtRetailPrice.Text = FormatCurrency(0, 2)
        picBookCover.Image = BookManager.My.Resources.Resources.image_not_found
        txtTitle.Focus()
    End Sub

    Private Function validateText(text As String, maxLength As Integer) As String
        Dim moddedText As String = text

        'Ensure input do not go beyond max length
        If (moddedText.Length >= maxLength) Then
            moddedText = moddedText.Substring(0, maxLength)
        End If

        Return moddedText 'Return trimmed String
    End Function

    Private Function validateNumber(text As String, allowDot As Boolean, purgeLetterStart As Integer) As String
        Dim moddedText As String = text

        'Ensure input does not contain letters/special chars
        'If first character is typed
        If (text.Length = 1) Then
            If (Not IsNumeric(text)) Then
                'Set empty text
                moddedText = ""
            End If
        Else
            'If >= 2 characters are typed
            'Ensure letters are not in the string
            Dim pointer As String
            Dim remoddedText As String
            If (text.Length < purgeLetterStart) Then
                remoddedText = moddedText
            Else
                remoddedText = text.Substring(0, purgeLetterStart)
            End If

            If (allowDot) Then
                'Extract all chars excluding letters / special chars but include dots
                For i As Integer = purgeLetterStart To moddedText.Length - 1
                    pointer = moddedText.Substring(i, 1)
                    If (IsNumeric(pointer) Or pointer = ".") Then
                        remoddedText += pointer
                    End If
                Next
            Else
                'Extract all chars excluding letters / special chars
                For i As Integer = purgeLetterStart To moddedText.Length - 1
                    pointer = moddedText.Substring(i, 1)
                    If (IsNumeric(pointer)) Then
                        remoddedText += pointer
                    End If
                Next
            End If
            moddedText = remoddedText
        End If

        Return moddedText.Trim() 'Return trimmed String
    End Function
End Class