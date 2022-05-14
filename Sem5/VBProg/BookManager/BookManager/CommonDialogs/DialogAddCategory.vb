Imports System.Windows.Forms

Public Class DialogAddCategory
    Public Property categoryName As String
        Get
            Return txtCategory.Text.Trim()
        End Get
        Set(value As String)
            txtCategory.Text = value
        End Set
    End Property

    Public Property strCategories As List(Of String)
        Get
            Return mstrCategoryList
        End Get
        Set(value As List(Of String))
            mstrCategoryList = value
        End Set
    End Property

    ' Variables
    Dim mstrCategoryList As New List(Of String)

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        If String.IsNullOrEmpty(txtCategory.Text) Then
            lblErrorMessage.ForeColor = Color.Red
            lblErrorMessage.Text = "Input field cannot be empty!"
            lblErrorMessage.Visible = True
            txtCategory.Focus()
        Else
            Dim choiceCategoryUpper As String
            Dim txtCategoryUpper As String = txtCategory.Text.Trim().ToUpper()
            Dim isExistInCob As Boolean = False

            'Check whether the user input category is already in combobox or not
            'Combo box already include db + previous user input records
            For i As Integer = 0 To mstrCategoryList.Count - 1
                choiceCategoryUpper = mstrCategoryList(i).Trim().ToUpper()
                If (choiceCategoryUpper = txtCategoryUpper) Then
                    lblErrorMessage.ForeColor = Color.Red
                    lblErrorMessage.Text = "This category already exists, please try again."
                    lblErrorMessage.Visible = True
                    txtCategory.Focus()
                    isExistInCob = True 'Set the flag to true if exist
                End If
            Next

            'Only return to main form with "OK" status if the flag is false
            If (isExistInCob = False) Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtCategory_TextChanged(sender As Object, e As EventArgs) Handles txtCategory.TextChanged
        txtCategory.Text = txtCategory.Text.TrimStart
    End Sub
End Class
