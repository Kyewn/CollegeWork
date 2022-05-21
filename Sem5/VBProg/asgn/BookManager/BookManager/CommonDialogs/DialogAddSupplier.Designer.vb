<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogAddSupplier
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
        Me.lblSupName = New System.Windows.Forms.Label()
        Me.txtSupName = New System.Windows.Forms.TextBox()
        Me.lblErrorMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSupName
        '
        Me.lblSupName.AutoSize = True
        Me.lblSupName.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupName.Location = New System.Drawing.Point(24, 29)
        Me.lblSupName.Name = "lblSupName"
        Me.lblSupName.Size = New System.Drawing.Size(168, 23)
        Me.lblSupName.TabIndex = 3
        Me.lblSupName.Text = "Enter Supplier Name"
        '
        'txtSupName
        '
        Me.txtSupName.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupName.Location = New System.Drawing.Point(28, 55)
        Me.txtSupName.Name = "txtSupName"
        Me.txtSupName.Size = New System.Drawing.Size(376, 30)
        Me.txtSupName.TabIndex = 4
        '
        'lblErrorMessage
        '
        Me.lblErrorMessage.AutoSize = True
        Me.lblErrorMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblErrorMessage.Location = New System.Drawing.Point(29, 97)
        Me.lblErrorMessage.Name = "lblErrorMessage"
        Me.lblErrorMessage.Size = New System.Drawing.Size(221, 17)
        Me.lblErrorMessage.TabIndex = 5
        Me.lblErrorMessage.Text = "Reminder: Input cannot be empty."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConfirm, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(185, 118)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(233, 55)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(130, 7)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(89, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CANCEL"
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnConfirm.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(13, 7)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(89, 40)
        Me.btnConfirm.TabIndex = 0
        Me.btnConfirm.Text = "CONFIRM"
        '
        'DialogAddSupplier
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(432, 183)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblErrorMessage)
        Me.Controls.Add(Me.txtSupName)
        Me.Controls.Add(Me.lblSupName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogAddSupplier"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Supplier"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSupName As Label
    Friend WithEvents txtSupName As TextBox
    Friend WithEvents lblErrorMessage As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnConfirm As Button
End Class
