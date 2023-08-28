Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DialogOrderSearchSettings
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim dataAdapter As SqlDataAdapter
    Dim dataTable As DataTable
    Dim intSelectedSupplier As Integer
    Dim intSelectedStatus As Integer

    Public Property boolChkAll As Boolean
        Get
            Return chkAll.Checked
        End Get
        Set(value As Boolean)
            chkAll.Checked = value
        End Set
    End Property

    Public Property boolChkOrderId As Boolean
        Get
            Return chkOrderId.Checked
        End Get
        Set(value As Boolean)
            chkOrderId.Checked = value
        End Set
    End Property

    Public Property boolChkStockNumber As Boolean
        Get
            Return chkStockNumber.Checked
        End Get
        Set(value As Boolean)
            chkStockNumber.Checked = value
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

    Public Property boolChkWholesalePrice As Boolean
        Get
            Return chkWholesalePrice.Checked
        End Get
        Set(value As Boolean)
            chkWholesalePrice.Checked = value
        End Set
    End Property

    Public Property boolChkOrderDate As Boolean
        Get
            Return chkOrderDate.Checked
        End Get
        Set(value As Boolean)
            chkOrderDate.Checked = value
        End Set
    End Property

    Public Property boolChkIsbn As Boolean
        Get
            Return chkIsbn.Checked
        End Get
        Set(value As Boolean)
            chkIsbn.Checked = value
        End Set
    End Property

    Public Property strCobSupplier As String
        Get
            Return cobSupplier.SelectedItem.ToString
        End Get
        Set(value As String)
            cobSupplier.SelectedItem = value
        End Set
    End Property

    Public Property selectedSupplier As Integer
        Get
            Return intSelectedSupplier
        End Get
        Set(value As Integer)
            intSelectedSupplier = value
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

    Public Property selectedStatus As Integer
        Get
            Return intSelectedStatus
        End Get
        Set(value As Integer)
            intSelectedStatus = value
        End Set
    End Property

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked Then
            ' Set all checkboxes to True
            chkOrderId.Checked = True
            chkStockNumber.Checked = True
            chkTitle.Checked = True
            chkWholesalePrice.Checked = True
            chkOrderDate.Checked = True
            chkIsbn.Checked = True
            ' Disable other checkboxes to avoid messing up settings
            chkOrderId.Enabled = False
            chkStockNumber.Enabled = False
            chkTitle.Enabled = False
            chkWholesalePrice.Enabled = False
            chkOrderDate.Enabled = False
            chkIsbn.Enabled = False
        Else
            ' Set all checkboxes to False
            chkOrderId.Checked = False
            chkStockNumber.Checked = False
            chkTitle.Checked = False
            chkWholesalePrice.Checked = False
            chkOrderDate.Checked = False
            chkIsbn.Checked = False
            ' Enable other checkboxes
            chkOrderId.Enabled = True
            chkStockNumber.Enabled = True
            chkTitle.Enabled = True
            chkWholesalePrice.Enabled = True
            chkOrderDate.Enabled = True
            chkIsbn.Enabled = True
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Clear checkboxes and dropdown lists
        chkAll.Checked = True
        cobSupplier.SelectedIndex = 0
        cobStatus.SelectedIndex = 0
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ' Do nothing and hide dialog
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cobStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobStatus.SelectedIndexChanged
        intSelectedStatus = cobStatus.SelectedIndex
    End Sub

    Private Sub cobSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobSupplier.SelectedIndexChanged
        intSelectedSupplier = cobSupplier.SelectedIndex
    End Sub

    Private Sub DialogOrderSearchSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateComboBoxes()
    End Sub

    Private Sub populateComboBoxes()
        cobSupplier.Items.Clear()
        cobStatus.Items.Clear()
        cobSupplier.Items.Clear()
        '   cobSupplier
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT SupplierName FROM Supplier;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        cobSupplier.Items.Add("-") ' Default value
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobSupplier.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobSupplier.SelectedIndex = intSelectedSupplier
        '   cobStatus
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT StatusDesc FROM OrderStatus;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        cobStatus.Items.Add("-") ' Default value
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobStatus.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobStatus.SelectedIndex = intSelectedStatus
    End Sub

    Public Sub clickApply(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnApply_Click(sender, e)
    End Sub
End Class
