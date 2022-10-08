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
            dgvProduct.DataSource = objProducts.dtProduct
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

    Private Sub MenuClicked(sender As Object, e As System.EventArgs)
        Dim selectedIndex As Integer = dgvProduct.SelectedRows(0).Index
        Try
            Dim sender1 As MenuItem = CType(sender, MenuItem)
            Dim myarr() As String = sender1.Tag.ToString().Split(New Char() {"^"c})
            Dim myid As Int32 = CType(myarr(0), Int32)
            Dim myitemno As String = myarr(1)
            Dim mysheet As String = myarr(2)
            Dim mychineseherb As Boolean = CType(myarr(3), Boolean)
            Diagnostics.Debug.WriteLine(sender1.Text)
            Select Case sender1.Text
                Case "顯示"
                    Dim frmShow As New frmItem(myitemno, "show")
                    frmShow.setSheetSpec(mysheet)
                    frmShow.setId(myid)
                    frmShow.setIsLotNumberReq(mychineseherb)
                    frmShow.StartPosition = FormStartPosition.CenterParent
                    If frmShow.ShowDialog = DialogResult.OK Then
                        frmShow = Nothing
                    End If
                Case "新增在此行前"
                    If modCommon.objCopiedItem Is Nothing Then
                        MsgBox("請先複制！")
                        Return
                    End If
                    Dim frmInsert1 As New frmItem(myitemno, "insertbefore")
                    frmInsert1.setSheetSpec(mysheet)
                    frmInsert1.setId(myid)
                    frmInsert1.setRefItem(myitemno)
                    frmInsert1.StartPosition = FormStartPosition.CenterParent
                    If frmInsert1.ShowDialog = DialogResult.OK Then
                        frmInsert1 = Nothing
                        'Read the json menu without refilling the custom map
                        Dim isMenuRetrieved As Boolean = modCommon.ReadTheJsonMenu
                        If isMenuRetrieved Then
                            RefreshDatagrid(selectedIndex)
                        End If
                    End If
                Case "新增在此行後"
                    If modCommon.objCopiedItem Is Nothing Then
                        MsgBox("請先複制！")
                        Return
                    End If
                    Dim frmInsert2 As New frmItem(myitemno, "insertafter")
                    frmInsert2.setSheetSpec(mysheet)
                    frmInsert2.setId(myid)
                    frmInsert2.setRefItem(myitemno)
                    frmInsert2.StartPosition = FormStartPosition.CenterParent
                    If frmInsert2.ShowDialog = DialogResult.OK Then
                        frmInsert2 = Nothing
                        'Read the json menu without refilling the custom map
                        Dim isMenuRetrieved As Boolean = modCommon.ReadTheJsonMenu
                        If isMenuRetrieved Then
                            RefreshDatagrid(selectedIndex + 1)
                        End If
                    End If
                Case "修改"
                    Dim frmEdit As New frmItem(myitemno, "edit")
                    frmEdit.setSheetSpec(mysheet)
                    frmEdit.setId(myid)
                    frmEdit.setIsLotNumberReq(mychineseherb)
                    frmEdit.StartPosition = FormStartPosition.CenterParent
                    If frmEdit.ShowDialog = DialogResult.OK Then
                        frmEdit = Nothing
                        'Read the json menu without refilling the custom map
                        Dim isMenuRetrieved As Boolean = modCommon.ReadTheJsonMenu
                        If isMenuRetrieved Then
                            RefreshDatagrid(selectedIndex)
                        End If
                    End If
                Case "刪除"
                    Dim result As DialogResult = MessageBox.Show(String.Format("確定刪除貨品 #{0}?", myitemno),
                              "刪除貨品", MessageBoxButtons.YesNo)
                    If (result = DialogResult.Yes) Then
                        Dim itemfile_1 As String = String.Format(modCommon.pathOfItem & "\{0}.json", myitemno)
                        Dim menufile_1 As String = modCommon.pathOfMenu & "\labels.json"
                        If IO.File.Exists(itemfile_1) = True Then
                            IO.File.Delete(itemfile_1)
                        End If
                        'modCommon.objBarcodeItemnumMap.removeBarcodeItemNumPairByItemnum(myitemno)
                        If IO.File.Exists(menufile_1) Then
                            Try
                                Dim styleError As MsgBoxStyle = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical
                                'Read the json menu without refilling the custom map
                                Dim isMenuRead4 As Boolean = modCommon.ReadTheJsonMenu
                                If isMenuRead4 = False Then
                                    MsgBox("不能讀取清單檔案，請聯絡技術支援！", styleError, "無法讀取4")
                                    Return
                                End If
                                objJMenu.DeleteItByItem(myitemno)
                                Dim jsonmenu_1 As String = JsonConvert.SerializeObject(objJMenu)
                                If jsonmenu_1.IndexOf("lstMenu") > -1 Then 'found
                                    jsonmenu_1 = "[" & modCommon.retrivingSquareBracket(jsonmenu_1) & "]"
                                End If
                                IO.File.WriteAllText(menufile_1, jsonmenu_1)                                '
                            Catch ex As Exception
                                Diagnostics.Debug.WriteLine("Error: " & vbCrLf & ex.Message)
                                Return
                            End Try
                            'Read the json menu without refilling the custom map
                            Dim isMenuRetrieved As Boolean = modCommon.ReadTheJsonMenu
                            If isMenuRetrieved Then
                                RefreshDatagrid(selectedIndex - 1)
                            End If
                            Return
                        End If
                    End If
                Case "複制"
                    Dim isChineseHerb As Boolean = CType(dgvItemListing.SelectedRows.Item(0).Cells.Item("ColIsLotNumberReq").Value, Boolean)
                    Dim iscopied As Boolean = modCommon.copyItemFromItemnum(myid, myitemno, mysheet, isChineseHerb)
                    If iscopied Then
                        MsgBox("複制 #" & myitemno & " 成功")
                    Else
                        MsgBox("複制 #" & myitemno & " 失敗，請聯絡技術支援。")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvProduct_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvProduct.MouseClick
        If dgvProduct.Rows.Count = 0 Then
            Return
        End If
        If (e.Button = MouseButtons.Right) Then
            Dim currMouseOverRow As Integer = dgvProduct.HitTest(e.X, e.Y).RowIndex
            Dim id_1 As String = dgvProduct.SelectedRows.Item(0).Cells.Item("ColId").Value.ToString
            Dim item_1 As String = dgvProduct.SelectedRows.Item(0).Cells.Item("ColItemnum").Value.ToString
            Dim tag_1 As String = id_1 & "^" & item_1
            Dim cm1 As ContextMenu = New ContextMenu()
            Dim menuitemforshow As MenuItem = New MenuItem() With {.Text = "show", .Tag = id_1}
            AddHandler menuitemforshow.Click, AddressOf Me.MenuClicked
            Dim menuitemforedit As MenuItem = New MenuItem() With {.Text = "edit", .Tag = id_1}
            AddHandler menuitemforedit.Click, AddressOf Me.MenuClicked
            Dim menuitemfordelete As MenuItem = New MenuItem() With {.Text = "delete", .Tag = id_1}
            AddHandler menuitemfordelete.Click, AddressOf Me.MenuClicked
            Dim menuitemforcopy As MenuItem = New MenuItem() With {.Text = "copy", .Tag = id_1}
            AddHandler menuitemforcopy.Click, AddressOf Me.MenuClicked
            cm1.MenuItems.Add(menuitemforshow)
            cm1.MenuItems.Add(menuitemforedit)
            cm1.MenuItems.Add(menuitemfordelete)
            cm1.MenuItems.Add(menuitemforcopy)
            cm1.Show(dgvProduct, New Point(e.X, e.Y))
        End If
    End Sub

End Class
