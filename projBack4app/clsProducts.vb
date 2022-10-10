Imports Newtonsoft
Imports System.ComponentModel
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class clsProducts

    Public Property lstProduct As List(Of clsProduct)

    Public dtProduct As DataTable

    Public dtFilter As DataTable

    Public Event ListFilledDone(ByVal isSuccess As Boolean)

    Private Sub ConvertToDataTable()
        If lstProduct Is Nothing Then
            dtProduct = Nothing
        End If
        dtProduct = New DataTable
        'Adding the Columns.
        dtProduct.Columns.Add("id", GetType(System.Int32))
        dtProduct.Columns.Add("itemnum", GetType(System.String))
        dtProduct.Columns.Add("itemname", GetType(System.String))
        dtProduct.Columns.Add("standardweight", GetType(System.String))
        dtProduct.Columns.Add("uom", GetType(System.String))
        dtProduct.Columns.Add("price", GetType(System.Decimal))
        Dim idx As Int16 = 0
        'Adding the Rows.
        For Each obj_1 As clsProduct In lstProduct
            idx += 1
            Dim newrow As DataRow = dtProduct.NewRow()
            newrow("id") = idx
            newrow("itemnum") = obj_1.itemnum
            newrow("itemname") = obj_1.itemname
            newrow("standardweight") = obj_1.itemstandardweight
            newrow("uom") = obj_1.itemuom
            newrow("price") = obj_1.itemprice
            dtProduct.Rows.Add(newrow)
        Next
    End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsProduct)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsProduct)))(e.Result)
        ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
        ' Dim newObjectId As String = ""
        ' Dim lstData As New List(Of clsProduct)
        jsonResultToDict.TryGetValue("results", lstProduct)
        ' uuu
        ConvertToDataTable()
        Console.WriteLine("Event is triggered")
        RaiseEvent ListFilledDone(True)
        ' MsgBox("New record with objectId: " & newObjectId & " is added", "New Record Added")
    End Sub

    Public Function findProductByItemnum(_itemnum As String) As clsProduct
        Dim objFound As clsProduct = Nothing
        For Each obj_2 As clsProduct In lstProduct
            If obj_2.itemnum = _itemnum Then
                objFound = obj_2
                Exit For
            End If
        Next
        Return objFound
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

    ' this function replaceProduct is used replace item in the list 
    ' i.e. update the list
    Public Function replaceProductInTheList(ByRef _obj As clsProduct) As Boolean

        Dim foundidx As Int32 = foundIndexInTheList(_obj.itemnum)
        If foundidx > -1 Then
            lstProduct(foundidx) = _obj
            ConvertToDataTable()
            Return True
        End If
        Return False
    End Function

    ' this function addProduct is used add item in the list 
    ' i.e. add the list
    Public Function addProductToTheList(ByRef _obj As clsProduct) As Boolean

        Dim foundidx As Int32 = foundIndexInTheList(_obj.itemnum)
        If foundidx = -1 Then
            lstProduct.Add(_obj)
            ConvertToDataTable()
            Return True
        End If
        Return False
    End Function

    Private Function foundIndexInTheList(_itemnum As String) As Int32
        Dim foundidx As Int32 = -1
        Dim i As Int32 = 0
        For Each obj_1 As clsProduct In lstProduct
            If obj_1.itemnum = _itemnum Then
                foundidx = i
                Exit For
            End If
            i += 1
        Next
        Return foundidx
    End Function

End Class
