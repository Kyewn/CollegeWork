Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DialogAddSale
    Dim fmtStrTable As String = "{0,-11}{1,-11}{2,-36}{3,-13}{4,-10}"
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dtbExistingStockNo As DataTable
    Dim dtbLatestSaleID As New DataTable
    Dim dtbOrderSoldStock As DataTable
    Dim dtbAddRow As DataTable

    'Property value holders
    Dim arrAddedStockNos As List(Of Integer) = New List(Of Integer)
    Dim intSaleId As Integer

    Public Property propArrAddedStockNos As List(Of Integer)
        Get
            Return arrAddedStockNos
        End Get
        Set(value As List(Of Integer))
            arrAddedStockNos = value
        End Set
    End Property

    Public Property saleId As Integer
        Get
            Return intSaleId
        End Get
        Set(value As Integer)
            intSaleId = value
        End Set
    End Property

    Private Sub DialogAddSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.Open()

        query = "SELECT SaleId
                FROM Sale
                ORDER BY SaleId DESC;"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbLatestSaleID)

        If (dtbLatestSaleID.Rows.Count = 0) Then
            intSaleId = 1
        Else
            intSaleId = dtbLatestSaleID.Rows(0)(0) + 1
        End If
        txtSaleId.Text = "S" & intSaleId

        'Display empty message in listbox
        lstSaleItems.Items.Add("No items added.")

        connection.Close()
    End Sub

    Private Sub btnConfirmSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmSale.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim intConfirm As Integer = MessageBox.Show("Are you sure?" & ControlChars.NewLine &
                                    "Caution: All changes will be discarded.",
                                   "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If intConfirm = DialogResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtStockNo_TextChanged(sender As Object, e As EventArgs) Handles txtStockNo.TextChanged
        txtStockNo.Text = validateStockNumber(txtStockNo.Text, 1)
        txtStockNo.SelectionStart = txtStockNo.Text.Length
        setVerifyFeedback("", True, False) 'Clear feedback
        txtSupplier.Text = ""
        btnAdd.Visible = False
    End Sub

    Private Sub txtStockNo_Enter(sender As Object, e As EventArgs) Handles txtStockNo.Enter
        Dim supplierData As String = txtSupplier.Text.Trim
        Try
            txtStockNo.Text = FormatNumber(txtStockNo.Text.Substring(1, txtStockNo.Text.Length - 1), 0)
        Catch
            txtStockNo.Text = ""
        End Try
        'Prevent supplier text from being cleared if user just editing/clicking
        'the stock number field
        txtSupplier.Text = supplierData
    End Sub

    Private Sub txtStockNo_Leave(sender As Object, e As EventArgs) Handles txtStockNo.Leave
        Dim supplierData As String = txtSupplier.Text.Trim
        Dim stockNoPrefix As String = "C"
        txtStockNo.Text = stockNoPrefix + txtStockNo.Text
        'Prevent supplier text from being cleared if user just editing/clicking
        'the stock number field
        txtSupplier.Text = supplierData
    End Sub

    Private Sub txtStockNo_Click(sender As Object, e As EventArgs) Handles txtStockNo.Click
        txtStockNo.SelectAll()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        resetForm()
        setVerifyFeedback("Note: Stock number field only accept numbers. Please specify one without the prefix.", False, True)
        lblVerifyResult.ForeColor = Color.Blue
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim boolIsAlreadyAdded As Boolean = False
        Dim boolIsAlreadyOrderedSold As Boolean = False
        dtbExistingStockNo = New DataTable

        If (txtStockNo.Text = "") Then
            'Show input cannot be empty feedback
            setVerifyFeedback("Input field cannot be empty!", True, True)

            'Clear data and focus on stock number input field for user correction
            resetForm()
        Else
            connection.Open()
            Try
                'Make query and get results
                Dim stockNo As String = txtStockNo.Text.Substring(1, txtStockNo.Text.Length - 1)
                query = "SELECT Title, Author, SupplierName
                FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                JOIN Supplier ON (Stock.SupplierId = Supplier.SupplierId)
                WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = CInt(stockNo)
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbExistingStockNo)

                If (dtbExistingStockNo.Rows.Count <> 0) Then
                    'Show record found feedback
                    setVerifyFeedback(hideTextOverflow("Stock found! " & dtbExistingStockNo.Rows(0).Item(0).ToString.ToUpper &
                                                  " by " & dtbExistingStockNo.Rows(0).Item(1).ToString.ToUpper,
                                                  75, "…"), False, True)

                    'Set input placeholders
                    txtSupplier.Text = dtbExistingStockNo.Rows(0).Item(2)

                    'Check whether stock is already sold
                    dtbOrderSoldStock = New DataTable
                    query = "SELECT StockStatusId
                        FROM Stock 
                        WHERE StockNumber = @stockNo;"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = CInt(stockNo)
                    dataAdapter = New SqlDataAdapter(sqlCommand)
                    dataAdapter.Fill(dtbOrderSoldStock)

                    If (dtbOrderSoldStock.Rows(0)(0) = 3 Or dtbOrderSoldStock.Rows(0)(0) = 4) Then
                        boolIsAlreadyOrderedSold = True
                        'Hide add item button
                        btnAdd.Visible = False
                        'Focus on ISBN input field for user correction
                        txtStockNo.Focus()
                        txtStockNo.SelectAll()
                        If (dtbOrderSoldStock.Rows(0)(0) = 3) Then
                            setVerifyFeedback("Stock in order: Stock found, but the stock is in order.", True, True)
                        Else
                            setVerifyFeedback("Stock sold: Stock found, but the stock is already sold.", True, True)
                        End If
                    End If

                    ' Check whether stock is already in the table
                    For i As Integer = 0 To arrAddedStockNos.Count - 1
                        If (arrAddedStockNos.Item(i) = stockNo) Then
                            boolIsAlreadyAdded = True
                            'Hide add item button
                            btnAdd.Visible = False
                            'Focus on ISBN input field for user correction
                            txtStockNo.Focus()
                            txtStockNo.SelectAll()
                            setVerifyFeedback("Stock added: Stock found, but the stock is already added to the table.", True, True)
                        End If
                    Next

                    'Enable add button if stock hasnt been added to the table and isnt sold yet
                    If (boolIsAlreadyAdded = False And boolIsAlreadyOrderedSold = False) Then
                        btnAdd.Visible = True
                    End If
                Else
                    txtSupplier.Clear()
                    'Hide add item button
                    btnAdd.Visible = False
                    'Focus on ISBN input field for user correction
                    txtStockNo.Focus()
                    txtStockNo.SelectAll()
                    'Show record not found feedback
                    setVerifyFeedback("Stock not found: Please enter a valid stock number. Try copy pasting a valid stock number.", True, True)
                End If
            Catch
                ' Catch all
                MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            connection.Close()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        connection.Open()

        'Delete 'no items message' only on initial addition
        If (arrAddedStockNos.Count = 0) Then
            lstSaleItems.Items.Clear()
            btnDelete.Visible = True
            btnConfirmSale.Enabled = True
        End If

        'Make query and get results
        Dim stockNo As String = txtStockNo.Text.Substring(1, txtStockNo.Text.Length - 1)
        Dim todayDate As String = String.Format("{0:d/M/yyyy}", Date.Now())
        dtbAddRow = New DataTable
        query = "SELECT Title, RetailPrice
                FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE StockNumber = @stockNo;"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = CInt(stockNo)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbAddRow)

        'Add record to list
        lstSaleItems.Items.Add(String.Format(fmtStrTable,
            hideTextOverflow(txtSaleId.Text.Trim, 6, "…"),
            hideTextOverflow(txtStockNo.Text.Trim, 6, "…"),
            hideTextOverflow(dtbAddRow.Rows(0)(0).ToString.Trim(), 30, "…"),
            hideTextOverflow(dtbAddRow.Rows(0)(1).ToString.Trim(), 8, "…"),
            hideTextOverflow(todayDate, 10, "…")
        ))
        'Select the record
        lstSaleItems.SelectedIndex = lstSaleItems.Items.Count - 1
        'Save record to AddedStocks array for reference
        arrAddedStockNos.Add(stockNo)

        'Reset inputs
        txtStockNo.Clear()
        setVerifyFeedback("Note: Stock number field only accept numbers. Please specify one without the prefix.", False, True)
        lblVerifyResult.ForeColor = Color.Blue
        btnAdd.Visible = False

        connection.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim deleteIndex As Integer = lstSaleItems.SelectedIndex

        'Only perform deletion if an index is selected
        If (lstSaleItems.SelectedIndex <> -1) Then
            If (lstSaleItems.Items.Count = 1) Then
                'Display no items message in listbox
                lstSaleItems.Items.Add("No items added.")
                'Select the no items message
                lstSaleItems.SelectedIndex = 1
                'Disable confirm button
                btnConfirmSale.Enabled = False
                btnDelete.Visible = False
            ElseIf (lstSaleItems.SelectedIndex = lstSaleItems.Items.Count - 1) Then
                'Select item above if selected record is last record
                lstSaleItems.SelectedIndex -= 1
            Else
                'Else select item below
                lstSaleItems.SelectedIndex += 1
            End If

            'Only delete from array if delete target is not the no items message
            If (lstSaleItems.Items(deleteIndex).ToString <> "No items added.") Then
                arrAddedStockNos.RemoveAt(deleteIndex)
            End If
            'Remove target record
            lstSaleItems.Items.RemoveAt(deleteIndex)
        Else
            'Or else show error message
            MessageBox.Show("No stock selected, please select a stock in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
        txtStockNo.Clear()
        txtSupplier.Clear()
        'Hide add item button
        btnAdd.Visible = False
        'Focus on ISBN input field for user correction
        txtStockNo.Focus()
        txtStockNo.SelectAll()
    End Sub

    Private Function validateStockNumber(text As String, purgeLetterStart As Integer) As String
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


            'Extract all chars excluding letters / special chars
            For i As Integer = purgeLetterStart To moddedText.Length - 1
                pointer = moddedText.Substring(i, 1)
                If (IsNumeric(pointer)) Then
                    remoddedText += pointer
                End If
            Next
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
