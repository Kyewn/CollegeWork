Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class DialogEditStock
    'Change Server & DB name in connection string
    Dim connection As New SqlConnection("Server=DESKTOP-2TPV8RK\SQLEXPRESS;Database=BookManager;Trusted_Connection=True")
    Dim query As String
    Dim sqlCommand As SqlCommand
    Dim dataAdapter As SqlDataAdapter
    Dim dataTable As DataTable
    Dim ms As MemoryStream
    Dim arrImage() As Byte
    Dim mArrCustomLocImg As ArrayList
    Dim mIntSupplierId As Integer
    Dim mIntStatusid As Integer
    Dim mIntLocationid As Integer
    Dim mIntResult As Integer
    Public Property intResult As Integer
        Get
            Return mIntResult
        End Get
        Set(value As Integer)
            mIntResult = value
        End Set
    End Property

    Public Property strStockNo As String
        Get
            Return txtStockNumber.Text
        End Get
        Set(value As String)
            txtStockNumber.Text = value
        End Set
    End Property

    Public Property decWholesalePrice As Decimal
        Get
            Return FormatNumber(txtStockNumber.Text, 2)
        End Get
        Set(value As Decimal)
            txtWholesalePrice.Text = FormatCurrency(value, 2)
        End Set
    End Property

    Public Property intSupplierId As Integer
        Get
            Return cobSupplier.SelectedIndex
        End Get
        Set(value As Integer)
            mIntSupplierId = value
        End Set
    End Property

    Public Property intStatusId As Integer
        Get
            If (cobStatus.SelectedIndex = 2) Then
                Return 5
            Else
                Return cobStatus.SelectedIndex + 1
            End If
        End Get
        Set(value As Integer)
            If (value = 3 Or value = 4) Then
                mIntStatusid = 0
            Else
                If (value = 5) Then
                    mIntStatusid = 2
                Else
                    mIntStatusid = value - 1
                End If
            End If
        End Set
    End Property

    Public Property intLocationId As Integer
        Get
            Return cobLocation.SelectedIndex
        End Get
        Set(value As Integer)
            mIntLocationid = value
        End Set
    End Property

    Public Property byteLocationPicture As Byte()
        Get
            Dim converter As New ImageConverter
            Return converter.ConvertTo(picLocation, GetType(Byte()))
        End Get
        Set(value As Byte())
            ms = New MemoryStream(value)
            picLocation.Image = Image.FromStream(ms)
        End Set
    End Property

    ' Variables
    Dim mintSupplierCount As Integer
    Dim mintLocationCount As Integer

    Private Sub DialogEditStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Populate combo boxes
        populateComboBoxes()
        mArrCustomLocImg = New ArrayList 'Reinstantiate array for storing custom location images
        ' Get current number of suppliers and locations
        mintSupplierCount = cobSupplier.Items.Count
        mintLocationCount = cobLocation.Items.Count
    End Sub

    Private Sub cobSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobSupplier.SelectedIndexChanged
        'Clear feedback message
        setFormFeedback("", False, False)
    End Sub

    Private Sub cobLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cobLocation.SelectedIndexChanged
        Dim selectIndexToId As Integer = cobLocation.SelectedIndex + 1
        'Get location image according to selection from DB -
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT * FROM StockLocation;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        Dim customImgStartIndex As Integer = dataTable.Rows.Count 'Immediately afer DB records

        If (cobLocation.SelectedIndex < customImgStartIndex) Then
            'If selected item is existing location in DB
            'SelectedIndex = 0 ~ no. of rows in database
            dataTable = New DataTable 'Reinstantiate dataTable
            query = "SELECT * FROM StockLocation WHERE LocationId = @locationId;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@locationId", SqlDbType.Int)).Value = selectIndexToId
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dataTable)
            'Choose image directly from DB if record exists in DB
            arrImage = dataTable.Rows(0)(2)
            ms = New MemoryStream(arrImage)
            picLocation.Image = Image.FromStream(ms)
        Else
            'If selected item is custom location
            'SelectedIndex = no.of rows in database + 1 ~ cobLocation.Items.Count - 1 / startIndex + customImgCount
            Dim customImgCount As Integer = cobLocation.Items.Count - dataTable.Rows.Count
            Dim dbImgCount As Integer = cobLocation.Items.Count - customImgCount
            'Choose custom location images saved in array
            For i As Integer = customImgStartIndex To customImgStartIndex + customImgCount - 1
                If (cobLocation.SelectedIndex = i) Then
                    'Get index of target image from arr mapped from custom pic index in combobox
                    'e.g.   DB image - 8 pics
                    '       Uses index starting from 0 to access image arr for combobox indexes >= 9
                    Dim arrImageIndex As Integer = i - dbImgCount
                    picLocation.Image = mArrCustomLocImg.Item(arrImageIndex)
                End If
            Next
        End If
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        Dim dlgAddSupplier As New DialogAddSupplier
        Dim strSupplierList As New List(Of String)

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

    Private Sub btnAddLocation_Click(sender As Object, e As EventArgs) Handles btnAddLocation.Click
        Dim dlgAddLocationEdit As New DialogAddLocation
        Dim strLocationList As New List(Of String)

        'Pass existing entries in cobSupplier to dlgAddSupplier
        For i As Integer = 0 To cobLocation.Items.Count - 1
            strLocationList.Add(cobLocation.Items(i).ToString())
        Next
        dlgAddLocationEdit.strLocations = strLocationList

        'Open DialogAddLocation and get user input
        If dlgAddLocationEdit.ShowDialog() = DialogResult.OK Then
            'Add the user-defined location to cobLocation
            mArrCustomLocImg.Add(dlgAddLocationEdit.locPic)
            cobLocation.Items.Add(dlgAddLocationEdit.locName)
            cobLocation.SelectedIndex = cobLocation.Items.Count - 1
            picLocation.Image = dlgAddLocationEdit.locPic
            ' Remove previously added but unused entry
            If cobLocation.Items.Count > mintLocationCount + 1 Then
                cobLocation.Items.RemoveAt(cobLocation.Items.Count - 2)
            End If
        End If
    End Sub

    Private Sub txtWholesalePrice_Click(sender As Object, e As EventArgs) Handles txtWholesalePrice.Click
        txtWholesalePrice.SelectAll() 'Select all text
    End Sub

    Private Sub txtWholesalePrice_TextChanged(sender As Object, e As EventArgs) Handles txtWholesalePrice.TextChanged
        setFormFeedback("", False, False)
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

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim decPrice As Decimal = FormatNumber(txtWholesalePrice.Text, 2) 'Get price

        If (cobSupplier.SelectedIndex = 0) Then
            'If no supplier selected
            setFormFeedback("Please select a supplier!", True, True)
        ElseIf (decPrice >= 1000) Then
            'If price over 999.99, which is over the maximum char count
            setFormFeedback("Wholesale price cannot be greater than " & FormatCurrency(999.99, 2) + "!", True, True)
        Else
            'All inputs are valid. Proceed to insert data into DB
            setFormFeedback("", False, False)

            Dim newSupplierId As Integer
            Dim newLocationId As Integer

            connection.Open()

            'Insert new supplier if custom supplier is chosen
            dataTable = New DataTable 'Reinstantiate dataTable
            query = "SELECT * FROM Supplier WHERE UPPER(SupplierName) = @supplierName;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@supplierName", SqlDbType.VarChar)).Value = cobSupplier.Items(cobSupplier.SelectedIndex).ToString.ToUpper
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dataTable)

            'Insert if record does not exist in DB
            If (dataTable.Rows.Count = 0) Then
                'Count existing records to determine new supplier id
                dataTable = New DataTable 'Reinstantiate dataTable
                query = "SELECT COUNT(*) FROM Supplier;"
                dataAdapter = New SqlDataAdapter(query, connection)
                dataAdapter.Fill(dataTable)
                newSupplierId = dataTable.Rows(0)(0) + 1

                query = "INSERT INTO Supplier (SupplierName) VALUES (@name);"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@name", SqlDbType.VarChar, 50)).Value =
                cobSupplier.Items(cobSupplier.SelectedIndex).ToString
                sqlCommand.ExecuteNonQuery()
            End If

            'Insert new location if custom location is chosen
            dataTable = New DataTable 'Reinstantiate dataTable
            query = "SELECT * FROM StockLocation WHERE UPPER(LocationName) = @locationName;"
            sqlCommand = New SqlCommand(query, connection)
            sqlCommand.Parameters.Add(New SqlParameter("@locationName", SqlDbType.VarChar)).Value = cobLocation.Items(cobLocation.SelectedIndex).ToString.ToUpper
            dataAdapter = New SqlDataAdapter(sqlCommand)
            dataAdapter.Fill(dataTable)
            'Insert if record does not exist in DB
            If (dataTable.Rows.Count = 0) Then
                'Count existing records to determine new record id
                dataTable = New DataTable 'Reinstantiate dataTable
                query = "SELECT COUNT(*) FROM StockLocation;"
                dataAdapter = New SqlDataAdapter(query, connection)
                dataAdapter.Fill(dataTable)
                newLocationId = dataTable.Rows(0)(0) + 1

                ms = New MemoryStream()
                picLocation.Image.Save(ms, picLocation.Image.RawFormat)
                arrImage = ms.GetBuffer()
                ms.Close()

                query = "INSERT INTO StockLocation (LocationName, LocationPicture) VALUES (@name, @pic);"
                sqlCommand = New SqlCommand(query, connection)
                sqlCommand.Parameters.Add(New SqlParameter("@name", SqlDbType.VarChar, 50)).Value =
                cobLocation.Items(cobLocation.SelectedIndex).ToString
                sqlCommand.Parameters.Add(New SqlParameter("@pic", SqlDbType.Image)).Value = arrImage
                sqlCommand.ExecuteNonQuery()
            End If

            'Update stock record
            Dim intStatus As Integer

            'Set wholesale price decimal parameter
            Dim sqlWholesaleParam As New SqlParameter("@wholesale", SqlDbType.Decimal)
            sqlWholesaleParam.Precision = 5
            sqlWholesaleParam.Scale = 2

            query = "UPDATE Stock 
                    SET SupplierId = @supplierid, 
                        WholesalePrice = @wholesale, 
                        StockStatusId = @statusid,                         
                        LocationId = @locationid
                    WHERE StockNumber = @stockNo"
            sqlCommand = New SqlCommand(query, connection)
            'stockNo
            sqlCommand.Parameters.Add(New SqlParameter("@stockNo", SqlDbType.Int)).Value = CInt(strStockNo.Substring(1, strStockNo.Length - 1))
            'Status
            '   Remap combobox index to database index
            If (cobStatus.SelectedIndex + 1 = 3) Then
                intStatus = 5
            Else
                intStatus = cobStatus.SelectedIndex + 1
            End If
            sqlCommand.Parameters.Add(New SqlParameter("@statusid", SqlDbType.Int)).Value = intStatus
            'Supplier
            '   Use new supplier id if custom supplier is chosen
            If (newSupplierId <> Nothing) Then
                sqlCommand.Parameters.Add(New SqlParameter("@supplierid", SqlDbType.Int)).Value = newSupplierId
            Else
                sqlCommand.Parameters.Add(New SqlParameter("@supplierid", SqlDbType.Int)).Value = cobSupplier.SelectedIndex
            End If
            'Wholesale price
            sqlCommand.Parameters.Add(sqlWholesaleParam).Value = FormatNumber(txtWholesalePrice.Text, 2)
            'Location
            '   Use new location id if custom location is chosen

            If (newLocationId <> Nothing) Then
                sqlCommand.Parameters.Add(New SqlParameter("@locationid", SqlDbType.Int)).Value = newLocationId
            Else
                sqlCommand.Parameters.Add(New SqlParameter("@locationid", SqlDbType.Int)).Value = cobLocation.SelectedIndex + 1
            End If

            mIntResult = sqlCommand.ExecuteNonQuery()
            connection.Close()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Do nothing and close dialog
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub setFormFeedback(message As String, isInvalid As Boolean, isVisible As Boolean)
        'Set label color
        If (isInvalid) Then
            lblFormFeedback.ForeColor = Color.Red
        Else
            lblFormFeedback.ForeColor = Color.Green
        End If

        lblFormFeedback.Text = message
        lblFormFeedback.Visible = isVisible
    End Sub

    Private Sub populateComboBoxes()
        '   cobSupplier
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT SupplierName FROM Supplier;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        cobSupplier.Items.Add("Select a supplier:")
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobSupplier.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobSupplier.SelectedIndex = mIntSupplierId
        '   cobStatus
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT StatusDesc FROM StockStatus;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            If (i <> 2 And i <> 3) Then
                cobStatus.Items.Add(dataTable.Rows(i).Item(0).ToString)
            End If
        Next
        cobStatus.SelectedIndex = mIntStatusid
        '   cobLocation
        dataTable = New DataTable 'Reinstantiate dataTable
        query = "SELECT LocationName FROM StockLocation;"
        dataAdapter = New SqlDataAdapter(query, connection)
        dataAdapter.Fill(dataTable)
        For i As Integer = 0 To dataTable.Rows.Count - 1
            cobLocation.Items.Add(dataTable.Rows(i).Item(0).ToString)
        Next
        cobLocation.SelectedIndex = mIntLocationid - 1
    End Sub

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
End Class

