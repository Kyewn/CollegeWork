Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class DialogBookSearchSettings

    Public Property boolChkAll As Boolean
        Get
            Return chkAll.Checked
        End Get
        Set(value As Boolean)
            chkAll.Checked = value
        End Set
    End Property
    Public Property boolChkIsbn As Boolean
        Get
            Return chkISBN.Checked
        End Get
        Set(value As Boolean)
            chkISBN.Checked = value
        End Set
    End Property
    Public Property boolChkTitle As Boolean
        Get
            Return chkTitle.Checked
        End Get
        Set(value As Boolean)
            chkTitle.Checked = value
        End Set
    End Property
    Public Property boolChkAuthor As Boolean
        Get
            Return chkAuthor.Checked
        End Get
        Set(value As Boolean)
            chkAuthor.Checked = value
        End Set
    End Property
    Public Property boolChkPublisher As Boolean
        Get
            Return chkPublisher.Checked
        End Get
        Set(value As Boolean)
            chkPublisher.Checked = value
        End Set
    End Property
    Public Property boolChkPublicationDate As Boolean
        Get
            Return chkPublicationDate.Checked
        End Get
        Set(value As Boolean)
            chkPublicationDate.Checked = value
        End Set
    End Property
    Public Property boolChkRetailPrice As Boolean
        Get
            Return chkRetailPrice.Checked
        End Get
        Set(value As Boolean)
            chkRetailPrice.Checked = value
        End Set
    End Property
    Public Property strCobCategory As String
        Get
            Return cobCategory.SelectedItem.ToString
        End Get
        Set(value As String)
            cobCategory.SelectedItem = value
        End Set
    End Property
    Public Property strCobStatus As String
        Get
            Return cobStatus.SelectedItem.ToString
        End Get
        Set(value As String)
            cobStatus.SelectedItem = value
        End Set
    End Property
    Public Property selectedCategory As Integer
        Get
            Return intSelectedCategory
        End Get
        Set(value As Integer)
            intSelectedCategory = value
        End Set
    End Property
    Public Property selectedStatus As Integer
        Get
            Return intSelectedStatus
        End Get
        Set(value As Integer)
            intSelectedStatus = value
        End Set
    End Property

    ' SQL Server variables
    Dim sql1, sql2 As String
    Dim cmd1, cmd2 As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim conn As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    ' Current selected combo box items (need to be stored in variable as combo boxes reset on each load)
    Dim intSelectedCategory As Integer
    Dim intSelectedStatus As Integer

    Private Sub DialogBookSearchSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.Open()

        ' Set query and create SQL command
        sql1 = "SELECT * FROM Category;"
        sql2 = "SELECT * FROM BookStatus;"
        cmd1 = New SqlCommand(sql1, conn)
        cmd2 = New SqlCommand(sql2, conn)
        ' Retrieve data from DB
        adapter = New SqlDataAdapter(cmd1)
        Dim dataSet As New DataSet()
        adapter.Fill(dataSet, "Category")
        adapter = New SqlDataAdapter(cmd2)
        adapter.Fill(dataSet, "BookStatus")
        Dim rows0 As Integer = dataSet.Tables(0).Rows.Count ' CATEGORY
        Dim rows1 As Integer = dataSet.Tables(1).Rows.Count ' BOOKSTATUS

        ' Clear previous entries from combo boxes
        cobCategory.Items.Clear()
        cobStatus.Items.Clear()
        ' Load categories and statuses into respective combo box
        cobCategory.Items.Add("-")
        If rows0 > 0 Then
            For i As Integer = 0 To rows0 - 1
                cobCategory.Items.Add(dataSet.Tables(0).Rows(i)("CategoryName"))
            Next
            cobCategory.SelectedIndex = intSelectedCategory
        End If
        cobStatus.Items.Add("-")
        If rows1 > 0 Then
            For i As Integer = 0 To rows1 - 1
                cobStatus.Items.Add(dataSet.Tables(1).Rows(i)("StatusDesc"))
            Next
            cobStatus.SelectedIndex = intSelectedStatus
        End If

        conn.Close()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked Then
            ' Set all checkboxes to True
            chkISBN.Checked = True
            chkTitle.Checked = True
            chkAuthor.Checked = True
            chkPublisher.Checked = True
            chkPublicationDate.Checked = True
            chkRetailPrice.Checked = True
            ' Disable other checkboxes to avoid messing up settings
            chkISBN.Enabled = False
            chkTitle.Enabled = False
            chkAuthor.Enabled = False
            chkPublisher.Enabled = False
            chkPublicationDate.Enabled = False
            chkRetailPrice.Enabled = False
        Else
            ' Set all checkboxes to False
            chkISBN.Checked = False
            chkTitle.Checked = False
            chkAuthor.Checked = False
            chkPublisher.Checked = False
            chkPublicationDate.Checked = False
            chkRetailPrice.Checked = False
            ' Enable other checkboxes
            chkISBN.Enabled = True
            chkTitle.Enabled = True
            chkAuthor.Enabled = True
            chkPublisher.Enabled = True
            chkPublicationDate.Enabled = True
            chkRetailPrice.Enabled = True
        End If
    End Sub

    Private Sub cobCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobCategory.SelectedIndexChanged
        ' Store selected index in variable
        intSelectedCategory = cobCategory.SelectedIndex
    End Sub

    Private Sub cobStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobStatus.SelectedIndexChanged
        ' Store selected index in variable
        intSelectedStatus = cobStatus.SelectedIndex
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Reset checkboxes and dropdown lists
        chkAll.Checked = True
        cobCategory.SelectedIndex = 0
        cobStatus.SelectedIndex = 0
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ' Do nothing and close dialog
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Public Sub clickApply(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnApply_Click(sender, e)
    End Sub
End Class
