Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class DialogEditOrder
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataTable As DataTable

    Dim mintSupplierCount As Integer
    Dim intOrderId As Integer
    Dim intStockNo As Integer
    Dim intSupplierId As Integer = 0
    Dim intStatusId As Integer = 1
    Dim decWholesalePrice As Decimal
    Dim dateOrderDate As DateTime

    Public Property propOrderId As Integer
        Get
            Return intOrderId
        End Get
        Set(value As Integer)
            intOrderId = value
            txtOrderId.Text = "O" & intOrderId
        End Set
    End Property

    Public Property propStockNo As Integer
        Get
            Return intStockNo
        End Get
        Set(value As Integer)
            intStockNo = value
            txtStockNo.Text = "C" & intStockNo
        End Set
    End Property

    Public Property propWholesalePrice As Decimal
        Get
            Return FormatNumber(txtWholesalePrice.Text, 2)
        End Get
        Set(value As Decimal)
            decWholesalePrice = value
            txtWholesalePrice.Text = FormatCurrency(decWholesalePrice, 2)
        End Set
    End Property

    Public Property intCobSupplier As Integer
        Get
            Return cobSupplier.SelectedIndex
        End Get
        Set(value As Integer)
            intSupplierId = value
        End Set
    End Property

    Public Property intCobStatus As Integer
        Get
            Return cobStatus.SelectedIndex
        End Get
        Set(value As Integer)
            intStatusId = value
        End Set
    End Property

    ReadOnly Property strCobSupplier As String
        Get
            Return cobSupplier.SelectedItem.ToString
        End Get
    End Property

    Public Property propOrderDate As DateTime
        Get
            Return dtpOrderDate.Value
        End Get
        Set(value As DateTime)
            dateOrderDate = value
            dtpOrderDate.Value = Date.Parse(dateOrderDate.ToShortDateString)
        End Set
    End Property

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Dim dlgAddSupplier As New DialogAddSupplier
        Dim strSupplierList As New List(Of String)

        mintSupplierCount = cobSupplier.Items.Count
        'Pass existing entries in cobSupplier to dlgAddSupplier
        For i As Integer = 0 To cobSupplier.Items.Count - 1
            strSupplierList.Add(cobSupplier.Items(i).ToString())
        Next
        dlgAddSupplier.strSuppliers = strSupplierList

        'Open DialogAddSupplier and get user input
        If dlgAddSupplier.ShowDialog() = DialogResult.OK Then
            'Add the user-defined supplier to cobSupplier
            cobSupplier.Items.Add(dlgAddSupplier.supName)
            cobSupplier.SelectedIndex = cobSupplier.Items.Count - 1
            ' Remove previously added but unused entry
            If cobSupplier.Items.Count > mintSupplierCount + 1 Then
                cobSupplier.Items.RemoveAt(cobSupplier.Items.Count - 2)
            End If
        End If
    End Sub

    Private Sub txtWholesalePrice_Click(sender As Object, e As EventArgs) Handles txtWholesalePrice.Click
        txtWholesalePrice.SelectAll() 'Select all text
    End Sub

    Private Sub txtWholesalePrice_TextChanged(sender As Object, e As EventArgs) Handles txtWholesalePrice.TextChanged
        setFeedback("", False, False)
        txtWholesalePrice.Text = validateNumber(txtWholesalePrice.Text, True, 2) 'Validate numeric input
        txtWholesalePrice.SelectionStart = txtWholesalePrice.Text.Length 'Keep cursor to the right
    End Sub

    Private Sub txtWholesalePrice_Enter(sender As Object, e As EventArgs) Handles txtWholesalePrice.Enter
        txtWholesalePrice.Text = FormatNumber(txtWholesalePrice.Text, 2) 'Convert to decimal number
    End Sub

    Private Sub txtWholesalePrice_Leave(sender As Object, e As EventArgs) Handles txtWholesalePrice.Leave
        'Try block to prevent empty input or invalid inputs caused by dots 
        Try
            txtWholesalePrice.Text = FormatCurrency(txtWholesalePrice.Text, 2)
        Catch
            'If empty or invalid input, reset to default value
            txtWholesalePrice.Text = FormatCurrency(0, 2)
        End Try
    End Sub


    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim decPrice As Decimal = FormatNumber(txtWholesalePrice.Text, 2) 'Get price

        If (decPrice >= 1000) Then
            'If price over 999.99, which is over the maximum char count
            txtWholesalePrice.Focus()
            setFeedback("Wholesale price cannot be greater than " & FormatCurrency(999.99, 2) + "!", True, True)
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogEditOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateComboboxes()
        dtpOrderDate.MinDate = propOrderDate
        dtpOrderDate.MaxDate = New Date(propOrderDate.Year, 12, 31)
    End Sub

    Private Sub setFeedback(message As String, isInvalid As Boolean, isVisible As Boolean)
        'Set label color
        If (isInvalid) Then
            lblVerifyResult.ForeColor = Color.Red
        Else
            lblVerifyResult.ForeColor = Color.Green
        End If

        lblVerifyResult.Text = message
        lblVerifyResult.Visible = isVisible
    End Sub

    Private Function validateText(text As String, maxLength As Integer) As String
        Dim moddedText As String = text

        'Ensure input do not go beyond max length
        If (moddedText.Length >= maxLength) Then
            moddedText = moddedText.Substring(0, maxLength)
        End If

        Return moddedText.Trim() 'Return trimmed String
    End Function


    Private Function validateNumber(text As String, allowDot As Boolean, purgeLetterStart As Integer) As String
        Dim moddedText As String = text

        'Ensure input does not contain letters/special chars
        'If first character is typed
        If (text.Length = 1) Then
            If (Not IsNumeric(text)) Then
                'Set empty text
                moddedText = ""
            End If
        Else
            'If >= 2 characters are typed
            'Ensure letters are not in the string
            Dim pointer As String
            Dim remoddedText As String
            If (text.Length < purgeLetterStart) Then
                remoddedText = moddedText
            Else
                remoddedText = text.Substring(0, purgeLetterStart)
            End If

            If (allowDot) Then
                'Extract all chars excluding letters / special chars but include dots
                For i As Integer = purgeLetterStart To moddedText.Length - 1
                    pointer = moddedText.Substring(i, 1)
                    If (IsNumeric(pointer) Or pointer = ".") Then
                        remoddedText += pointer
                    End If
                Next
            Else
                'Extract all chars excluding letters / special chars
                For i As Integer = purgeLetterStart To moddedText.Length - 1
                    pointer = moddedText.Substring(i, 1)
                    If (IsNumeric(pointer)) Then
                        remoddedText += pointer
                    End If
                Next
            End If
            moddedText = remoddedText
        End If

        Return moddedText.Trim() 'Return trimmed String
    End Function

    Private Sub populateComboboxes()
        connection.Open()
        '   cobSupplier
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT SupplierName FROM Supplier;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobSupplier.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobSupplier.SelectedIndex = intSupplierId - 1
        '   cobStatus
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT StatusDesc FROM OrderStatus;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobStatus.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobStatus.SelectedIndex = intStatusId - 1
        connection.Close()
    End Sub
End Class
