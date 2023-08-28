Imports System.Data.SqlClient
Imports System.IO

Public Class ViewStocks

    Public Property pDlgStockSearchSettings As DialogStockSearchSettings
        Get
            Return dlgStockSearchSettings
        End Get
        Set(value As DialogStockSearchSettings)
            dlgStockSearchSettings = value
        End Set
    End Property

    ' Table format string - Stock number, Title, Supplier, Wholesale price, Retail price, Status, Location
    Dim mStockTableFormatString = "{0,-16}{1,-58}{2,-29}{3,-15}{4,-13}{5,-17}{6,-11}"
    ' DB Connection variables - Change Server & DB name in connection string
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataSet As DataSet
    Dim dtbStock As New DataTable
    Dim dataTable As New DataTable
    Dim dtbInvalidSale As DataTable
    Dim dtbInvalidOrder As DataTable
    Dim dtbStockCountExcludeOrderSold As DataTable
    Dim ms As MemoryStream
    Dim arrImage() As Byte
    Dim mArrCustomLocImg As ArrayList
    ' Search function variables
    Dim dlgStockSearchSettings As New DialogStockSearchSettings
    Dim boolSettingsApplied As Boolean = False
    Dim boolSearchAll As Boolean
    Dim boolSearchStockNumber As Boolean
    Dim boolSearchTitle As Boolean
    Dim boolSearchRetailPrice As Boolean
    Dim boolSearchWholesalePrice As Boolean
    Dim boolSearchIsbn As Boolean
    Dim strSearchSupplier As String
    Dim strSearchStatus As String
    Dim strSearchLocation As String
    Dim strOrConditions As New List(Of String)
    Dim strAndConditions As New List(Of String)

    Private Sub ViewStocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection.Open()
        Try
            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

            ' Update UI
            dtbStock.Clear()
            updateStatusBlocks()
            updateBookInfo()

            ' Clear search inputs
            txtSearchBar.Clear()
            ' Retrieve all Stocks from DB
            displayAllStocks()

            Me.Cursor = Cursors.Default ' Set cursor to back to default after program fetches data from DB
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        connection.Close()
    End Sub

    Private Sub lstStock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstStock.SelectedIndexChanged
        If (lstStock.Items(0).ToString() <> "No matching stocks found." And lstStock.Items(0).ToString() <> "No stocks found.") Then
            If sqlCommand.Connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            Try
                toggleStockDetail(True)
                dtbStock.Clear()
                ' Get stock number
                Dim stockNumber As Integer = lstStock.Items(lstStock.SelectedIndex).ToString().Substring(3, 6).Trim
                Try
                    query = "SELECT Book.IsbnNumber, Author, Publisher, PublicationDate, CategoryName, LocationPicture
                       FROM Stock INNER JOIN Book ON (Stock.IsbnNumber = Book.IsbnNumber)
                       INNER JOIN Category ON (Book.CategoryId = Category.CategoryId)
                       INNER JOIN StockLocation ON (Stock.LocationId= StockLocation.LocationId)              
                       WHERE StockNumber = @stockNo;"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                    ' Retrieve data from DB
                    dataAdapter = New SqlDataAdapter(sqlCommand)
                    dataAdapter.Fill(dtbStock)

                    ' Update book information
                    updateBookInfo()
                Catch
                    'Error - cant fetch data from database
                    MessageBox.Show("Unable to fetch the stock's data from database, please try again.", "Data Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch
                'Error - no selected index
                MessageBox.Show("No stock selected, please select a stock in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            connection.Close()
        Else
            toggleStockDetail(False)
        End If
    End Sub

    Private Sub btnSearchSettings_Click(sender As Object, e As EventArgs) Handles btnSearchSettings.Click
        If dlgStockSearchSettings.ShowDialog() = DialogResult.OK Then
            ' Apply search settings and filters
            strOrConditions.Clear()
            strAndConditions.Clear()
            ' Get search settings and filters
            boolSearchAll = dlgStockSearchSettings.boolChkAll
            boolSearchStockNumber = dlgStockSearchSettings.boolChkStockNumber
            boolSearchTitle = dlgStockSearchSettings.boolChkTitle
            boolSearchRetailPrice = dlgStockSearchSettings.boolChkRetailPrice
            boolSearchWholesalePrice = dlgStockSearchSettings.boolChkWholesalePrice
            boolSearchIsbn = dlgStockSearchSettings.boolChkIsbn
            strSearchSupplier = dlgStockSearchSettings.strCobSupplier
            strSearchStatus = dlgStockSearchSettings.strCobStatus
            strSearchLocation = dlgStockSearchSettings.strCobLocation

            'If all checkboxes are checked false, check "All" option
            If (boolSearchAll = False And boolSearchStockNumber = False And boolSearchTitle = False And
                boolSearchRetailPrice = False And boolSearchWholesalePrice = False And boolSearchIsbn = False) Then
                dlgStockSearchSettings.boolChkAll = True
                boolSearchAll = True
            End If

            ' Check whether any search options were selected
            If boolSearchAll = True Or boolSearchStockNumber = True Or boolSearchTitle = True Or
                boolSearchRetailPrice = True Or boolSearchWholesalePrice = True Or boolSearchIsbn = True Or
                strSearchSupplier <> "-" Or strSearchStatus <> "-" Or strSearchLocation <> "-" Then
                boolSettingsApplied = True
            End If
            ' Add applied settings/filters to Lists storing SQL WHERE conditions
            ' - - - OR conditions ("Search by" checkboxes) - - -
            If boolSearchAll Then
                strOrConditions.Add("StockNumber LIKE @searchKey")
                strOrConditions.Add("Title LIKE @searchKey")
                strOrConditions.Add("RetailPrice LIKE @searchKey")
                strOrConditions.Add("WholesalePrice LIKE @searchKey")
                strOrConditions.Add("SupplierName LIKE @searchKey")
                strOrConditions.Add("StatusDesc LIKE @searchKey")
                strOrConditions.Add("LocationName LIKE @searchKey")
                strOrConditions.Add("s.IsbnNumber LIKE @searchKey")
            Else
                If boolSearchStockNumber Then
                    strOrConditions.Add("StockNumber LIKE @searchKey")
                End If
                If boolSearchTitle Then
                    strOrConditions.Add("Title LIKE @searchKey")
                End If
                If boolSearchRetailPrice Then
                    strOrConditions.Add("RetailPrice LIKE @searchKey")
                End If
                If boolSearchWholesalePrice Then
                    strOrConditions.Add("WholesalePrice LIKE @searchKey")
                End If
                If boolSearchIsbn Then
                    strOrConditions.Add("s.IsbnNumber LIKE @searchKey")
                End If
            End If
            ' - - - AND conditions ("Filters" combo boxes) - - -
            If strSearchSupplier <> "-" Then
                strAndConditions.Add("SupplierName = @supplierName")
            End If
            If strSearchStatus <> "-" Then
                strAndConditions.Add("StatusDesc = @statusDesc")
            End If
            If strSearchLocation <> "-" Then
                strAndConditions.Add("LocationName = @locationName")
            End If

            'Focus on search textbox for easier entering
            txtSearchBar.Focus()
        End If
    End Sub

    Private Sub txtSearchBar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchBar.KeyDown
        ' Execute Search function if user presses ENTER from txtSearchBar
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        connection.Open()

        ' Construct SQL query to retrieve books with details that match the search key and search settings
        Try
            Dim searchKey As String = txtSearchBar.Text.ToString().Trim()
            'If search key is following stock number's pattern, modify search key to exclude the prefix 
            'to allow matching in DB
            'Only do the modification if search box is not empty and has at least 2 chars
            If (Not String.IsNullOrEmpty(searchKey) And searchKey.Length >= 2) Then
                If (searchKey.ToUpper.Substring(0, 1) = "C" And IsNumeric(searchKey.Substring(1, 1))) Then
                    searchKey = searchKey.Substring(1, searchKey.Length - 1)
                End If
            End If

            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

            query = "SELECT StockNumber, Title, SupplierName, WholesalePrice, RetailPrice, StatusDesc, LocationName, LocationPicture,
                    Author, Publisher, PublicationDate, CategoryName, s.IsbnNumber
                    FROM Stock s JOIN Book b ON (s.IsbnNumber = b.IsbnNumber) 
                    JOIN Supplier sup ON (s.SupplierId = sup.SupplierId)
                    JOIN StockStatus stat ON (s.StockStatusId = stat.StockStatusId) 
                    JOIN StockLocation loc ON (s.LocationId = loc.LocationId)
                    JOIN Category cat ON (b.CategoryId = cat.CategoryId)
                    WHERE "

            ' Modify SQL query WHERE conditions based on applied "Search by" settings
            If boolSettingsApplied Then
                ' - - - OR conditions ("Search by" checkboxes) - - -
                If boolSearchAll Then
                    ' Search by all columns
                    query += "(StockNumber LIKE @searchKey OR Title LIKE @searchKey OR RetailPrice LIKE @searchKey 
                              OR WholesalePrice LIKE @searchKey OR SupplierName LIKE @searchKey OR StatusDesc LIKE @searchKey
                              OR LocationName LIKE @searchKey)"
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
                query += "(StockNumber LIKE @searchKey OR Title LIKE @searchKey OR RetailPrice LIKE @searchKey 
                         OR WholesalePrice LIKE @searchKey OR SupplierName LIKE @searchKey OR StatusDesc LIKE @searchKey
                         OR LocationName LIKE @searchKey OR s.IsbnNumber LIKE @searchKey)"
            End If
            query += ";" ' END OF SQL QUERY CONSTRUCTION

            ' Set SQL command to execute search query and retrieve data from DB
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add("@searchKey", SqlDbType.VarChar).Value = "%" & searchKey & "%"
            If strAndConditions.Count <> 0 Then
                sqlCommand.Parameters.Add("@supplierName", SqlDbType.VarChar).Value = strSearchSupplier
                sqlCommand.Parameters.Add("@statusDesc", SqlDbType.VarChar).Value = strSearchStatus
                sqlCommand.Parameters.Add("@locationName", SqlDbType.VarChar).Value = strSearchLocation
            End If
            dataAdapter = New SqlDataAdapter(sqlCommand)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "MatchedStock")

            ' Update lstBooks (If matching rows returned: add items; Else: show no results)
            Dim rows As Integer = dataSet.Tables(0).Rows.Count
            lstStock.Items.Clear()
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    lstStock.Items.Add(String.Format(mStockTableFormatString, hideTextOverflow("  C" + CStr(dataSet.Tables(0).Rows(i)("StockNumber")), 9, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("Title"), 52, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("SupplierName"), 20, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("WholesalePrice"), 7, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("RetailPrice"), 7, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("StatusDesc"), 10, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("LocationName"), 11, "…")
                    ))
                Next
            Else
                lstStock.Items.Add("No matching stocks found.")
            End If
            lstStock.SelectedIndex = 0
            ' Update lblResults to display number of stocks loaded
            lblResults.Text = rows & " stock(s) found..."

            Me.Cursor = Cursors.Default ' Set cursor back to Default when search process is complete
        Catch ex As Exception
            ' Catch all
            MessageBox.Show(ex.ToString)
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        connection.Close()

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program resets

        ' Clear searchbar and search settings
        txtSearchBar.Clear()
        strOrConditions.Clear()
        strAndConditions.Clear()
        boolSettingsApplied = False
        boolSearchAll = False
        boolSearchStockNumber = False
        boolSearchTitle = False
        boolSearchRetailPrice = False
        boolSearchWholesalePrice = False
        boolSearchIsbn = False
        strSearchSupplier = "-"
        strSearchStatus = "-"
        strSearchLocation = "-"

        ' Reset lstBooks
        dtbStock.Clear()
        updateStatusBlocks()
        updateBookInfo()
        displayAllStocks()

        lstStock.SelectedIndex = 0
        ' Reset settings in DialogBookSearchSettings
        dlgStockSearchSettings.boolChkAll = True
        dlgStockSearchSettings.selectedSupplier = 0
        dlgStockSearchSettings.selectedStatus = 0
        dlgStockSearchSettings.selectedLocation = 0

        Me.Cursor = Cursors.Default ' Set cursor back to Default when reset process is complete
        'Focus on search textbox for easier entering
        txtSearchBar.Focus()
    End Sub

    Private Sub btnEditStock_Click(sender As Object, e As EventArgs) Handles btnEditStock.Click
        Try
            Dim stockNumber As Integer = lstStock.Items(lstStock.SelectedIndex).ToString().Substring(3, 6).Trim
            dtbStock.Clear()

            connection.Open()
            query = "SELECT WholesalePrice, SupplierId, StockStatusId, Stock.LocationId, LocationPicture
                FROM Stock JOIN StockLocation ON (Stock.LocationId = StockLocation.LocationId)
                WHERE stockNumber = @stockNo"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dtbStock)

            Dim dlgEditStock As New DialogEditStock
            dlgEditStock.strStockNo = "C" & CStr(stockNumber)
            dlgEditStock.decWholesalePrice = dtbStock.Rows(0)("WholesalePrice")
            dlgEditStock.intSupplierId = dtbStock.Rows(0)("SupplierId")
            dlgEditStock.intStatusId = dtbStock.Rows(0)("StockStatusId")
            dlgEditStock.intLocationId = dtbStock.Rows(0)("LocationId")
            dlgEditStock.byteLocationPicture = dtbStock.Rows(0)("LocationPicture")

            ' Open DialogEditStock and get user input
            If dlgEditStock.ShowDialog = DialogResult.OK Then
                If (dlgEditStock.intResult > 0) Then
                    'If rows are inserted, show success message
                    MessageBox.Show("Successfully edited stock information.",
                                "Edit success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    'If not, show error message
                    MessageBox.Show("An unexpected error occured, stock information was not edited." & vbCr &
                                "Please try again.", "Edit failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' Records has been updated
                ' Update book information & status blocks
                ' There is another updateStatusBlocks() underneath this Sub but it is still needed here because
                ' updateBookInfo() depends on the code of updateStatusBlocks(), they go in pairs
                updateStatusBlocks()
                updateBookInfo()
                'Update record in table
                dtbStock.Clear()
                query = "SELECT StockNumber, Title, SupplierName, WholesalePrice, RetailPrice, StatusDesc, LocationName, s.IsbnNumber
                    FROM Stock s JOIN Book b ON (s.IsbnNumber = b.IsbnNumber) JOIN Supplier sup ON (s.SupplierId = sup.SupplierId)
                    JOIN StockStatus stat ON (s.StockStatusId = stat.StockStatusId) 
                    JOIN StockLocation loc ON (s.LocationId = loc.LocationId)
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbStock)

                Dim editIndex As Integer = lstStock.SelectedIndex
                lstStock.Items.Insert(editIndex, String.Format(mStockTableFormatString, hideTextOverflow("  C" + CStr(dtbStock.Rows(0)("StockNumber")), 9, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("Title"), 52, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("SupplierName"), 20, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("WholesalePrice"), 7, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("RetailPrice"), 7, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("StatusDesc"), 10, "…"),
                    hideTextOverflow(dtbStock.Rows(0)("LocationName"), 11, "…")
                ))
                lstStock.SelectedIndex = editIndex
                lstStock.Items.RemoveAt(editIndex + 1)

                'If stock status was edited from sold/ordered
                'Update stock from Sales/Orders table if found
                '   Only records with 'Sold' and 'Ordered' status will be in Sales and Orders table
                '   so no need to worry about deleting record if they have other status
                ' 1. Find stock number in Sale table
                dtbInvalidSale = New DataTable
                query = "SELECT *
                        FROM Sale s JOIN Stock stk ON (s.StockNumber = stk.StockNumber)
                        WHERE s.StockNumber = @stockNo"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbInvalidSale)

                ' 2. Find stock number in Order table
                dtbInvalidOrder = New DataTable
                query = "SELECT *
                        FROM Orders o JOIN Stock s ON (o.StockNumber = s.StockNumber)
                        WHERE o.StockNumber = @stockNo"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbInvalidOrder)
                connection.Close()

                If (dtbInvalidOrder.Rows.Count <> 0) Then
                    'If the record is in Order table, update status to 'Received'
                    connection.Open()
                    query = "UPDATE Orders
                            SET OrderStatusId = 1
                            WHERE StockNumber = @stockNo"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                    sqlCommand.ExecuteNonQuery()
                    connection.Close()
                ElseIf (dtbInvalidSale.Rows.Count <> 0) Then
                    'If the record is in Sale table, delete it
                    connection.Open()
                    query = "DELETE FROM Sale
                            WHERE StockNumber = @stockNo"
                    sqlCommand = New SqlCommand(query, connection)
                    sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                    sqlCommand.ExecuteNonQuery()
                    connection.Close()
                End If

                'Refresh and reset book statuses 
                connection.Open()
                refreshBookStatus(dtbStock.Rows(0)("IsbnNumber").ToString)
                updateStatusBlocks()
                connection.Close()
            Else
                connection.Close()
            End If
        Catch ex As Exception
            'Error - no selected index
            MessageBox.Show("No stock selected, please select a stock in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteStock_Click(sender As Object, e As EventArgs) Handles btnDeleteStock.Click
        Try
            Dim stockNumber As Integer = lstStock.Items(lstStock.SelectedIndex).ToString().Substring(3, 6).Trim
            Dim intConfirm As Integer = MessageBox.Show("Are you sure?" & ControlChars.NewLine & "Caution: All records of this stock will be removed.",
                                                            "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If (intConfirm = DialogResult.Yes) Then
                '1) Delete in Stock table, records in Orders/Sale table will be cascaded accordingly
                connection.Open()
                query = "DELETE FROM Stock WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNumber
                Dim intResult As Integer = sqlCommand.ExecuteNonQuery()

                '2) Reset book status for the target book in Dashboard
                'Get number of stocks including new records
                Dim intBookStatusId As Integer
                dataTable = New DataTable
                query = "SELECT COUNT(*) From Stock WHERE IsbnNumber = @isbn"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = lblISBN1.Text
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dataTable)

                'Check the sum of quantity to determine book status
                If (dataTable.Rows(0)(0) >= 10) Then
                    intBookStatusId = 1 'In stock
                ElseIf (dataTable.Rows(0)(0) = 0) Then
                    intBookStatusId = 3 'Out of stock
                ElseIf (dataTable.Rows(0)(0) < 10) Then
                    intBookStatusId = 2 'Low stock
                End If

                'Update the status id value of the target book
                query = "UPDATE Book
                        SET BookStatusId = @bookStatusId
                        WHERE IsbnNumber = @isbn"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = lblISBN1.Text
                sqlCommand.Parameters.Add(New SqlParameter("@bookStatusId", SqlDbType.Int)).Value = intBookStatusId
                sqlCommand.ExecuteNonQuery()

                '3) Check if there are number of records are affected
                If (intResult > 0) Then
                    MessageBox.Show("Successfully deleted stock.",
                                "Delete success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    'Remove from table and select another record
                    Dim editIndex As Integer = lstStock.SelectedIndex

                    'Calibrate selected index to prevent selected index = -1 errors
                    'If selected record is not the last record in the table
                    If (editIndex + 1 <> lstStock.Items.Count) Then
                        lstStock.SelectedIndex = editIndex + 1
                    Else
                        'Else if it is the last table record
                        'If table only has 1 record
                        If (lstStock.Items.Count = 1) Then
                            lstStock.Items.Insert(0, "No matching stocks found.")
                            lstStock.SelectedIndex = 0
                            editIndex = 1
                        Else
                            'Else if table has more than 1 record
                            lstStock.SelectedIndex -= 1
                        End If
                    End If

                    'After setting up, delete the item
                    lstStock.Items.RemoveAt(editIndex)

                    'Update status blocks
                    updateStatusBlocks()
                Else
                    MessageBox.Show("An unexpected error occured, stock was not deleted." & vbCr &
                                "Please try again later", "Delete failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                connection.Close()
            End If
        Catch ex As Exception
            'Error - no selected index
            MessageBox.Show("No stock selected, please select a stock in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub updateStatusBlocks()
        ' Set query and create SQL command
        query = "SELECT StockNumber, Title, SupplierName, WholesalePrice, RetailPrice, StatusDesc, LocationName, LocationPicture,
                    Author, Publisher, PublicationDate, CategoryName, s.IsbnNumber
                    FROM Stock s JOIN Book b ON (s.IsbnNumber = b.IsbnNumber) JOIN Supplier sup ON (s.SupplierId = sup.SupplierId)
                    JOIN StockStatus stat ON (s.StockStatusId = stat.StockStatusId) 
                    JOIN StockLocation loc ON (s.LocationId = loc.LocationId)
                    JOIN Category cat ON (b.CategoryId = cat.CategoryId);"
        sqlCommand = New SqlCommand(query, connection)
        ' Retrieve Stock data from DB - 0
        dataAdapter = New SqlDataAdapter(sqlCommand)
        Dim dataSet As New DataSet()
        dataAdapter.Fill(dataSet, "Stock")
        dtbStock = dataSet.Tables(0)
        ' Retrieve Order quantity from DB - 1
        query = "SELECT COUNT(*) AS OrderQuantity FROM Stock
                WHERE StockStatusId = 3;"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "Order")
        ' Retrieve Sale quantity from DB - 2
        query = "SELECT COUNT(*) AS SaleQuantity FROM Stock
                WHERE StockStatusId = 4;"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "Sale")
        ' Retrieve In Display, In Storage & Missing stocks - 3
        query = "SELECT (SELECT COUNT(*)
                    FROM Stock
                    WHERE StockStatusId = 1) DisplayStocks, 
                    (SELECT COUNT(*)
                    FROM Stock
                    WHERE StockStatusId = 2) StorageStocks,
                    (SELECT COUNT(*)
                    FROM Stock
                    WHERE StockStatusId = 5) MissingStocks;"
        sqlCommand = New SqlCommand(query, connection)
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dataSet, "StockStatusCount")

        ' Update dynamic user interface elements based on loaded data
        lblResults.Text = dtbStock.Rows.Count & " stock(s) found..."
        lblTotalStocks.Text = hideTextOverflow(CStr(dataSet.Tables(0).Rows.Count), 6, "…")
        lblOrdered.Text = hideTextOverflow(dataSet.Tables(1).Rows(0)("OrderQuantity"), 6, "…")
        lblSold.Text = hideTextOverflow(dataSet.Tables(2).Rows(0)("SaleQuantity"), 6, "…")
        lblOnDisplay.Text = hideTextOverflow(dataSet.Tables(3).Rows(0)("DisplayStocks"), 6, "…")
        lblStorage.Text = hideTextOverflow(dataSet.Tables(3).Rows(0)("StorageStocks"), 6, "…")
        lblMissing.Text = hideTextOverflow(dataSet.Tables(3).Rows(0)("MissingStocks"), 6, "…")
    End Sub

    Private Sub updateBookInfo()
        If (dtbStock.Rows.Count <> 0) Then
            'Update book details
            lblAuthor1.Text = hideTextOverflow(dtbStock.Rows(0)("Author"), 21, "…")
            lblPublisher1.Text = hideTextOverflow(dtbStock.Rows(0)("Publisher"), 21, "…")
            lblPubDate1.Text = hideTextOverflow(dtbStock.Rows(0)("PublicationDate"), 21, "…")
            lblCategory1.Text = hideTextOverflow(dtbStock.Rows(0)("CategoryName"), 21, "…")
            lblISBN1.Text = hideTextOverflow(dtbStock.Rows(0)("IsbnNumber"), 21, "…")

            ' Update stock location image
            Try
                arrImage = CType(dtbStock.Rows(0)("LocationPicture"), Byte())
                ms = New MemoryStream(arrImage)
                picLocation.Image = Image.FromStream(ms)
            Catch argEx As ArgumentException
                ' Catch exception caused by image loading error
                picLocation.Image = Image.FromFile("images/image-not-found.jpg")
                MessageBox.Show("Unable to load image of location picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub refreshBookStatus(isbn As String)
        Dim intBookStatusId As Integer

        ' Recalculate available stock amount and set BookStatusId for Book table
        ' (Count the ISBN of recently added stocks in Stocks without including sold stocks)
        dtbStockCountExcludeOrderSold = New DataTable
        query = "SELECT COUNT(*)
            FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
            WHERE Stock.IsbnNumber = @isbn
            AND NOT StockStatusId IN (3,4);"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = isbn
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
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = isbn
        sqlCommand.Parameters.Add(New SqlParameter("@bookStatusId", SqlDbType.Int)).Value = intBookStatusId
        sqlCommand.ExecuteNonQuery()
    End Sub

    Private Sub displayAllStocks()
        lstStock.Items.Clear()
        Dim rows As Integer = dtbStock.Rows.Count
        If rows > 0 Then
            'Has records
            For i As Integer = 0 To rows - 1
                lstStock.Items.Add(String.Format(mStockTableFormatString, hideTextOverflow("  C" + CStr(dtbStock.Rows(i)("StockNumber")), 9, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("Title"), 52, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("SupplierName"), 20, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("WholesalePrice"), 7, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("RetailPrice"), 7, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("StatusDesc"), 10, "…"),
                        hideTextOverflow(dtbStock.Rows(i)("LocationName"), 11, "…")
                    ))
            Next
            lstStock.SelectedIndex = 0
        Else
            'No records
            lstStock.Items.Add("No stocks found.")
        End If

        ' Update lblResults to display number of stock loaded
        lblResults.Text = rows & " stock(s) found..."
    End Sub

    Private Sub toggleStockDetail(bool As Boolean)
        If bool = False Then
            picLocation.Image = Image.FromFile("images/image-not-found.jpg")
        End If
        btnEditStock.Visible = bool
        btnDeleteStock.Visible = bool
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
        ViewStocks_Load(sender, e)
    End Sub

    Public Sub clickSearch(sender As Object, e As EventArgs)
        btnSearch_Click(sender, e)
    End Sub
End Class