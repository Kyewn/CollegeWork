Imports System.Windows.Forms

Public Class DialogAddLocation
    Public Property locName As String
        Get
            Return txtLocation.Text.Trim()
        End Get
        Set(value As String)
            txtLocation.Text = value
        End Set
    End Property

    Public Property locPic As Image
        Get
            Return picLocation.Image
        End Get
        Set(value As Image)
            picLocation.Image = value
        End Set
    End Property

    Public Property strLocations As List(Of String)
        Get
            Return mstrLocationList
        End Get
        Set(value As List(Of String))
            mstrLocationList = value
        End Set
    End Property

    ' Variables
    Dim mstrLocationList As New List(Of String)

    Private Sub txtLocation_TextChanged(sender As Object, e As EventArgs) Handles txtLocation.TextChanged
        'Prevents any leading whitespace
        txtLocation.Text = txtLocation.Text.TrimStart()
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim moddedTxtLocation As String = txtLocation.Text.Trim().ToUpper()

        'Invalid input. Empty input
        If (moddedTxtLocation = "") Then
            lblErrorMessage.ForeColor = Color.Red
            lblErrorMessage.Text = "Input field cannot be empty!"
            lblErrorMessage.Visible = True
            txtLocation.Focus()
        Else
            ' Check if Location already exist in main page's combobox
            Dim isExistInCob As Boolean = False
            For i As Integer = 1 To mstrLocationList.Count - 1
                If (mstrLocationList(i).ToUpper() = moddedTxtLocation) Then
                    isExistInCob = True
                End If
            Next

            If (isExistInCob) Then
                'Invalid input. Record already exists
                lblErrorMessage.ForeColor = Color.Red
                lblErrorMessage.Text = "This location already exists, please try again."
                lblErrorMessage.Visible = True
                txtLocation.Focus()
            Else
                'No errors, return DialogResult.OK and close window
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBrowseLocation_Click(sender As Object, e As EventArgs) Handles btnBrowseLocation.Click
        Dim dlgOpenFile As New OpenFileDialog

        If dlgOpenFile.ShowDialog() = DialogResult.OK Then
            'Ensure selected file is an image, then load it
            Try
                picLocation.Image = Image.FromFile(dlgOpenFile.FileName)
            Catch ex As Exception
                MessageBox.Show("You must select an image file", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
