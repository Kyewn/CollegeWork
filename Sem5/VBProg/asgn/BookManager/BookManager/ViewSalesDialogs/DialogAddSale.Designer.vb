<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogAddSale
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
        Me.dlgActionPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirmSale = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblStockNumber = New System.Windows.Forms.Label()
        Me.txtStockNo = New System.Windows.Forms.TextBox()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.lblVerifyResult = New System.Windows.Forms.Label()
        Me.txtSaleId = New System.Windows.Forms.TextBox()
        Me.lblSaleId = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstSaleItems = New System.Windows.Forms.ListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.dlgActionPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'dlgActionPanel
        '
        Me.dlgActionPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dlgActionPanel.ColumnCount = 2
        Me.dlgActionPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.dlgActionPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.dlgActionPanel.Controls.Add(Me.btnCancel, 1, 0)
        Me.dlgActionPanel.Controls.Add(Me.btnConfirmSale, 0, 0)
        Me.dlgActionPanel.Location = New System.Drawing.Point(561, 513)
        Me.dlgActionPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.dlgActionPanel.Name = "dlgActionPanel"
        Me.dlgActionPanel.RowCount = 1
        Me.dlgActionPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.dlgActionPanel.Size = New System.Drawing.Size(285, 48)
        Me.dlgActionPanel.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(169, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        '
        'btnConfirmSale
        '
        Me.btnConfirmSale.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirmSale.Enabled = False
        Me.btnConfirmSale.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmSale.ForeColor = System.Drawing.Color.Black
        Me.btnConfirmSale.Location = New System.Drawing.Point(4, 4)
        Me.btnConfirmSale.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmSale.Name = "btnConfirmSale"
        Me.btnConfirmSale.Size = New System.Drawing.Size(134, 40)
        Me.btnConfirmSale.TabIndex = 0
        Me.btnConfirmSale.Text = "CONFIRM SALE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(213, 32)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Enter Sale Details"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.ForeColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(25, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 2)
        Me.Panel2.TabIndex = 59
        '
        'lblStockNumber
        '
        Me.lblStockNumber.AutoSize = True
        Me.lblStockNumber.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockNumber.Location = New System.Drawing.Point(24, 88)
        Me.lblStockNumber.Name = "lblStockNumber"
        Me.lblStockNumber.Size = New System.Drawing.Size(96, 19)
        Me.lblStockNumber.TabIndex = 60
        Me.lblStockNumber.Text = "Stock Number"
        '
        'txtStockNo
        '
        Me.txtStockNo.Location = New System.Drawing.Point(141, 86)
        Me.txtStockNo.Name = "txtStockNo"
        Me.txtStockNo.Size = New System.Drawing.Size(280, 22)
        Me.txtStockNo.TabIndex = 61
        '
        'btnVerify
        '
        Me.btnVerify.BackColor = System.Drawing.Color.White
        Me.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnVerify.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.ForeColor = System.Drawing.Color.Blue
        Me.btnVerify.Location = New System.Drawing.Point(301, 122)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(120, 39)
        Me.btnVerify.TabIndex = 63
        Me.btnVerify.Text = "VERIFY STOCK"
        Me.btnVerify.UseVisualStyleBackColor = False
        '
        'lblVerifyResult
        '
        Me.lblVerifyResult.AutoSize = True
        Me.lblVerifyResult.ForeColor = System.Drawing.Color.Blue
        Me.lblVerifyResult.Location = New System.Drawing.Point(24, 211)
        Me.lblVerifyResult.Name = "lblVerifyResult"
        Me.lblVerifyResult.Size = New System.Drawing.Size(548, 17)
        Me.lblVerifyResult.TabIndex = 64
        Me.lblVerifyResult.Text = "Note: Stock Number field only accepts numbers. Please specify one without the pre" &
    "fix."
        '
        'txtSaleId
        '
        Me.txtSaleId.Location = New System.Drawing.Point(550, 86)
        Me.txtSaleId.Name = "txtSaleId"
        Me.txtSaleId.ReadOnly = True
        Me.txtSaleId.Size = New System.Drawing.Size(275, 22)
        Me.txtSaleId.TabIndex = 66
        '
        'lblSaleId
        '
        Me.lblSaleId.AutoSize = True
        Me.lblSaleId.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaleId.Location = New System.Drawing.Point(477, 88)
        Me.lblSaleId.Name = "lblSaleId"
        Me.lblSaleId.Size = New System.Drawing.Size(51, 19)
        Me.lblSaleId.TabIndex = 65
        Me.lblSaleId.Text = "Sale ID"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(477, 132)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(58, 19)
        Me.lblSupplier.TabIndex = 67
        Me.lblSupplier.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 23)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Sale Items"
        '
        'lstSaleItems
        '
        Me.lstSaleItems.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSaleItems.FormattingEnabled = True
        Me.lstSaleItems.ItemHeight = 17
        Me.lstSaleItems.Location = New System.Drawing.Point(25, 310)
        Me.lstSaleItems.Name = "lstSaleItems"
        Me.lstSaleItems.Size = New System.Drawing.Size(800, 123)
        Me.lstSaleItems.TabIndex = 70
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(125, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 19)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Stock No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 19)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Sale ID"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(232, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 19)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Title"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(545, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 19)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Retail Price (RM)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(697, 288)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 19)
        Me.Label11.TabIndex = 75
        Me.Label11.Text = "Sale Date"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(705, 203)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 35)
        Me.btnAdd.TabIndex = 76
        Me.btnAdd.Text = "Add Item"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Salmon
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(705, 439)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(120, 35)
        Me.btnDelete.TabIndex = 77
        Me.btnDelete.Text = "Delete Item"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.ForeColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(25, 500)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 2)
        Me.Panel1.TabIndex = 60
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(550, 130)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(275, 22)
        Me.txtSupplier.TabIndex = 78
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.ForeColor = System.Drawing.Color.Silver
        Me.Panel3.Location = New System.Drawing.Point(25, 244)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(800, 2)
        Me.Panel3.TabIndex = 60
        Me.Panel3.Visible = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.White
        Me.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReset.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Blue
        Me.btnReset.Location = New System.Drawing.Point(212, 122)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(82, 39)
        Me.btnReset.TabIndex = 79
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'DialogAddSale
        '
        Me.AcceptButton = Me.btnConfirmSale
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(852, 573)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtSupplier)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lstSaleItems)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.txtSaleId)
        Me.Controls.Add(Me.lblSaleId)
        Me.Controls.Add(Me.lblVerifyResult)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.txtStockNo)
        Me.Controls.Add(Me.lblStockNumber)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dlgActionPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAddSale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New Sale"
        Me.dlgActionPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dlgActionPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnConfirmSale As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblStockNumber As Label
    Friend WithEvents txtStockNo As TextBox
    Friend WithEvents btnVerify As Button
    Friend WithEvents lblVerifyResult As Label
    Friend WithEvents txtSaleId As TextBox
    Friend WithEvents lblSaleId As Label
    Friend WithEvents lblSupplier As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lstSaleItems As ListBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnReset As Button
End Class
