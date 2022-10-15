Imports Newtonsoft
Imports System.ComponentModel
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class clsProducts

    Public Property blProduct As BindingList(Of clsProduct)

    Public Sub New()
        blProduct = New BindingList(Of clsProduct)
    End Sub

    Public Event ListFilledDone(ByVal isSuccess As Boolean)
    Public Event RemoveElementDone(ByVal isSuccess As Boolean, ByVal objid As String)

    Private Sub ConvertToBindingList(ByRef lst As List(Of clsProduct))
        blProduct.Clear()

        If lst Is Nothing Then
            Return
        End If
        For Each obj As clsProduct In lst
            blProduct.Add(obj)
        Next

    End Sub

    'Private Sub ConvertToDataTable()
    '    If lstProduct Is Nothing Then
    '        dtProduct = Nothing
    '    End If
    '    dtProduct = New DataTable
    '    'Adding the Columns.
    '    dtProduct.Columns.Add("id", GetType(System.Int32))
    '    dtProduct.Columns.Add("itemnum", GetType(System.String))
    '    dtProduct.Columns.Add("itemname", GetType(System.String))
    '    dtProduct.Columns.Add("standardweight", GetType(System.String))
    '    dtProduct.Columns.Add("uom", GetType(System.String))
    '    dtProduct.Columns.Add("price", GetType(System.Decimal))
    '    Dim idx As Int16 = 0
    '    'Adding the Rows.
    '    For Each obj_1 As clsProduct In lstProduct
    '        idx += 1
    '        Dim newrow As DataRow = dtProduct.NewRow()
    '        newrow("id") = idx
    '        newrow("itemnum") = obj_1.itemnum
    '        newrow("itemname") = obj_1.itemname
    '        newrow("standardweight") = obj_1.itemstandardweight
    '        newrow("uom") = obj_1.itemuom
    '        newrow("price") = obj_1.itemprice
    '        dtProduct.Rows.Add(newrow)
    '    Next
    'End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim lstData As List(Of clsProduct) = Nothing
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsProduct)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsProduct)))(e.Result)
        ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
        ' Dim newObjectId As String = ""
        ' Dim lstData As New List(Of clsProduct)
        jsonResultToDict.TryGetValue("results", lstData)
        ' uuu
        'ConvertToDataTable()
        ConvertToBindingList(lstData)
        Console.WriteLine("Event is triggered")
        RaiseEvent ListFilledDone(True)
        ' MsgBox("New record with objectId: " & newObjectId & " is added", "New Record Added")
    End Sub

    Public Function findProductByItemnum(_itemnum As String) As clsProduct
        Dim objFound As clsProduct = Nothing
        For Each obj_2 As clsProduct In blProduct
            If obj_2.itemnum = _itemnum Then
                objFound = obj_2
                Exit For
            End If
        Next
        Return objFound
    End Function

    Public Async Function deleteProductData(_itemno As String) As Task(Of Boolean)

        Dim foundObjectid As String = findObjectIdByItemNum(_itemno)

        If foundObjectid = "" Then

            Return False
        End If

        ' using TLS 1.2
        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product/" & foundObjectid

        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        web.
        ' web.Encoding = System.Text.Encoding.UTF8
        'Add the event handler here
        'AddHandler web.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        Try
            Dim response As String = Await web.UploadStringTaskAsync(myurl, "DELETE")
            RaiseEvent RemoveElementDone(True, _itemno)
            Return True
        Catch ex As Exception
            Console.WriteLine("clsProducts.deleteProductData: " & vbCrLf & ex.Message)
            RaiseEvent RemoveElementDone(False, _itemno)
            Return False
        End Try
    End Function

    Public Function getProductData() As Boolean

        ' using TLS 1.2
        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product"

        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        web.Encoding = System.Text.Encoding.UTF8
        'Add the event handler here
        AddHandler web.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted
        Try
            Dim objuri As Uri = New Uri(myurl)
            web.DownloadStringAsync(objuri)
            Return True
        Catch ex As Exception
            Console.WriteLine("clsProducts.getProductData: " & vbCrLf & ex.Message)
            RaiseEvent ListFilledDone(False)
            Return False
        End Try
        'Dim sendData As String = 

    End Function

    Public Function deleteProductInTheList(ByVal _itemno As String) As Boolean
        Dim foundidx As Int32 = findIndexInTheList(_itemno)
        If foundidx > -1 Then
            blProduct.RemoveAt(foundidx)
            ' ConvertToDataTable()
            Return True
        End If
        Return False
    End Function

    ' this function replaceProduct is used replace item in the list 
    ' i.e. update the list
    Public Function replaceProductInTheList(ByRef _obj As clsProduct) As Boolean

        Dim foundidx As Int32 = findIndexInTheList(_obj.itemnum)
        If foundidx > -1 Then
            blProduct(foundidx) = _obj
            ' ConvertToDataTable()
            Return True
        End If
        Return False
    End Function

    ' this function addProduct is used add item in the list 
    ' i.e. add the list
    Public Function addProductToTheList(ByRef _obj As clsProduct) As Boolean

        Dim foundidx As Int32 = findIndexInTheList(_obj.itemnum)
        If foundidx = -1 Then
            blProduct.Add(_obj)
            'ConvertToDataTable()
            Return True
        End If
        Return False
    End Function

    Private Function findIndexInTheList(_itemnum As String) As Int32
        Dim foundidx As Int32 = -1
        Dim i As Int32 = 0
        For Each obj_1 As clsProduct In blProduct
            If obj_1.itemnum = _itemnum Then
                foundidx = i
                Exit For
            End If
            i += 1
        Next
        Return foundidx
    End Function


    ' find object id by item number
    Private Function findObjectIdByItemNum(_itemno As String) As String
        Dim foundObjectid As String = ""
        ' Dim i As Int32 = 0
        For Each obj_1 As clsProduct In blProduct
            If obj_1.itemnum = _itemno Then
                foundObjectid = obj_1.objectId
                Exit For
            End If
        Next
        Return foundObjectid
    End Function

End Class
