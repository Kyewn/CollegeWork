Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class DialogEditSale
    'Property value holder
    Dim intSaleId As Integer
    Dim intStockNo As Integer
    Dim dateSaleDate As DateTime

    Public Property propSaleId As Integer
        Get
            Return intSaleId
        End Get
        Set(value As Integer)
            intSaleId = value
            txtSaleId.Text = "S" & intSaleId
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

    Public Property propSaleDate As DateTime
        Get
            Return dtpSaleDate.Value
        End Get
        Set(value As DateTime)
            dateSaleDate = value
            dtpSaleDate.Value = Date.Parse(dateSaleDate.ToShortDateString)
        End Set
    End Property

    Private Sub DialogEditSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpSaleDate.MinDate = propSaleDate
        dtpSaleDate.MaxDate = New Date(propSaleDate.Year, 12, 31)
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
