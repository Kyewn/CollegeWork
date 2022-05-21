Imports System.Data.SqlClient
Imports System.IO

Public Class Dashboard

    Public Property pDlgBookSearchSettings As DialogBookSearchSettings
        Get
            Return dlgBookSearchSettings
        End Get
        Set(value As DialogBookSearchSettings)
            dlgBookSearchSettings = value
        End Set
    End Property

    ' SQL Server database variables
    Dim ms As MemoryStream
    Dim arrImage() As Byte
    Dim sql As String
    Dim cmd As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim dtbBooks As New DataTable
    Dim dtbSelectedBook As New DataTable
    Dim conn As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    ' Search settings variables
    Dim boolSettingsApplied As Boolean = False
    Dim boolSearchAll As Boolean
    Dim boolSearchIsbn As Boolean
    Dim boolSearchTitle As Boolean
    Dim boolSearchAuthor As Boolean
    Dim boolSearchPublisher As Boolean
    Dim boolSearchPublicationDate As Boolean
    Dim boolSearchRetailPrice As Boolean
    Dim strSearchCategory As String
    Dim strSearchStatus As String
    Dim strOrConditions As New List(Of String)
    Dim strAndConditions As New List(Of String)
    ' Others
    Dim mfmtStrBook As String = "{0, -17}{1, -54}{2, -24}{3, -21}{4, -24}{5, -14}{6, -9}"
    Dim dlgBookSearchSettings As New DialogBookSearchSettings

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

            ' Retrieve all Books from DB
            displayAllBooks()

            ' Refresh user interface
            txtSearchBar.Clear()
            updateStatusBlocks()

            Me.Cursor = Cursors.Default ' Set cursor back to Default when loading process is complete
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub

    Private Sub txtSearchBar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchBar.KeyDown
        ' Execute Search function if user presses ENTER from txtSearchBar
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        conn.Open()

        ' Construct SQL query to retrieve books with details that match the search key and search settings
        Try
            Me.Cursor = Cursors.WaitCursor ' Set cursor to WaitCursor while program fetches data from DB

            sql = "SELECT IsbnNumber, Title, Author, CategoryName, Publisher, PublicationDate, RetailPrice, BookPicture, StatusDesc
                   FROM Book INNER JOIN Category ON (Book.CategoryId = Category.CategoryId)
                   INNER JOIN BookStatus ON (Book.BookStatusId = BookStatus.BookStatusId)
                   WHERE "

            ' Modify SQL query WHERE conditions based on applied search settings
            If boolSettingsApplied Then

                ' - - - OR conditions ("Search by" checkboxes) - - -
                If boolSearchAll Then
                    ' Search by all columns
                    sql += "(IsbnNumber LIKE @searchKey OR Title LIKE @searchKey OR Author LIKE @searchKey OR CategoryName LIKE @searchKey
                            OR Publisher LIKE @searchKey OR PublicationDate LIKE @searchKey OR RetailPrice LIKE @searchKey)"
                ElseIf strOrConditions.Count <> 0 Then
                    sql += "("
                    ' Search by selected columns
                    For i As Integer = 0 To strOrConditions.Count - 1
                        sql += strOrConditions(i)
                        ' Append OR operator if current item is not the last one
                        If i <> strOrConditions.Count - 1 Then
                            sql += " OR "
                        End If
                    Next
                    sql += ")"
                End If

                ' - - - AND conditions ("Filter" combo boxes) - - -
                If strAndConditions.Count <> 0 Then
                    sql += " AND "
                    For i As Integer = 0 To strAndConditions.Count - 1
                        sql += strAndConditions(i)
                        ' Append AND operator if current item is not the last one
                        If i <> strAndConditions.Count - 1 Then
                            sql += " AND "
                        End If
                    Next
                End If
            Else
                ' Search by all columns (DEFAULT/NO SETTINGS APPLIED)
                sql += "(IsbnNumber LIKE @searchKey OR Title LIKE @searchKey OR Author LIKE @searchKey OR CategoryName LIKE @searchKey
                        OR Publisher LIKE @searchKey OR PublicationDate LIKE @searchKey OR RetailPrice LIKE @searchKey)"
            End If
            sql += ";" ' END OF SQL QUERY CONSTRUCTION

            ' Set SQL command to execute search query and retrieve data from DB
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.Add("@searchKey", SqlDbType.VarChar).Value = "%" & txtSearchBar.Text.ToString().Trim() & "%"
            If strAndConditions.Count <> 0 Then
                cmd.Parameters.Add("@categoryName", SqlDbType.VarChar).Value = strSearchCategory
                cmd.Parameters.Add("@statusDesc", SqlDbType.VarChar).Value = strSearchStatus
            End If
            adapter = New SqlDataAdapter(cmd)
            Dim dataSet As New DataSet
            adapter.Fill(dataSet, "MatchedBook")

            ' Update lstBooks (If matching rows returned: add items; Else: show no results)
            Dim rows As Integer = dataSet.Tables(0).Rows.Count
            lstBooks.Items.Clear()
            If rows > 0 Then
                For i As Integer = 0 To rows - 1
                    lstBooks.Items.Add(String.Format(mfmtStrBook, HideTextOverflow(dataSet.Tables(0).Rows(i)("IsbnNumber"), 13),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("Title"), 50),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("Author"), 20),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("CategoryName"), 17),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("Publisher"), 20),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("PublicationDate"), 10),
                                                    HideTextOverflow(dataSet.Tables(0).Rows(i)("RetailPrice"), 7)))
                Next
            Else
                lstBooks.Items.Add("No matching books found.")
            End If
            lstBooks.SelectedIndex = 0
            ' Update lblResults to display number of books loaded
            lblResults.Text = rows & " book(s) found..."

            Me.Cursor = Cursors.Default ' Set cursor back to Default when search process is complete
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Private Sub btnSearchSettings_Click(sender As Object, e As EventArgs) Handles btnSearchSettings.Click
        ' Open DialogBookSearchSettings and get user input
        If dlgBookSearchSettings.ShowDialog() = DialogResult.OK Then
            strOrConditions.Clear()
            strAndConditions.Clear()
            ' Get search settings and filters
            boolSearchAll = dlgBookSearchSettings.boolChkAll
            boolSearchIsbn = dlgBookSearchSettings.boolChkIsbn
            boolSearchTitle = dlgBookSearchSettings.boolChkTitle
            boolSearchAuthor = dlgBookSearchSettings.boolChkAuthor
            boolSearchPublisher = dlgBookSearchSettings.boolChkPublisher
            boolSearchPublicationDate = dlgBookSearchSettings.boolChkPublicationDate
            boolSearchRetailPrice = dlgBookSearchSettings.boolChkRetailPrice
            strSearchCategory = dlgBookSearchSettings.strCobCategory
            strSearchStatus = dlgBookSearchSettings.strCobStatus

            ' If all checkboxes are unchecked, check "All" option
            If boolSearchAll = False Or boolSearchIsbn = False Or boolSearchTitle = False Or boolSearchPublisher = False Or
               boolSearchPublicationDate = False Or boolSearchRetailPrice = False Then
                dlgBookSearchSettings.boolChkAll = True
                boolSearchAll = True
            End If

            ' Check whether any search options were selected
            If boolSearchAll = True Or boolSearchIsbn = True Or boolSearchTitle = True Or boolSearchPublisher = True Or
                   boolSearchPublicationDate = True Or boolSearchRetailPrice = True Or strSearchCategory <> "-" Or strSearchStatus <> "-" Then
                boolSettingsApplied = True
            End If

            ' Add applied settings/filters to Lists storing SQL WHERE conditions
            ' - - - OR conditions ("Search by" checkboxes) - - -
            If boolSearchAll Then
                strOrConditions.Add("IsbnNumber LIKE @searchKey")
                strOrConditions.Add("Title LIKE @searchKey")
                strOrConditions.Add("Author LIKE @searchKey")
                strOrConditions.Add("Category LIKE @searchKey")
                strOrConditions.Add("Publisher LIKE @searchKey")
                strOrConditions.Add("PublicationDate LIKE @searchKey")
                strOrConditions.Add("RetailPrice LIKE @searchKey")
            Else
                If boolSearchIsbn Then
                    strOrConditions.Add("IsbnNumber LIKE @searchKey")
                End If
                If boolSearchTitle Then
                    strOrConditions.Add("Title LIKE @searchKey")
                End If
                If boolSearchAuthor Then
                    strOrConditions.Add("Author LIKE @searchKey")
                End If
                If boolSearchPublisher Then
                    strOrConditions.Add("Publisher LIKE @searchKey")
                End If
                If boolSearchPublicationDate Then
                    strOrConditions.Add("PublicationDate LIKE @searchKey")
                End If
                If boolSearchRetailPrice Then
                    strOrConditions.Add("RetailPrice LIKE @searchKey")
                End If
            End If
            ' - - - AND conditions ("Filters" combo boxes) - - -
            If strSearchCategory <> "-" Then
                strAndConditions.Add("CategoryName = @categoryName")
            End If
            If strSearchStatus <> "-" Then
                strAndConditions.Add("StatusDesc = @statusDesc")
            End If

            ' Focus on searchbar for user's convenience
            txtSearchBar.Focus()
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Clear searchbar and search settings
        txtSearchBar.Clear()
        strOrConditions.Clear()
        strAndConditions.Clear()
        boolSettingsApplied = False
        boolSearchAll = False
        boolSearchIsbn = False
        boolSearchTitle = False
        boolSearchAuthor = False
        boolSearchPublisher = False
        boolSearchPublicationDate = False
        boolSearchRetailPrice = False
        strSearchCategory = "None"
        strSearchStatus = "None"
        ' Reset lstBooks
        lstBooks.Items.Clear()
        For i As Integer = 0 To dtbBooks.Rows.Count - 1
            lstBooks.Items.Add(String.Format(mfmtStrBook, hideTextOverflow(dtbBooks.Rows(i)("IsbnNumber"), 13),
                                                    hideTextOverflow(dtbBooks.Rows(i)("Title"), 50),
                                                    hideTextOverflow(dtbBooks.Rows(i)("Author"), 20),
                                                    hideTextOverflow(dtbBooks.Rows(i)("CategoryName"), 17),
                                                    hideTextOverflow(dtbBooks.Rows(i)("Publisher"), 20),
                                                    hideTextOverflow(dtbBooks.Rows(i)("PublicationDate"), 10),
                                                    hideTextOverflow(dtbBooks.Rows(i)("RetailPrice"), 8)))
        Next
        If lstBooks.Items.Count = 0 Then
            lstBooks.Items.Add("No books found.")
        End If
        lstBooks.SelectedIndex = 0
        lblResults.Text = dtbBooks.Rows.Count & " book(s) found..."
        ' Reset settings in DialogBookSearchSettings
        dlgBookSearchSettings.boolChkAll = True
        dlgBookSearchSettings.selectedCategory = 0
        dlgBookSearchSettings.selectedStatus = 0
        ' Set focus to searchbar
        txtSearchBar.Focus()
    End Sub

    Private Sub lstBooks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBooks.SelectedIndexChanged
        If lstBooks.Items(0).ToString() <> "No matching books found." And lstBooks.Items(0).ToString() <> "No books found." Then
            If cmd.Connection.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Try
                toggleBookDetail(True)
                dtbSelectedBook.Clear()
                ' Get ISBN of selected book item, get current year
                Dim isbn As String = lstBooks.Items(lstBooks.SelectedIndex).ToString().Substring(0, 13)
                Dim datCurrentYear As New Date(Date.Now().Year, 1, 1)

                Try
                    ' SQL query to get book picture, status, sales count, stocks count, and orders count
                    sql = "SELECT Book.IsbnNumber, Title, Author, Publisher, Book.CategoryId, Publisher, PublicationDate, RetailPrice,
                              BookPicture, Book.BookStatusId, StatusDesc,
	                          ISNULL((SELECT COUNT(*) FROM Book INNER JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
			                          INNER JOIN Sale ON (Stock.StockNumber = Sale.StockNumber)
			                          WHERE Stock.IsbnNumber = Book.IsbnNumber
			                          AND Book.IsbnNumber = @isbn
                                      AND SaleDate >= @date), 0) AS Sales,
	                          ISNULL((SELECT COUNT(*) FROM Book INNER JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
			                          WHERE Stock.IsbnNumber = Book.IsbnNumber
			                          AND Book.IsbnNumber = @isbn
                                      AND NOT StockStatusId IN (3, 4)), 0) AS Stocks,
	                          ISNULL((SELECT COUNT(*) FROM Book INNER JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
			                          INNER JOIN Orders On (Stock.StockNumber = Orders.StockNumber)
			                          WHERE Stock.IsbnNumber = Book.IsbnNumber
			                          AND Book.IsbnNumber = @isbn
                                      AND NOT OrderStatusId = 1), 0) AS Orders
                           FROM Book INNER JOIN BookStatus ON (Book.BookStatusId = BookStatus.BookStatusId)
                           INNER JOIN Category ON (Book.CategoryId = Category.CategoryId)
                           WHERE Book.IsbnNumber = @isbn;"
                    cmd = New SqlCommand(sql, conn)
                    cmd.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = isbn
                    cmd.Parameters.Add(New SqlParameter("@date", SqlDbType.Date)).Value = datCurrentYear
                    ' Retrieve data from DB
                    adapter = New SqlDataAdapter(cmd)
                    adapter.Fill(dtbSelectedBook)

                    ' Update dynamic user interface elements
                    Try
                        arrImage = CType(dtbSelectedBook.Rows(0)("BookPicture"), Byte())
                        ms = New MemoryStream(arrImage)
                        picBookCover.Image = Image.FromStream(ms)
                    Catch argEx As ArgumentException
                        ' Catch exception caused by image loading error
                        picBookCover.Image = Image.FromFile("images/image-not-found.jpg")
                        MessageBox.Show("Unable to load image of book picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    lblBookStatus.Text = dtbSelectedBook.Rows(0)("StatusDesc").ToString().ToUpper()
                    lblBookSales.Text = dtbSelectedBook.Rows(0)("Sales")
                    lblAvailableStock.Text = dtbSelectedBook.Rows(0)("Stocks")
                    lblBookOrders.Text = dtbSelectedBook.Rows(0)("Orders")

                    If dtbSelectedBook.Rows(0)("BookStatusId") <> 4 Then
                        With btnDiscontinue
                            .Text = "Discontinue"
                            .BackColor = Color.Salmon
                        End With
                    Else
                        With btnDiscontinue
                            .Text = "Resume Sale"
                            .BackColor = Color.LimeGreen
                        End With
                    End If
                Catch ex As Exception
                    ' Catch all
                    MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch ex As IndexOutOfRangeException
                MessageBox.Show("No book selected, please select a book in the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            dtbSelectedBook.Clear()
            ' Disable buttons and hide book details
            toggleBookDetail(False)
        End If

        conn.Close()
    End Sub

    Private Sub btnEditBook_Click(sender As Object, e As EventArgs) Handles btnEditBook.Click
        Dim dlgEditBook As New DialogEditBook
        ' Pass selected book's information to dlgEditBook
        Try
            dlgEditBook.strTitle = dtbSelectedBook.Rows(0)("Title")
            dlgEditBook.strAuthor = dtbSelectedBook.Rows(0)("Author")
            dlgEditBook.strPublisher = dtbSelectedBook.Rows(0)("Publisher")
            dlgEditBook.datPublicationDate = dtbSelectedBook.Rows(0)("PublicationDate")
            dlgEditBook.decRetailPrice = dtbSelectedBook.Rows(0)("RetailPrice")
            dlgEditBook.strISBN = dtbSelectedBook.Rows(0)("IsbnNumber")
            dlgEditBook.intCategory = dtbSelectedBook.Rows(0)("CategoryId") - 1
            dlgEditBook.bytArrImage = dtbSelectedBook.Rows(0)("BookPicture")

            ' Open DialogEditBook and get user input
            If dlgEditBook.ShowDialog() = DialogResult.OK Then
                ' Refresh dashboard
                Dim intSelectedIndex As Integer = lstBooks.SelectedIndex
                lstBooks.Items.Clear()
                Dashboard_Load(sender, e)
                lstBooks.SelectedIndex = intSelectedIndex
                ' Notify user that the edit was successful
                MessageBox.Show("The book was successfully edited.", "Edit successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch argEx As ArgumentException
            MessageBox.Show("Unable to get book image or book category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch indexEx As IndexOutOfRangeException
            MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDiscontinue_Click(sender As Object, e As EventArgs) Handles btnDiscontinue.Click
        conn.Open()

        Dim intReply As Integer

        Try
            ' Get ISBN of selected book item
            Dim isbn As String = lstBooks.Items(lstBooks.SelectedIndex).ToString().Substring(0, 13)

            ' Get the status of the selected book
            sql = "Select BookStatusId, COUNT(*) Stocks
                   FROM Book INNER JOIN Stock ON (Book.IsbnNumber = Stock.IsbnNumber)
                   WHERE Book.IsbnNumber = @isbn
                   GROUP BY Book.IsbnNumber, BookStatusId;"
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = isbn
            adapter = New SqlDataAdapter(cmd)
            Dim dataSet As New DataSet()
            adapter.Fill(dataSet, "Books")

            ' Check the status (4: Discontinued, 1,2,3: In Stock, Low Stock, Sold Out)
            If dataSet.Tables(0).Rows(0)("BookStatusId") <> 4 Then
                ' Prompt user to confirm to discontinue
                intReply = MessageBox.Show("Are you sure?" & ControlChars.NewLine & "Reminder: You can put this book back on sale anytime.",
                                       "Discontinue Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                ' If user chooses Yes, set book status to 4
                If intReply = DialogResult.Yes Then
                    sql = "UPDATE Book SET BookStatusId = 4 WHERE IsbnNumber = @isbn;"
                    cmd = New SqlCommand(sql, conn)
                    cmd.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = isbn
                    cmd.ExecuteNonQuery()
                    ' Refresh user interface
                    With btnDiscontinue
                        .Text = "Resume Sale"
                        .BackColor = Color.LimeGreen
                    End With
                    lblBookStatus.Text = "DISCONTINUED"
                    lblDiscontinued.Text = CStr(CInt(lblDiscontinued.Text) + 1)
                End If
            Else
                ' Prompt user to confirm to resume sale
                intReply = MessageBox.Show("Are you sure?", "Resume Sale Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                ' If user chooses Yes, update book status
                If intReply = DialogResult.Yes Then
                    ' Determine status of book
                    Dim statusId As Integer
                    Dim statusDesc As String
                    Dim stockCount As Integer = dataSet.Tables(0).Rows(0)("Stocks")
                    If stockCount < 10 Then
                        statusId = 2 'LOW STOCK
                        statusDesc = "LOW STOCK"
                    ElseIf stockCount = 0 Then
                        statusId = 3 'SOLD OUT
                        statusDesc = "SOLD OUT"
                    Else
                        statusId = 1 'IN STOCK
                        statusDesc = "IN STOCK"
                    End If
                    ' Update status
                    sql = "UPDATE Book SET BookStatusId = @statusId WHERE IsbnNumber = @isbn;"
                    cmd = New SqlCommand(sql, conn)
                    cmd.Parameters.Add(New SqlParameter("@statusId", SqlDbType.Int)).Value = statusId
                    cmd.Parameters.Add(New SqlParameter("@isbn", SqlDbType.VarChar)).Value = isbn
                    cmd.ExecuteNonQuery()
                    ' Refresh user interface
                    With btnDiscontinue
                        .Text = "Discontinue"
                        .BackColor = Color.Salmon
                    End With
                    lblBookStatus.Text = statusDesc
                    lblDiscontinued.Text = CStr(CInt(lblDiscontinued.Text) - 1)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch indexEx As IndexOutOfRangeException
            MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Private Sub btnViewStocks_Click(sender As Object, e As EventArgs) Handles btnViewStocks.Click
        ' Get ISBN of selected book
        Dim isbn As String = dtbSelectedBook.Rows(0)(0).ToString()

        ' Get the parent window
        Dim layout As Layout = Me.Parent.Parent
        ' Get the stock search settings dialog object
        Dim dlgStockSearchSettings As DialogStockSearchSettings = ViewStocks.pDlgStockSearchSettings

        ' Switch to ViewStocks tab
        layout.switchViewStocks(sender, e)

        'Configure search settings
        ViewStocks.txtSearchBar.Text = isbn
        dlgStockSearchSettings.boolChkAll = False
        dlgStockSearchSettings.boolChkIsbn = True
        dlgStockSearchSettings.clickApply(sender, e)

        'Click Search
        ViewStocks.clickSearch(sender, e)
    End Sub

    Private Sub btnTrackOrders_Click(sender As Object, e As EventArgs) Handles btnTrackOrders.Click
        ' Get ISBN of selected book
        Dim isbn As String = dtbSelectedBook.Rows(0)(0).ToString()

        ' Get the parent window
        Dim layout As Layout = Me.Parent.Parent
        ' Get the order search settings dialog object
        Dim dlgOrderSearchSettings As DialogOrderSearchSettings = TrackOrders.pDlgOrderSearchSettings

        ' Switch to TrackOrders tab
        layout.switchTrackOrders(sender, e)

        'Configure search settings
        TrackOrders.txtSearchBar.Text = isbn
        dlgOrderSearchSettings.boolChkAll = False
        dlgOrderSearchSettings.boolChkIsbn = True
        dlgOrderSearchSettings.clickApply(sender, e)

        'Click Search
        TrackOrders.clickSearch(sender, e)
    End Sub

    Private Sub btnViewSales_Click(sender As Object, e As EventArgs) Handles btnViewSales.Click
        ' Get ISBN of selected book
        Dim isbn As String = dtbSelectedBook.Rows(0)(0).ToString()

        ' Get the parent window
        Dim layout As Layout = Me.Parent.Parent
        ' Get the stock search settings dialog object
        Dim dlgSaleSearchSettings As DialogSaleSearchSettings = ViewSales.pDlgSaleSearchSettings

        ' Switch to ViewSales tab
        layout.switchViewSales(sender, e)

        'Configure search settings
        ViewSales.txtSearchBar.Text = isbn
        dlgSaleSearchSettings.boolChkAll = False
        dlgSaleSearchSettings.boolChkIsbn = True
        dlgSaleSearchSettings.clickApply(sender, e)

        'Click Search
        ViewSales.clickSearch(sender, e)
    End Sub

    Private Sub displayAllBooks()
        conn.Open()

        Try
            lstBooks.Items.Clear()

            ' Set query and create SQL command
            sql = "SELECT IsbnNumber, Title, Author, CategoryName, Publisher, PublicationDate, RetailPrice, BookPicture
                   FROM Book INNER JOIN Category ON (Book.CategoryId = Category.CategoryId);"
            cmd = New SqlCommand(sql, conn)
            ' Retrieve Book data from DB - 0
            adapter = New SqlDataAdapter(cmd)
            Dim dataSet As New DataSet()
            adapter.Fill(dataSet, "Book")
            dtbBooks = dataSet.Tables(0)
            Dim rows As Integer = dataSet.Tables(0).Rows.Count

            If rows > 0 Then
                ' Load data into lstBooks
                For i As Integer = 0 To rows - 1
                    ' Add row into lstBooks
                    lstBooks.Items.Add(String.Format(mfmtStrBook, hideTextOverflow(dataSet.Tables(0).Rows(i)("IsbnNumber"), 13),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("Title"), 50),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("Author"), 20),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("CategoryName"), 17),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("Publisher"), 20),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("PublicationDate"), 10),
                                                     hideTextOverflow(dataSet.Tables(0).Rows(i)("RetailPrice"), 8)))
                Next
                ' Update image of book picture
                Try
                    arrImage = CType(dataSet.Tables(0).Rows(0)("BookPicture"), Byte())
                    ms = New MemoryStream(arrImage)
                    picBookCover.Image = Image.FromStream(ms)
                Catch argEx As ArgumentException
                    ' Catch exception caused by image loading error
                    picBookCover.Image = Image.FromFile("images/image-not-found.jpg")
                    MessageBox.Show("Unable to load image of book picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch indexEx As IndexOutOfRangeException
                    MessageBox.Show("No book selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                lstBooks.SelectedIndex = 0
            Else
                lstBooks.Items.Add("No books found.")
            End If

            ' Update lblResults to display number of books loaded
            lblResults.Text = rows & " book(s) found..."
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Private Sub updateStatusBlocks()
        conn.Open()

        Try
            Dim dataSet As New DataSet
            ' Retrieve Stock quantity from DB - 0
            sql = "SELECT COUNT(*) As StockQuantity FROM Stock;"
            cmd = New SqlCommand(sql, conn)
            adapter = New SqlDataAdapter(cmd)
            adapter.Fill(dataSet, "Stock")
            ' Retrieve Order quantity from DB - 1
            sql = "SELECT COUNT(*) AS OrderQuantity FROM Orders
                   WHERE NOT OrderStatusId = 1;"
            cmd = New SqlCommand(sql, conn)
            adapter = New SqlDataAdapter(cmd)
            adapter.Fill(dataSet, "Order")
            ' Retrieve number of low-stock, sold-out, and discontinued books - 2
            sql = "SELECT (SELECT COUNT(*)
                           FROM Book WHERE BookStatusId = 2) LowStockBooks,
                          (SELECT COUNT(*)
                           FROM Book WHERE BookStatusId = 3) SoldOutBooks,
                          (SELECT COUNT(*)
                           FROM Book WHERE BookStatusId = 4) DiscontinuedBooks;"
            cmd = New SqlCommand(sql, conn)
            adapter = New SqlDataAdapter(cmd)
            adapter.Fill(dataSet, "BookStatusCount")

            ' Update status blocks based on loaded data
            lblTotalBooks.Text = dtbBooks.Rows.Count
            lblTotalStock.Text = dataSet.Tables(0).Rows(0)("StockQuantity")
            lblOrders.Text = dataSet.Tables(1).Rows(0)("OrderQuantity")
            lblLowStock.Text = dataSet.Tables(2).Rows(0)("LowStockBooks")
            lblSoldOut.Text = dataSet.Tables(2).Rows(0)("SoldOutBooks")
            lblDiscontinued.Text = dataSet.Tables(2).Rows(0)("DiscontinuedBooks")
        Catch ex As Exception
            ' Catch all
            MessageBox.Show("An unknown error has occured, please try again.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        conn.Close()
    End Sub

    Private Sub toggleBookDetail(bool As Boolean)
        If bool = False Then
            picBookCover.Image = Image.FromFile("images/image-not-found.jpg")
        End If
        btnEditBook.Visible = bool
        btnDiscontinue.Visible = bool
        btnViewStocks.Visible = bool
        btnTrackOrders.Visible = bool
        btnViewSales.Visible = bool
        lblBookStatus.Visible = bool
        lblBookStatus1.Visible = bool
        lblBookSales.Visible = bool
        lblBookSales1.Visible = bool
        lblAvailableStock.Visible = bool
        lblAvailableStock1.Visible = bool
        lblBookOrders.Visible = bool
        lblBookOrders1.Visible = bool
    End Sub

    Private Function hideTextOverflow(text As String, max As Integer) As String
        If text.Length > max Then
            text = text.Substring(0, max - 1)
            text += "…"
        End If
        Return text
    End Function

    Public Sub refreshForm(sender As Object, e As EventArgs)
        Dashboard_Load(sender, e)
    End Sub

    Public Sub clickSearch(sender As Object, e As EventArgs)
        btnSearch_Click(sender, e)
    End Sub
End Class
