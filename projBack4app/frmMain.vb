Imports System.Net
Imports Newtonsoft
Public Class frmMain

    ' objProducts holds list of clsProduct
    Public WithEvents objProducts As clsProducts
    ' copiedProduct is copied clsProduct for add used
    Private copiedProduct As clsProduct

    Private lstTableHeader As List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnAdd.Text = "Add Product"
        btnRefresh.Text = "Refresh"
        Me.Text = "Weighting Product System"
        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ListFilledDoneHandler
        ' AddHandler objProducts.RemoveElementDone, AddressOf RemoveElementDoneHandler
        objProducts.getProductData()
        lstTableHeader = New List(Of String)(
            {"objectId", "item no.", "Name", "Name2", "Unit", "Std. Weight", "Price"}
        )
    End Sub

    Private Sub ListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then
            dgvProduct.DataSource = objProducts.blProduct  'dtProduct
            For i As Int16 = 0 To lstTableHeader.Count - 1
                Me.dgvProduct.Columns(i).HeaderText = lstTableHeader(i)
            Next
            Me.dgvProduct.Columns(0).Visible = False ' objectId is invisible
            Me.dgvProduct.Columns(1).Width = 100 ' Item No.
            Me.dgvProduct.Columns(2).Width = 200 ' Name
            Me.dgvProduct.Columns(3).Width = 200 ' Name2
            Me.dgvProduct.Columns(5).Width = 130 'Std. Weight
            Me.dgvProduct.Columns(6).Width = 80
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dlgInsert As dlgProduct = New dlgProduct
        dlgInsert.setOperation("add")
        If copiedProduct IsNot Nothing Then
            dlgInsert.setObject(copiedProduct)
        End If
        Dim response = dlgInsert.ShowDialog(Me)
        If response = DialogResult.OK Then
            ' Reset copied object
            copiedProduct = Nothing
            ' update the bindinglist by insert new object
            Dim objReturn As clsProduct = dlgInsert.getResultingObject
            objProducts.addProductToTheList(objReturn)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ListFilledDoneHandler
        objProducts.getProductData()
    End Sub

    Private Async Sub MenuClicked(sender As Object, e As System.EventArgs)
        Dim selectedIndex As Integer = dgvProduct.SelectedRows(0).Index
        Try
            Dim sender1 As MenuItem = CType(sender, MenuItem)
            Diagnostics.Debug.WriteLine(sender1.Text)
            Dim myitemno As String = sender1.Tag.ToString()

            Select Case sender1.Text
                Case "show"
                    Dim dlgShow As New dlgProduct
                    dlgShow.setOperation("show")
                    dlgShow.setObject(objProducts.findProductByItemnum(myitemno))
                    dlgShow.StartPosition = FormStartPosition.CenterParent
                    If dlgShow.ShowDialog = DialogResult.OK Then
                        dlgShow = Nothing
                    End If
                Case "edit"
                    Dim dlgEdit As New dlgProduct
                    dlgEdit.setOperation("edit")
                    dlgEdit.setObject(objProducts.findProductByItemnum(myitemno))
                    dlgEdit.StartPosition = FormStartPosition.CenterParent
                    If dlgEdit.ShowDialog = DialogResult.OK Then
                        ' update the bindinglist by replacing new object
                        Dim objReturn As clsProduct = dlgEdit.getResultingObject
                        objProducts.replaceProductInTheList(objReturn)
                    End If
                Case "delete"
                    Dim question As String = String.Format("Delete item #{0}?", myitemno)
                    Dim result As DialogResult = MessageBox.Show(question, "Confirm Delete", MessageBoxButtons.YesNo)
                    If (result = DialogResult.Yes) Then
                        Try
                            Dim styleError As MsgBoxStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical
                            Dim isdeleted As Boolean = Await objProducts.deleteProductData(myitemno)
                            If isdeleted Then
                                ' update the bindinglist
                                objProducts.deleteProductInTheList(myitemno)
                            End If                            '
                        Catch ex As Exception
                            Diagnostics.Debug.WriteLine("Error: " & vbCrLf & ex.Message)
                            Return
                        End Try
                    End If
                    'End If
                Case "copy"
                    copiedProduct = objProducts.findProductByItemnum(myitemno)
                    If copiedProduct Is Nothing Then
                        MsgBox("Copy #" & myitemno & " failed, please contact it support!")
                    Else
                        MsgBox("Copy #" & myitemno & " successfully.")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProduct_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvProduct.MouseClick
        If dgvProduct.Rows.Count = 0 Then
            Return
        End If
        If dgvProduct.SelectedRows.Count = 0 Then
            Return
        End If
        If (e.Button = MouseButtons.Right) Then
            Dim currMouseOverRow As Integer = dgvProduct.HitTest(e.X, e.Y).RowIndex
            ' column 1 is item number
            Dim item_1 As String = dgvProduct.SelectedRows.Item(0).Cells.Item(1).Value.ToString
            'Dim tag_1 As String = id_1 & "^" & item_1
            Dim cm1 As ContextMenu = New ContextMenu()
            Dim menuitemforshow As MenuItem = New MenuItem() With {.Text = "show", .Tag = item_1}
            AddHandler menuitemforshow.Click, AddressOf Me.MenuClicked
            Dim menuitemforedit As MenuItem = New MenuItem() With {.Text = "edit", .Tag = item_1}
            AddHandler menuitemforedit.Click, AddressOf Me.MenuClicked
            Dim menuitemfordelete As MenuItem = New MenuItem() With {.Text = "delete", .Tag = item_1}
            AddHandler menuitemfordelete.Click, AddressOf Me.MenuClicked
            Dim menuitemforcopy As MenuItem = New MenuItem() With {.Text = "copy", .Tag = item_1}
            AddHandler menuitemforcopy.Click, AddressOf Me.MenuClicked
            cm1.MenuItems.Add(menuitemforshow)
            cm1.MenuItems.Add(menuitemforedit)
            cm1.MenuItems.Add(menuitemfordelete)
            cm1.MenuItems.Add(menuitemforcopy)
            cm1.Show(dgvProduct, New Point(e.X, e.Y))
        End If
    End Sub

End Class
