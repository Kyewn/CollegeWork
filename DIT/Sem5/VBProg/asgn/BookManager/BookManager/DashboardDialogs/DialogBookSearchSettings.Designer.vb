<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBookSearchSettings
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
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkRetailPrice = New System.Windows.Forms.CheckBox()
        Me.chkPublicationDate = New System.Windows.Forms.CheckBox()
        Me.chkPublisher = New System.Windows.Forms.CheckBox()
        Me.chkAuthor = New System.Windows.Forms.CheckBox()
        Me.chkTitle = New System.Windows.Forms.CheckBox()
        Me.chkISBN = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cobStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cobCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnReset, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnApply, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(443, 214)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(215, 36)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(9, 4)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(89, 28)
        Me.btnReset.TabIndex = 10
        Me.btnReset.Text = "RESET"
        '
        'btnApply
        '
        Me.btnApply.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnApply.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.Location = New System.Drawing.Point(116, 4)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(89, 28)
        Me.btnApply.TabIndex = 11
        Me.btnApply.Text = "APPLY"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkRetailPrice)
        Me.Panel1.Controls.Add(Me.chkPublicationDate)
        Me.Panel1.Controls.Add(Me.chkPublisher)
        Me.Panel1.Controls.Add(Me.chkAuthor)
        Me.Panel1.Controls.Add(Me.chkTitle)
        Me.Panel1.Controls.Add(Me.chkISBN)
        Me.Panel1.Controls.Add(Me.chkAll)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(30, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 150)
        Me.Panel1.TabIndex = 1
        '
        'chkRetailPrice
        '
        Me.chkRetailPrice.AutoSize = True
        Me.chkRetailPrice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRetailPrice.Location = New System.Drawing.Point(150, 93)
        Me.chkRetailPrice.Name = "chkRetailPrice"
        Me.chkRetailPrice.Size = New System.Drawing.Size(105, 21)
        Me.chkRetailPrice.TabIndex = 7
        Me.chkRetailPrice.Text = "Retail Price"
        Me.chkRetailPrice.UseVisualStyleBackColor = True
        '
        'chkPublicationDate
        '
        Me.chkPublicationDate.AutoSize = True
        Me.chkPublicationDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPublicationDate.Location = New System.Drawing.Point(150, 66)
        Me.chkPublicationDate.Name = "chkPublicationDate"
        Me.chkPublicationDate.Size = New System.Drawing.Size(136, 21)
        Me.chkPublicationDate.TabIndex = 6
        Me.chkPublicationDate.Text = "Publication Date"
        Me.chkPublicationDate.UseVisualStyleBackColor = True
        '
        'chkPublisher
        '
        Me.chkPublisher.AutoSize = True
        Me.chkPublisher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPublisher.Location = New System.Drawing.Point(150, 39)
        Me.chkPublisher.Name = "chkPublisher"
        Me.chkPublisher.Size = New System.Drawing.Size(91, 21)
        Me.chkPublisher.TabIndex = 5
        Me.chkPublisher.Text = "Publisher"
        Me.chkPublisher.UseVisualStyleBackColor = True
        '
        'chkAuthor
        '
        Me.chkAuthor.AutoSize = True
        Me.chkAuthor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAuthor.Location = New System.Drawing.Point(7, 120)
        Me.chkAuthor.Name = "chkAuthor"
        Me.chkAuthor.Size = New System.Drawing.Size(72, 21)
        Me.chkAuthor.TabIndex = 4
        Me.chkAuthor.Text = "Author"
        Me.chkAuthor.UseVisualStyleBackColor = True
        '
        'chkTitle
        '
        Me.chkTitle.AutoSize = True
        Me.chkTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTitle.Location = New System.Drawing.Point(7, 93)
        Me.chkTitle.Name = "chkTitle"
        Me.chkTitle.Size = New System.Drawing.Size(56, 21)
        Me.chkTitle.TabIndex = 3
        Me.chkTitle.Text = "Title"
        Me.chkTitle.UseVisualStyleBackColor = True
        '
        'chkISBN
        '
        Me.chkISBN.AutoSize = True
        Me.chkISBN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkISBN.Location = New System.Drawing.Point(7, 66)
        Me.chkISBN.Name = "chkISBN"
        Me.chkISBN.Size = New System.Drawing.Size(119, 21)
        Me.chkISBN.TabIndex = 2
        Me.chkISBN.Text = "ISBN Number"
        Me.chkISBN.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(7, 39)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(45, 21)
        Me.chkAll.TabIndex = 1
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search by:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cobStatus)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cobCategory)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(350, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(300, 150)
        Me.Panel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Status"
        '
        'cobStatus
        '
        Me.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.IntegralHeight = False
        Me.cobStatus.Location = New System.Drawing.Point(93, 89)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(204, 25)
        Me.cobStatus.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Category"
        '
        'cobCategory
        '
        Me.cobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobCategory.FormattingEnabled = True
        Me.cobCategory.IntegralHeight = False
        Me.cobCategory.ItemHeight = 17
        Me.cobCategory.Location = New System.Drawing.Point(93, 36)
        Me.cobCategory.Name = "cobCategory"
        Me.cobCategory.Size = New System.Drawing.Size(204, 25)
        Me.cobCategory.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Filters:"
        '
        'DialogBookSearchSettings
        '
        Me.AcceptButton = Me.btnReset
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnApply
        Me.ClientSize = New System.Drawing.Size(682, 263)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBookSearchSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Advanced Search Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkRetailPrice As CheckBox
    Friend WithEvents chkPublicationDate As CheckBox
    Friend WithEvents chkPublisher As CheckBox
    Friend WithEvents chkAuthor As CheckBox
    Friend WithEvents chkTitle As CheckBox
    Friend WithEvents chkISBN As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents cobCategory As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cobStatus As ComboBox
End Class
