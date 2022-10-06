Imports System.Net
Imports Newtonsoft

Public Class Form1

    Private WithEvents objProducts As clsProducts

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAdd.Text = "Add Product"
        btnRefresh.Text = "Refresh"
        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ListFilledDoneHandler
        objProducts.getProductData()
    End Sub

    Private Sub ListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then

            dgvProduct.DataSource = objProducts.dtProduct 'modCommon.objJMenu.lstMenu
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dlg As Form = New dlgProductAdd
        Dim response = dlg.ShowDialog(Me)
        If response = DialogResult.OK Then
            'dgvRefreshing("ingredientlabel")
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ListFilledDoneHandler
        objProducts.getProductData()
    End Sub
End Class
