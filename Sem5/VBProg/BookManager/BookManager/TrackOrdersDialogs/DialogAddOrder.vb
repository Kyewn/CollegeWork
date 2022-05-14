Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DialogAddOrder
    Dim fmtStrTable As String = "{0,-10}{1,-35}{2,-20}{3,-20}{4,-8}"
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataTable As DataTable
    Dim dtbLatestOrderID As New DataTable
    Dim dtbLatestStockNumber As New DataTable
    Dim dtbExistingBook As DataTable
    Dim dtbAddRow As DataTable
    Dim mintSupplierCount As Integer

    'Property value holders
    Dim arrOrderStockNos As List(Of Integer) = New List(Of Integer)
    Dim arrOrderStockSuppliers As List(Of String) = New List(Of String)
    Dim arrOrderStockPrices As List(Of Decimal) = New List(Of Decimal)
    Dim arrOrderStockIsbns As List(Of String) = New List(Of String)
    Dim intOrderId As Integer
    Dim intStockNumber As Integer

    Public Property propOrderStockNos As List(Of Integer)
        Get
            Return arrOrderStockNos
        End Get
        Set(value As List(Of Integer))
            arrOrderStockNos = value
        End Set
    End Property

    Public Property propOrderStockSuppliers As List(Of String)
        Get
            Return arrOrderStockSuppliers
        End Get
        Set(value As List(Of String))
            arrOrderStockSuppliers = value
        End Set
    End Property

    Public Property propOrderStockPrices As List(Of Decimal)
        Get
            Return arrOrderStockPrices
        End Get
        Set(value As List(Of Decimal))
            arrOrderStockPrices = value
        End Set
    End Property

    Public Property propOrderStockIsbns As List(Of String)
        Get
            Return arrOrderStockIsbns
        End Get
        Set(value As List(Of String))
            arrOrderStockIsbns = value
        End Set
    End Property

    Public Property orderId As Integer
        Get
            Return intOrderId
        End Get
        Set(value As Integer)
            intOrderId = value
        End Set
    End Property

    Private Sub txtISBN_TextChanged(sender As Object, e As EventArgs) Handles txtISBN.TextChanged
        toggleForm(False)
        setVerifyFeedback("", False, False)
        'Ensure numeric data type
        txtISBN.Text = validateText(validateNumber(txtISBN.Text, False, 0), 13)
        txtISBN.SelectionStart = txtISBN.Text.Length
        'If isbn length is reached, switch focus to button
        If (txtISBN.Text.Length = 13) Then
            btnVerify.Focus()
        End If
    End Sub

    Private Sub txtISBN_Click(sender As Object, e As EventArgs) Handles txtISBN.Click
        txtISBN.SelectAll()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        resetForm()
        setVerifyFeedback("Note: ISBN field only accept 13-digit numbers.", False, True)
        lblVerifyResult.ForeColor = Color.Blue
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        cobSupplier.SelectedIndex = 0
        If (txtISBN.Text = "") Then
            'Clear data and focus on stock number input field for user correction
            resetForm()
            'Show input cannot be empty feedback
            setVerifyFeedback("Input field cannot be empty!", True, True)
        Else
            connection.Open()
            Try
                dtbExistingBook = New DataTable
                'Make query and get results
                query = "SELECT Title, Author
                    FROM Book
                    WHERE IsbnNumber = @isbn;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text.Trim
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbExistingBook)

                If (dtbExistingBook.Rows.Count <> 0) Then
                    'Show record found feedback
                    setVerifyFeedback(hideTextOverflow("Book found! " & dtbExistingBook.Rows(0).Item(0).ToString.ToUpper &
                                              " by " & dtbExistingBook.Rows(0).Item(1).ToString.ToUpper,
                                              75, "…"), False, True)

                    toggleForm(True)
                    txtQuantity.Focus()
                Else
                    'Clear data and focus on stock number input field for user correction
                    resetForm()
                    'Show record not found feedback
                    setVerifyFeedback("Book not found: Please enter a valid ISBN! Try copy pasting an existing ISBN.", True, True)
                End If
            Catch
                ' Catch all
                MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            connection.Close()
        End If
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
        setVerifyFeedback("", False, False)
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

        mintSupplierCount = cobSupplier.Items.Count
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim decPrice As Decimal = FormatNumber(txtWholesalePrice.Text, 2) 'Get price

        If (cobSupplier.SelectedIndex = 0) Then
            'If no supplier selected
            setVerifyFeedback("Please select a supplier!", True, True)
        ElseIf (decPrice >= 1000) Then
            'If price over 999.99, which is over the maximum char count
            txtWholesalePrice.Focus()
            setVerifyFeedback("Wholesale price cannot be greater than " & FormatCurrency(999.99, 2) + "!", True, True)
        Else
            connection.Open()
            'Delete 'no items message' only on initial addition
            If (arrOrderStockIsbns.Count = 0) Then
                lstOrderItems.Items.Clear()
                btnDelete.Visible = True
                btnConfirmOrder.Enabled = True
            End If

            'Make query and get results
            For i As Integer = 0 To CInt(txtQuantity.Text) - 1
                Dim newStockNo As Integer = intStockNumber
                Dim todayDate As String = String.Format("{0:d/M/yyyy}", Date.Now())
                'StockNumber, Title, Author, SupplierName, WholesalePrice
                dtbAddRow = New DataTable
                query = "SELECT Title, Author
                FROM Book
                WHERE IsbnNumber = @isbn;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = txtISBN.Text.Trim
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbAddRow)

                'Add record to list
                lstOrderItems.Items.Add(String.Format(fmtStrTable,
                    hideTextOverflow("C" & newStockNo, 6, "…"),
                    hideTextOverflow(dtbAddRow.Rows(0)(0).ToString.Trim(), 28, "…"),
                    hideTextOverflow(dtbAddRow.Rows(0)(1).ToString.Trim(), 16, "…"),
                    hideTextOverflow(cobSupplier.SelectedItem.ToString, 14, "…"),
                    hideTextOverflow(txtWholesalePrice.Text.Substring(2, txtWholesalePrice.Text.Length - 2), 8, "…")
                ))

                'Save record to arrays for insert statement later
                arrOrderStockIsbns.Add(txtISBN.Text.Trim)
                arrOrderStockSuppliers.Add(cobSupplier.SelectedItem.ToString)
                arrOrderStockPrices.Add(FormatNumber(txtWholesalePrice.Text, 2))
                arrOrderStockNos.Add(intStockNumber)

                intStockNumber += 1
            Next
            'Select the record
            lstOrderItems.SelectedIndex = lstOrderItems.Items.Count - 1

            'Reset inputs
            resetForm()
            setVerifyFeedback("Note: ISBN field only accept 13-digit numbers.", False, True)
            lblVerifyResult.ForeColor = Color.Blue

            connection.Close()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim deleteIndex As Integer = lstOrderItems.SelectedIndex
        Dim boolPreviousTopSelection As Boolean = False
        Dim boolPreviousBottomSelection As Boolean = False

        'Only perform deletion if an index is selected
        If (lstOrderItems.SelectedIndex <> -1) Then
            If (lstOrderItems.Items.Count = 1) Then
                'Display no items message in listbox
                lstOrderItems.Items.Add("No items added.")
                'Select the no items message
                lstOrderItems.SelectedIndex = 1
                'Disable confirm button
                btnConfirmOrder.Enabled = False
                'Hide delete button
                btnDelete.Visible = False
            ElseIf (lstOrderItems.SelectedIndex = lstOrderItems.Items.Count - 1) Then
                'Select item above if selected record is last record
                lstOrderItems.SelectedIndex -= 1
                boolPreviousBottomSelection = True
            Else
                'Else select item below
                lstOrderItems.SelectedIndex += 1
                boolPreviousTopSelection = True
            End If

            'Only delete from array if delete target is not the no items message
            If (lstOrderItems.Items(deleteIndex).ToString <> "No items added.") Then
                arrOrderStockIsbns.RemoveAt(deleteIndex)
                arrOrderStockSuppliers.RemoveAt(deleteIndex)
                arrOrderStockPrices.RemoveAt(deleteIndex)
                arrOrderStockNos.RemoveAt(deleteIndex)
            End If
            'Remove target record
            lstOrderItems.Items.RemoveAt(deleteIndex)
            'Update latest stock number
            intStockNumber -= 1

            ' Update the following records' stock number and decrement them by 1
            ' Only if selected index is not last item
            Dim numOfRecordsToEdit As Integer = lstOrderItems.Items.Count - lstOrderItems.SelectedIndex - 1
            If (numOfRecordsToEdit <> 0) Then
                'Update stock number in array
                Dim currentIndex = lstOrderItems.SelectedIndex
                For i As Integer = currentIndex To arrOrderStockNos.Count - 1
                    arrOrderStockNos.Item(i) -= 1
                Next

                'Update stock number in table
                For i As Integer = 0 To numOfRecordsToEdit
                    'currentIndex = lstOrderItems.SelectedIndex
                    Dim stockNo As String = lstOrderItems.Items(currentIndex).ToString.Substring(1, 9).Trim()
                    Dim bookTitle As String = lstOrderItems.Items(currentIndex).ToString.Substring(10, 35).Trim()
                    Dim bookAuthor As String = lstOrderItems.Items(currentIndex).ToString.Substring(45, 20).Trim()
                    Dim supplierName As String = lstOrderItems.Items(currentIndex).ToString.Substring(65, 20).Trim()
                    Dim wholesalePrice As String = lstOrderItems.Items(currentIndex).ToString.Substring(85, 8).Trim()
                    lstOrderItems.Items.Add(String.Format(fmtStrTable,
                        hideTextOverflow("C" & (CInt(stockNo) - 1), 6, "…"),
                        hideTextOverflow(bookTitle, 28, "…"),
                        hideTextOverflow(bookAuthor, 16, "…"),
                        hideTextOverflow(supplierName, 14, "…"),
                        hideTextOverflow(wholesalePrice, 8, "…")
                    ))
                    lstOrderItems.SelectedIndex += 1
                    lstOrderItems.Items.RemoveAt(currentIndex)
                Next
            Else
                ' Also Returns true if selected item is last item, ensure next selected item (item above)
                ' doesn't enter the condition
                If (boolPreviousTopSelection = True And boolPreviousBottomSelection = False) Then
                    'Replace the last item if 2nd last item is selected
                    Dim lastIndex = lstOrderItems.Items.Count - 1
                    If (arrOrderStockNos.Count <> 0) Then
                        arrOrderStockNos.Item(arrOrderStockNos.Count - 1) -= 1
                    End If
                    Dim stockNo As String = lstOrderItems.Items(lastIndex).ToString.Substring(1, 9).Trim()
                    Dim bookTitle As String = lstOrderItems.Items(lastIndex).ToString.Substring(10, 35).Trim()
                    Dim bookAuthor As String = lstOrderItems.Items(lastIndex).ToString.Substring(45, 20).Trim()
                    Dim supplierName As String = lstOrderItems.Items(lastIndex).ToString.Substring(65, 20).Trim()
                    Dim wholesalePrice As String = lstOrderItems.Items(lastIndex).ToString.Substring(85, 8).Trim()
                    lstOrderItems.Items.Add(String.Format(fmtStrTable,
                        hideTextOverflow("C" & (CInt(stockNo) - 1), 6, "…"),
                        hideTextOverflow(bookTitle, 28, "…"),
                        hideTextOverflow(bookAuthor, 16, "…"),
                        hideTextOverflow(supplierName, 14, "…"),
                        hideTextOverflow(wholesalePrice, 8, "…")
                    ))
                    lstOrderItems.SelectedIndex += 1
                    lstOrderItems.Items.RemoveAt(lastIndex)
                End If
            End If
        Else
            'Or else show error message
            MessageBox.Show("No stock selected, please select a stock in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnConfirmOrder_Click(sender As Object, e As EventArgs) Handles btnConfirmOrder.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim intConfirm As Integer = MessageBox.Show("Are you sure?" & ControlChars.NewLine &
                                    "Caution: All changes will be discarded.",
                                    "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If (intConfirm = DialogResult.Yes) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub DialogAddOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateCobSupplier()
        txtWholesalePrice.Text = FormatCurrency(0, 2)

        'Get latest order ID
        connection.Open()
        query = "SELECT OrderId
                    FROM Orders
                    ORDER BY OrderId DESC;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dtbLatestOrderID)
        connection.Close()

        If (dtbLatestOrderID.Rows.Count = 0) Then
            intOrderId = 1
        Else
            intOrderId = dtbLatestOrderID.Rows(0)(0) + 1
        End If
        txtOrderId.Text = "O" & intOrderId

        'Get latest stock number
        connection.Open()
        query = "SELECT IDENT_CURRENT('Stock')"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dtbLatestStockNumber)
        connection.Close()

        If (dtbLatestStockNumber.Rows.Count = 0) Then
            intStockNumber = 1
        Else
            intStockNumber = dtbLatestStockNumber.Rows(0)(0) + 1
        End If

        'Display empty message in listbox
        lstOrderItems.Items.Add("No items added.")
    End Sub

    Private Sub setVerifyFeedback(message As String, isInvalid As Boolean, isVisible As Boolean)
        'Set label color
        If (isInvalid) Then
            lblVerifyResult.ForeColor = Color.Red
        Else
            lblVerifyResult.ForeColor = Color.Green
        End If

        lblVerifyResult.Text = message
        lblVerifyResult.Visible = isVisible
    End Sub

    Private Sub resetForm()
        'Clear all input data excluding sale ID (need to be reused)
        txtISBN.Clear()
        txtQuantity.Clear()
        txtWholesalePrice.Text = FormatCurrency(0, 2)
        cobSupplier.SelectedIndex = 0
        'Hide add item button
        toggleForm(False)
        'Focus on ISBN input field for user correction
        txtISBN.Focus()
        txtISBN.SelectAll()
    End Sub

    Private Sub toggleForm(bool As Boolean)
        lblQuantity.Visible = bool
        txtQuantity.Visible = bool
        lblWholesalePrice.Visible = bool
        txtWholesalePrice.Visible = bool
        lblSupplier.Visible = bool
        cobSupplier.Visible = bool
        btnAddSupplier.Visible = bool
        btnAdd.Visible = bool
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

    Private Sub populateCobSupplier()
        connection.Open()
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
        connection.Close()
    End Sub
End Class
