Imports System.Data.SqlClient
Imports System.IO

Public Class AddStock
    'Change Server & DB name in connection string
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataTable As DataTable
    Dim ms As MemoryStream
    Dim mArrLocImageByte() As Byte
    Dim mArrCustomLocImg As ArrayList
    ' Other variables
    Dim mintSupplierCount As Integer
    Dim mintLocationCount As Integer

    Private Sub AddStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Get current number of suppliers and locations
        mintSupplierCount = cobSupplier.Items.Count
        mintLocationCount = cobLocation.Items.Count
    End Sub

    Private Sub txtISBN_TextChanged(sender As Object, e As EventArgs) Handles txtISBN.TextChanged
        'Ensure numeric data type
        txtISBN.Text = validateText(validateNumber(txtISBN.Text, False, 0), 13)
        txtISBN.SelectionStart = txtISBN.Text.Length
        'If isbn length is reached, switch focus to button
        If (txtISBN.Text.Length = 13) Then
            btnVerifyISBN.Focus()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear all ISBN input and feedback message
        txtISBN.Text = ""
        setFeedback("", True, False)
        pnlAddStockValid.Visible = False
        txtISBN.Focus()
    End Sub

    Private Sub btnVerifyISBN_Click(sender As Object, e As EventArgs) Handles btnVerifyISBN.Click
        'Reinstantiate elements for every session
        mArrCustomLocImg = New ArrayList 'Reinstantiate array for storing custom location images
        setFeedback("", True, False) 'Reinstantiate feedback
        resetFormPanel() 'Reinstantiate input fields

        'Make query and get results
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT * FROM Book WHERE IsbnNumber = @isbn;"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = txtISBN.Text
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataTable)

        If (txtISBN.Text.Trim = "") Then
            'Show input cannot be empty feedback
            setFeedback("Input field cannot be empty!", True, True)
            'Focus on ISBN input field for user correction
            txtISBN.Focus()
        Else
            If (dataTable.Rows.Count <> 0) Then
                'Show record found feedback
                setFeedback(hideTextOverflow("Book found! " & dataTable.Rows(0).Item(1).ToString.ToUpper &
                                              " by " & dataTable.Rows(0).Item(2).ToString.ToUpper,
                                              80, "..."), False, True)
                'Populate comboboxes with valid entries from DB
                populateComboBoxes()
                setISBNFormEnabled(False)

                'Display the form panel
                pnlAddStockValid.Visible = True
                'Set input placeholders
                txtQuantity.Text = "1"
                txtWholesalePrice.Text = FormatCurrency(0, 2)

                'Focus first text field - txtQuantity
                txtQuantity.Focus()
                txtQuantity.SelectAll()
            Else
                'Show record not found feedback
                setFeedback("Book not found: Please enter a valid ISBN! Try copy pasting an existing ISBN.", True, True)
                'Hide form panel
                pnlAddStockValid.Visible = False
                'Focus on ISBN input field for user correction
                txtISBN.Focus()
                txtISBN.SelectAll()
            End If
        End If
    End Sub

    Private Sub cobSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobSupplier.SelectedIndexChanged
        setFormFeedback("", False, False) 'Clear feedback message
    End Sub

    Private Sub txtQuantity_Enter(sender As Object, e As EventArgs) Handles txtQuantity.Enter
        txtQuantity.SelectAll() 'Select all text
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        txtQuantity.Text = validateNumber(txtQuantity.Text, False, 0) 'Validate numeric input 
        txtQuantity.SelectionStart = txtQuantity.Text.Length 'Keep cursor to the right
    End Sub

    Private Sub txtQuantity_Leave(sender As Object, e As EventArgs) Handles txtQuantity.Leave
        'Try block to prevent empty input
        Try
            Dim intQuantity As Integer = CInt(txtQuantity.Text)
            txtQuantity.Text = CStr(intQuantity)
            If (intQuantity < 1) Then
                'If less than 1, reset to default value
                txtQuantity.Text = "1"
            End If
        Catch
            'If empty input, reset to default value
            txtQuantity.Text = "1"
        End Try
    End Sub

    Private Sub txtWholesalePrice_Click(sender As Object, e As EventArgs) Handles txtWholesalePrice.Click
        txtWholesalePrice.SelectAll() 'Select all text
    End Sub

    Private Sub txtWholesalePrice_TextChanged(sender As Object, e As EventArgs) Handles txtWholesalePrice.TextChanged
        setFormFeedback("", False, False)
        txtWholesalePrice.Text = validateNumber(txtWholesalePrice.Text, True, 2) 'Validate numeric input
        txtWholesalePrice.SelectionStart = txtWholesalePrice.Text.Length 'Keep cursor to the right
    End Sub

    Private Sub txtWholesalePrice_Enter(sender As Object, e As EventArgs) Handles txtWholesalePrice.Enter
        txtWholesalePrice.Text = FormatNumber(txtWholesalePrice.Text, 2) 'Convert to decimal number
    End Sub

    Private Sub txtWholesalePrice_Leave(sender As Object, e As EventArgs) Handles txtWholesalePrice.Leave
        'Try block to prevent empty input or invalid inputs caused by dots 
        Try
            txtWholesalePrice.Text = FormatCurrency(txtWholesalePrice.Text, 2)
        Catch
            'If empty or invalid input, reset to default value
            txtWholesalePrice.Text = FormatCurrency(0, 2)
        End Try
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Dim dlgAddSupplier As New DialogAddSupplier
        Dim strSupplierList As New List(Of String)

        'Pass existing entries in cobSupplier to dlgAddSupplier
        For i As Integer = 0 To cobSupplier.Items.Count - 1
            strSupplierList.Add(cobSupplier.Items(i).ToString())
        Next
        dlgAddSupplier.strSuppliers = strSupplierList

        'Open DialogAddSupplier and get user input
        If dlgAddSupplier.ShowDialog() = DialogResult.OK Then
            'Add the user-defined supplier to cobSupplier
            cobSupplier.Items.Add(dlgAddSupplier.supName)
            cobSupplier.SelectedIndex = cobSupplier.Items.Count - 1
            ' Remove previously added but unused entry
            If cobSupplier.Items.Count > mintSupplierCount + 1 Then
                cobSupplier.Items.RemoveAt(cobSupplier.Items.Count - 2)
            End If
        End If
    End Sub

    Private Sub btnAddLocation_Click(sender As Object, e As EventArgs) Handles btnAddLocation.Click
        Dim dlgAddLocation As New DialogAddLocation
        Dim strLocationList As New List(Of String)

        'Pass existing entries in cobLocation to dlgAddLocation
        For i As Integer = 0 To cobLocation.Items.Count - 1
            strLocationList.Add(cobLocation.Items(i).ToString())
        Next
        dlgAddLocation.strLocations = strLocationList

        'Open DialogAddLocation and get user input
        If dlgAddLocation.ShowDialog() = DialogResult.OK Then
            'Add the user-defined location to cobLocation
            mArrCustomLocImg.Add(dlgAddLocation.locPic)
            cobLocation.Items.Add(dlgAddLocation.locName)
            cobLocation.SelectedIndex = cobLocation.Items.Count - 1
            picLocation.Image = dlgAddLocation.locPic

        End If
    End Sub

    Private Sub cobLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobLocation.SelectedIndexChanged
        Dim selectIndexToId As Integer = cobLocation.SelectedIndex + 1
        'Get location image according to selection from DB -
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT * FROM StockLocation;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        Dim customImgStartIndex As Integer = dataTable.Rows.Count 'Immediately afer DB records

        If (cobLocation.SelectedIndex < customImgStartIndex) Then
            'If selected item is existing location in DB
            'SelectedIndex = 0 ~ no. of rows in database
            dataTable = New DataTable 'Reinstantiate dataTable
            query = "SELECT * FROM StockLocation WHERE LocationId = @locationId;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@locationId", SqlDbType.Int)).Value = selectIndexToId
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dataTable)
            'Choose image directly from DB if record exists in DB
            mArrLocImageByte = dataTable.Rows(0)(2)
            ms = New MemoryStream(mArrLocImageByte)
            picLocation.Image = Image.FromStream(ms)
        Else
            'If selected item is custom location
            'SelectedIndex = no.of rows in database + 1 ~ cobLocation.Items.Count - 1 / startIndex + customImgCount
            Dim customImgCount As Integer = cobLocation.Items.Count - dataTable.Rows.Count
            Dim dbImgCount As Integer = cobLocation.Items.Count - customImgCount
            'Choose custom location images saved in array
            For i As Integer = customImgStartIndex To customImgStartIndex + customImgCount - 1
                If (cobLocation.SelectedIndex = i) Then
                    'Get index of target image from arr mapped from custom pic index in combobox
                    'e.g.   DB image - 8 pics
                    '       Uses index starting from 0 to access image arr for combobox indexes >= 9
                    Dim arrImageIndex As Integer = i - dbImgCount
                    picLocation.Image = mArrCustomLocImg.Item(arrImageIndex)
                End If
            Next
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim decPrice As Decimal = FormatNumber(txtWholesalePrice.Text, 2) 'Get price

        If (cobSupplier.SelectedIndex = 0) Then
            'If no supplier selected
            setFormFeedback("Please select a supplier!", True, True)
        ElseIf (decPrice >= 1000) Then
            'If price over 999.99, which is over the maximum char count
            txtWholesalePrice.Focus()
            setFormFeedback("Wholesale price cannot be greater than " & FormatCurrency(999.99, 2) + "!", True, True)
        Else
            'All inputs are valid. Proceed to insert data into DB
            setFormFeedback("", False, False)

            'Show confirmation box
            Dim intConfirm As Integer = MessageBox.Show("Are you sure about adding this stock " & vbCr & "into the database?",
                                                        "Add stock confirmation", MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question)
            If (intConfirm = DialogResult.Yes) Then
                Dim newSupplierId As Integer
                Dim newLocationId As Integer

                connection.Open()

                '1a) Insert new supplier if custom supplier is chosen
                dataTable = New DataTable 'Reinstantiate dataTable
                query = "SELECT * FROM Supplier WHERE UPPER(SupplierName) = @supplierName;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@supplierName", SqlDbType.VarChar)).Value = cobSupplier.Items(cobSupplier.SelectedIndex).ToString.ToUpper
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataTable)

                'Insert if record does not exist in DB
                If (dataTable.Rows.Count = 0) Then
                    'Count existing records to determine new supplier id
                    dataTable = New DataTable 'Reinstantiate dataTable
                    query = "SELECT COUNT(*) FROM Supplier;"
                    dataAdapter = New SqlDataAdapter(query, connection)
                    dataAdapter.Fill(dataTable)
                    newSupplierId = dataTable.Rows(0)(0) + 1

                    query = "INSERT INTO Supplier (SupplierName) VALUES (@name);"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@name", SqlDbType.VarChar, 50)).Value =
                    cobSupplier.Items(cobSupplier.SelectedIndex).ToString
                    sqlCommand.ExecuteNonQuery()
                End If

                '1b) Insert new location if custom location is chosen
                dataTable = New DataTable 'Reinstantiate dataTable
                query = "SELECT * FROM StockLocation WHERE UPPER(LocationName) = @locationName;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@locationName", SqlDbType.VarChar)).Value = cobLocation.Items(cobLocation.SelectedIndex).ToString.ToUpper
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataTable)
                'Insert if record does not exist in DB
                If (dataTable.Rows.Count = 0) Then
                    'Count existing records to determine new record id
                    dataTable = New DataTable 'Reinstantiate dataTable
                    query = "SELECT COUNT(*) FROM StockLocation;"
                    dataAdapter = New SqlDataAdapter(query, connection)
                    dataAdapter.Fill(dataTable)
                    newLocationId = dataTable.Rows(0)(0) + 1

                    ms = New MemoryStream()
                    picLocation.Image.Save(ms, picLocation.Image.RawFormat)
                    mArrLocImageByte = ms.GetBuffer()
                    ms.Close()

                    query = "INSERT INTO StockLocation (LocationName, LocationPicture) VALUES (@name, @pic);"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@name", SqlDbType.VarChar, 50)).Value =
                    cobLocation.Items(cobLocation.SelectedIndex).ToString
                    sqlCommand.Parameters.Add(New SqlParameter("@pic", SqlDbType.Image)).Value = mArrLocImageByte
                    sqlCommand.ExecuteNonQuery()
                End If


                '2) Insert record into Stock
                Dim intStatus As Integer
                Dim intResult As Integer

                For i As Integer = 0 To CInt(txtQuantity.Text) - 1
                    Dim sqlWholesaleParam As New SqlParameter("@wholesale", SqlDbType.Decimal)
                    sqlWholesaleParam.Precision = 5
                    sqlWholesaleParam.Scale = 2

                    query = "INSERT INTO Stock 
                        VALUES(@isbn, @statusid, @supplierid, @wholesale, @locationid);"
                    sqlCommand = New SqlCommand(query, connection)
                    'ISBN
                    sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text
                    'Status
                    '   Remap combobox index to database index
                    If (cobStatus.SelectedIndex + 1 = 3) Then
                        intStatus = 5
                    Else
                        intStatus = cobStatus.SelectedIndex + 1
                    End If
                    sqlCommand.Parameters.Add(New SqlParameter("@statusid", SqlDbType.Int)).Value = intStatus
                    'Supplier
                    '   Use new supplier id if custom supplier is chosen
                    If (newSupplierId <> Nothing) Then
                        sqlCommand.Parameters.Add(New SqlParameter("@supplierid", SqlDbType.Int)).Value = newSupplierId
                    Else
                        sqlCommand.Parameters.Add(New SqlParameter("@supplierid", SqlDbType.Int)).Value = cobSupplier.SelectedIndex
                    End If
                    'Wholesale price
                    sqlCommand.Parameters.Add(sqlWholesaleParam).Value = FormatNumber(txtWholesalePrice.Text, 2)
                    'Location
                    '   Use new location id if custom location is chosen
                    If (newLocationId <> Nothing) Then
                        sqlCommand.Parameters.Add(New SqlParameter("@locationid", SqlDbType.Int)).Value = newLocationId
                    Else
                        sqlCommand.Parameters.Add(New SqlParameter("@locationid", SqlDbType.Int)).Value = cobLocation.SelectedIndex + 1
                    End If

                    intResult = sqlCommand.ExecuteNonQuery()
                Next

                '3) Reset book status for the target book in Dashboard
                'Get number of stocks including new records
                Dim intBookStatusId As Integer
                dataTable = New DataTable
                query = "SELECT COUNT(*) From Stock WHERE IsbnNumber = @isbn"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataTable)

                'Check if sum of quantity >= in stock minimum count (10)
                If (dataTable.Rows(0)(0) >= 10) Then
                    intBookStatusId = 1 'In stock
                Else
                    intBookStatusId = 2 'Low stock
                End If

                'Update the status id value of the target book
                query = "UPDATE Book
                        SET BookStatusId = @bookStatusId
                        WHERE IsbnNumber = @isbn"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text
                sqlCommand.Parameters.Add(New SqlParameter("@bookStatusId", SqlDbType.Int)).Value = intBookStatusId
                sqlCommand.ExecuteNonQuery()

                '4) Check if stock records are inserted successfully
                If (intResult > 0) Then
                        'If rows are inserted, show success message
                        MessageBox.Show("Successfully added stocks." & vbCr & "Check your new records in " & ControlChars.Quote & "View Stocks" & ControlChars.Quote & ".",
                                    "Add stock success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Else
                        'If not, show error message
                        MessageBox.Show("An unexpected error occured, and the stocks were not added." & vbCr &
                                    "Please try again later.", "Add stock failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    connection.Close()

                    'Hide input form and go back to ISBN validation
                    returnValidateISBN()
                End If
            End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim intReply As Integer = MessageBox.Show("Are you sure?" & vbCr & "Caution: All inputs will be discarded!", "Cancel confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If (intReply = DialogResult.Yes) Then
            'Hide input form and go back to ISBN validation
            returnValidateISBN()
        End If
    End Sub

    Private Sub setFeedback(message As String, isInvalid As Boolean, isVisible As Boolean)
        'Set label color
        If (isInvalid) Then
            lblFeedback.ForeColor = Color.Red
        Else
            lblFeedback.ForeColor = Color.Green
        End If

        lblFeedback.Text = message
        lblFeedback.Visible = isVisible
    End Sub

    Private Sub setFormFeedback(message As String, isInvalid As Boolean, isVisible As Boolean)
        'Set label color
        If (isInvalid) Then
            lblFormFeedback.ForeColor = Color.Red
        Else
            lblFormFeedback.ForeColor = Color.Green
        End If

        lblFormFeedback.Text = message
        lblFormFeedback.Visible = isVisible
    End Sub

    Private Sub populateComboBoxes()
        '   cobSupplier
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT SupplierName FROM Supplier;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        cobSupplier.Items.Add("Select a supplier:")
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobSupplier.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobSupplier.SelectedIndex = 0
        '   cobStatus
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT StatusDesc FROM StockStatus;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            If (Not (i = 2 Or i = 3)) Then
                cobStatus.Items.Add(dataTable.Rows(i).Item(0).ToString)
            End If
        Next
        cobStatus.SelectedIndex = 0
        '   cobLocation
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT LocationName FROM StockLocation;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobLocation.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobLocation.SelectedIndex = 0
    End Sub

    Private Sub returnValidateISBN()
        setFeedback("", True, False)
        pnlAddStockValid.Visible = False
        setISBNFormEnabled(True)
        txtISBN.Focus()
        txtISBN.SelectAll()
    End Sub

    Private Sub resetFormPanel()
        'Clear all control data
        txtQuantity.Clear()
        txtWholesalePrice.Clear()
        cobSupplier.Items.Clear()
        cobStatus.Items.Clear()
        cobLocation.Items.Clear()
    End Sub

    Private Sub setISBNFormEnabled(b As Boolean)
        'Set all ISBN Form controls Enabled to the boolean
        txtISBN.Enabled = b
        btnVerifyISBN.Enabled = b
        btnClear.Enabled = b
    End Sub

    Private Function validateText(text As String, maxLength As Integer) As String
        Dim moddedText As String = text

        'Ensure input do not go beyond max length
        If (moddedText.Length >= maxLength) Then
            moddedText = moddedText.Substring(0, maxLength)
        End If

        Return moddedText.Trim() 'Return trimmed String
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

    Private Function hideTextOverflow(text As String, maxLength As Integer, substituteChar As String) As String
        Dim moddedText As String = text
        'Hide overflowing chars with substitute char
        If (text.Length > maxLength) Then
            moddedText = moddedText.Substring(0, maxLength)
            moddedText = moddedText + substituteChar
        End If
        Return moddedText
    End Function
End Class