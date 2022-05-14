Imports System.Data.SqlClient

Public Class ViewSales

    Public Property pDlgSaleSearchSettings As DialogSaleSearchSettings
        Get
            Return dlgSaleSearchSettings
        End Get
        Set(value As DialogSaleSearchSettings)
            dlgSaleSearchSettings = value
        End Set
    End Property

    Dim fmtStrSalesTable As String = "{0,-12}{1,-14}{2,-91}{3,-22}{4,-10}"
    Dim fmtStrCategoryTable As String = "{0,-10}{1,-52}{2,-23}{3,-27}{4,-27}{5, -10}"
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataSet As New DataSet
    Dim dtbSaleRecords As DataTable
    Dim dtbSaleRecordBookInfo As DataTable
    Dim dtbSavedStockInfo As DataTable
    Dim dtbStockCountExcludeOrderSold As DataTable
    Dim dtbCategoryRanking As DataTable
    Dim dtbRemainingStocks As DataTable
    Dim dtbBookOfCategory As DataTable
    'Search function variables
    Dim dlgSaleSearchSettings As New DialogSaleSearchSettings
    Dim boolSettingsApplied As Boolean = False
    Dim boolSearchAll As Boolean
    Dim boolSearchSaleId As Boolean
    Dim boolSearchStockNumber As Boolean
    Dim boolSearchTitle As Boolean
    Dim boolSearchRetailPrice As Boolean
    Dim boolSearchSaleDate As Boolean
    Dim boolSearchIsbn As Boolean
    Dim strSearchSupplier As String
    Dim strOrConditions As New List(Of String)
    Dim strAndConditions As New List(Of String)

    Private Sub ViewSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cobDate.SelectedIndex = 0
        txtSearchBar.Clear()
        connection.Open()
        ' Populate sale table based on cobDate
        updateSaleRecords()
        ' Populate category table based on cobDate
        updateCategoryRanking()
        connection.Close()
    End Sub

    Private Sub btnSearchSettings_Click(sender As Object, e As EventArgs) Handles btnSearchSettings.Click
        If dlgSaleSearchSettings.ShowDialog() = DialogResult.OK Then
            ' Apply search settings and filters
            strOrConditions.Clear()
            strAndConditions.Clear()
            ' Get search settings and filters
            boolSearchAll = dlgSaleSearchSettings.boolChkAll
            boolSearchSaleId = dlgSaleSearchSettings.boolChkSaleId
            boolSearchStockNumber = dlgSaleSearchSettings.boolChkStockNumber
            boolSearchTitle = dlgSaleSearchSettings.boolChkTitle
            boolSearchRetailPrice = dlgSaleSearchSettings.boolChkRetailPrice
            boolSearchSaleDate = dlgSaleSearchSettings.boolChkSaleDate
            boolSearchIsbn = dlgSaleSearchSettings.boolChkIsbn
            strSearchSupplier = dlgSaleSearchSettings.strCobSupplier

            'If all checkboxes are checked false, check "All" option
            If (boolSearchAll = False And boolSearchSaleId = False And boolSearchStockNumber = False And
                boolSearchTitle = False And boolSearchRetailPrice = False And boolSearchSaleDate = False And boolSearchIsbn = False) Then
                dlgSaleSearchSettings.boolChkAll = True
                boolSearchAll = True
            End If

            ' Check whether any search options were selected
            If boolSearchAll = True Or boolSearchSaleId = True Or boolSearchStockNumber = True Or
               boolSearchTitle = True Or boolSearchRetailPrice = True Or boolSearchSaleDate = True Or
               boolSearchIsbn = True Or strSearchSupplier <> "-" Then
                boolSettingsApplied = True
            End If
            ' Add applied settings/filters to Lists storing SQL WHERE conditions
            ' - - - OR conditions ("Search by" checkboxes) - - -
            If boolSearchAll Then
                strOrConditions.Add("SaleId LIKE @searchKey")
                strOrConditions.Add("Sale.StockNumber LIKE @searchKey")
                strOrConditions.Add("Title LIKE @searchKey")
                strOrConditions.Add("RetailPrice LIKE @searchKey")
                strOrConditions.Add("SaleDate LIKE @searchKey")
                strOrConditions.Add("SupplierName LIKE @searchKey")
                strOrConditions.Add("b.IsbnNumber LIKE @searchKey")
            Else
                If boolSearchSaleId Then
                    strOrConditions.Add("SaleId LIKE @searchKey")
                End If
                If boolSearchStockNumber Then
                    strOrConditions.Add("Sale.StockNumber LIKE @searchKey")
                End If
                If boolSearchTitle Then
                    strOrConditions.Add("Title LIKE @searchKey")
                End If
                If boolSearchRetailPrice Then
                    strOrConditions.Add("RetailPrice LIKE @searchKey")
                End If
                If boolSearchSaleDate Then
                    strOrConditions.Add("SaleDate LIKE @searchKey")
                End If
                If boolSearchIsbn Then
                    strOrConditions.Add("b.IsbnNumber LIKE @searchKey")
                End If
            End If
            ' - - - AND conditions ("Filters" combo boxes) - - -
            If strSearchSupplier <> "-" Then
                strAndConditions.Add("SupplierName = @supplierName")
            End If

            'Focus on search textbox for easier entering
            txtSearchBar.Focus()
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program resets

        ' Clear searchbar and search settings
        txtSearchBar.Clear()
        strOrConditions.Clear()
        strAndConditions.Clear()
        boolSettingsApplied = False
        boolSearchAll = False
        boolSearchSaleId = False
        boolSearchStockNumber = False
        boolSearchTitle = False
        boolSearchRetailPrice = False
        boolSearchSaleDate = False
        boolSearchIsbn = False
        strSearchSupplier = "-"

        ' Reset sales list to this year's list
        cobDate.SelectedIndex = 0
        updateSaleRecords()

        ' Reset settings in DialogBookSearchSettings
        dlgSaleSearchSettings.boolChkAll = True
        dlgSaleSearchSettings.selectedSupplier = 0

        Me.Cursor = Cursors.Default ' Set cursor back to Default when reset process is complete
        'Focus on search textbox for easier entering
        txtSearchBar.Focus()
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
            Dim yearConfig As Integer
            If (cobDate.SelectedIndex = 0) Then
                yearConfig = -1
            ElseIf (cobDate.SelectedIndex = 1) Then
                yearConfig = -2
            ElseIf (cobDate.SelectedIndex = 2) Then
                yearConfig = -3
            End If
            Dim todayDate As Date = Date.Now
            Dim dateStart As New Date(todayDate.Year, 1, 1)
            Dim dateEnd As New Date(todayDate.Year, 12, 31)
            If (yearConfig <> -1) Then
                dateStart = Date.Parse(todayDate.AddYears(yearConfig))
            End If

            'If search key is following stock number's pattern, modify search key to exclude the prefix 
            'to allow matching in DB
            'Only do the modification if search box is not empty and has at least 2 chars
            If (Not String.IsNullOrEmpty(searchKey) And searchKey.Length >= 2) Then
                If (searchKey.ToUpper.Substring(0, 1) = "C" And IsNumeric(searchKey.Substring(1, 1)) Or
                    searchKey.ToUpper.Substring(0, 1) = "S" And IsNumeric(searchKey.Substring(1, 1))) Then
                    searchKey = searchKey.Substring(1, searchKey.Length - 1)
                End If
            End If

            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

            query = "SELECT SaleId, Sale.StockNumber, Title, RetailPrice, SaleDate
                    FROM Sale sale JOIN Stock stk ON (sale.StockNumber = stk.StockNumber)
                        JOIN Book b ON (stk.IsbnNumber = b.IsbnNumber) 
                        JOIN Supplier sup ON (stk.SupplierId = sup.SupplierId)
                    WHERE "

            ' Modify SQL query WHERE conditions based on applied "Search by" settings
            If boolSettingsApplied Then
                ' - - - OR conditions ("Search by" checkboxes) - - -
                If boolSearchAll Then
                    ' Search by all columns
                    query += "(SaleId LIKE @searchKey OR Sale.StockNumber LIKE @searchKey OR Title LIKE @searchKey 
                              OR RetailPrice LIKE @searchKey OR SaleDate LIKE @searchKey OR b.IsbnNumber LIKE @searchKey)"
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
                query += "(SaleId LIKE @searchKey OR Sale.StockNumber LIKE @searchKey OR Title LIKE @searchKey 
                              OR RetailPrice LIKE @searchKey OR SaleDate LIKE @searchKey OR b.IsbnNumber LIKE @searchKey)"
            End If
            query += " AND SaleDate BETWEEN @startDate AND @endOfYear;" ' END OF SQL QUERY CONSTRUCTION

            ' Set SQL command to execute search query and retrieve data from DB
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add("@searchKey", SqlDbType.VarChar).Value = "%" & searchKey & "%"
            sqlCommand.Parameters.Add(New SqlParameter("@startDate", SqlDbType.Date)).Value = dateStart
            sqlCommand.Parameters.Add(New SqlParameter("@endOfYear", SqlDbType.Date)).Value = dateEnd
            If strAndConditions.Count <> 0 Then
                sqlCommand.Parameters.Add("@supplierName", SqlDbType.VarChar).Value = strSearchSupplier
            End If
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataSet = New DataSet
            dataAdapter.Fill(dataSet, "MatchedStock")

            ' Update lstBooks (If matching rows returned: add items; Else: show no results)
            Dim rows As Integer = dataSet.Tables(0).Rows.Count
            lstSales.Items.Clear()
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    lstSales.Items.Add(String.Format(fmtStrSalesTable,
                            hideTextOverflow("S" + CStr(dataSet.Tables(0).Rows(i)("SaleId")), 20, "…"),
                            hideTextOverflow("C" + CStr(dataSet.Tables(0).Rows(i)("StockNumber")), 9, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("Title"), 52, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("RetailPrice"), 7, "…"),
                            hideTextOverflow(dataSet.Tables(0).Rows(i)("SaleDate"), 10, "…")
                    ))
                Next
                lstSales.SelectedIndex = 0
                toggleSaleDetail(True)
            Else
                lstSales.Items.Add("No matching sales found.")
                toggleSaleDetail(False)
            End If
            ' Update lblResults to display number of stocks loaded
            lblResults.Text = rows & " sale(s) found..."

            Me.Cursor = Cursors.Default ' Set cursor back to Default when search process is complete
        Catch ex As Exception
            ' Catch all
            MessageBox.Show(ex.ToString)
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        connection.Close()
    End Sub

    Private Sub cobDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobDate.SelectedIndexChanged
        connection.Open()
        updateSaleRecords()
        updateCategoryRanking()
        connection.Close()
    End Sub

    Private Sub lstSales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSales.SelectedIndexChanged
        Try
            Dim stockNo As Integer
            If (lstSales.Items(lstSales.SelectedIndex).ToString <> "No sales found." And
                lstSales.Items(lstSales.SelectedIndex).ToString <> "No matching sales found.") Then
                stockNo = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(13, 13).Trim())
            End If
            Dim shortDate As DateTime
            dtbSaleRecordBookInfo = New DataTable
            ' Get book info
            query = "SELECT Sale.StockNumber, Book.IsbnNumber, Title, CategoryName,
                        SupplierName, SaleDate
                    FROM Sale JOIN Stock ON (Sale.StockNumber = Stock.StockNumber)
                        JOIN Book On (Stock.IsbnNumber = Book.IsbnNumber)
                        JOIN Category On (Book.CategoryId = Category.CategoryId)
                        JOIN Supplier On (Stock.SupplierId = Supplier.SupplierId)
                    WHERE Sale.StockNumber = @stockNo;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dtbSaleRecordBookInfo)

            ' Get category ranking
            Dim intRanking As Integer
            For i As Integer = 0 To lstCategory.Items.Count - 1
                'Loop through category table and find category name substring
                If (lstCategory.Items(i).ToString.Substring(10, 52).Trim() = dtbSaleRecordBookInfo.Rows(0)(3).ToString) Then
                    intRanking = i + 1
                End If
            Next

            ' Display in panel
            shortDate = dtbSaleRecordBookInfo.Rows(0)(5)
            lblStockNo.Text = hideTextOverflow("S" & dtbSaleRecordBookInfo.Rows(0)(0).ToString, 8, "…")
            lblISBN.Text = dtbSaleRecordBookInfo.Rows(0)(1).ToString
            lblTitle.Text = hideTextOverflow(dtbSaleRecordBookInfo.Rows(0)(2).ToString, 30, "…")
            lblCategory.Text = hideTextOverflow(dtbSaleRecordBookInfo.Rows(0)(3).ToString, 17, "…")
            lblRanking.Text = hideTextOverflow("#" & intRanking, 5, "…")
            lblSupplier.Text = hideTextOverflow(dtbSaleRecordBookInfo.Rows(0)(4).ToString, 30, "…")
            lblDate.Text = shortDate.ToShortDateString
        Catch
            'Do nothing
        End Try
    End Sub

    Private Sub btnEditSale_Click(sender As Object, e As EventArgs) Handles btnEditSale.Click
        Dim editIndex As Integer = lstSales.SelectedIndex
        If (editIndex <> -1) Then
            Dim stockNo As Integer = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(13, 13).Trim())
            ' Issue with getting date value - specially retrieved date from DB to easily convert to
            ' short date format
            connection.Open()
            dtbSaleRecordBookInfo = New DataTable
            query = "SELECT SaleDate
                    FROM Sale
                    WHERE StockNumber = @stockNo;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dtbSaleRecordBookInfo)
            connection.Close()

            Dim saleId As Integer = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(1, 11).Trim())
            Dim saleDate As DateTime = dtbSaleRecordBookInfo.Rows(0)(0)
            Dim intResult As Integer

            Dim dlgEditSale As New DialogEditSale
            dlgEditSale.propSaleId = saleId
            dlgEditSale.propStockNo = stockNo
            dlgEditSale.propSaleDate = saleDate
            If dlgEditSale.ShowDialog() = DialogResult.OK Then
                ' 1. Edit sale record based on user inputs in the table (GUI)
                dtbSavedStockInfo = New DataTable
                connection.Open()
                query = "SELECT Title, RetailPrice, Stock.IsbnNumber
                FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = dlgEditSale.propStockNo
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbSavedStockInfo)

                lstSales.Items.Insert(editIndex, String.Format(fmtStrSalesTable,
                    hideTextOverflow("S" & saleId, 8, "…"),
                    hideTextOverflow("C" & stockNo, 8, "…"),
                    hideTextOverflow(dtbSavedStockInfo.Rows(0)(0).ToString, 88, "…"),
                    hideTextOverflow(dtbSavedStockInfo.Rows(0)(1).ToString, 8, "…"),
                    hideTextOverflow(dlgEditSale.propSaleDate.ToShortDateString, 10, "…")
                ))
                ' Select latest inserted record
                lstSales.SelectedIndex = editIndex
                ' Remove previous target record
                lstSales.Items.RemoveAt(editIndex + 1)

                ' 2. Update record in DB Sale table
                query = "UPDATE Sale 
                        SET SaleDate = @date
                        WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                sqlCommand.Parameters.Add(New SqlParameter("@date", SqlDbType.Date)).Value = dlgEditSale.propSaleDate
                intResult = sqlCommand.ExecuteNonQuery()

                ' 3. Recalculate available stock amount and set BookStatusId for Book table
                refreshBookStatus()

                ' 4. Update category ranking - because sale date can affect it
                updateCategoryRanking()
                ' Show success / fail message
                If (intResult > 0) Then
                    MessageBox.Show("Successfully edited sale record.",
                                    "Edit sale success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("An unexpected error occured, the sale record was not edited." & vbCr &
                                    "Please try again.", "Edit sale failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                connection.Close()
            End If
        Else
            'No index selected, show error message
            MessageBox.Show("No sale record selected, please select a sale record in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRemoveSale_Click(sender As Object, e As EventArgs) Handles btnRemoveSale.Click
        Dim intReply As Integer
        intReply = MessageBox.Show("Are you sure?" & ControlChars.NewLine & "Note: This cannot be undone.",
                                   "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        ' Remove sale record If answer is YES, Else do nothing
        'Update category ranking
        If (intReply = DialogResult.Yes) Then
            Dim editIndex As Integer = lstSales.SelectedIndex
            Dim stockNo As Integer = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(13, 13).Trim())
            Dim intResult As Integer

            If (editIndex <> -1) Then
                ' 1. Delete sale record in the table (GUI)
                'Calibrate selected index to prevent selected index = -1 errors
                'If selected record is not the last record in the table
                If (editIndex + 1 <> lstSales.Items.Count) Then
                    lstSales.SelectedIndex = editIndex + 1
                Else
                    'Else if it is the last table record
                    'If table only has 1 record
                    If (lstSales.Items.Count = 1) Then
                        lstSales.Items.Insert(0, "No sales found.")
                        lstSales.SelectedIndex = 0
                        editIndex = 1
                    Else
                        'Else if table has more than 1 record
                        lstSales.SelectedIndex -= 1
                    End If
                End If
                'After setting up, delete the item
                lstSales.Items.RemoveAt(editIndex)
                ' Clear lblResults and txtSearchBar text
                lblResults.Text = "1 sale deleted."
                txtSearchBar.Text = ""
                ' Hide details if no more items in the table
                If (lstSales.Items(0).ToString = "No sales found.") Then
                    toggleSaleDetail(False)
                End If

                ' 2. Update record in DB Sale table
                connection.Open()
                query = "DELETE FROM Sale 
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                intResult = sqlCommand.ExecuteNonQuery()

                ' 3. Update target stock status back to 'On Display'
                query = "UPDATE Stock
                    SET StockStatusId = 1
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                sqlCommand.ExecuteNonQuery()

                ' 4. Recalculate available stock amount and set BookStatusId for Book table
                dtbSavedStockInfo = New DataTable
                query = "SELECT Title, RetailPrice, Stock.IsbnNumber
                    FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                    WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbSavedStockInfo)

                refreshBookStatus()

                ' 5. Update category ranking
                updateCategoryRanking()
                ' Show success / fail message
                If (intResult > 0) Then
                    MessageBox.Show("Successfully deleted sale record.",
                                    "Delete sale success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    MessageBox.Show("An unexpected error occured, the sale record was not deleted." & vbCr &
                                    "Please try again.", "Delete sale failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                connection.Close()
            Else
                'No index selected, show error message
                MessageBox.Show("No sale record selected, please select a sale record in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnAddSale_Click(sender As Object, e As EventArgs) Handles btnAddSale.Click
        Dim dlgAddSale As New DialogAddSale
        If dlgAddSale.ShowDialog() = DialogResult.OK Then
            Dim arrSavedStockNos As List(Of Integer) = dlgAddSale.propArrAddedStockNos
            Dim intSaleId As Integer = dlgAddSale.saleId
            Dim todayDate As String = String.Format("{0:d/M/yyyy}", Date.Now())
            Dim intResult As Integer

            connection.Open()
            'For all records to be processed
            For i As Integer = 0 To arrSavedStockNos.Count - 1
                ' 1. Add sale records based on user inputs in the dialog (GUI)
                dtbSavedStockInfo = New DataTable
                query = "SELECT Title, RetailPrice, Stock.IsbnNumber
                FROM Stock JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = arrSavedStockNos.Item(i)
                dataAdapter = New SqlDataAdapter(sqlCommand)
                dataAdapter.Fill(dtbSavedStockInfo)

                lstSales.Items.Add(String.Format(fmtStrSalesTable,
                    hideTextOverflow("S" & intSaleId.ToString, 8, "…"),
                    hideTextOverflow("C" & arrSavedStockNos.Item(i).ToString, 8, "…"),
                    hideTextOverflow(dtbSavedStockInfo.Rows(0)(0).ToString, 88, "…"),
                    hideTextOverflow(dtbSavedStockInfo.Rows(0)(1).ToString, 8, "…"),
                    hideTextOverflow(todayDate, 10, "…")
                ))

                ' 2. Add to Sale table in DB
                query = "INSERT INTO Sale (SaleId, StockNumber, SaleDate)
                        VALUES (@id, @stockNo, @date);"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = intSaleId
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = arrSavedStockNos.Item(i)
                sqlCommand.Parameters.Add(New SqlParameter("@date", SqlDbType.Date)).Value = todayDate
                intResult = sqlCommand.ExecuteNonQuery()

                ' 3. Change stock status in View Stocks table
                query = "UPDATE Stock
                        SET StockStatusId = 4
                        WHERE StockNumber = @stockNo;"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = arrSavedStockNos.Item(i)
                sqlCommand.ExecuteNonQuery()

                ' 4. Recalculate available stock amount and set BookStatusId for Book table
                refreshBookStatus()
            Next
            ' Select latest inserted record
            lstSales.SelectedIndex = lstSales.Items.Count - 1
            ' Clear lblResults and txtSearchBar text
            lblResults.Text = arrSavedStockNos.Count & " new sale(s) added..."
            txtSearchBar.Text = ""
            'Show panel
            toggleSaleDetail(True)
            'Delete no sale message
            If (lstSales.Items(0).ToString = "No sales found." Or
                lstSales.Items(0).ToString = "No matching sales found.") Then
                lstSales.Items.RemoveAt(0)
            End If



            ' 5. Update category ranking
            updateCategoryRanking()
            ' Show success / fail message
            If (intResult > 0) Then
                MessageBox.Show("Successfully added sale record(s).",
                                "Add sales success",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                MessageBox.Show("An unexpected error occured, sale record(s) were not added." & vbCr &
                                "Please try again.", "Add sales failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            connection.Close()
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
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = dtbSavedStockInfo.Rows(0)(2).ToString
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
        sqlCommand.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar, 13)).Value = dtbSavedStockInfo.Rows(0)(2).ToString
        sqlCommand.Parameters.Add(New SqlParameter("@bookStatusId", SqlDbType.Int)).Value = intBookStatusId
        sqlCommand.ExecuteNonQuery()
    End Sub

    Private Sub updateCategoryRanking()
        Dim yearConfig As Integer
        If (cobDate.SelectedIndex = 0) Then
            yearConfig = -1
        ElseIf (cobDate.SelectedIndex = 1) Then
            yearConfig = -2
        ElseIf (cobDate.SelectedIndex = 2) Then
            yearConfig = -3
        End If
        Dim todayDate As Date = Date.Now
        Dim dateStart As New Date(todayDate.Year, 1, 1)
        Dim dateEnd As New Date(todayDate.Year, 12, 31)
        If (yearConfig <> -1) Then
            dateStart = Date.Parse(todayDate.AddYears(yearConfig))
        End If

        '   Calculate income, investment and profit of 1 category, rank the categories (based on total profit earned)
        dtbCategoryRanking = New DataTable
        query = "SELECT CategoryName, COUNT(Stock.IsbnNumber) As SoldAmount, 
                    SUM(RetailPrice) As TotalIncome, SUM(WholesalePrice) As TotalInvested,
                    SUM(RetailPrice) - SUM(WholesalePrice) As Profit
                FROM Sale JOIN Stock ON (Sale.StockNumber = Stock.StockNumber)
                    JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                    JOIN Category ON (Book.CategoryId = Category.CategoryId)
                WHERE SaleDate BETWEEN @startDate AND @endOfYear
                GROUP BY Category.CategoryName
                ORDER BY Profit DESC;"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@startDate", SqlDbType.Date)).Value = dateStart
        sqlCommand.Parameters.Add(New SqlParameter("@endOfYear", SqlDbType.Date)).Value = dateEnd
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbCategoryRanking)

        lstCategory.Items.Clear()
        If (dtbCategoryRanking.Rows.Count <> 0) Then
            For i As Integer = 0 To dtbCategoryRanking.Rows.Count - 1
                lstCategory.Items.Add(String.Format(fmtStrCategoryTable,
                hideTextOverflow((i + 1).ToString, 7, "…"),
                hideTextOverflow(dtbCategoryRanking.Rows(i)(0).ToString, 49, "…"),
                hideTextOverflow(dtbCategoryRanking.Rows(i)(1).ToString, 10, "…"),
                hideTextOverflow(dtbCategoryRanking.Rows(i)(2).ToString, 10, "…"),
                hideTextOverflow(dtbCategoryRanking.Rows(i)(3).ToString, 10, "…"),
                hideTextOverflow(dtbCategoryRanking.Rows(i)(4).ToString, 10, "…")
            ))
            Next
        Else
            lstCategory.Items.Add("No ranking.")
        End If

        lstCategory.SelectedIndex = 0
    End Sub

    Private Sub updateSaleRecords()
        Dim yearConfig As Integer
        If (cobDate.SelectedIndex = 0) Then
            yearConfig = -1
        ElseIf (cobDate.SelectedIndex = 1) Then
            yearConfig = -2
        ElseIf (cobDate.SelectedIndex = 2) Then
            yearConfig = -3
        End If
        Dim todayDate As Date = Date.Now
        Dim dateStart As New Date(todayDate.Year, 1, 1)
        Dim dateEnd As New Date(todayDate.Year, 12, 31)
        If (yearConfig <> -1) Then
            dateStart = Date.Parse(todayDate.AddYears(yearConfig))
        End If

        '   Query and get all table records
        dtbSaleRecords = New DataTable
        query = "SELECT SaleId, Sale.StockNumber, Title, RetailPrice, SaleDate
                FROM Sale JOIN Stock ON (Sale.StockNumber = Stock.StockNumber)
                    JOIN BOOK ON (Stock.IsbnNumber = Book.IsbnNumber)
                WHERE SaleDate BETWEEN @startDate AND @endOfYear;"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@startDate", SqlDbType.Date)).Value = dateStart
        sqlCommand.Parameters.Add(New SqlParameter("@endOfYear", SqlDbType.Date)).Value = dateEnd
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbSaleRecords)

        lstSales.Items.Clear()
        If (dtbSaleRecords.Rows.Count <> 0) Then
            For i As Integer = 0 To dtbSaleRecords.Rows.Count - 1
                Dim shortDate As DateTime = dtbSaleRecords.Rows(i)(4)
                lstSales.Items.Add(String.Format(fmtStrSalesTable,
                hideTextOverflow("S" & dtbSaleRecords.Rows(i)(0).ToString, 8, "…"),
                hideTextOverflow("C" & dtbSaleRecords.Rows(i)(1).ToString, 8, "…"),
                hideTextOverflow(dtbSaleRecords.Rows(i)(2).ToString, 88, "…"),
                hideTextOverflow(dtbSaleRecords.Rows(i)(3).ToString, 8, "…"),
                hideTextOverflow(shortDate.ToShortDateString, 10, "…")
            ))
            Next
            toggleSaleDetail(True)
        Else
            lstSales.Items.Add("No sales found.")
            toggleSaleDetail(False)
        End If

        lstSales.SelectedIndex = 0
        lblResults.Text = dtbSaleRecords.Rows.Count & " sale(s) found..."
    End Sub

    Private Sub toggleSaleDetail(bool As Boolean)
        btnEditSale.Visible = bool
        btnRemoveSale.Visible = bool
        lblStockNo.Visible = bool
        lblStockNo1.Visible = bool
        lblISBN.Visible = bool
        lblISBN1.Visible = bool
        lblTitle.Visible = bool
        lblTitle1.Visible = bool
        lblCategory.Visible = bool
        lblCategory1.Visible = bool
        lblRanking.Visible = bool
        lblRanking1.Visible = bool
        lblSupplier.Visible = bool
        lblSupplier1.Visible = bool
        lblDate.Visible = bool
        lblDate1.Visible = bool
        btnViewRemStocks.Visible = bool
        btnViewBooksOfCat.Visible = bool
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
        ViewSales_Load(sender, e)
    End Sub

    Private Sub btnViewRemStocks_Click(sender As Object, e As EventArgs) Handles btnViewRemStocks.Click
        Dim stockNo As Integer = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(13, 13).Trim())

        dtbRemainingStocks = New DataTable
        connection.Open()
        query = "SELECT Title 
                FROM Book JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
                WHERE StockNumber = @stockNo"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbRemainingStocks)
        connection.Close()

        'Get actual window user is using
        Dim layout As Layout = Me.Parent.Parent
        'Switch to View Stocks tab
        layout.switchViewStocks(sender, e)
        'Configure settings
        ViewStocks.txtSearchBar.Text = dtbRemainingStocks.Rows(0)(0).ToString
        'Click Search
        ViewStocks.clickSearch(sender, e)
    End Sub

    Private Sub btnViewBooksOfCat_Click(sender As Object, e As EventArgs) Handles btnViewBooksOfCat.Click
        Dim stockNo As Integer = CInt(lstSales.Items(lstSales.SelectedIndex).ToString.Substring(13, 13).Trim())

        dtbBookOfCategory = New DataTable
        connection.Open()
        query = "SELECT CategoryName 
                FROM Book JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
                    JOIN Category ON (Book.CategoryId = Category.CategoryId)
                WHERE StockNumber = @stockNo"
        sqlCommand = New SqlCommand(query, connection)
        sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = stockNo
        dataAdapter = New SqlDataAdapter(sqlCommand)
        dataAdapter.Fill(dtbBookOfCategory)
        connection.Close()

        'Get actual window user is using
        Dim layout As Layout = Me.Parent.Parent
        Dim dlgBookSearchSettings As DialogBookSearchSettings = Dashboard.pDlgBookSearchSettings

        'Switch to Dashboard tab
        layout.switchDashboard(sender, e)

        'Configure settings
        Dashboard.txtSearchBar.Text = dtbBookOfCategory.Rows(0)(0).ToString()
        dlgBookSearchSettings.cobCategory.SelectedItem = dtbBookOfCategory.Rows(0)(0).ToString()
        dlgBookSearchSettings.clickApply(sender, e)

        'Click Search
        Dashboard.clickSearch(sender, e)
    End Sub

    Public Sub clickSearch(sender As Object, e As EventArgs)
        btnSearch_Click(sender, e)
    End Sub
End Class