<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogEditBook
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPublisher = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRetailPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtISBN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cobCategory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAddCategory = New System.Windows.Forms.Button()
        Me.picBookCover = New System.Windows.Forms.PictureBox()
        Me.btnBrowseImages = New System.Windows.Forms.Button()
        Me.dtpPublicationDate = New System.Windows.Forms.DateTimePicker()
        Me.lblErrorMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(529, 375)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(235, 51)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(8, 5)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(100, 40)
        Me.btnConfirm.TabIndex = 10
        Me.btnConfirm.Text = "CONFIRM"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(126, 5)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 40)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "CANCEL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(168, 70)
        Me.txtTitle.MaxLength = 150
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(237, 25)
        Me.txtTitle.TabIndex = 2
        '
        'txtAuthor
        '
        Me.txtAuthor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthor.Location = New System.Drawing.Point(168, 115)
        Me.txtAuthor.MaxLength = 100
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(237, 25)
        Me.txtAuthor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Author"
        '
        'txtPublisher
        '
        Me.txtPublisher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPublisher.Location = New System.Drawing.Point(168, 160)
        Me.txtPublisher.MaxLength = 50
        Me.txtPublisher.Name = "txtPublisher"
        Me.txtPublisher.Size = New System.Drawing.Size(237, 25)
        Me.txtPublisher.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Publisher"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Publication Date"
        '
        'txtRetailPrice
        '
        Me.txtRetailPrice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailPrice.Location = New System.Drawing.Point(168, 250)
        Me.txtRetailPrice.Name = "txtRetailPrice"
        Me.txtRetailPrice.Size = New System.Drawing.Size(237, 25)
        Me.txtRetailPrice.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Retail Price"
        '
        'txtISBN
        '
        Me.txtISBN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtISBN.Location = New System.Drawing.Point(168, 25)
        Me.txtISBN.MaxLength = 13
        Me.txtISBN.Name = "txtISBN"
        Me.txtISBN.Size = New System.Drawing.Size(237, 25)
        Me.txtISBN.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ISBN Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 297)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Category"
        '
        'cobCategory
        '
        Me.cobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobCategory.FormattingEnabled = True
        Me.cobCategory.IntegralHeight = False
        Me.cobCategory.Location = New System.Drawing.Point(168, 297)
        Me.cobCategory.Name = "cobCategory"
        Me.cobCategory.Size = New System.Drawing.Size(237, 25)
        Me.cobCategory.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(494, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Book Picture"
        '
        'btnAddCategory
        '
        Me.btnAddCategory.BackColor = System.Drawing.SystemColors.Control
        Me.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddCategory.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddCategory.FlatAppearance.BorderSize = 0
        Me.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddCategory.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCategory.ForeColor = System.Drawing.Color.Blue
        Me.btnAddCategory.Location = New System.Drawing.Point(273, 325)
        Me.btnAddCategory.Name = "btnAddCategory"
        Me.btnAddCategory.Size = New System.Drawing.Size(132, 24)
        Me.btnAddCategory.TabIndex = 8
        Me.btnAddCategory.Text = "ADD CATEGORY"
        Me.btnAddCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddCategory.UseVisualStyleBackColor = False
        '
        'picBookCover
        '
        Me.picBookCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picBookCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picBookCover.Image = Global.BookManager.My.Resources.Resources.image_not_found
        Me.picBookCover.Location = New System.Drawing.Point(497, 68)
        Me.picBookCover.Name = "picBookCover"
        Me.picBookCover.Size = New System.Drawing.Size(258, 252)
        Me.picBookCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBookCover.TabIndex = 16
        Me.picBookCover.TabStop = False
        '
        'btnBrowseImages
        '
        Me.btnBrowseImages.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseImages.Location = New System.Drawing.Point(592, 24)
        Me.btnBrowseImages.Name = "btnBrowseImages"
        Me.btnBrowseImages.Size = New System.Drawing.Size(166, 26)
        Me.btnBrowseImages.TabIndex = 9
        Me.btnBrowseImages.Text = "Browse..."
        Me.btnBrowseImages.UseVisualStyleBackColor = True
        '
        'dtpPublicationDate
        '
        Me.dtpPublicationDate.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPublicationDate.Location = New System.Drawing.Point(168, 205)
        Me.dtpPublicationDate.Name = "dtpPublicationDate"
        Me.dtpPublicationDate.Size = New System.Drawing.Size(237, 22)
        Me.dtpPublicationDate.TabIndex = 5
        '
        'lblErrorMessage
        '
        Me.lblErrorMessage.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorMessage.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMessage.Location = New System.Drawing.Point(40, 375)
        Me.lblErrorMessage.Name = "lblErrorMessage"
        Me.lblErrorMessage.Size = New System.Drawing.Size(365, 45)
        Me.lblErrorMessage.TabIndex = 17
        '
        'DialogEditBook
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(807, 443)
        Me.Controls.Add(Me.lblErrorMessage)
        Me.Controls.Add(Me.dtpPublicationDate)
        Me.Controls.Add(Me.btnBrowseImages)
        Me.Controls.Add(Me.btnAddCategory)
        Me.Controls.Add(Me.picBookCover)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cobCategory)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtISBN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRetailPrice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPublisher)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogEditBook"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Book Details"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.picBookCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPublisher As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRetailPrice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtISBN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents picBookCover As PictureBox
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents btnBrowseImages As Button
    Friend WithEvents dtpPublicationDate As DateTimePicker
    Friend WithEvents cobCategory As ComboBox
    Friend WithEvents lblErrorMessage As Label
End Class
