Imports System.Windows.Forms

Public Class DialogAddSupplier
    Public Property supName As String
        Get
            Return txtSupName.Text.Trim()
        End Get
        Set(value As String)
            txtSupName.Text = value
        End Set
    End Property

    Public Property strSuppliers As List(Of String)
        Get
            Return mstrSupplierList
        End Get
        Set(value As List(Of String))
            mstrSupplierList = value
        End Set
    End Property

    ' Variables
    Dim mstrSupplierList As New List(Of String)

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        txtSupName.Text = txtSupName.Text.TrimStart()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim moddedTxtSupName As String = txtSupName.Text.Trim().ToUpper()

        'Invalid input. Empty input
        If (moddedTxtSupName = "") Then
            lblErrorMessage.ForeColor = Color.Red
            lblErrorMessage.Text = "Input field cannot be empty!"
            lblErrorMessage.Visible = True
            txtSupName.Focus()
        Else
            ' Check if Supplier already exist in main page's combobox (contains both db and user input records)
            Dim isExistInCob As Boolean = False
            For i As Integer = 1 To mstrSupplierList.Count - 1
                If (mstrSupplierList(i).ToUpper() = moddedTxtSupName) Then
                    isExistInCob = True
                End If
            Next

            If (isExistInCob) Then
                'Invalid input. Record already exists
                lblErrorMessage.ForeColor = Color.Red
                lblErrorMessage.Text = "This supplier already exists, please try again."
                lblErrorMessage.Visible = True
                txtSupName.Focus()
            Else
                'No errors, return DialogResult.OK and close window
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
