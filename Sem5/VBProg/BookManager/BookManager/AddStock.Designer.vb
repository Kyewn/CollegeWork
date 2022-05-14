<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddStock
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.lblValidMsg = New System.Windows.Forms.Label()
        Me.pnlAddStockValid = New System.Windows.Forms.Panel()
        Me.lblFormFeedback = New System.Windows.Forms.Label()
        Me.btnAddLocation = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlAddStock_Input = New System.Windows.Forms.Panel()
        Me.cobSupplier = New System.Windows.Forms.ComboBox()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.txtWholesalePrice = New System.Windows.Forms.TextBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.cobStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picLocation = New System.Windows.Forms.PictureBox()
        Me.cobLocation = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnVerifyISBN = New System.Windows.Forms.Button()
        Me.lblFeedback = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlAddStockValid.SuspendLayout()
        Me.pnlAddStock_Input.SuspendLayout()
        CType(Me.picLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Stock Details"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(290, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 28)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "ISBN Number"
        '
        'txtISBN
        '
        Me.txtISBN.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtISBN.Location = New System.Drawing.Point(462, 131)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(354, 30)
        Me.txtISBN.TabIndex = 0
        '
        'lblValidMsg
        '
        Me.lblValidMsg.AutoSize = True
        Me.lblValidMsg.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblValidMsg.Location = New System.Drawing.Point(41, 232)
        Me.lblValidMsg.Name = "lblValidMsg"
        Me.lblValidMsg.Size = New System.Drawing.Size(0, 15)
        Me.lblValidMsg.TabIndex = 21
        '
        'pnlAddStockValid
        '
        Me.pnlAddStockValid.BackColor = System.Drawing.SystemColors.Control
        Me.pnlAddStockValid.Controls.Add(Me.lblFormFeedback)
        Me.pnlAddStockValid.Controls.Add(Me.btnAddLocation)
        Me.pnlAddStockValid.Controls.Add(Me.btnConfirm)
        Me.pnlAddStockValid.Controls.Add(Me.btnCancel)
        Me.pnlAddStockValid.Controls.Add(Me.pnlAddStock_Input)
        Me.pnlAddStockValid.Controls.Add(Me.picLocation)
        Me.pnlAddStockValid.Controls.Add(Me.cobLocation)
        Me.pnlAddStockValid.Controls.Add(Me.Label7)
        Me.pnlAddStockValid.Location = New System.Drawing.Point(213, 0)
        Me.pnlAddStockValid.Name = "pnlAddStockValid"
        Me.pnlAddStockValid.Size = New System.Drawing.Size(1298, 642)
        Me.pnlAddStockValid.TabIndex = 22
        Me.pnlAddStockValid.Visible = False
        '
        'lblFormFeedback
        '
        Me.lblFormFeedback.AutoSize = True
        Me.lblFormFeedback.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormFeedback.ForeColor = System.Drawing.Color.Red
        Me.lblFormFeedback.Location = New System.Drawing.Point(77, 578)
        Me.lblFormFeedback.Name = "lblFormFeedback"
        Me.lblFormFeedback.Size = New System.Drawing.Size(112, 15)
        Me.lblFormFeedback.TabIndex = 37
        Me.lblFormFeedback.Text = "Form Error Message"
        Me.lblFormFeedback.Visible = False
        '
        'btnAddLocation
        '
        Me.btnAddLocation.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddLocation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddLocation.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddLocation.FlatAppearance.BorderSize = 0
        Me.btnAddLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddLocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLocation.ForeColor = System.Drawing.Color.Blue
        Me.btnAddLocation.Location = New System.Drawing.Point(1092, 160)
        Me.btnAddLocation.Name = "btnAddLocation"
        Me.btnAddLocation.Size = New System.Drawing.Size(134, 34)
        Me.btnAddLocation.TabIndex = 9
        Me.btnAddLocation.Text = "ADD LOCATION"
        Me.btnAddLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddLocation.UseVisualStyleBackColor = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(855, 558)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(162, 53)
        Me.btnConfirm.TabIndex = 10
        Me.btnConfirm.Text = "CONFIRM"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1064, 558)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(162, 53)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pnlAddStock_Input
        '
        Me.pnlAddStock_Input.Controls.Add(Me.cobSupplier)
        Me.pnlAddStock_Input.Controls.Add(Me.btnAddSupplier)
        Me.pnlAddStock_Input.Controls.Add(Me.txtWholesalePrice)
        Me.pnlAddStock_Input.Controls.Add(Me.txtQuantity)
        Me.pnlAddStock_Input.Controls.Add(Me.cobStatus)
        Me.pnlAddStock_Input.Controls.Add(Me.Label6)
        Me.pnlAddStock_Input.Controls.Add(Me.Label5)
        Me.pnlAddStock_Input.Controls.Add(Me.Label4)
        Me.pnlAddStock_Input.Controls.Add(Me.Label3)
        Me.pnlAddStock_Input.Location = New System.Drawing.Point(62, 255)
        Me.pnlAddStock_Input.Name = "pnlAddStock_Input"
        Me.pnlAddStock_Input.Size = New System.Drawing.Size(579, 280)
        Me.pnlAddStock_Input.TabIndex = 3
        '
        'cobSupplier
        '
        Me.cobSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobSupplier.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobSupplier.FormattingEnabled = True
        Me.cobSupplier.IntegralHeight = False
        Me.cobSupplier.Location = New System.Drawing.Point(187, 26)
        Me.cobSupplier.Name = "cobSupplier"
        Me.cobSupplier.Size = New System.Drawing.Size(354, 31)
        Me.cobSupplier.TabIndex = 3
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
        Me.btnAddSupplier.Location = New System.Drawing.Point(413, 56)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(128, 34)
        Me.btnAddSupplier.TabIndex = 4
        Me.btnAddSupplier.Text = "ADD SUPPLIER"
        Me.btnAddSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddSupplier.UseVisualStyleBackColor = False
        '
        'txtWholesalePrice
        '
        Me.txtWholesalePrice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWholesalePrice.Location = New System.Drawing.Point(187, 158)
        Me.txtWholesalePrice.Name = "txtWholesalePrice"
        Me.txtWholesalePrice.Size = New System.Drawing.Size(354, 30)
        Me.txtWholesalePrice.TabIndex = 6
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(187, 92)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(354, 30)
        Me.txtQuantity.TabIndex = 5
        '
        'cobStatus
        '
        Me.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.IntegralHeight = False
        Me.cobStatus.Location = New System.Drawing.Point(187, 225)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(354, 31)
        Me.cobStatus.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 25)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Status"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 25)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Wholesale Price"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 25)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 25)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Supplier"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picLocation
        '
        Me.picLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picLocation.Image = Global.BookManager.My.Resources.Resources.image_not_found
        Me.picLocation.Location = New System.Drawing.Point(746, 200)
        Me.picLocation.Name = "picLocation"
        Me.picLocation.Size = New System.Drawing.Size(480, 314)
        Me.picLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLocation.TabIndex = 25
        Me.picLocation.TabStop = False
        '
        'cobLocation
        '
        Me.cobLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobLocation.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobLocation.FormattingEnabled = True
        Me.cobLocation.IntegralHeight = False
        Me.cobLocation.Location = New System.Drawing.Point(855, 128)
        Me.cobLocation.Name = "cobLocation"
        Me.cobLocation.Size = New System.Drawing.Size(371, 31)
        Me.cobLocation.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(741, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 28)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Location"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnVerifyISBN
        '
        Me.btnVerifyISBN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerifyISBN.Location = New System.Drawing.Point(670, 165)
        Me.btnVerifyISBN.Name = "btnVerifyISBN"
        Me.btnVerifyISBN.Size = New System.Drawing.Size(147, 34)
        Me.btnVerifyISBN.TabIndex = 1
        Me.btnVerifyISBN.Text = "VERIFY ISBN"
        Me.btnVerifyISBN.UseVisualStyleBackColor = True
        '
        'lblFeedback
        '
        Me.lblFeedback.AutoSize = True
        Me.lblFeedback.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeedback.ForeColor = System.Drawing.Color.Red
        Me.lblFeedback.Location = New System.Drawing.Point(290, 205)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(111, 15)
        Me.lblFeedback.TabIndex = 32
        Me.lblFeedback.Text = "Error/Valid Message"
        Me.lblFeedback.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(286, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1176, 2)
        Me.Panel2.TabIndex = 33
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(221, 680)
        Me.Panel1.TabIndex = 34
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel3.Location = New System.Drawing.Point(1507, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(233, 680)
        Me.Panel3.TabIndex = 35
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(570, 165)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(92, 34)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'AddStock
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1740, 680)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblFeedback)
        Me.Controls.Add(Me.btnVerifyISBN)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lblValidMsg)
        Me.Controls.Add(Me.txtISBN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlAddStockValid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddStock"
        Me.Text = " "
        Me.pnlAddStockValid.ResumeLayout(False)
        Me.pnlAddStockValid.PerformLayout()
        Me.pnlAddStock_Input.ResumeLayout(False)
        Me.pnlAddStock_Input.PerformLayout()
        CType(Me.picLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents lblValidMsg As Label
    Friend WithEvents pnlAddStockValid As Panel
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents pnlAddStock_Input As Panel
    Friend WithEvents txtWholesalePrice As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents cobStatus As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents picLocation As PictureBox
    Friend WithEvents cobLocation As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents btnVerifyISBN As Button
    Friend WithEvents lblFeedback As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnAddLocation As Button
    Friend WithEvents cobSupplier As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents lblFormFeedback As Label
End Class
