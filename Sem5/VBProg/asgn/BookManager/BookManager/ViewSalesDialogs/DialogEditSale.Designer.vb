<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditSale
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtSaleId = New System.Windows.Forms.TextBox()
        Me.lblVerify = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpSaleDate = New System.Windows.Forms.DateTimePicker()
        Me.txtStockNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnConfirm, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(247, 244)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(235, 53)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConfirm.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(4, 6)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(109, 41)
        Me.btnConfirm.TabIndex = 0
        Me.btnConfirm.Text = "CONFIRM"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(131, 6)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 41)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        '
        'txtSaleId
        '
        Me.txtSaleId.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaleId.Location = New System.Drawing.Point(145, 45)
        Me.txtSaleId.Name = "txtSaleId"
        Me.txtSaleId.ReadOnly = True
        Me.txtSaleId.Size = New System.Drawing.Size(285, 22)
        Me.txtSaleId.TabIndex = 66
        '
        'lblVerify
        '
        Me.lblVerify.AutoSize = True
        Me.lblVerify.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerify.Location = New System.Drawing.Point(28, 47)
        Me.lblVerify.Name = "lblVerify"
        Me.lblVerify.Size = New System.Drawing.Size(51, 19)
        Me.lblVerify.TabIndex = 65
        Me.lblVerify.Text = "Sale ID"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.ForeColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(23, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 2)
        Me.Panel1.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Sale Date"
        '
        'dtpSaleDate
        '
        Me.dtpSaleDate.CalendarFont = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSaleDate.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSaleDate.Location = New System.Drawing.Point(145, 192)
        Me.dtpSaleDate.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpSaleDate.Name = "dtpSaleDate"
        Me.dtpSaleDate.Size = New System.Drawing.Size(285, 22)
        Me.dtpSaleDate.TabIndex = 74
        Me.dtpSaleDate.Value = New Date(2022, 3, 17, 0, 0, 0, 0)
        '
        'txtStockNo
        '
        Me.txtStockNo.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNo.Location = New System.Drawing.Point(145, 94)
        Me.txtStockNo.Name = "txtStockNo"
        Me.txtStockNo.ReadOnly = True
        Me.txtStockNo.Size = New System.Drawing.Size(285, 22)
        Me.txtStockNo.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 19)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Stock Number"
        '
        'DialogEditSale
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(495, 310)
        Me.Controls.Add(Me.txtStockNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpSaleDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSaleId)
        Me.Controls.Add(Me.lblVerify)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogEditSale"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Sale Details"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtSaleId As TextBox
    Friend WithEvents lblVerify As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpSaleDate As DateTimePicker
    Friend WithEvents txtStockNo As TextBox
    Friend WithEvents Label1 As Label
End Class
