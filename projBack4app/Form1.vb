Imports System.Net
Imports Newtonsoft

Public Class Form1

    Private WithEvents objProducts As clsProducts

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ListFilledDoneHandler
        objProducts.getProductData()
    End Sub

    Private Sub ListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then

            dgvProduct.DataSource = objProducts.dtProduct 'modCommon.objJMenu.lstMenu
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dlg As Form = New dlgProductAdd
        Dim response = dlg.ShowDialog(Me)
        If response = DialogResult.OK Then
            'dgvRefreshing("ingredientlabel")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
