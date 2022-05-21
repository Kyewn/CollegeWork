<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrackOrders
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
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSearchSettings = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblReceived = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTotalOrders = New System.Windows.Forms.Label()
        Me.txtSearchBar = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNotReceived = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblRetail = New System.Windows.Forms.Label()
        Me.lblWp = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblStockNum = New System.Windows.Forms.Label()
        Me.lstOrder = New System.Windows.Forms.ListBox()
        Me.pnlBookStats = New System.Windows.Forms.Panel()
        Me.lblAuthor1 = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.lblPublisher1 = New System.Windows.Forms.Label()
        Me.lblPublisher = New System.Windows.Forms.Label()
        Me.lblCategory1 = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblISBN1 = New System.Windows.Forms.Label()
        Me.lblISBN = New System.Windows.Forms.Label()
        Me.lblPubDate1 = New System.Windows.Forms.Label()
        Me.lblPubDate = New System.Windows.Forms.Label()
        Me.btnEditOrder = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnDeleteOrder = New System.Windows.Forms.Button()
        Me.btnAddOrder = New System.Windows.Forms.Button()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBookStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Silver
        Me.Panel7.Location = New System.Drawing.Point(29, 95)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1663, 2)
        Me.Panel7.TabIndex = 64
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
        Me.btnReset.TabIndex = 63
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
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
        Me.btnSearchSettings.TabIndex = 62
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
        Me.btnSearch.TabIndex = 61
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblReceived)
        Me.Panel2.Location = New System.Drawing.Point(168, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(120, 55)
        Me.Panel2.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "RECEIVED"
        '
        'lblReceived
        '
        Me.lblReceived.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblReceived.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceived.Location = New System.Drawing.Point(0, 0)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(118, 33)
        Me.lblReceived.TabIndex = 0
        Me.lblReceived.Text = "69"
        Me.lblReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.lblTotalOrders)
        Me.Panel1.Location = New System.Drawing.Point(29, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(120, 55)
        Me.Panel1.TabIndex = 55
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(17, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 15)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "TOTAL ORDERS"
        '
        'lblTotalOrders
        '
        Me.lblTotalOrders.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalOrders.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOrders.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalOrders.Name = "lblTotalOrders"
        Me.lblTotalOrders.Size = New System.Drawing.Size(118, 33)
        Me.lblTotalOrders.TabIndex = 0
        Me.lblTotalOrders.Text = "420"
        Me.lblTotalOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSearchBar
        '
        Me.txtSearchBar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBar.Location = New System.Drawing.Point(1210, 24)
        Me.txtSearchBar.Name = "txtSearchBar"
        Me.txtSearchBar.Size = New System.Drawing.Size(405, 25)
        Me.txtSearchBar.TabIndex = 60
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblNotReceived)
        Me.Panel3.Location = New System.Drawing.Point(307, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(120, 55)
        Me.Panel3.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NOT RECEIVED"
        '
        'lblNotReceived
        '
        Me.lblNotReceived.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotReceived.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotReceived.Location = New System.Drawing.Point(0, 0)
        Me.lblNotReceived.Name = "lblNotReceived"
        Me.lblNotReceived.Size = New System.Drawing.Size(118, 33)
        Me.lblNotReceived.TabIndex = 0
        Me.lblNotReceived.Text = "69"
        Me.lblNotReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(1165, 105)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(78, 19)
        Me.lblStatus.TabIndex = 54
        Me.lblStatus.Text = "Order Date"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(1330, 105)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(47, 19)
        Me.lblLocation.TabIndex = 53
        Me.lblLocation.Text = "Status"
        '
        'lblRetail
        '
        Me.lblRetail.AutoSize = True
        Me.lblRetail.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetail.Location = New System.Drawing.Point(1025, 105)
        Me.lblRetail.Name = "lblRetail"
        Me.lblRetail.Size = New System.Drawing.Size(104, 19)
        Me.lblRetail.TabIndex = 52
        Me.lblRetail.Text = "Wholesale Price"
        '
        'lblWp
        '
        Me.lblWp.AutoSize = True
        Me.lblWp.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWp.Location = New System.Drawing.Point(886, 105)
        Me.lblWp.Name = "lblWp"
        Me.lblWp.Size = New System.Drawing.Size(58, 19)
        Me.lblWp.TabIndex = 51
        Me.lblWp.Text = "Supplier"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(288, 105)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(34, 19)
        Me.lblSupplier.TabIndex = 50
        Me.lblSupplier.Text = "Title"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(138, 105)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(96, 19)
        Me.lblTitle.TabIndex = 49
        Me.lblTitle.Text = "Stock Number"
        '
        'lblStockNum
        '
        Me.lblStockNum.AutoSize = True
        Me.lblStockNum.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockNum.Location = New System.Drawing.Point(46, 105)
        Me.lblStockNum.Name = "lblStockNum"
        Me.lblStockNum.Size = New System.Drawing.Size(63, 19)
        Me.lblStockNum.TabIndex = 48
        Me.lblStockNum.Text = "Order ID"
        '
        'lstOrder
        '
        Me.lstOrder.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrder.FormattingEnabled = True
        Me.lstOrder.ItemHeight = 17
        Me.lstOrder.Items.AddRange(New Object() {"  aaaaaa      aaaaaa      aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" &
                "aaaaa    aaaaaaaaaaaaaaaaaaaa      aaaaaaa      aaaaaaaaaa      aaaaaaaaaaaa"})
        Me.lstOrder.Location = New System.Drawing.Point(29, 125)
        Me.lstOrder.Name = "lstOrder"
        Me.lstOrder.Size = New System.Drawing.Size(1443, 514)
        Me.lstOrder.TabIndex = 46
        '
        'pnlBookStats
        '
        Me.pnlBookStats.BackColor = System.Drawing.Color.White
        Me.pnlBookStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBookStats.Controls.Add(Me.lblAuthor1)
        Me.pnlBookStats.Controls.Add(Me.lblAuthor)
        Me.pnlBookStats.Controls.Add(Me.lblPublisher1)
        Me.pnlBookStats.Controls.Add(Me.lblPublisher)
        Me.pnlBookStats.Controls.Add(Me.lblCategory1)
        Me.pnlBookStats.Controls.Add(Me.lblCategory)
        Me.pnlBookStats.Controls.Add(Me.lblISBN1)
        Me.pnlBookStats.Controls.Add(Me.lblISBN)
        Me.pnlBookStats.Controls.Add(Me.lblPubDate1)
        Me.pnlBookStats.Controls.Add(Me.lblPubDate)
        Me.pnlBookStats.Location = New System.Drawing.Point(1496, 195)
        Me.pnlBookStats.Name = "pnlBookStats"
        Me.pnlBookStats.Size = New System.Drawing.Size(198, 246)
        Me.pnlBookStats.TabIndex = 45
        '
        'lblAuthor1
        '
        Me.lblAuthor1.AutoSize = True
        Me.lblAuthor1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor1.Location = New System.Drawing.Point(13, 32)
        Me.lblAuthor1.Name = "lblAuthor1"
        Me.lblAuthor1.Size = New System.Drawing.Size(135, 19)
        Me.lblAuthor1.TabIndex = 11
        Me.lblAuthor1.Text = "Hajime Kamoshida"
        Me.lblAuthor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(14, 17)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(54, 15)
        Me.lblAuthor.TabIndex = 10
        Me.lblAuthor.Text = "AUTHOR"
        '
        'lblPublisher1
        '
        Me.lblPublisher1.AutoSize = True
        Me.lblPublisher1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPublisher1.Location = New System.Drawing.Point(13, 75)
        Me.lblPublisher1.Name = "lblPublisher1"
        Me.lblPublisher1.Size = New System.Drawing.Size(137, 19)
        Me.lblPublisher1.TabIndex = 9
        Me.lblPublisher1.Text = "ASCII Media Works"
        Me.lblPublisher1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPublisher
        '
        Me.lblPublisher.AutoSize = True
        Me.lblPublisher.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPublisher.Location = New System.Drawing.Point(14, 60)
        Me.lblPublisher.Name = "lblPublisher"
        Me.lblPublisher.Size = New System.Drawing.Size(66, 15)
        Me.lblPublisher.TabIndex = 8
        Me.lblPublisher.Text = "PUBLISHER"
        '
        'lblCategory1
        '
        Me.lblCategory1.AutoSize = True
        Me.lblCategory1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory1.Location = New System.Drawing.Point(13, 161)
        Me.lblCategory1.Name = "lblCategory1"
        Me.lblCategory1.Size = New System.Drawing.Size(71, 19)
        Me.lblCategory1.TabIndex = 7
        Me.lblCategory1.Text = "Romance"
        Me.lblCategory1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(14, 146)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(65, 15)
        Me.lblCategory.TabIndex = 6
        Me.lblCategory.Text = "CATEGORY"
        '
        'lblISBN1
        '
        Me.lblISBN1.AutoSize = True
        Me.lblISBN1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISBN1.Location = New System.Drawing.Point(13, 204)
        Me.lblISBN1.Name = "lblISBN1"
        Me.lblISBN1.Size = New System.Drawing.Size(113, 19)
        Me.lblISBN1.TabIndex = 5
        Me.lblISBN1.Text = "9781975312534"
        Me.lblISBN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblISBN
        '
        Me.lblISBN.AutoSize = True
        Me.lblISBN.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISBN.Location = New System.Drawing.Point(14, 189)
        Me.lblISBN.Name = "lblISBN"
        Me.lblISBN.Size = New System.Drawing.Size(83, 15)
        Me.lblISBN.TabIndex = 4
        Me.lblISBN.Text = "ISBN NUMBER"
        '
        'lblPubDate1
        '
        Me.lblPubDate1.AutoSize = True
        Me.lblPubDate1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPubDate1.Location = New System.Drawing.Point(13, 118)
        Me.lblPubDate1.Name = "lblPubDate1"
        Me.lblPubDate1.Size = New System.Drawing.Size(78, 19)
        Me.lblPubDate1.TabIndex = 3
        Me.lblPubDate1.Text = "April 2014"
        Me.lblPubDate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPubDate
        '
        Me.lblPubDate.AutoSize = True
        Me.lblPubDate.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPubDate.Location = New System.Drawing.Point(14, 103)
        Me.lblPubDate.Name = "lblPubDate"
        Me.lblPubDate.Size = New System.Drawing.Size(110, 15)
        Me.lblPubDate.TabIndex = 2
        Me.lblPubDate.Text = "PUBLICATION DATE"
        '
        'btnEditOrder
        '
        Me.btnEditOrder.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEditOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditOrder.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEditOrder.FlatAppearance.BorderSize = 0
        Me.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditOrder.ForeColor = System.Drawing.Color.White
        Me.btnEditOrder.Location = New System.Drawing.Point(1496, 125)
        Me.btnEditOrder.Name = "btnEditOrder"
        Me.btnEditOrder.Size = New System.Drawing.Size(90, 32)
        Me.btnEditOrder.TabIndex = 43
        Me.btnEditOrder.Text = "Edit"
        Me.btnEditOrder.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1553, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 15)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "BOOK DETAILS"
        '
        'btnDeleteOrder
        '
        Me.btnDeleteOrder.BackColor = System.Drawing.Color.Salmon
        Me.btnDeleteOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteOrder.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnDeleteOrder.FlatAppearance.BorderSize = 0
        Me.btnDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteOrder.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteOrder.ForeColor = System.Drawing.Color.White
        Me.btnDeleteOrder.Location = New System.Drawing.Point(1604, 125)
        Me.btnDeleteOrder.Name = "btnDeleteOrder"
        Me.btnDeleteOrder.Size = New System.Drawing.Size(90, 32)
        Me.btnDeleteOrder.TabIndex = 65
        Me.btnDeleteOrder.Text = "Delete"
        Me.btnDeleteOrder.UseVisualStyleBackColor = False
        '
        'btnAddOrder
        '
        Me.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.btnAddOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddOrder.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddOrder.ForeColor = System.Drawing.Color.White
        Me.btnAddOrder.Location = New System.Drawing.Point(1495, 585)
        Me.btnAddOrder.Name = "btnAddOrder"
        Me.btnAddOrder.Size = New System.Drawing.Size(198, 50)
        Me.btnAddOrder.TabIndex = 66
        Me.btnAddOrder.Text = "ADD ORDER"
        Me.btnAddOrder.UseVisualStyleBackColor = False
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResults.Location = New System.Drawing.Point(1207, 54)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(0, 16)
        Me.lblResults.TabIndex = 67
        '
        'TrackOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1705, 642)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.btnAddOrder)
        Me.Controls.Add(Me.btnDeleteOrder)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearchSettings)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSearchBar)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblRetail)
        Me.Controls.Add(Me.lblWp)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblStockNum)
        Me.Controls.Add(Me.lstOrder)
        Me.Controls.Add(Me.pnlBookStats)
        Me.Controls.Add(Me.btnEditOrder)
        Me.Controls.Add(Me.Label14)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TrackOrders"
        Me.Text = "TrackOrders"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlBookStats.ResumeLayout(False)
        Me.pnlBookStats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnReset As Button
    Friend WithEvents btnSearchSettings As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblReceived As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents lblTotalOrders As Label
    Friend WithEvents txtSearchBar As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNotReceived As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblRetail As Label
    Friend WithEvents lblWp As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStockNum As Label
    Friend WithEvents lstOrder As ListBox
    Friend WithEvents pnlBookStats As Panel
    Friend WithEvents lblAuthor1 As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblPublisher1 As Label
    Friend WithEvents lblPublisher As Label
    Friend WithEvents lblCategory1 As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblISBN1 As Label
    Friend WithEvents lblISBN As Label
    Friend WithEvents lblPubDate1 As Label
    Friend WithEvents lblPubDate As Label
    Friend WithEvents btnEditOrder As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents btnDeleteOrder As Button
    Friend WithEvents btnAddOrder As Button
    Friend WithEvents lblResults As Label
End Class
