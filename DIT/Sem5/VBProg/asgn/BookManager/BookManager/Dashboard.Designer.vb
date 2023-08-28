<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblTotalBooks = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalStock = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOrders = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLowStock = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDiscontinued = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lstBooks = New System.Windows.Forms.ListBox()
        Me.btnEditBook = New System.Windows.Forms.Button()
        Me.btnDiscontinue = New System.Windows.Forms.Button()
        Me.pnlBookStats = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblBookOrders1 = New System.Windows.Forms.Label()
        Me.lblBookOrders = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblAvailableStock1 = New System.Windows.Forms.Label()
        Me.lblAvailableStock = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblBookSales1 = New System.Windows.Forms.Label()
        Me.lblBookSales = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblBookStatus1 = New System.Windows.Forms.Label()
        Me.lblBookStatus = New System.Windows.Forms.Label()
        Me.btnViewSales = New System.Windows.Forms.Button()
        Me.btnTrackOrders = New System.Windows.Forms.Button()
        Me.btnViewStocks = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSearchBar = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnSearchSettings = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picBookCover = New System.Windows.Forms.PictureBox()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblSoldOut = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlBookStats.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.lblTotalBooks)
        Me.Panel1.Location = New System.Drawing.Point(29, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(120, 55)
        Me.Panel1.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(0, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 23)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "TOTAL BOOKS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalBooks
        '
        Me.lblTotalBooks.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalBooks.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBooks.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalBooks.Name = "lblTotalBooks"
        Me.lblTotalBooks.Size = New System.Drawing.Size(118, 30)
        Me.lblTotalBooks.TabIndex = 0
        Me.lblTotalBooks.Text = "0"
        Me.lblTotalBooks.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblTotalStock)
        Me.Panel2.Location = New System.Drawing.Point(168, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(120, 55)
        Me.Panel2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TOTAL STOCK"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalStock
        '
        Me.lblTotalStock.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalStock.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStock.Location = New System.Drawing.Point(0, 0)
        Me.lblTotalStock.Name = "lblTotalStock"
        Me.lblTotalStock.Size = New System.Drawing.Size(118, 30)
        Me.lblTotalStock.TabIndex = 0
        Me.lblTotalStock.Text = "0"
        Me.lblTotalStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblOrders)
        Me.Panel3.Location = New System.Drawing.Point(307, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(120, 55)
        Me.Panel3.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ORDERS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOrders
        '
        Me.lblOrders.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOrders.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrders.Location = New System.Drawing.Point(0, 0)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(118, 30)
        Me.lblOrders.TabIndex = 0
        Me.lblOrders.Text = "0"
        Me.lblOrders.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.lblLowStock)
        Me.Panel4.Location = New System.Drawing.Point(446, 24)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(120, 55)
        Me.Panel4.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "LOW STOCK"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLowStock
        '
        Me.lblLowStock.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLowStock.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLowStock.Location = New System.Drawing.Point(0, 0)
        Me.lblLowStock.Name = "lblLowStock"
        Me.lblLowStock.Size = New System.Drawing.Size(118, 30)
        Me.lblLowStock.TabIndex = 0
        Me.lblLowStock.Text = "0"
        Me.lblLowStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.lblDiscontinued)
        Me.Panel5.Location = New System.Drawing.Point(585, 24)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(120, 55)
        Me.Panel5.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "DISCONTINUED"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDiscontinued
        '
        Me.lblDiscontinued.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDiscontinued.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscontinued.Location = New System.Drawing.Point(0, 0)
        Me.lblDiscontinued.Name = "lblDiscontinued"
        Me.lblDiscontinued.Size = New System.Drawing.Size(118, 30)
        Me.lblDiscontinued.TabIndex = 0
        Me.lblDiscontinued.Text = "0"
        Me.lblDiscontinued.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Silver
        Me.Panel6.Location = New System.Drawing.Point(29, 95)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1663, 2)
        Me.Panel6.TabIndex = 14
        '
        'lstBooks
        '
        Me.lstBooks.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBooks.FormattingEnabled = True
        Me.lstBooks.ItemHeight = 17
        Me.lstBooks.Location = New System.Drawing.Point(29, 125)
        Me.lstBooks.Name = "lstBooks"
        Me.lstBooks.Size = New System.Drawing.Size(1450, 514)
        Me.lstBooks.TabIndex = 15
        '
        'btnEditBook
        '
        Me.btnEditBook.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEditBook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditBook.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnEditBook.FlatAppearance.BorderSize = 0
        Me.btnEditBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditBook.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditBook.ForeColor = System.Drawing.Color.White
        Me.btnEditBook.Location = New System.Drawing.Point(1496, 125)
        Me.btnEditBook.Name = "btnEditBook"
        Me.btnEditBook.Size = New System.Drawing.Size(67, 38)
        Me.btnEditBook.TabIndex = 4
        Me.btnEditBook.Text = "Edit"
        Me.btnEditBook.UseVisualStyleBackColor = False
        '
        'btnDiscontinue
        '
        Me.btnDiscontinue.BackColor = System.Drawing.Color.Salmon
        Me.btnDiscontinue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiscontinue.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDiscontinue.FlatAppearance.BorderSize = 0
        Me.btnDiscontinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiscontinue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscontinue.ForeColor = System.Drawing.Color.White
        Me.btnDiscontinue.Location = New System.Drawing.Point(1569, 125)
        Me.btnDiscontinue.Name = "btnDiscontinue"
        Me.btnDiscontinue.Size = New System.Drawing.Size(125, 38)
        Me.btnDiscontinue.TabIndex = 5
        Me.btnDiscontinue.Text = "Discontinue"
        Me.btnDiscontinue.UseVisualStyleBackColor = False
        '
        'pnlBookStats
        '
        Me.pnlBookStats.BackColor = System.Drawing.Color.White
        Me.pnlBookStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBookStats.Controls.Add(Me.Panel10)
        Me.pnlBookStats.Controls.Add(Me.Panel9)
        Me.pnlBookStats.Controls.Add(Me.Panel8)
        Me.pnlBookStats.Controls.Add(Me.Panel7)
        Me.pnlBookStats.Controls.Add(Me.btnViewSales)
        Me.pnlBookStats.Controls.Add(Me.btnTrackOrders)
        Me.pnlBookStats.Controls.Add(Me.btnViewStocks)
        Me.pnlBookStats.Location = New System.Drawing.Point(1496, 335)
        Me.pnlBookStats.Name = "pnlBookStats"
        Me.pnlBookStats.Size = New System.Drawing.Size(198, 300)
        Me.pnlBookStats.TabIndex = 19
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblBookOrders1)
        Me.Panel10.Controls.Add(Me.lblBookOrders)
        Me.Panel10.Location = New System.Drawing.Point(94, 113)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(99, 50)
        Me.Panel10.TabIndex = 13
        '
        'lblBookOrders1
        '
        Me.lblBookOrders1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBookOrders1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookOrders1.Location = New System.Drawing.Point(0, 0)
        Me.lblBookOrders1.Name = "lblBookOrders1"
        Me.lblBookOrders1.Size = New System.Drawing.Size(99, 20)
        Me.lblBookOrders1.TabIndex = 0
        Me.lblBookOrders1.Text = "ORDERED"
        Me.lblBookOrders1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBookOrders
        '
        Me.lblBookOrders.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBookOrders.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookOrders.Location = New System.Drawing.Point(0, 16)
        Me.lblBookOrders.Name = "lblBookOrders"
        Me.lblBookOrders.Size = New System.Drawing.Size(99, 34)
        Me.lblBookOrders.TabIndex = 1
        Me.lblBookOrders.Text = "0"
        Me.lblBookOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.lblAvailableStock1)
        Me.Panel9.Controls.Add(Me.lblAvailableStock)
        Me.Panel9.Location = New System.Drawing.Point(-1, 113)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(99, 50)
        Me.Panel9.TabIndex = 12
        '
        'lblAvailableStock1
        '
        Me.lblAvailableStock1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAvailableStock1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableStock1.Location = New System.Drawing.Point(0, 0)
        Me.lblAvailableStock1.Name = "lblAvailableStock1"
        Me.lblAvailableStock1.Size = New System.Drawing.Size(99, 20)
        Me.lblAvailableStock1.TabIndex = 0
        Me.lblAvailableStock1.Text = "AVAILABLE"
        Me.lblAvailableStock1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblAvailableStock
        '
        Me.lblAvailableStock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvailableStock.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableStock.Location = New System.Drawing.Point(0, 16)
        Me.lblAvailableStock.Name = "lblAvailableStock"
        Me.lblAvailableStock.Size = New System.Drawing.Size(99, 34)
        Me.lblAvailableStock.TabIndex = 1
        Me.lblAvailableStock.Text = "0"
        Me.lblAvailableStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblBookSales1)
        Me.Panel8.Controls.Add(Me.lblBookSales)
        Me.Panel8.Location = New System.Drawing.Point(-1, 61)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(198, 50)
        Me.Panel8.TabIndex = 12
        '
        'lblBookSales1
        '
        Me.lblBookSales1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBookSales1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookSales1.Location = New System.Drawing.Point(0, 0)
        Me.lblBookSales1.Name = "lblBookSales1"
        Me.lblBookSales1.Size = New System.Drawing.Size(198, 20)
        Me.lblBookSales1.TabIndex = 0
        Me.lblBookSales1.Text = "SOLD THIS YEAR"
        Me.lblBookSales1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBookSales
        '
        Me.lblBookSales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBookSales.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookSales.Location = New System.Drawing.Point(0, 16)
        Me.lblBookSales.Name = "lblBookSales"
        Me.lblBookSales.Size = New System.Drawing.Size(198, 34)
        Me.lblBookSales.TabIndex = 1
        Me.lblBookSales.Text = "0"
        Me.lblBookSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblBookStatus1)
        Me.Panel7.Controls.Add(Me.lblBookStatus)
        Me.Panel7.Location = New System.Drawing.Point(-1, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(198, 50)
        Me.Panel7.TabIndex = 11
        '
        'lblBookStatus1
        '
        Me.lblBookStatus1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBookStatus1.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookStatus1.Location = New System.Drawing.Point(0, 0)
        Me.lblBookStatus1.Name = "lblBookStatus1"
        Me.lblBookStatus1.Size = New System.Drawing.Size(198, 20)
        Me.lblBookStatus1.TabIndex = 0
        Me.lblBookStatus1.Text = "STATUS"
        Me.lblBookStatus1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblBookStatus
        '
        Me.lblBookStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBookStatus.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookStatus.Location = New System.Drawing.Point(0, 16)
        Me.lblBookStatus.Name = "lblBookStatus"
        Me.lblBookStatus.Size = New System.Drawing.Size(198, 34)
        Me.lblBookStatus.TabIndex = 1
        Me.lblBookStatus.Text = "UNKNOWN"
        Me.lblBookStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnViewSales
        '
        Me.btnViewSales.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewSales.Location = New System.Drawing.Point(17, 246)
        Me.btnViewSales.Name = "btnViewSales"
        Me.btnViewSales.Size = New System.Drawing.Size(163, 33)
        Me.btnViewSales.TabIndex = 8
        Me.btnViewSales.Text = "VIEW SALES"
        Me.btnViewSales.UseVisualStyleBackColor = True
        '
        'btnTrackOrders
        '
        Me.btnTrackOrders.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrackOrders.Location = New System.Drawing.Point(17, 210)
        Me.btnTrackOrders.Name = "btnTrackOrders"
        Me.btnTrackOrders.Size = New System.Drawing.Size(163, 33)
        Me.btnTrackOrders.TabIndex = 7
        Me.btnTrackOrders.Text = "TRACK ORDERS"
        Me.btnTrackOrders.UseVisualStyleBackColor = True
        '
        'btnViewStocks
        '
        Me.btnViewStocks.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewStocks.Location = New System.Drawing.Point(17, 171)
        Me.btnViewStocks.Name = "btnViewStocks"
        Me.btnViewStocks.Size = New System.Drawing.Size(163, 33)
        Me.btnViewStocks.TabIndex = 6
        Me.btnViewStocks.Text = "VIEW STOCKS"
        Me.btnViewStocks.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(44, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 19)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "ISBN Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(200, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 19)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Title"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(690, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 19)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Author"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1080, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 19)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Publisher"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1245, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 19)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Publication Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1370, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 19)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Retail Price"
        '
        'txtSearchBar
        '
        Me.txtSearchBar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchBar.Location = New System.Drawing.Point(1210, 24)
        Me.txtSearchBar.Name = "txtSearchBar"
        Me.txtSearchBar.Size = New System.Drawing.Size(405, 25)
        Me.txtSearchBar.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1612, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 26)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = True
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
        Me.btnSearchSettings.TabIndex = 3
        Me.btnSearchSettings.Text = "ADVANCED SETTINGS"
        Me.btnSearchSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchSettings.UseVisualStyleBackColor = False
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
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(890, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Category"
        '
        'picBookCover
        '
        Me.picBookCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picBookCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBookCover.Image = Global.BookManager.My.Resources.Resources.image_not_found
        Me.picBookCover.Location = New System.Drawing.Point(1496, 169)
        Me.picBookCover.Name = "picBookCover"
        Me.picBookCover.Size = New System.Drawing.Size(198, 166)
        Me.picBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBookCover.TabIndex = 18
        Me.picBookCover.TabStop = False
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResults.Location = New System.Drawing.Point(1207, 54)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(0, 16)
        Me.lblResults.TabIndex = 27
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Label16)
        Me.Panel11.Controls.Add(Me.lblSoldOut)
        Me.Panel11.Location = New System.Drawing.Point(724, 24)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(120, 55)
        Me.Panel11.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 23)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "SOLD OUT"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSoldOut
        '
        Me.lblSoldOut.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSoldOut.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoldOut.Location = New System.Drawing.Point(0, 0)
        Me.lblSoldOut.Name = "lblSoldOut"
        Me.lblSoldOut.Size = New System.Drawing.Size(118, 30)
        Me.lblSoldOut.TabIndex = 0
        Me.lblSoldOut.Text = "0"
        Me.lblSoldOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1705, 642)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pnlBookStats)
        Me.Controls.Add(Me.picBookCover)
        Me.Controls.Add(Me.btnDiscontinue)
        Me.Controls.Add(Me.btnEditBook)
        Me.Controls.Add(Me.lstBooks)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearchSettings)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearchBar)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.pnlBookStats.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label21 As Label
    Friend WithEvents lblTotalBooks As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalStock As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblOrders As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblLowStock As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDiscontinued As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lstBooks As ListBox
    Friend WithEvents btnEditBook As Button
    Friend WithEvents btnDiscontinue As Button
    Friend WithEvents picBookCover As PictureBox
    Friend WithEvents pnlBookStats As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnViewSales As Button
    Friend WithEvents btnTrackOrders As Button
    Friend WithEvents btnViewStocks As Button
    Friend WithEvents lblBookStatus As Label
    Friend WithEvents lblBookStatus1 As Label
    Friend WithEvents txtSearchBar As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnSearchSettings As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblResults As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents lblAvailableStock1 As Label
    Friend WithEvents lblAvailableStock As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblBookSales1 As Label
    Friend WithEvents lblBookSales As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblBookOrders1 As Label
    Friend WithEvents lblBookOrders As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents lblSoldOut As Label
End Class
