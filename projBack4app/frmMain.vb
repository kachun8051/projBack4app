Imports System.Net
Imports Newtonsoft
Public Class frmMain

    ' objProducts holds list of clsProduct for tab#1
    Public WithEvents objProducts As clsProducts
    ' copiedProduct is copied clsProduct for add used
    Private copiedProduct As clsProduct
    ' objRecords holds list of clsRecords for tab#2
    Public WithEvents objRecords As clsRecords
    ' objRangeRecords holds list of clsRecords for tab#3
    Public WithEvents objRangeRecords As clsRecords

    Private lstProductTableHeader As List(Of String)
    Private lstRecordTableHeader As List(Of String)
    Private lstPeriodTableHeader As List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPage1.Text = "Products"
        TabPage2.Text = "Records"
        TabPage3.Text = "Reports"
        btnAdd.Text = "Add Product"
        btnRefresh.Text = "Refresh"
        Me.Text = "Weighting Product System"

        objProducts = New clsProducts
        AddHandler objProducts.ListFilledDone, AddressOf ProductListFilledDoneHandler
        ' AddHandler objProducts.RemoveElementDone, AddressOf RemoveElementDoneHandler
        objProducts.getProductData()

        objRecords = New clsRecords
        AddHandler objRecords.ListFilledDone, AddressOf RecordListFilledDoneHandler
        dtpProduction.Value = DateTime.Today
        objRecords.getRecords(dtpProduction.Value)

        objRangeRecords = New clsRecords
        AddHandler objRangeRecords.RangeListFilledDone, AddressOf RangeRecordListFilledDoneHandler

        lstProductTableHeader = New List(Of String)(
            {"objectId", "item no.", "Name", "Name2", "Unit", "Std. Weight", "Price"}
        )
        lstRecordTableHeader = New List(Of String)(
            {"objectId", "item no.", "Name", "Name2", "Unit", "Std. Weight", "Price", "Weight", "Selling Price", "Barcode", "Packing Date"}
        )

        'lstPeriodTableHeader = New List(Of String)(
        '    {"objectId", "Packing Date", "item no.", "Name", "Name2", "Unit", "Std. Weight", "Price", "Weight", "Selling Price", "Barcode"}
        ')
        Dim lstPeriod As List(Of String) = New List(Of String)({"Period...", "Monthly", "Weekly", "Daily"})
        For Each str As String In lstPeriod
            cbxPeriod.Items.Add(str)
        Next
        cbxPeriod.SelectedIndex = 0
    End Sub

    Private Sub ProductListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then
            dgvProduct.DataSource = objProducts.blProduct  'dtProduct
            For i As Int16 = 0 To lstProductTableHeader.Count - 1
                Me.dgvProduct.Columns(i).HeaderText = lstProductTableHeader(i)
            Next
            With Me.dgvProduct
                .Columns(0).Visible = False ' objectId is invisible
                .Columns(1).Width = 100 ' Item No.
                .Columns(2).Width = 200 ' Name
                .Columns(3).Width = 200 ' Name2
                .Columns(4).Width = 200 ' Unit
                .Columns(5).Width = 130 ' Std. Weight
                .Columns(6).Width = 80
            End With

        End If
    End Sub

    Private Sub RecordListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then
            dgvProductionRecord.DataSource = objRecords.blRecord
            For i As Int32 = 0 To lstRecordTableHeader.Count - 1
                Me.dgvProductionRecord.Columns(i).HeaderText = lstRecordTableHeader(i)
            Next
            With Me.dgvProductionRecord
                .Columns(0).Visible = False ' objectId is invisible
                .Columns(1).Width = 100 ' Item No.
                .Columns(2).Width = 200 ' Name
                .Columns(3).Width = 200 ' Name 2
                .Columns(4).Width = 200 ' Unit
                .Columns(5).Width = 130 ' Std. Weight
                .Columns(6).Visible = False ' Price
                .Columns(7).Width = 100 ' Weight
                .Columns(8).Width = 200 ' Selling Price
                .Columns(9).Width = 200 ' Barcode
                .Columns(10).Width = 200 ' Packing Date
            End With
        End If
    End Sub

    Private Sub RangeRecordListFilledDoneHandler(ByVal isSuccess As Boolean)
        If isSuccess Then
            dgvRangeRecords.DataSource = objRangeRecords.blRecord
            Me.dgvRangeRecords.Columns("packingdt").ValueType = GetType(Date)
            Me.dgvRangeRecords.Columns("packingdt").DefaultCellStyle.Format = "yyyy/MM/dd hh:mm:ss"
            For j As Int32 = 0 To lstRecordTableHeader.Count - 1
                Me.dgvRangeRecords.Columns(j).HeaderText = lstRecordTableHeader(j)
            Next
            With Me.dgvRangeRecords
                ' objectId is invisible
                .Columns("objectId").Visible = False
                .Columns("packingdt").Width = 200 ' Packing Date
                .Columns("itemnum").Width = 100 ' Item No.
                .Columns("itemname").Width = 200 ' Name
                .Columns("itemname2").Width = 200 ' Name 2
                .Columns("itemuom").Width = 200 ' Unit
                .Columns("itemstandardweight").Width = 130 ' Std. Weight
                .Columns("itemprice").Visible = False ' Price
                .Columns("weightingram").Width = 100 ' Weight
                .Columns("sellingprice").Width = 200 ' Selling Price
                .Columns("barcode").Width = 200 ' Barcode
            End With
            With Me.dgvRangeRecords
                .Columns("packingdt").DisplayIndex = 0
                .Columns("itemnum").DisplayIndex = 1
                .Columns("itemname").DisplayIndex = 2
                .Columns("itemname2").DisplayIndex = 3
                .Columns("itemuom").DisplayIndex = 4
                .Columns("itemstandardweight").DisplayIndex = 5
                .Columns("weightingram").DisplayIndex = 6
                .Columns("sellingprice").DisplayIndex = 7
                .Columns("barcode").DisplayIndex = 8
            End With

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
        AddHandler objProducts.ListFilledDone, AddressOf ProductListFilledDoneHandler
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

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim idx As Integer = TabControl1.SelectedIndex
        Select Case idx
            Case 0 ' Products page

            Case 1 ' Records page

            Case 2 ' Records in Date Range

        End Select
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Private Sub dtpProduction_ValueChanged(sender As Object, e As EventArgs) Handles dtpProduction.ValueChanged
        objRecords.getRecords(dtpProduction.Value)
        'End Sub
    End Sub

    Private Sub cbxPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPeriod.SelectedIndexChanged
        Dim dt As Date = dtpFrom.Value
        Select Case cbxPeriod.SelectedIndex
            Case 1 ' Monthly
                dtpFrom.Value = modCommon.FirstDayOfMonth(dt)
                dtpTo.Value = modCommon.LastDayOfMonth(dt)
            Case 2 ' Weekly
                dtpFrom.Value = modCommon.FirstDayOfWeek(dt)
                dtpTo.Value = modCommon.LastDayOfWeek(dt)
            Case 3 ' Daily
                dtpFrom.Value = dt
                dtpTo.Value = dt
        End Select
    End Sub

    Private Sub btnRangeSearch_Click(sender As Object, e As EventArgs) Handles btnRangeSearch.Click
        objRangeRecords.getRangeRecords(dtpFrom.Value, dtpTo.Value)
    End Sub

End Class
