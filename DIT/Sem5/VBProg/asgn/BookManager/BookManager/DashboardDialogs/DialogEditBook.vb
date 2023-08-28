Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class DialogEditBook

    Public Property strTitle As String
        Get
            Return txtTitle.Text
        End Get
        Set(value As String)
            txtTitle.Text = value
        End Set
    End Property
    Public Property strAuthor As String
        Get
            Return txtAuthor.Text
        End Get
        Set(value As String)
            txtAuthor.Text = value
        End Set
    End Property
    Public Property strPublisher As String
        Get
            Return txtPublisher.Text
        End Get
        Set(value As String)
            txtPublisher.Text = value
        End Set
    End Property
    Public Property datPublicationDate As Date
        Get
            Return dtpPublicationDate.Value
        End Get
        Set(value As Date)
            dtpPublicationDate.Value = value
        End Set
    End Property
    Public Property decRetailPrice As Decimal
        Get
            Return txtRetailPrice.Text
        End Get
        Set(value As Decimal)
            txtRetailPrice.Text = CStr(value)
        End Set
    End Property
    Public Property strISBN As String
        Get
            Return txtISBN.Text
        End Get
        Set(value As String)
            txtISBN.Text = value
        End Set
    End Property
    Public Property intCategory As Integer
        Get
            Return cobCategory.SelectedIndex
        End Get
        Set(value As Integer)
            intSelectedCategory = value
        End Set
    End Property
    Public Property bytArrImage As Byte()
        Get
            Dim converter As New ImageConverter
            Return converter.ConvertTo(picBookCover, GetType(Byte()))
        End Get
        Set(value As Byte())
            ms = New MemoryStream(value)
            picBookCover.Image = Image.FromStream(ms)
        End Set
    End Property

    ' SQL Server variables
    Dim ms As MemoryStream
    Dim arrImage() As Byte
    Dim sql As String
    Dim cmd As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim conn As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    ' Other variables
    Dim currentISBN As String
    Dim intSelectedCategory As Integer
    Dim strErrorMessage As String
    Dim intCategoryCount As Integer

    Private Sub DialogEditBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()

        ' Store current ISBN upon each load
        currentISBN = txtISBN.Text.Trim()

        Try
            ' Set query and create SQL command
            sql = "SELECT * FROM Category;"
            cmd = New SqlCommand(sql, conn)
            ' Retrieve categories from DB
            adapter = New SqlDataAdapter(cmd)
            Dim dataSet As New DataSet()
            adapter.Fill(dataSet, "Category")
            Dim rows As Integer = dataSet.Tables(0).Rows.Count

            ' Load categories into cobCategory
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    cobCategory.Items.Add(dataSet.Tables(0).Rows(i)("CategoryName"))
                Next
            End If
            ' Set selected category to the book's current category
            cobCategory.SelectedIndex = intSelectedCategory

            ' Get current number of categories
            intCategoryCount = cobCategory.Items.Count
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
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
        ' Display OpenFileDialog for user to upload image
        If dlgOpenFile.ShowDialog() = DialogResult.OK Then
            Try
                picBookCover.Image = Image.FromFile(dlgOpenFile.FileName)
            Catch ex As Exception
                MessageBox.Show("You must select an image file", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim hasError As Boolean = False
        Dim decRetailPrice As Decimal
        strErrorMessage = ""

        ' Perform input validation and error checks
        ' Check for empty input fields
        If String.IsNullOrEmpty(txtTitle.Text.Trim()) Or String.IsNullOrEmpty(txtAuthor.Text.Trim()) Or
           String.IsNullOrEmpty(txtPublisher.Text.Trim()) Or String.IsNullOrEmpty(txtRetailPrice.Text.Trim()) Or
           String.IsNullOrEmpty(txtISBN.Text.Trim()) Then
            hasError = True
            strErrorMessage = "Please ensure there are no empty input fields." & ControlChars.NewLine
        ElseIf Not IsNumeric(txtISBN.Text) Then
            ' Check if ISBN has alphabets/special characters
            hasError = True
            strErrorMessage = "ISBN Number must not contain alphabets or special characters."
        ElseIf txtISBN.Text.ToString().Length <> 13 Then
            ' Check if ISBN has 13 numbers
            hasError = True
            strErrorMessage = "ISBN Number must be 13 numbers long."
        Else
            ' Check if retail price has alphabets/special characters (other than fullstop)
            Try
                decRetailPrice = CDec(txtRetailPrice.Text.Trim())
                ' Check if retail price exceeds limit
                If decRetailPrice > 999.99 Then
                    hasError = True
                    strErrorMessage = "Retail Price cannot exceed 999.99."
                End If
            Catch ex As InvalidCastException
                hasError = True
                strErrorMessage = "Retail Price must not contain alphabets or special characters other than '.'."
            End Try
        End If

        ' If no basic errors, proceed to check for database rules/constraints violations
        If Not hasError Then
            conn.Open()

            ' Validate inputs against rules, constraints, etc. set in database definitions
            Try
                Dim dataTable As New DataTable
                ' Check for duplicate ISBN
                sql = "SELECT * FROM Book WHERE IsbnNumber = @isbn;"
                cmd = New SqlCommand(sql, conn)
                cmd.Parameters.Add("@isbn", SqlDbType.VarChar).Value = txtISBN.Text
                adapter = New SqlDataAdapter(cmd)
                adapter.Fill(dataTable)
                If dataTable.Rows.Count > 0 Then
                    If dataTable.Rows(0)("IsbnNumber") <> currentISBN Then
                        hasError = True
                        strErrorMessage = "This ISBN Number already exists in the database, please enter a unique ISBN Number." & ControlChars.NewLine
                        txtISBN.Select()
                    End If
                End If
            Catch ex As Exception
                ' Catch all exceptions
                MessageBox.Show("An unknown error has occured while validating inputs, please try again.", "Unknown Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' If no violations, update book record and close dialog
            If Not hasError Then
                ' Clear error message
                lblErrorMessage.Text = ""
                Try
                    ' Prompt user for confirmation
                    Dim intReply As Integer = MessageBox.Show("Are you sure?" & ControlChars.NewLine & "Changes made cannot be reversed.",
                                                              "Edit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    ' If user chooses Yes, proceed to UPDATE Book record
                    If intReply = DialogResult.Yes Then
                        ' If user added new category, insert it into database before updating Book record
                        sql = "SELECT * FROM Category WHERE UPPER(CategoryName) = @categoryName"
                        cmd = New SqlCommand(sql, conn)
                        cmd.Parameters.Add(New SqlParameter("@categoryName", SqlDbType.VarChar, 30)).Value = cobCategory.SelectedItem.ToString().ToUpper()
                        adapter = New SqlDataAdapter(cmd)
                        Dim dtbExistingCategories As New DataTable
                        adapter.Fill(dtbExistingCategories)

                        'If category does not exist in database
                        If (dtbExistingCategories.Rows.Count = 0) Then
                            ' Add new category into Category table in database
                            sql = "INSERT INTO Category (CategoryName) VALUES (@categoryName);"
                            cmd = New SqlCommand(sql, conn)
                            cmd.Parameters.Add(New SqlParameter("categoryName", SqlDbType.VarChar, 30)).Value = cobCategory.SelectedItem.ToString()
                            cmd.ExecuteNonQuery()
                        End If

                        ' Set SQL query to UPDATE Book record
                        sql = "UPDATE Book SET IsbnNumber = @newIsbn, Title = @title, Author = @author, Publisher = @publisher,
                               PublicationDate = @publicationDate, RetailPrice = @retailPrice, CategoryId = @categoryId, BookPicture = @bookPicture
                               WHERE IsbnNumber = @currentIsbn;"
                        cmd = New SqlCommand(sql, conn)
                        ' Set parameters in SQL query
                        cmd.Parameters.Add("@newIsbn", SqlDbType.VarChar).Value = txtISBN.Text
                        cmd.Parameters.Add("@currentIsbn", SqlDbType.VarChar).Value = currentISBN
                        cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txtTitle.Text
                        cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = txtAuthor.Text
                        cmd.Parameters.Add("@publisher", SqlDbType.VarChar).Value = txtPublisher.Text
                        cmd.Parameters.Add("@publicationDate", SqlDbType.Date).Value = dtpPublicationDate.Value
                        cmd.Parameters.Add("@retailPrice", SqlDbType.Decimal).Value = decRetailPrice
                        cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = cobCategory.SelectedIndex + 1
                        ' Set image parameter
                        ms = New MemoryStream()
                        picBookCover.Image.Save(ms, picBookCover.Image.RawFormat)
                        arrImage = ms.GetBuffer()
                        cmd.Parameters.Add("@bookPicture", SqlDbType.Image).Value = arrImage
                        ' Execute query
                        cmd.ExecuteNonQuery()
                        ' Close dialog
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Catch ex As Exception
                    ' Catch all exceptions
                    MessageBox.Show("An error has occured while updating book record, please try again.", "Unknown Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                ' Show error message
                lblErrorMessage.Text = strErrorMessage
            End If
        Else
            ' Show error message
            lblErrorMessage.Text = strErrorMessage
        End If

        conn.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Do nothing and close dialog
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtISBN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtISBN.KeyDown
        ' Supress letters from being entered
        If Char.IsLetter(ChrW(e.KeyCode)) And e.Modifiers <> Keys.Control Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtISBN_KeyPressed(sender As Object, e As KeyPressEventArgs) Handles txtISBN.KeyPress
        ' Prevent all special characters
        If Regex.IsMatch(e.KeyChar, "[\`\~\!\@\#\$\%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRetailPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetailPrice.KeyDown
        ' Suppress letters from being entered
        If Char.IsLetter(ChrW(e.KeyCode)) And e.Modifiers <> Keys.Control Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtRetailPrice_KeyPressed(sender As Object, e As KeyPressEventArgs) Handles txtRetailPrice.KeyPress
        ' Prevent special characters except for Period/Fullstop
        If Regex.IsMatch(e.KeyChar, "[\`\~\!\@\#\$\%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\\?/]") Then
            e.Handled = True
        End If
        ' Prevent more than 1 Period/Fullstop from being entered
        If e.KeyChar = "." And txtRetailPrice.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub
End Class
