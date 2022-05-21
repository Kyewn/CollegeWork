Public Class Layout

    Private Sub Layout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetBounds(0, 0, 1400, 620)
        switchPanel(Dashboard, btnNavDashboard)
    End Sub

    Sub switchPanel(ByVal pnlSelected As Form, btnSelected As Button)
        pnlSelected.SetBounds(0, 0, 1400, 532)
        ' Clear current controls in panel and switch to selected form
        pnlMain.Controls.Clear()
        pnlSelected.TopLevel = False
        pnlMain.Controls.Add(pnlSelected)
        pnlSelected.Show()
        ' Update navigation bar (title and buttons)
        lblTitle.Text = btnSelected.Text.ToUpper()
        With btnNavDashboard
            .ForeColor = Color.Black
            .Font = New Font(btnNavDashboard.Font, FontStyle.Regular)
        End With
        With btnNavAddBook
            .ForeColor = Color.Black
            .Font = New Font(btnNavAddBook.Font, FontStyle.Regular)
        End With
        With btnNavAddStock
            .ForeColor = Color.Black
            .Font = New Font(btnNavAddStock.Font, FontStyle.Regular)
        End With
        With btnNavViewStock
            .ForeColor = Color.Black
            .Font = New Font(btnNavViewStock.Font, FontStyle.Regular)
        End With
        With btnNavTrackOrders
            .ForeColor = Color.Black
            .Font = New Font(btnNavTrackOrders.Font, FontStyle.Regular)
        End With
        With btnNavViewSales
            .ForeColor = Color.Black
            .Font = New Font(btnNavViewSales.Font, FontStyle.Regular)
        End With
        With btnSelected
            .ForeColor = Color.Blue
            .Font = New Font(btnSelected.Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        switchPanel(Dashboard, btnNavDashboard)
        Dashboard.refreshForm(sender, e)
    End Sub

    Private Sub btnNavAddBook_Click(sender As Object, e As EventArgs) Handles btnNavAddBook.Click
        switchPanel(AddBook, btnNavAddBook)
    End Sub

    Private Sub btnNavAddStock_Click(sender As Object, e As EventArgs) Handles btnNavAddStock.Click
        switchPanel(AddStock, btnNavAddStock)
    End Sub

    Private Sub btnNavViewStock_Click(sender As Object, e As EventArgs) Handles btnNavViewStock.Click
        switchPanel(ViewStocks, btnNavViewStock)
        ViewStocks.refreshForm(sender, e)
    End Sub

    Private Sub btnNavTrackOrders_Click(sender As Object, e As EventArgs) Handles btnNavTrackOrders.Click
        switchPanel(TrackOrders, btnNavTrackOrders)
        TrackOrders.refreshForm(sender, e)
    End Sub

    Private Sub btnNavViewSales_Click(sender As Object, e As EventArgs) Handles btnNavViewSales.Click
        switchPanel(ViewSales, btnNavViewSales)
        ViewSales.refreshForm(sender, e)
    End Sub

    Public Sub switchDashboard(sender As Object, e As EventArgs)
        btnNavDashboard_Click(sender, e)
    End Sub

    Public Sub switchViewStocks(sender As Object, e As EventArgs)
        btnNavViewStock_Click(sender, e)
    End Sub

    Public Sub switchTrackOrders(sender As Object, e As EventArgs)
        btnNavTrackOrders_Click(sender, e)
    End Sub

    Public Sub switchViewSales(sender As Object, e As EventArgs)
        btnNavViewSales_Click(sender, e)
    End Sub
End Class