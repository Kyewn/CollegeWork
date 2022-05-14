<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnViewBooksOfCat = New System.Windows.Forms.Button()
        Me.btnViewRemStocks = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlSaleStats = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblDate1 = New System.Windows.Forms.Label()
        Me.lblRanking = New System.Windows.Forms.Label()
        Me.lblRanking1 = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.lblSupplier1 = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblISBN = New System.Windows.Forms.Label()
        Me.lblISBN1 = New System.Windows.Forms.Label()
        Me.lblCategory1 = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTitle1 = New System.Windows.Forms.Label()
        Me.lblStockNo = New System.Windows.Forms.Label()
        Me.lblStockNo1 = New System.Windows.Forms.Label()
        Me.btnSearchSettings = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchBar = New System.Windows.Forms.TextBox()
        Me.btnRemoveSale = New System.Windows.Forms.Button()
        Me.btnEditSale = New System.Windows.Forms.Button()
        Me.lstSales = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstCategory = New System.Windows.Forms.ListBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cobDate = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnAddSale = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.pnlSaleStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnViewBooksOfCat
        '
        Me.btnViewBooksOfCat.Location = New System.Drawing.Point(18, 319)
        Me.btnViewBooksOfCat.Name = "btnViewBooksOfCat"
        Me.btnViewBooksOfCat.Size = New System.Drawing.Size(212, 33)
        Me.btnViewBooksOfCat.TabIndex = 9
        Me.btnViewBooksOfCat.Text = "VIEW BOOKS OF CATEGORY"
        Me.btnViewBooksOfCat.UseVisualStyleBackColor = True
        '
        'btnViewRemStocks
        '
        Me.btnViewRemStocks.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRemStocks.Location = New System.Drawing.Point(18, 280)
        Me.btnViewRemStocks.Name = "btnViewRemStocks"
        Me.btnViewRemStocks.Size = New System.Drawing.Size(212, 33)
        Me.btnViewRemStocks.TabIndex = 8
        Me.btnViewRemStocks.Text = "VIEW REMAINING STOCKS"
        Me.btnViewRemStocks.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(915, 133)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 19)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = " "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1254, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 19)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Sale Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1035, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 19)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Retail Price (RM)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(135, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 19)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Stock No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 19)
        Me.Label8.TabIndex = 41
        Me.Label8.Text = "Sale ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(263, 132)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 19)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Title"
        '
        'pnlSaleStats
        '
        Me.pnlSaleStats.BackColor = System.Drawing.Color.White
        Me.pnlSaleStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSaleStats.Controls.Add(Me.lblDate)
        Me.pnlSaleStats.Controls.Add(Me.lblDate1)
        Me.pnlSaleStats.Controls.Add(Me.lblRanking)
        Me.pnlSaleStats.Controls.Add(Me.lblRanking1)
        Me.pnlSaleStats.Controls.Add(Me.lblSupplier)
        Me.pnlSaleStats.Controls.Add(Me.lblSupplier1)
        Me.pnlSaleStats.Controls.Add(Me.lblCategory)
        Me.pnlSaleStats.Controls.Add(Me.lblISBN)
        Me.pnlSaleStats.Controls.Add(Me.lblISBN1)
        Me.pnlSaleStats.Controls.Add(Me.btnViewBooksOfCat)
        Me.pnlSaleStats.Controls.Add(Me.btnViewRemStocks)
        Me.pnlSaleStats.Controls.Add(Me.lblCategory1)
        Me.pnlSaleStats.Controls.Add(Me.lblTitle)
        Me.pnlSaleStats.Controls.Add(Me.lblTitle1)
        Me.pnlSaleStats.Controls.Add(Me.lblStockNo)
        Me.pnlSaleStats.Controls.Add(Me.lblStockNo1)
        Me.pnlSaleStats.Location = New System.Drawing.Point(1444, 188)
        Me.pnlSaleStats.Name = "pnlSaleStats"
        Me.pnlSaleStats.Size = New System.Drawing.Size(248, 376)
        Me.pnlSaleStats.TabIndex = 40
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(13, 226)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDate.Size = New System.Drawing.Size(77, 19)
        Me.lblDate.TabIndex = 18
        Me.lblDate.Text = "12/3/2022"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate1.Location = New System.Drawing.Point(14, 211)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(63, 15)
        Me.lblDate1.TabIndex = 17
        Me.lblDate1.Text = "SALE DATE"
        '
        'lblRanking
        '
        Me.lblRanking.AutoSize = True
        Me.lblRanking.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRanking.Location = New System.Drawing.Point(169, 130)
        Me.lblRanking.Name = "lblRanking"
        Me.lblRanking.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRanking.Size = New System.Drawing.Size(25, 19)
        Me.lblRanking.TabIndex = 16
        Me.lblRanking.Text = "#1"
        Me.lblRanking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRanking1
        '
        Me.lblRanking1.AutoSize = True
        Me.lblRanking1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRanking1.Location = New System.Drawing.Point(170, 115)
        Me.lblRanking1.Name = "lblRanking1"
        Me.lblRanking1.Size = New System.Drawing.Size(58, 15)
        Me.lblRanking1.TabIndex = 15
        Me.lblRanking1.Text = "RANKING"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(13, 177)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSupplier.Size = New System.Drawing.Size(110, 19)
        Me.lblSupplier.TabIndex = 14
        Me.lblSupplier.Text = "ABC Bookstore"
        Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSupplier1
        '
        Me.lblSupplier1.AutoSize = True
        Me.lblSupplier1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier1.Location = New System.Drawing.Point(14, 162)
        Me.lblSupplier1.Name = "lblSupplier1"
        Me.lblSupplier1.Size = New System.Drawing.Size(57, 15)
        Me.lblSupplier1.TabIndex = 13
        Me.lblSupplier1.Text = "SUPPLIER"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(13, 130)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCategory.Size = New System.Drawing.Size(71, 19)
        Me.lblCategory.TabIndex = 12
        Me.lblCategory.Text = "Romance"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblISBN
        '
        Me.lblISBN.AutoSize = True
        Me.lblISBN.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISBN.Location = New System.Drawing.Point(105, 33)
        Me.lblISBN.Name = "lblISBN"
        Me.lblISBN.Size = New System.Drawing.Size(113, 19)
        Me.lblISBN.TabIndex = 11
        Me.lblISBN.Text = "9781975312534"
        Me.lblISBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblISBN1
        '
        Me.lblISBN1.AutoSize = True
        Me.lblISBN1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISBN1.Location = New System.Drawing.Point(106, 18)
        Me.lblISBN1.Name = "lblISBN1"
        Me.lblISBN1.Size = New System.Drawing.Size(83, 15)
        Me.lblISBN1.TabIndex = 10
        Me.lblISBN1.Text = "ISBN NUMBER"
        '
        'lblCategory1
        '
        Me.lblCategory1.AutoSize = True
        Me.lblCategory1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory1.Location = New System.Drawing.Point(14, 115)
        Me.lblCategory1.Name = "lblCategory1"
        Me.lblCategory1.Size = New System.Drawing.Size(65, 15)
        Me.lblCategory1.TabIndex = 4
        Me.lblCategory1.Text = "CATEGORY"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(13, 81)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(217, 19)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Rascal Does Not Dream of Bu..."
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle1
        '
        Me.lblTitle1.AutoSize = True
        Me.lblTitle1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle1.Location = New System.Drawing.Point(14, 66)
        Me.lblTitle1.Name = "lblTitle1"
        Me.lblTitle1.Size = New System.Drawing.Size(34, 15)
        Me.lblTitle1.TabIndex = 2
        Me.lblTitle1.Text = "TITLE"
        '
        'lblStockNo
        '
        Me.lblStockNo.AutoSize = True
        Me.lblStockNo.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockNo.Location = New System.Drawing.Point(13, 33)
        Me.lblStockNo.Name = "lblStockNo"
        Me.lblStockNo.Size = New System.Drawing.Size(49, 19)
        Me.lblStockNo.TabIndex = 1
        Me.lblStockNo.Text = "S1234"
        Me.lblStockNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStockNo1
        '
        Me.lblStockNo1.AutoSize = True
        Me.lblStockNo1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockNo1.Location = New System.Drawing.Point(14, 18)
        Me.lblStockNo1.Name = "lblStockNo1"
        Me.lblStockNo1.Size = New System.Drawing.Size(66, 15)
        Me.lblStockNo1.TabIndex = 0
        Me.lblStockNo1.Text = "STOCK NO."
        '
        'btnSearchSettings
        '
        Me.btnSearchSettings.BackColor = System.Drawing.SystemColors.Control
        Me.btnSearchSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSearchSettings.FlatAppearance.BorderSize = 0
        Me.btnSearchSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSettings.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchSettings.ForeColor = System.Drawing.Color.Blue
        Me.btnSearchSettings.Location = New System.Drawing.Point(1514, 51)
        Me.btnSearchSettings.Name = "btnSearchSettings"
        Me.btnSearchSettings.Size = New System.Drawing.Size(178, 24)
        Me.btnSearchSettings.TabIndex = 33
        Me.btnSearchSettings.Text = "ADVANCED SETTINGS"
        Me.btnSearchSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchSettings.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1612, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 26)
        Me.btnSearch.TabIndex = 32
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearchBar
        '
        Me.txtSearchBar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBar.Location = New System.Drawing.Point(1210, 24)
        Me.txtSearchBar.Name = "txtSearchBar"
        Me.txtSearchBar.Size = New System.Drawing.Size(405, 25)
        Me.txtSearchBar.TabIndex = 31
        '
        'btnRemoveSale
        '
        Me.btnRemoveSale.BackColor = System.Drawing.Color.Salmon
        Me.btnRemoveSale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveSale.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnRemoveSale.FlatAppearance.BorderSize = 0
        Me.btnRemoveSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveSale.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSale.ForeColor = System.Drawing.Color.White
        Me.btnRemoveSale.Location = New System.Drawing.Point(1567, 114)
        Me.btnRemoveSale.Name = "btnRemoveSale"
        Me.btnRemoveSale.Size = New System.Drawing.Size(125, 38)
        Me.btnRemoveSale.TabIndex = 38
        Me.btnRemoveSale.Text = "Remove Sale"
        Me.btnRemoveSale.UseVisualStyleBackColor = False
        '
        'btnEditSale
        '
        Me.btnEditSale.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEditSale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditSale.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnEditSale.FlatAppearance.BorderSize = 0
        Me.btnEditSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditSale.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditSale.ForeColor = System.Drawing.Color.White
        Me.btnEditSale.Location = New System.Drawing.Point(1444, 114)
        Me.btnEditSale.Name = "btnEditSale"
        Me.btnEditSale.Size = New System.Drawing.Size(117, 38)
        Me.btnEditSale.TabIndex = 37
        Me.btnEditSale.Text = "Edit Sale"
        Me.btnEditSale.UseVisualStyleBackColor = False
        '
        'lstSales
        '
        Me.lstSales.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSales.FormattingEnabled = True
        Me.lstSales.ItemHeight = 17
        Me.lstSales.Location = New System.Drawing.Point(31, 155)
        Me.lstSales.Name = "lstSales"
        Me.lstSales.Size = New System.Drawing.Size(1366, 208)
        Me.lstSales.TabIndex = 36
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(29, 92)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1663, 2)
        Me.Panel2.TabIndex = 35
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.SystemColors.Control
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Red
        Me.btnReset.Location = New System.Drawing.Point(1418, 51)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(78, 24)
        Me.btnReset.TabIndex = 34
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1220, 409)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 19)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Generated Profit (RM)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(980, 409)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 19)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Money Invested (RM)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(122, 409)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 19)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Category"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 409)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 19)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Rank"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(560, 409)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 19)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "No. of Sales"
        '
        'lstCategory
        '
        Me.lstCategory.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCategory.FormattingEnabled = True
        Me.lstCategory.ItemHeight = 17
        Me.lstCategory.Items.AddRange(New Object() {"100       Philosophy and Religion                             42069              " &
                "    10000.00                   10000.00                   10000.00    "})
        Me.lstCategory.Location = New System.Drawing.Point(31, 432)
        Me.lstCategory.Name = "lstCategory"
        Me.lstCategory.Size = New System.Drawing.Size(1366, 208)
        Me.lstCategory.TabIndex = 47
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(28, 386)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(179, 23)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "CATEGORY RANKING"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 23)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "SALE RECORDS"
        '
        'cobDate
        '
        Me.cobDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobDate.FormattingEnabled = True
        Me.cobDate.Items.AddRange(New Object() {"This year", "Past 2 years", "Past 3 years"})
        Me.cobDate.Location = New System.Drawing.Point(29, 44)
        Me.cobDate.Name = "cobDate"
        Me.cobDate.Size = New System.Drawing.Size(196, 24)
        Me.cobDate.TabIndex = 58
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(28, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 19)
        Me.Label23.TabIndex = 59
        Me.Label23.Text = "Date range"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(1518, 165)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(101, 20)
        Me.Label21.TabIndex = 60
        Me.Label21.Text = "SALE DETAILS"
        '
        'btnAddSale
        '
        Me.btnAddSale.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btnAddSale.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSale.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSale.ForeColor = System.Drawing.Color.White
        Me.btnAddSale.Location = New System.Drawing.Point(1444, 579)
        Me.btnAddSale.Name = "btnAddSale"
        Me.btnAddSale.Size = New System.Drawing.Size(248, 50)
        Me.btnAddSale.TabIndex = 11
        Me.btnAddSale.Text = "ADD SALE"
        Me.btnAddSale.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(741, 410)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(145, 19)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Money Returned (RM)"
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResults.Location = New System.Drawing.Point(1207, 54)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(0, 16)
        Me.lblResults.TabIndex = 62
        '
        'ViewSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1705, 642)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnAddSale)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cobDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lstCategory)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.pnlSaleStats)
        Me.Controls.Add(Me.btnSearchSettings)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchBar)
        Me.Controls.Add(Me.btnRemoveSale)
        Me.Controls.Add(Me.btnEditSale)
        Me.Controls.Add(Me.lstSales)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnReset)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ViewSales"
        Me.Text = "ViewSales"
        Me.pnlSaleStats.ResumeLayout(False)
        Me.pnlSaleStats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnViewBooksOfCat As Button
    Friend WithEvents btnViewRemStocks As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlSaleStats As Panel
    Friend WithEvents btnSearchSettings As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearchBar As TextBox
    Friend WithEvents btnRemoveSale As Button
    Friend WithEvents btnEditSale As Button
    Friend WithEvents lstSales As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnReset As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lstCategory As ListBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cobDate As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents btnAddSale As Button
    Friend WithEvents lblCategory1 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblTitle1 As Label
    Friend WithEvents lblStockNo As Label
    Friend WithEvents lblStockNo1 As Label
    Friend WithEvents lblISBN As Label
    Friend WithEvents lblISBN1 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblDate1 As Label
    Friend WithEvents lblRanking As Label
    Friend WithEvents lblRanking1 As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblSupplier1 As Label
    Friend WithEvents lblResults As Label
End Class
