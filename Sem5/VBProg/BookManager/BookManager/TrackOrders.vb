Imports System.Data.SqlClient

Public Class TrackOrders

    Public Property pDlgOrderSearchSettings As DialogOrderSearchSettings
        Get
            Return dlgOrderSearchSettings
        End Get
        Set(value As DialogOrderSearchSettings)
            dlgOrderSearchSettings = value
        End Set
    End Property

    'OrderId, StockNumber, Title, Supplier, WholesalePrice, OrderDate, StatusDesc
    Dim fmtStrOrderTable = "{0,-14}{1,-12}{2,-64}{3,-26}{4,-13}{5,-16}{6,-12}"
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataSet As DataSet
    Dim dtbOrderRecords As DataTable
    Dim dtbOrderItemDetails As DataTable
    Dim dtbExistingSupplier As DataTable
    Dim dtbItemBookInfo As DataTable
    Dim dtbStockCountExcludeOrderSold As DataTable
    'DialogAddOrder Variables
    Dim arrOrderStockIsbns As List(Of String)
    Dim arrOrderStockSuppliers As List(Of String)
    Dim arrOrderStockPrices As List(Of Decimal)
    Dim arrOrderStockNos As List(Of Integer)
    'Search function variables
    Dim dlgOrderSearchSettings As New DialogOrderSearchSettings
    Dim boolSettingsApplied As Boolean = False
    Dim boolSearchAll As Boolean
    Dim boolSearchOrderId As Boolean
    Dim boolSearchStockNumber As Boolean
    Dim boolSearchTitle As Boolean
    Dim boolSearchWholesalePrice As Boolean
    Dim boolSearchOrderDate As Boolean
    Dim boolSearchIsbn As Boolean
    Dim strSearchSupplier As String
    Dim strSearchStatus As String
    Dim strOrConditions As New List(Of String)
    Dim strAndConditions As New List(Of String)

    Private Sub txtSearchBar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchBar.KeyDown
        ' Execute Search function if user presses ENTER from txtSearchBar
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Construct SQL query to retrieve books with details that match the search key and search settings
        Try
            Dim searchKey As String = txtSearchBar.Text.ToString().Trim()

            'If search key is following stock number's pattern, modify search key to exclude the prefix 
            'to allow matching in DB
            'Only do the modification if search box is not empty and has at least 2 chars
            If (Not String.IsNullOrEmpty(searchKey) And searchKey.Length >= 2) Then
                If (searchKey.ToUpper.Substring(0, 1) = "C" And IsNumeric(searchKey.Substring(1, 1)) Or
                    searchKey.ToUpper.Substring(0, 1) = "O" And IsNumeric(searchKey.Substring(1, 1))) Then
                    searchKey = searchKey.Substring(1, searchKey.Length - 1)
                End If
            End If

            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB
            connection.Open()
            query = "SELECT OrderId, Orders.StockNumber, Title, SupplierName, WholesalePrice, OrderDate, StatusDesc
                    FROM Orders JOIN Stock ON (Orders.StockNumber = Stock.StockNumber)
                        JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber) 
                        JOIN Supplier ON (Stock.SupplierId = Supplier.SupplierId)
                        JOIN OrderStatus ON (Orders.OrderStatusId = OrderStatus.OrderStatusId)
                    WHERE "

            ' Modify SQL query WHERE conditions based on applied "Search by" settings
            If boolSettingsApplied Then
                ' - - - OR conditions ("Search by" checkboxes) - - -
                If boolSearchAll Then
                    ' Search by all columns
                    query += "(OrderId LIKE @searchKey OR Orders.StockNumber LIKE @searchKey OR Title LIKE @searchKey 
                              OR WholesalePrice LIKE @searchKey OR OrderDate LIKE @searchKey OR Stock.IsbnNumber LIKE @searchKey)"
                ElseIf strOrConditions.Count <> 0 Then
                    query += "("
                    ' Search by selected columns
                    For i As Integer = 0 To strOrConditions.Count - 1
                        query += strOrConditions(i)
                        ' Append OR operator if current item is not the last one
                        If i <> strOrConditions.Count - 1 Then
                            query += " OR "
                        End If
                    Next
                    query += ")"
                End If
                ' - - - AND conditions ("Filter" combo boxes) - - -
                If strAndConditions.Count <> 0 Then
                    query += " AND "
                    For i As Integer = 0 To strAndConditions.Count - 1
                        query += strAndConditions(i)
                        ' Append AND operator if current item is not the last one
                        If i <> strAndConditions.Count - 1 Then
                            query += " AND "
                        End If
                    Next
                End If
            Else
                ' Search by all columns (DEFAULT/NO SETTINGS APPLIED)
                query += "(OrderId LIKE @searchKey OR Orders.StockNumber LIKE @searchKey OR Title LIKE @searchKey 
                           OR WholesalePrice LIKE @searchKey OR OrderDate LIKE @searchKey Or Stock.IsbnNumber LIKE @searchKey)"
            End If
            query += ";" ' END OF SQL QUERY CONSTRUCTION

            ' Set SQL command to execute search query and retrieve data from DB
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add("@searchKey", SqlDbType.VarChar).Value = "%" & searchKey & "%"
            If strAndConditions.Count <> 0 Then
                sqlCommand.Parameters.Add("@supplierName", SqlDbType.VarChar).Value = strSearchSupplier
                sqlCommand.Parameters.Add("@statusDesc", SqlDbType.VarChar).Value = strSearchStatus
            End If
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataSet = New DataSet
            dataAdapter.Fill(dataSet, "MatchedStock")
            connection.Close()

            ' Update lstBooks (If matching rows returned: add items; Else: show no results)
            Dim rows As Integer = dataSet.Tables(0).Rows.Count
            lstOrder.Items.Clear()
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    Dim shortDate As DateTime = dataSet.Tables(0).Rows(i)("OrderDate").ToString
                    lstOrder.Items.Add(String.Format(fmtStrOrderTable,
                        hideTextOverflow("  O" & dataSet.Tables(0).Rows(i)("OrderId").ToString, 6, "…"),
                        hideTextOverflow("C" & dataSet.Tables(0).Rows(i)("StockNumber").ToString, 6, "…"),
                        hideTextOverflow(dataSet.Tables(0).Rows(i)("Title").ToString, 60, "…"),
                        hideTextOverflow(dataSet.Tables(0).Rows(i)("SupplierName").ToString, 20, "…"),
                        hideTextOverflow(dataSet.Tables(0).Rows(i)("WholesalePrice").ToString, 7, "…"),
                        hideTextOverflow(shortDate.ToShortDateString, 10, "…"),
                        hideTextOverflow(dataSet.Tables(0).Rows(i)("StatusDesc").ToString, 12, "…")
                    ))
                Next
                lstOrder.SelectedIndex = 0
                toggleOrderDetail(True)
            Else
                lstOrder.Items.Add("No matching orders found.")
                toggleOrderDetail(False)
            End If
            ' Update lblResults to display number of stocks loaded
            lblResults.Text = rows & " order(s) found..."

            Me.Cursor = Cursors.Default ' Set cursor back to Default when search process is complete
        Catch
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program resets

        ' Clear searchbar and search settings
        txtSearchBar.Clear()
        strOrConditions.Clear()
        strAndConditions.Clear()
        boolSettingsApplied = False
        boolSearchAll = False
        boolSearchOrderId = False
        boolSearchStockNumber = False
        boolSearchTitle = False
        boolSearchWholesalePrice = False
        boolSearchOrderDate = False
        boolSearchIsbn = False
        strSearchSupplier = "-"
        strSearchStatus = "-"

        updateOrderRecords()

        ' Reset settings in DialogBookSearchSettings
        dlgOrderSearchSettings.boolChkAll = True
        dlgOrderSearchSettings.selectedSupplier = 0
        dlgOrderSearchSettings.selectedStatus = 0

        Me.Cursor = Cursors.Default ' Set cursor back to Default when reset process is complete
        'Focus on search textbox for easier entering
        txtSearchBar.Focus()
    End Sub

    Private Sub btnSearchSettings_Click(sender As Object, e As EventArgs) Handles btnSearchSettings.Click
        ' Open DialogOrderSearchSettings and get user input
        If dlgOrderSearchSettings.ShowDialog() = DialogResult.OK Then
            ' Apply search settings and filters
            strOrConditions.Clear()
            strAndConditions.Clear()
            ' Get search settings and filters
            boolSearchAll = dlgOrderSearchSettings.boolChkAll
            boolSearchOrderId = dlgOrderSearchSettings.boolChkOrderId
            boolSearchStockNumber = dlgOrderSearchSettings.boolChkStockNumber
            boolSearchTitle = dlgOrderSearchSettings.boolChkTitle
            boolSearchWholesalePrice = dlgOrderSearchSettings.boolChkWholesalePrice
            boolSearchOrderDate = dlgOrderSearchSettings.boolChkOrderDate
            boolSearchIsbn = dlgOrderSearchSettings.boolChkIsbn
            strSearchSupplier = dlgOrderSearchSettings.strCobSupplier
            strSearchStatus = dlgOrderSearchSettings.strCobStatus

            'If all checkboxes are checked false, check "All" option
            If (boolSearchAll = False And boolSearchOrderId = False And boolSearchStockNumber = False And
                boolSearchTitle = False And boolSearchWholesalePrice = False And boolSearchOrderDate = False And boolSearchIsbn = False) Then
                dlgOrderSearchSettings.boolChkAll = True
                boolSearchAll = True
            End If

            ' Check whether any search options were selected
            If boolSearchAll = True Or boolSearchOrderId = True Or boolSearchStockNumber = True Or
               boolSearchTitle = True Or boolSearchWholesalePrice = True Or boolSearchOrderDate = True Or
               boolSearchIsbn = True Or strSearchSupplier <> "-" Or strSearchStatus <> "-" Then
                boolSettingsApplied = True
            End If
            ' Add applied settings/filters to Lists storing SQL WHERE conditions
            ' - - - OR conditions ("Search by" checkboxes) - - -
            If boolSearchAll Then
                strOrConditions.Add("OrderId LIKE @searchKey")
                strOrConditions.Add("Orders.StockNumber LIKE @searchKey")
                strOrConditions.Add("Title LIKE @searchKey")
                strOrConditions.Add("WholesalePrice LIKE @searchKey")
                strOrConditions.Add("OrderDate LIKE @searchKey")
                strOrConditions.Add("SupplierName LIKE @searchKey")
                strOrConditions.Add("StatusDesc LIKE @searchKey")
                strOrConditions.Add("Stock.IsbnNumber LIKE @searchKey")
            Else
                If boolSearchOrderId Then
                    strOrConditions.Add("OrderId LIKE @searchKey")
                End If
                If boolSearchStockNumber Then
                    strOrConditions.Add("Orders.StockNumber LIKE @searchKey")
                End If
                If boolSearchTitle Then
                    strOrConditions.Add("Title LIKE @searchKey")
                End If
                If boolSearchWholesalePrice Then
                    strOrConditions.Add("WholesalePrice LIKE @searchKey")
                End If
                If boolSearchOrderDate Then
                    strOrConditions.Add("OrderDate LIKE @searchKey")
                End If
                If boolSearchIsbn Then
                    strOrConditions.Add("Stock.IsbnNumber LIKE @searchKey")
                End If
            End If
            ' - - - AND conditions ("Filters" combo boxes) - - -
            If strSearchSupplier <> "-" Then
                strAndConditions.Add("SupplierName = @supplierName")
            End If
            If strSearchStatus <> "-" Then
                strAndConditions.Add("StatusDesc = @statusDesc")
            End If

            'Focus on search textbox for easier entering
            txtSearchBar.Focus()
        End If
    End Sub

    Private Sub btnEditOrder_Click(sender As Object, e As EventArgs) Handles btnEditOrder.Click
        Dim editIndex As Integer = lstOrder.SelectedIndex
        If (editIndex <> -1) Then
            Dim stockNo As Integer = CInt(lstOrder.Items(lstOrder.SelectedIndex).ToString.Substring(15, 11).Trim())
            ' Issue with getting date value - specially retrieved date from DB to easily convert to
            ' short date format
            connection.Open()
            dtbOrderItemDetails = New DataTable
            query = "SELECT OrderId, SupplierId, WholesalePrice, OrderDate, OrderStatusId
                    FROM Orders JOIN Stock ON (Orders.StockNumber = Stock.StockNumber)
                    WHERE Orders.StockNumber = @stockNo;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dtbOrderItemDetails)
            connection.Close()

            Dim orderId As Integer = dtbOrderItemDetails.Rows(0)(0)
            Dim supplierId As Integer = dtbOrderItemDetails.Rows(0)(1)
            Dim wholesalePrice As Decimal = dtbOrderItemDetails.Rows(0)(2)
            Dim orderDate As DateTime = dtbOrderItemDetails.Rows(0)(3)
            Dim statusId As Integer = dtbOrderItemDetails.Rows(0)(4)

            Dim intResult As Integer

            Dim dlgEditOrder As New DialogEditOrder
            dlgEditOrder.propOrderId = orderId
            dlgEditOrder.propStockNo = stockNo
            dlgEditOrder.propWholesalePrice = wholesalePrice
            dlgEditOrder.intCobSupplier = supplierId
            dlgEditOrder.propOrderDate = orderDate
            dlgEditOrder.intCobStatus = statusId

            ' Open DialogEditOrder and get user input
            If dlgEditOrder.ShowDialog() = DialogResult.OK Then
                Dim intSupplierId As Integer = 0

                connection.Open()
                'Insert new supplier if chosen
                dtbExistingSupplier = New DataTable
                query = "SELECT SupplierId
                        FROM Supplier
                        WHERE UPPER(SupplierName) = @suppName"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = dlgEditOrder.strCobSupplier.Trim().ToUpper()
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbExistingSupplier)
                connection.Close()

                ' If supplier exists
                If (dtbExistingSupplier.Rows.Count <> 0) Then
                    ' Get supplier id
                    intSupplierId = CInt(dtbExistingSupplier.Rows(0)(0).ToString)
                Else
                    connection.Open()
                    ' Insert new supplier record
                    query = "INSERT INTO Supplier (SupplierName)
                            VALUES (@suppName)"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = dlgEditOrder.strCobSupplier.Trim()
                    sqlCommand.ExecuteNonQuery()

                    'Then get the new supplier id
                    dtbExistingSupplier = New DataTable
                    query = "SELECT SupplierId
                        FROM Supplier
                        WHERE UPPER(SupplierName) = @suppName"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = dlgEditOrder.strCobSupplier.Trim().ToUpper
                    dataAdapter = New SqlDataAdapter(sqlCommand)
                    dataAdapter.Fill(dtbExistingSupplier)
                    intSupplierId = CInt(dtbExistingSupplier.Rows(0)(0).ToString)
                    connection.Close()
                End If

                connection.Open()
                ' 1. Edit order record based on user inputs in the table (GUI)
                dataSet = New DataSet
                ' Process supplier string
                query = "SELECT SupplierName
                FROM Supplier
                WHERE SupplierId = @suppId;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@suppId", SqlDbType.Int)).Value = intSupplierId
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataSet, "SelectedSupplierName")

                ' Process status string
                query = "SELECT StatusDesc
                FROM OrderStatus
                WHERE OrderStatusId = @statusId;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@statusId", SqlDbType.Int)).Value = dlgEditOrder.intCobStatus + 1
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataSet, "SelectedStatusDesc")

                ' Edit record with new values
                dtbOrderItemDetails = New DataTable
                query = "SELECT Title, Stock.IsbnNumber
                FROM Stock JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = dlgEditOrder.propStockNo
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbOrderItemDetails)
                connection.Close()

                lstOrder.Items.Insert(editIndex, String.Format(fmtStrOrderTable,
                    hideTextOverflow("  O" & orderId, 6, "…"),
                    hideTextOverflow("C" & stockNo, 6, "…"),
                    hideTextOverflow(dtbOrderItemDetails.Rows(0)(0).ToString, 60, "…"),
                    hideTextOverflow(dataSet.Tables("SelectedSupplierName").Rows(0)(0).ToString, 20, "…"),
                    hideTextOverflow(dlgEditOrder.propWholesalePrice.ToString, 7, "…"),
                    hideTextOverflow(dlgEditOrder.propOrderDate.ToShortDateString, 10, "…"),
                    hideTextOverflow(dataSet.Tables("SelectedStatusDesc").Rows(0)(0).ToString, 12, "…")
                ))
                ' Select latest inserted record
                lstOrder.SelectedIndex = editIndex
                ' Remove previous target record
                lstOrder.Items.RemoveAt(editIndex + 1)

                ' 2. Update record in DB Orders and Stocks table
                Dim sqlWholesaleParam As New SqlParameter("@wholesale", SqlDbType.Decimal)
                sqlWholesaleParam.Precision = 5
                sqlWholesaleParam.Scale = 2
                Dim isReceived As Integer

                If (dlgEditOrder.intCobStatus = 0) Then
                    isReceived = 1
                Else
                    isReceived = 3
                End If

                connection.Open()
                query = "UPDATE Stock 
                        SET SupplierId = @suppId,
                            WholesalePrice = @wholesale,
                            StockStatusId = @statusId
                        WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@suppId", SqlDbType.Int)).Value = intSupplierId
                sqlCommand.Parameters.Add(sqlWholesaleParam).Value = dlgEditOrder.propWholesalePrice
                sqlCommand.Parameters.Add(New SqlParameter("@statusId", SqlDbType.Int)).Value = isReceived
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                sqlCommand.ExecuteNonQuery()

                query = "UPDATE Orders 
                    SET OrderDate = @date,
                        OrderStatusId = @statusId
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@date", SqlDbType.Date)).Value = dlgEditOrder.propOrderDate
                sqlCommand.Parameters.Add(New SqlParameter("@statusId", SqlDbType.Int)).Value = dlgEditOrder.intCobStatus + 1
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                intResult = sqlCommand.ExecuteNonQuery()

                ' 3. Recalculate available stock amount and set BookStatusId for Book table
                dtbItemBookInfo = New DataTable
                query = "SELECT Title, RetailPrice, Stock.IsbnNumber
                FROM Stock JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbItemBookInfo)
                refreshBookStatus()

                ' 4. Update status blocks
                updateStatusBlocks()

                ' Show success / fail message
                If (intResult > 0) Then
                    MessageBox.Show("Successfully edited order record.",
                                "Edit order success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("An unexpected error occured, the order record was not edited." & vbCr &
                                "Please try again.", "Edit order failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                connection.Close()
            End If
        Else
            'No index selected, show error message
            MessageBox.Show("No order record selected, please select a order record in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDeleteOrder_Click(sender As Object, e As EventArgs) Handles btnDeleteOrder.Click
        Dim intReply As Integer
        intReply = MessageBox.Show("Are you sure?" & ControlChars.NewLine & "Note: This cannot be undone.",
                                   "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        ' Delete order record If answer is YES, Else do nothing
        If (intReply = DialogResult.Yes) Then
            Dim editIndex As Integer = lstOrder.SelectedIndex
            Dim stockNo As Integer = CInt(lstOrder.Items(lstOrder.SelectedIndex).ToString.Substring(15, 11).Trim())
            Dim intResult As Integer

            If (editIndex <> -1) Then
                ' 1. Delete order record in the table (GUI)
                'Calibrate selected index to prevent selected index = -1 errors
                'If selected record is not the last record in the table
                If (editIndex + 1 <> lstOrder.Items.Count) Then
                    lstOrder.SelectedIndex = editIndex + 1
                Else
                    'Else if it is the last table record
                    'If table only has 1 record
                    If (lstOrder.Items.Count = 1) Then
                        lstOrder.Items.Insert(0, "No orders found.")
                        lstOrder.SelectedIndex = 0
                        editIndex = 1
                    Else
                        'Else if table has more than 1 record
                        lstOrder.SelectedIndex -= 1
                    End If
                End If
                'After setting up, delete the item
                lstOrder.Items.RemoveAt(editIndex)
                ' Clear lblResults and txtSearchBar text
                lblResults.Text = "1 order deleted..."
                txtSearchBar.Text = ""
                ' Hide details if no more items in the table
                If (lstOrder.Items(0).ToString = "No orders found.") Then
                    toggleOrderDetail(False)
                End If

                ' 2. Update record in DB Order table
                connection.Open()
                query = "DELETE FROM Orders 
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                intResult = sqlCommand.ExecuteNonQuery()

                ' 3. Delete target stock in DB Stock table
                query = "DELETE FROM Stock
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                sqlCommand.ExecuteNonQuery()

                'Update status blocks
                updateStatusBlocks()
                lblResults.Text = "1 order deleted."

                ' Show success / fail message
                If (intResult > 0) Then
                    MessageBox.Show("Successfully deleted order record.",
                                    "Delete order success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("An unexpected error occured, the order record was not deleted." & vbCr &
                                    "Please try again.", "Delete order failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                connection.Close()
            Else
                'No index selected, show error message
                MessageBox.Show("No order record selected, please select an order record in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim dlgAddOrder As New DialogAddOrder
        ' Open DialogAddOrder and get user input
        If dlgAddOrder.ShowDialog() = DialogResult.OK Then
            ' Add new order into Order table in database
            Dim intResult As Integer
            Dim intOrderId As Integer = dlgAddOrder.orderId
            Dim todayDate As String = String.Format("{0:d/M/yyyy}", Date.Now())
            arrOrderStockIsbns = dlgAddOrder.propOrderStockIsbns
            arrOrderStockSuppliers = dlgAddOrder.propOrderStockSuppliers
            arrOrderStockPrices = dlgAddOrder.propOrderStockPrices
            arrOrderStockNos = dlgAddOrder.propOrderStockNos

            'For each item to be processed
            For i As Integer = 0 To arrOrderStockIsbns.Count - 1
                Dim intSupplierId As Integer = 0

                connection.Open()
                ' 1. Process supplier name - get supplier id if exist in DB / insert into DB if doesnt exist
                dtbExistingSupplier = New DataTable
                query = "SELECT SupplierId
                        FROM Supplier
                        WHERE UPPER(SupplierName) = @suppName"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = arrOrderStockSuppliers.Item(i).ToUpper
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbExistingSupplier)

                ' If supplier exists
                If (dtbExistingSupplier.Rows.Count <> 0) Then
                    ' Get supplier id
                    intSupplierId = CInt(dtbExistingSupplier.Rows(0)(0).ToString)
                Else
                    ' Insert new supplier record
                    query = "INSERT INTO Supplier (SupplierName)
                            VALUES (@suppName)"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = arrOrderStockSuppliers.Item(i)
                    sqlCommand.ExecuteNonQuery()

                    'Then get the new supplier id
                    dtbExistingSupplier = New DataTable
                    query = "SELECT SupplierId
                        FROM Supplier
                        WHERE UPPER(SupplierName) = @suppName"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@suppName", SqlDbType.VarChar)).Value = arrOrderStockSuppliers.Item(i).ToUpper
                    dataAdapter = New SqlDataAdapter(sqlCommand)
                    dataAdapter.Fill(dtbExistingSupplier)
                    intSupplierId = CInt(dtbExistingSupplier.Rows(0)(0).ToString)
                End If

                ' 2. Add to Stock table in DB
                query = "INSERT INTO Stock (IsbnNumber, StockStatusId, SupplierId, WholesalePrice, LocationId)
                        VALUES (@isbn, 3, @suppId, @wsPrice, 1)"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = arrOrderStockIsbns.Item(i)
                sqlCommand.Parameters.Add(New SqlParameter("@suppId", SqlDbType.Int)).Value = intSupplierId
                sqlCommand.Parameters.Add(New SqlParameter("@wsPrice", SqlDbType.VarChar)).Value = arrOrderStockPrices.Item(i)
                sqlCommand.ExecuteNonQuery()

                ' 3. Add to Orders table in DB
                query = "INSERT INTO Orders (OrderId, StockNumber, OrderDate, OrderStatusId)
                        VALUES (@orderId, @stockNo, @date, 2)"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@orderId", SqlDbType.Int)).Value = intOrderId
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = arrOrderStockNos.Item(i)
                sqlCommand.Parameters.Add(New SqlParameter("@date", SqlDbType.Date)).Value = todayDate
                intResult = sqlCommand.ExecuteNonQuery()

                ' 4. Add order records based on user inputs in the dialog (GUI)
                dtbItemBookInfo = New DataTable
                query = "SELECT Title, StatusDesc
                        FROM Orders JOIN Stock ON (Orders.StockNumber = Stock.StockNumber) 
                            JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber)
                            JOIN OrderStatus ON (Orders.OrderStatusId = OrderStatus.OrderStatusId)
                        WHERE Stock.IsbnNumber = @isbn;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = arrOrderStockIsbns.Item(i)
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbItemBookInfo)

                lstOrder.Items.Add(String.Format(fmtStrOrderTable,
                    hideTextOverflow("  O" & intOrderId, 6, "…"),
                    hideTextOverflow("C" & arrOrderStockNos.Item(i).ToString, 6, "…"),
                    hideTextOverflow(dtbItemBookInfo.Rows(0)(0).ToString, 60, "…"),
                    hideTextOverflow(arrOrderStockSuppliers.Item(i).ToString, 20, "…"),
                    hideTextOverflow(arrOrderStockPrices.Item(i).ToString, 7, "…"),
                    hideTextOverflow(todayDate, 10, "…"),
                    hideTextOverflow(dtbItemBookInfo.Rows(0)(1).ToString, 12, "…")
                ))
                connection.Close()
            Next

            ' Select latest inserted record
            lstOrder.SelectedIndex = lstOrder.Items.Count - 1
            ' Clear lblResults and txtSearchBar text
            lblResults.Text = arrOrderStockIsbns.Count & " new order(s) added..."
            txtSearchBar.Text = ""
            'Show panel
            toggleOrderDetail(True)
            'Update status blocks
            connection.Open()
            updateStatusBlocks()
            connection.Close()
            'Delete no order message
            If (lstOrder.Items(0).ToString = "No orders found." Or
            lstOrder.Items(0).ToString = "No matching orders found.") Then
                lstOrder.Items.RemoveAt(0)
            End If

            If (intResult <> 0) Then
                MessageBox.Show("Successfully added order record(s).",
                                    "Add orders success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("An unexpected error occured, order record(s) were not added." & vbCr &
                                    "Please try again.", "Add orders failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub TrackOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearchBar.Clear()
        Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

        ' Populate order table
        updateOrderRecords()
        connection.Open()
        ' Update status blocks
        updateStatusBlocks()
        connection.Close()

        Me.Cursor = Cursors.Default ' Set cursor to back to default after program fetches data from DB
    End Sub

    Private Sub lstOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrder.SelectedIndexChanged
        If lstOrder.Items(0).ToString() <> "No matching orders found." And lstOrder.Items(0).ToString() <> "No orders found." Then
            Try
                connection.Open()
                'Update item detail banner
                updateItemDetails()
                connection.Close()
            Catch ex As Exception
                'Do nothing
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub refreshBookStatus()
        Dim intBookStatusId As Integer

        ' Recalculate available stock amount and set BookStatusId for Book table
        ' (Count the ISBN of recently added stocks in Stocks without including sold stocks)
        dtbStockCountExcludeOrderSold = New DataTable
        query = "SELECT COUNT(*)
            FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
            WHERE Stock.IsbnNumber = @isbn
            AND NOT StockStatusId IN (3,4);"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = dtbItemBookInfo.Rows(0)(2).ToString
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbStockCountExcludeOrderSold)

        If (dtbStockCountExcludeOrderSold.Rows(0)(0) >= 10) Then
            intBookStatusId = 1 'In stock
        ElseIf (dtbStockCountExcludeOrderSold.Rows(0)(0) = 0) Then
            intBookStatusId = 3 'Out of stock
        ElseIf (dtbStockCountExcludeOrderSold.Rows(0)(0) < 10) Then
            intBookStatusId = 2 'Low stock
        End If
        query = "UPDATE Book
                SET BookStatusId = @bookStatusId
                WHERE IsbnNumber = @isbn"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = dtbItemBookInfo.Rows(0)(2).ToString
        sqlCommand.Parameters.Add(New SqlParameter("@bookStatusId", SqlDbType.Int)).Value = intBookStatusId
        sqlCommand.ExecuteNonQuery()
    End Sub


    Private Sub updateOrderRecords()
        connection.Open()
        '   Query and get all table records
        dtbOrderRecords = New DataTable
        query = "SELECT OrderId, Orders.StockNumber, Title, SupplierName, WholesalePrice, OrderDate, StatusDesc
                FROM Orders JOIN Stock ON (Orders.StockNumber = Stock.StockNumber)
                    JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber)
                    JOIN Supplier ON (Stock.SupplierId = Supplier.SupplierId)
                    JOIN OrderStatus ON (Orders.OrderStatusId = OrderStatus.OrderStatusId);"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dtbOrderRecords)
        connection.Close()

        lstOrder.Items.Clear()
        If (dtbOrderRecords.Rows.Count <> 0) Then
            For i As Integer = 0 To dtbOrderRecords.Rows.Count - 1
                Dim shortDate As DateTime = dtbOrderRecords.Rows(i)(5)
                lstOrder.Items.Add(String.Format(fmtStrOrderTable,
                    hideTextOverflow("  O" & dtbOrderRecords.Rows(i)(0).ToString, 6, "…"),
                    hideTextOverflow("C" & dtbOrderRecords.Rows(i)(1).ToString, 6, "…"),
                    hideTextOverflow(dtbOrderRecords.Rows(i)(2).ToString, 60, "…"),
                    hideTextOverflow(dtbOrderRecords.Rows(i)(3).ToString, 20, "…"),
                    hideTextOverflow(dtbOrderRecords.Rows(i)(4).ToString, 7, "…"),
                    hideTextOverflow(shortDate.ToShortDateString, 10, "…"),
                    hideTextOverflow(dtbOrderRecords.Rows(i)(6).ToString, 12, "…")
                ))
            Next
            toggleOrderDetail(True)
        Else
            lstOrder.Items.Add("No orders found.")
            toggleOrderDetail(False)
        End If

        lstOrder.SelectedIndex = 0
        lblResults.Text = dtbOrderRecords.Rows.Count & " order(s) found..."
    End Sub

    Private Sub updateStatusBlocks()
        dataSet = New DataSet
        ' Retrieve Order quantity from DB - 1
        query = "SELECT COUNT(*) AS OrderQuantity FROM Orders"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "AllOrders")
        ' Retrieve Sale quantity from DB - 2
        query = "SELECT COUNT(*) AS ReceivedQuantity 
                FROM Orders 
                WHERE OrderStatusId = 1"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "ReceivedOrders")
        ' Retrieve In Display, In Storage & Missing stocks - 3
        query = "SELECT COUNT(*) AS PendingQuantity 
                FROM Orders 
                WHERE OrderStatusId = 2"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "PendingOrders")

        ' Update dynamic user interface elements based on loaded data
        lblTotalOrders.Text = hideTextOverflow(dataSet.Tables(0).Rows(0)(0).ToString, 6, "…")
        lblReceived.Text = hideTextOverflow(dataSet.Tables(1).Rows(0)(0).ToString, 6, "…")
        lblNotReceived.Text = hideTextOverflow(dataSet.Tables(2).Rows(0)(0).ToString, 6, "…")
    End Sub

    Private Sub updateItemDetails()
        Dim shortDate As DateTime
        Dim stockNo As Integer
        If (lstOrder.Items(lstOrder.SelectedIndex).ToString <> "No orders found." And
            lstOrder.Items(lstOrder.SelectedIndex).ToString <> "No matching orders found.") Then
            stockNo = CInt(lstOrder.Items(lstOrder.SelectedIndex).ToString.Substring(15, 11).Trim())
        End If
        dtbOrderItemDetails = New DataTable
        ' Get book info
        query = "SELECT Author, Publisher, PublicationDate, CategoryName, Book.IsbnNumber
                    FROM Stock JOIN Book On (Stock.IsbnNumber = Book.IsbnNumber)
                        JOIN Category On (Book.CategoryId = Category.CategoryId)
                    WHERE Stock.StockNumber = @stockNo;"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbOrderItemDetails)

        If (dtbOrderItemDetails.Rows.Count <> 0) Then
            ' Display in panel
            shortDate = dtbOrderItemDetails.Rows(0)(2)
            lblAuthor1.Text = hideTextOverflow(dtbOrderItemDetails.Rows(0)(0).ToString, 20, "…")
            lblPublisher1.Text = hideTextOverflow(dtbOrderItemDetails.Rows(0)(1).ToString, 20, "…")
            lblPubDate1.Text = shortDate.ToShortDateString
            lblCategory1.Text = hideTextOverflow(dtbOrderItemDetails.Rows(0)(3).ToString, 20, "…")
            lblISBN1.Text = dtbOrderItemDetails.Rows(0)(4).ToString
        End If
    End Sub

    Private Sub toggleOrderDetail(bool As Boolean)
        btnEditOrder.Visible = bool
        btnDeleteOrder.Visible = bool
        lblAuthor.Visible = bool
        lblAuthor1.Visible = bool
        lblPublisher.Visible = bool
        lblPublisher1.Visible = bool
        lblPubDate.Visible = bool
        lblPubDate1.Visible = bool
        lblCategory.Visible = bool
        lblCategory1.Visible = bool
        lblISBN.Visible = bool
        lblISBN1.Visible = bool
    End Sub

    Private Function hideTextOverflow(text As String, maxLength As Integer, substituteChar As String) As String
        Dim moddedText As String = text
        'Hide overflowing chars with substitute char
        If (text.Length > maxLength) Then
            moddedText = moddedText.Substring(0, maxLength)
            moddedText = moddedText + substituteChar
        End If
        Return moddedText
    End Function

    Public Sub refreshForm(sender As Object, e As EventArgs)
        TrackOrders_Load(sender, e)
    End Sub

    Public Sub clickSearch(sender As Object, e As EventArgs)
        btnSearch_Click(sender, e)
    End Sub
End Class