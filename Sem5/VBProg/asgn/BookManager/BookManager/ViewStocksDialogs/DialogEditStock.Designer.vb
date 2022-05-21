<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditStock
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
        Me.cobSupplier = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cobStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWholesalePrice = New System.Windows.Forms.TextBox()
        Me.cobLocation = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.picLocation = New System.Windows.Forms.PictureBox()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.btnAddLocation = New System.Windows.Forms.Button()
        Me.lblFormFeedback = New System.Windows.Forms.Label()
        Me.txtStockNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.83333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.16667!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnConfirm, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(497, 400)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(240, 44)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.Location = New System.Drawing.Point(10, 4)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(112, 36)
        Me.btnConfirm.TabIndex = 0
        Me.btnConfirm.Text = "CONFIRM"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(142, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 36)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        '
        'cobSupplier
        '
        Me.cobSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobSupplier.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobSupplier.FormattingEnabled = True
        Me.cobSupplier.Location = New System.Drawing.Point(153, 144)
        Me.cobSupplier.Name = "cobSupplier"
        Me.cobSupplier.Size = New System.Drawing.Size(230, 27)
        Me.cobSupplier.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Supplier"
        '
        'cobStatus
        '
        Me.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobStatus.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.Location = New System.Drawing.Point(153, 293)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(230, 27)
        Me.cobStatus.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 20)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Wholesale Price"
        '
        'txtWholesalePrice
        '
        Me.txtWholesalePrice.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWholesalePrice.Location = New System.Drawing.Point(153, 219)
        Me.txtWholesalePrice.Name = "txtWholesalePrice"
        Me.txtWholesalePrice.Size = New System.Drawing.Size(230, 27)
        Me.txtWholesalePrice.TabIndex = 38
        '
        'cobLocation
        '
        Me.cobLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobLocation.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobLocation.FormattingEnabled = True
        Me.cobLocation.Location = New System.Drawing.Point(501, 145)
        Me.cobLocation.Name = "cobLocation"
        Me.cobLocation.Size = New System.Drawing.Size(227, 27)
        Me.cobLocation.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(429, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 20)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Location"
        '
        'picLocation
        '
        Me.picLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLocation.Image = Global.BookManager.My.Resources.Resources.image_not_found
        Me.picLocation.Location = New System.Drawing.Point(433, 219)
        Me.picLocation.Name = "picLocation"
        Me.picLocation.Size = New System.Drawing.Size(295, 158)
        Me.picLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLocation.TabIndex = 41
        Me.picLocation.TabStop = False
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
        Me.btnAddSupplier.Location = New System.Drawing.Point(255, 175)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(128, 24)
        Me.btnAddSupplier.TabIndex = 42
        Me.btnAddSupplier.Text = "ADD SUPPLIER"
        Me.btnAddSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddSupplier.UseVisualStyleBackColor = False
        '
        'btnAddLocation
        '
        Me.btnAddLocation.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddLocation.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddLocation.FlatAppearance.BorderSize = 0
        Me.btnAddLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddLocation.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLocation.ForeColor = System.Drawing.Color.Blue
        Me.btnAddLocation.Location = New System.Drawing.Point(600, 175)
        Me.btnAddLocation.Name = "btnAddLocation"
        Me.btnAddLocation.Size = New System.Drawing.Size(128, 24)
        Me.btnAddLocation.TabIndex = 43
        Me.btnAddLocation.Text = "ADD LOCATION"
        Me.btnAddLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddLocation.UseVisualStyleBackColor = False
        '
        'lblFormFeedback
        '
        Me.lblFormFeedback.AutoSize = True
        Me.lblFormFeedback.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormFeedback.ForeColor = System.Drawing.Color.Red
        Me.lblFormFeedback.Location = New System.Drawing.Point(33, 415)
        Me.lblFormFeedback.Name = "lblFormFeedback"
        Me.lblFormFeedback.Size = New System.Drawing.Size(112, 15)
        Me.lblFormFeedback.TabIndex = 44
        Me.lblFormFeedback.Text = "Form Error Message"
        Me.lblFormFeedback.Visible = False
        '
        'txtStockNumber
        '
        Me.txtStockNumber.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockNumber.Location = New System.Drawing.Point(153, 46)
        Me.txtStockNumber.Name = "txtStockNumber"
        Me.txtStockNumber.ReadOnly = True
        Me.txtStockNumber.Size = New System.Drawing.Size(230, 27)
        Me.txtStockNumber.TabIndex = 45
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 20)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Stock Number"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Silver
        Me.Panel7.Location = New System.Drawing.Point(36, 107)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(693, 2)
        Me.Panel7.TabIndex = 47
        '
        'DialogEditStock
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(772, 467)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStockNumber)
        Me.Controls.Add(Me.lblFormFeedback)
        Me.Controls.Add(Me.btnAddLocation)
        Me.Controls.Add(Me.btnAddSupplier)
        Me.Controls.Add(Me.picLocation)
        Me.Controls.Add(Me.cobLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtWholesalePrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cobStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cobSupplier)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogEditStock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Stock Details"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cobSupplier As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cobStatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtWholesalePrice As TextBox
    Friend WithEvents cobLocation As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents picLocation As PictureBox
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents btnAddLocation As Button
    Friend WithEvents lblFormFeedback As Label
    Friend WithEvents txtStockNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel7 As Panel
End Class
