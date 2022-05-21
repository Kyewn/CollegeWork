<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogAddOrder
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
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lstOrderItems = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtOrderId = New System.Windows.Forms.TextBox()
        Me.lblVerifyResult = New System.Windows.Forms.Label()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirmOrder = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.lblWholesalePrice = New System.Windows.Forms.Label()
        Me.cobSupplier = New System.Windows.Forms.ComboBox()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.txtWholesalePrice = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(495, 126)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 22)
        Me.txtQuantity.TabIndex = 99
        Me.txtQuantity.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.ForeColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(25, 510)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(870, 2)
        Me.Panel1.TabIndex = 82
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Salmon
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(775, 449)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 35)
        Me.btnDelete.TabIndex = 98
        Me.btnDelete.Text = "Delete Item"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(775, 212)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 35)
        Me.btnAdd.TabIndex = 97
        Me.btnAdd.Text = "Add Item"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(734, 298)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 19)
        Me.Label11.TabIndex = 96
        Me.Label11.Text = "Wholesale Price (RM)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(606, 297)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 19)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Supplier"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(126, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 19)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 19)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Stock No."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(433, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 19)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Author"
        '
        'lstOrderItems
        '
        Me.lstOrderItems.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrderItems.FormattingEnabled = True
        Me.lstOrderItems.ItemHeight = 17
        Me.lstOrderItems.Location = New System.Drawing.Point(25, 320)
        Me.lstOrderItems.Name = "lstOrderItems"
        Me.lstOrderItems.Size = New System.Drawing.Size(870, 123)
        Me.lstOrderItems.TabIndex = 91
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 23)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Order Items"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(423, 128)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(63, 19)
        Me.lblQuantity.TabIndex = 89
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.Visible = False
        '
        'txtOrderId
        '
        Me.txtOrderId.Location = New System.Drawing.Point(495, 86)
        Me.txtOrderId.Name = "txtOrderId"
        Me.txtOrderId.ReadOnly = True
        Me.txtOrderId.Size = New System.Drawing.Size(100, 22)
        Me.txtOrderId.TabIndex = 88
        '
        'lblVerifyResult
        '
        Me.lblVerifyResult.AutoSize = True
        Me.lblVerifyResult.ForeColor = System.Drawing.Color.Blue
        Me.lblVerifyResult.Location = New System.Drawing.Point(24, 221)
        Me.lblVerifyResult.Name = "lblVerifyResult"
        Me.lblVerifyResult.Size = New System.Drawing.Size(297, 17)
        Me.lblVerifyResult.TabIndex = 86
        Me.lblVerifyResult.Text = "Note: ISBN field only accept 13-digit numbers."
        '
        'btnVerify
        '
        Me.btnVerify.BackColor = System.Drawing.Color.White
        Me.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnVerify.FlatAppearance.BorderSize = 0
        Me.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnVerify.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.ForeColor = System.Drawing.Color.Blue
        Me.btnVerify.Location = New System.Drawing.Point(258, 121)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(120, 39)
        Me.btnVerify.TabIndex = 85
        Me.btnVerify.Text = "VERIFY ISBN"
        Me.btnVerify.UseVisualStyleBackColor = False
        '
        'txtISBN
        '
        Me.txtISBN.Location = New System.Drawing.Point(141, 86)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(237, 22)
        Me.txtISBN.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "ISBN Number"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.ForeColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(25, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(870, 2)
        Me.Panel2.TabIndex = 81
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(233, 32)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Enter Order Details"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(168, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        '
        'btnConfirmOrder
        '
        Me.btnConfirmOrder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirmOrder.Enabled = False
        Me.btnConfirmOrder.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmOrder.ForeColor = System.Drawing.Color.Black
        Me.btnConfirmOrder.Location = New System.Drawing.Point(4, 4)
        Me.btnConfirmOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmOrder.Name = "btnConfirmOrder"
        Me.btnConfirmOrder.Size = New System.Drawing.Size(134, 40)
        Me.btnConfirmOrder.TabIndex = 0
        Me.btnConfirmOrder.Text = "CONFIRM ORDER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(423, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 19)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Order ID"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConfirmOrder, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(639, 523)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(284, 48)
        Me.TableLayoutPanel1.TabIndex = 79
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(663, 127)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(58, 19)
        Me.lblSupplier.TabIndex = 100
        Me.lblSupplier.Text = "Supplier"
        Me.lblSupplier.Visible = False
        '
        'lblWholesalePrice
        '
        Me.lblWholesalePrice.AutoSize = True
        Me.lblWholesalePrice.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWholesalePrice.Location = New System.Drawing.Point(617, 88)
        Me.lblWholesalePrice.Name = "lblWholesalePrice"
        Me.lblWholesalePrice.Size = New System.Drawing.Size(104, 19)
        Me.lblWholesalePrice.TabIndex = 101
        Me.lblWholesalePrice.Text = "Wholesale Price"
        Me.lblWholesalePrice.Visible = False
        '
        'cobSupplier
        '
        Me.cobSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobSupplier.FormattingEnabled = True
        Me.cobSupplier.Location = New System.Drawing.Point(727, 125)
        Me.cobSupplier.Name = "cobSupplier"
        Me.cobSupplier.Size = New System.Drawing.Size(168, 24)
        Me.cobSupplier.TabIndex = 102
        Me.cobSupplier.Visible = False
        '
        'btnAddSupplier
        '
        Me.btnAddSupplier.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddSupplier.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddSupplier.FlatAppearance.BorderSize = 0
        Me.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddSupplier.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSupplier.ForeColor = System.Drawing.Color.Blue
        Me.btnAddSupplier.Location = New System.Drawing.Point(767, 151)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(128, 31)
        Me.btnAddSupplier.TabIndex = 103
        Me.btnAddSupplier.Text = "ADD SUPPLIER"
        Me.btnAddSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddSupplier.UseVisualStyleBackColor = False
        Me.btnAddSupplier.Visible = False
        '
        'txtWholesalePrice
        '
        Me.txtWholesalePrice.Location = New System.Drawing.Point(727, 86)
        Me.txtWholesalePrice.Name = "txtWholesalePrice"
        Me.txtWholesalePrice.Size = New System.Drawing.Size(168, 22)
        Me.txtWholesalePrice.TabIndex = 104
        Me.txtWholesalePrice.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.ForeColor = System.Drawing.Color.Silver
        Me.Panel3.Location = New System.Drawing.Point(25, 257)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(870, 2)
        Me.Panel3.TabIndex = 82
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.White
        Me.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReset.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Blue
        Me.btnReset.Location = New System.Drawing.Point(172, 121)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(80, 39)
        Me.btnReset.TabIndex = 105
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'DialogAddOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(932, 583)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtWholesalePrice)
        Me.Controls.Add(Me.btnAddSupplier)
        Me.Controls.Add(Me.cobSupplier)
        Me.Controls.Add(Me.lblWholesalePrice)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lstOrderItems)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.txtOrderId)
        Me.Controls.Add(Me.lblVerifyResult)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.txtISBN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAddOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Order"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lstOrderItems As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents txtOrderId As TextBox
    Friend WithEvents lblVerifyResult As Label
    Friend WithEvents btnVerify As Button
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirmOrder As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblSupplier As Label
    Friend WithEvents lblWholesalePrice As Label
    Friend WithEvents cobSupplier As ComboBox
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents txtWholesalePrice As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnReset As Button
End Class
