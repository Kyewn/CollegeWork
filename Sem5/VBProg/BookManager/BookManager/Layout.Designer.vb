<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Layout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Layout))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnNavViewSales = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnNavTrackOrders = New System.Windows.Forms.Button()
        Me.btnNavViewStock = New System.Windows.Forms.Button()
        Me.btnNavAddStock = New System.Windows.Forms.Button()
        Me.btnNavAddBook = New System.Windows.Forms.Button()
        Me.btnNavDashboard = New System.Windows.Forms.Button()
        Me.pnlNavbar = New System.Windows.Forms.Panel()
        Me.pnlNavbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.SystemColors.Control
        Me.pnlMain.Location = New System.Drawing.Point(0, 62)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1740, 680)
        Me.pnlMain.TabIndex = 2
        '
        'btnNavViewSales
        '
        Me.btnNavViewSales.BackColor = System.Drawing.Color.White
        Me.btnNavViewSales.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.btnNavViewSales.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavViewSales.Location = New System.Drawing.Point(1585, 16)
        Me.btnNavViewSales.Name = "btnNavViewSales"
        Me.btnNavViewSales.Size = New System.Drawing.Size(110, 42)
        Me.btnNavViewSales.TabIndex = 5
        Me.btnNavViewSales.Text = "View Sales"
        Me.btnNavViewSales.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Roboto Black", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(28, 22)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(157, 29)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "DASHBOARD"
        '
        'btnNavTrackOrders
        '
        Me.btnNavTrackOrders.BackColor = System.Drawing.Color.White
        Me.btnNavTrackOrders.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.btnNavTrackOrders.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavTrackOrders.Location = New System.Drawing.Point(1471, 16)
        Me.btnNavTrackOrders.Name = "btnNavTrackOrders"
        Me.btnNavTrackOrders.Size = New System.Drawing.Size(110, 42)
        Me.btnNavTrackOrders.TabIndex = 4
        Me.btnNavTrackOrders.Text = "Track Orders"
        Me.btnNavTrackOrders.UseVisualStyleBackColor = False
        '
        'btnNavViewStock
        '
        Me.btnNavViewStock.BackColor = System.Drawing.Color.White
        Me.btnNavViewStock.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.btnNavViewStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavViewStock.Location = New System.Drawing.Point(1357, 16)
        Me.btnNavViewStock.Name = "btnNavViewStock"
        Me.btnNavViewStock.Size = New System.Drawing.Size(110, 42)
        Me.btnNavViewStock.TabIndex = 3
        Me.btnNavViewStock.Text = "View Stocks"
        Me.btnNavViewStock.UseVisualStyleBackColor = False
        '
        'btnNavAddStock
        '
        Me.btnNavAddStock.BackColor = System.Drawing.Color.White
        Me.btnNavAddStock.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.btnNavAddStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavAddStock.Location = New System.Drawing.Point(1243, 16)
        Me.btnNavAddStock.Name = "btnNavAddStock"
        Me.btnNavAddStock.Size = New System.Drawing.Size(110, 42)
        Me.btnNavAddStock.TabIndex = 2
        Me.btnNavAddStock.Text = "Add Stock"
        Me.btnNavAddStock.UseVisualStyleBackColor = False
        '
        'btnNavAddBook
        '
        Me.btnNavAddBook.BackColor = System.Drawing.Color.White
        Me.btnNavAddBook.Font = New System.Drawing.Font("Arial", 7.8!)
        Me.btnNavAddBook.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavAddBook.Location = New System.Drawing.Point(1129, 16)
        Me.btnNavAddBook.Name = "btnNavAddBook"
        Me.btnNavAddBook.Size = New System.Drawing.Size(110, 42)
        Me.btnNavAddBook.TabIndex = 1
        Me.btnNavAddBook.Text = "Add Book"
        Me.btnNavAddBook.UseVisualStyleBackColor = False
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.BackColor = System.Drawing.Color.White
        Me.btnNavDashboard.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnNavDashboard.ForeColor = System.Drawing.Color.Blue
        Me.btnNavDashboard.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNavDashboard.Location = New System.Drawing.Point(1015, 16)
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.Size = New System.Drawing.Size(110, 42)
        Me.btnNavDashboard.TabIndex = 0
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.UseVisualStyleBackColor = False
        '
        'pnlNavbar
        '
        Me.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.pnlNavbar.Controls.Add(Me.btnNavDashboard)
        Me.pnlNavbar.Controls.Add(Me.btnNavAddBook)
        Me.pnlNavbar.Controls.Add(Me.btnNavAddStock)
        Me.pnlNavbar.Controls.Add(Me.btnNavViewStock)
        Me.pnlNavbar.Controls.Add(Me.btnNavTrackOrders)
        Me.pnlNavbar.Controls.Add(Me.lblTitle)
        Me.pnlNavbar.Controls.Add(Me.btnNavViewSales)
        Me.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNavbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlNavbar.Name = "pnlNavbar"
        Me.pnlNavbar.Size = New System.Drawing.Size(1702, 70)
        Me.pnlNavbar.TabIndex = 1
        '
        'Layout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1702, 703)
        Me.Controls.Add(Me.pnlNavbar)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Layout"
        Me.Text = "BookManager"
        Me.pnlNavbar.ResumeLayout(False)
        Me.pnlNavbar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As Panel
    Friend WithEvents btnNavViewSales As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnNavTrackOrders As Button
    Friend WithEvents btnNavViewStock As Button
    Friend WithEvents btnNavAddStock As Button
    Friend WithEvents btnNavAddBook As Button
    Friend WithEvents btnNavDashboard As Button
    Friend WithEvents pnlNavbar As Panel
End Class
