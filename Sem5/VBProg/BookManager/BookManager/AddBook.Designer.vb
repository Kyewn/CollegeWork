<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddBook
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblValidMsg = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPublisher = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRetailPrice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cobCategory = New System.Windows.Forms.ComboBox()
        Me.btnAddCategory = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBrowseImages = New System.Windows.Forms.Button()
        Me.picBookCover = New System.Windows.Forms.PictureBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.datePicker = New System.Windows.Forms.DateTimePicker()
        Me.lblErrorMessage = New System.Windows.Forms.Label()
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel3.Location = New System.Drawing.Point(1519, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(221, 680)
        Me.Panel3.TabIndex = 45
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Location = New System.Drawing.Point(286, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1176, 2)
        Me.Panel2.TabIndex = 43
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(221, 680)
        Me.Panel1.TabIndex = 44
        '
        'lblValidMsg
        '
        Me.lblValidMsg.AutoSize = True
        Me.lblValidMsg.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblValidMsg.Location = New System.Drawing.Point(42, 232)
        Me.lblValidMsg.Name = "lblValidMsg"
        Me.lblValidMsg.Size = New System.Drawing.Size(0, 15)
        Me.lblValidMsg.TabIndex = 39
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(463, 131)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(400, 30)
        Me.txtTitle.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 28)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Title"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(291, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 38)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Enter Book Details"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAuthor
        '
        Me.txtAuthor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthor.Location = New System.Drawing.Point(463, 183)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(400, 30)
        Me.txtAuthor.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(291, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 28)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Author"
        '
        'txtPublisher
        '
        Me.txtPublisher.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPublisher.Location = New System.Drawing.Point(463, 235)
        Me.txtPublisher.Name = "txtPublisher"
        Me.txtPublisher.Size = New System.Drawing.Size(400, 30)
        Me.txtPublisher.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 28)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Publisher"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(291, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 28)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Publication Date"
        '
        'txtISBN
        '
        Me.txtISBN.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtISBN.Location = New System.Drawing.Point(463, 339)
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(400, 30)
        Me.txtISBN.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 340)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 28)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "ISBN Number"
        '
        'txtRetailPrice
        '
        Me.txtRetailPrice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailPrice.Location = New System.Drawing.Point(463, 391)
        Me.txtRetailPrice.Name = "txtRetailPrice"
        Me.txtRetailPrice.Size = New System.Drawing.Size(400, 30)
        Me.txtRetailPrice.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(291, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 28)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Retail Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(291, 444)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 28)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Category"
        '
        'cobCategory
        '
        Me.cobCategory.AllowDrop = True
        Me.cobCategory.DropDownHeight = 200
        Me.cobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobCategory.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobCategory.FormattingEnabled = True
        Me.cobCategory.IntegralHeight = False
        Me.cobCategory.Location = New System.Drawing.Point(463, 443)
        Me.cobCategory.Name = "cobCategory"
        Me.cobCategory.Size = New System.Drawing.Size(400, 31)
        Me.cobCategory.TabIndex = 7
        '
        'btnAddCategory
        '
        Me.btnAddCategory.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddCategory.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddCategory.FlatAppearance.BorderSize = 0
        Me.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCategory.ForeColor = System.Drawing.Color.Blue
        Me.btnAddCategory.Location = New System.Drawing.Point(721, 479)
        Me.btnAddCategory.Name = "btnAddCategory"
        Me.btnAddCategory.Size = New System.Drawing.Size(142, 34)
        Me.btnAddCategory.TabIndex = 8
        Me.btnAddCategory.Text = "ADD CATEGORY"
        Me.btnAddCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddCategory.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(965, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 28)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Book Picture"
        '
        'btnBrowseImages
        '
        Me.btnBrowseImages.Location = New System.Drawing.Point(1130, 128)
        Me.btnBrowseImages.Name = "btnBrowseImages"
        Me.btnBrowseImages.Size = New System.Drawing.Size(320, 30)
        Me.btnBrowseImages.TabIndex = 9
        Me.btnBrowseImages.Text = "Browse..."
        Me.btnBrowseImages.UseVisualStyleBackColor = True
        '
        'picBookCover
        '
        Me.picBookCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBookCover.Image = Global.BookManager.My.Resources.Resources.image_not_found
        Me.picBookCover.Location = New System.Drawing.Point(970, 183)
        Me.picBookCover.Name = "picBookCover"
        Me.picBookCover.Size = New System.Drawing.Size(480, 311)
        Me.picBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBookCover.TabIndex = 61
        Me.picBookCover.TabStop = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(1080, 558)
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
        Me.btnCancel.Location = New System.Drawing.Point(1288, 558)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(162, 53)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'datePicker
        '
        Me.datePicker.CalendarFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datePicker.Location = New System.Drawing.Point(463, 293)
        Me.datePicker.Name = "datePicker"
        Me.datePicker.Size = New System.Drawing.Size(400, 22)
        Me.datePicker.TabIndex = 4
        '
        'lblErrorMessage
        '
        Me.lblErrorMessage.AutoSize = True
        Me.lblErrorMessage.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMessage.Location = New System.Drawing.Point(293, 577)
        Me.lblErrorMessage.Name = "lblErrorMessage"
        Me.lblErrorMessage.Size = New System.Drawing.Size(101, 17)
        Me.lblErrorMessage.TabIndex = 63
        Me.lblErrorMessage.Text = "Error Message"
        Me.lblErrorMessage.Visible = False
        '
        'AddBook
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1740, 680)
        Me.Controls.Add(Me.lblErrorMessage)
        Me.Controls.Add(Me.datePicker)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.picBookCover)
        Me.Controls.Add(Me.btnBrowseImages)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnAddCategory)
        Me.Controls.Add(Me.cobCategory)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtRetailPrice)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtISBN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPublisher)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblValidMsg)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddBook"
        Me.Text = "AddBook"
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblValidMsg As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPublisher As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtRetailPrice As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cobCategory As ComboBox
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents btnBrowseImages As Button
    Friend WithEvents picBookCover As PictureBox
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents datePicker As DateTimePicker
    Friend WithEvents lblErrorMessage As Label
End Class
