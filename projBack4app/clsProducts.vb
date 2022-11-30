Imports Newtonsoft
Imports Newtonsoft.Json
Imports System.ComponentModel
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class clsProducts
    ' blProduct is the data source of datagridview i.e. dgvProduct
    ' Any change(s) to this list would automatically update datagridview i.e. data-binding
    Public Property blProduct As BindingList(Of clsProduct)

    Public Property newobjectId As String

    Public Sub New()
        blProduct = New BindingList(Of clsProduct)
        newobjectId = ""
    End Sub

    Public Event ListFilledDone(ByVal isSuccess As Boolean)

    Private Sub ConvertToBindingList(ByRef lst As List(Of clsProduct))
        blProduct.Clear()
        If lst Is Nothing Then
            Return
        End If
        For Each obj As clsProduct In lst
            blProduct.Add(obj)
        Next

    End Sub

    ' event handler of web client inside function getProductData().
    ' It is triggered when DownloadStringAsync complete i.e. DownloadStringCompleted 
    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim lstData As List(Of clsProduct) = Nothing
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsProduct)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsProduct)))(e.Result)
        jsonResultToDict.TryGetValue("results", lstData)
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
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product/" & foundObjectid

        Dim httpclient As New System.Net.Http.HttpClient
        Dim request = New HttpRequestMessage(HttpMethod.Delete, myurl)
        ' Set request's Content
        request.Content = New StringContent(String.Empty, Encoding.UTF8, "application/json")
        ' Set request's Headers
        request.Headers.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        request.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        request.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        Try
            Dim response = Await httpclient.SendAsync(request).ConfigureAwait(False)
            If response.StatusCode.Equals(HttpStatusCode.NotFound) Then
                Return False
            End If
            response.EnsureSuccessStatusCode()
            Return True
        Catch ex As Exception
            Console.WriteLine("clsProducts.deleteProductData: " & vbCrLf & ex.Message)
            Return False
        End Try

    End Function

    Public Async Function putProductData(ByVal json As String) As Task(Of Boolean)
        Dim obj As New clsProduct
        Dim isParsed As Boolean = obj.myDeserialize(json)
        If isParsed = False Then
            Return False
        End If

        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product/" & obj.objectId

        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        web.Encoding = System.Text.Encoding.UTF8
        Try
            Dim response As String = Await web.UploadStringTaskAsync(myurl, WebRequestMethods.Http.Put, obj.mySerialize())
            Dim jsonResultToDict As Dictionary(Of String, String) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)
            ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
            ' Dim newObjectId As String = ""
            ' Assign new object Id
            jsonResultToDict.TryGetValue("objectId", obj.objectId)
            Dim msgPrompt As String = "Existing record with objectId: " & obj.objectId & " is updated"
            Dim msgTitle As String = "Existing Record Updated"
            MsgBox(msgPrompt, MsgBoxStyle.Information, msgTitle)
            Return True
        Catch ex As Exception
            Console.WriteLine("dlgProductAdd.putProductData: " & vbCrLf & ex.Message)
            Return False
        End Try
    End Function

    Public Async Function postProductData(ByVal json As String) As Task(Of Boolean)

        Dim obj As New clsProduct
        Dim isParsed As Boolean = obj.myDeserialize(json)
        If isParsed = False Then
            Return False
        End If
        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product"

        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        web.Encoding = System.Text.Encoding.UTF8
        Try
            Dim response As String = Await web.UploadStringTaskAsync(myurl, obj.mySerialize())
            Dim jsonResultToDict As Dictionary(Of String, String) =
                JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)
            ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
            ' Dim newObjectId As String = ""
            ' Assign new object Id
            jsonResultToDict.TryGetValue("objectId", newobjectId)
            Dim msgPrompt As String = "New record with objectId: " & newobjectId & " is added"
            Dim msgTitle As String = "New Record Added"
            MsgBox(msgPrompt, MsgBoxStyle.Information, msgTitle)
            Return True
        Catch ex As Exception
            Console.WriteLine("dlgProductAdd.postProductData: " & vbCrLf & ex.Message)
            Return False
        End Try

    End Function

    Public Function getProductData() As Boolean

        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
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

    End Function

    ' this function deleteProductInTheList is used to delete item in the list
    ' i.e. update the list
    Public Function deleteProductInTheList(ByVal _itemno As String) As Boolean
        Dim foundidx As Int32 = findIndexInTheList(_itemno)
        If foundidx > -1 Then
            blProduct.RemoveAt(foundidx)
            Return True
        End If
        Return False
    End Function

    ' this function replaceProductInTheList is used to replace item in the list 
    ' i.e. update the list
    Public Function replaceProductInTheList(ByRef _obj As clsProduct) As Boolean

        Dim foundidx As Int32 = findIndexInTheListByObjectId(_obj.objectId)
        If foundidx > -1 Then
            blProduct(foundidx) = _obj
            Return True
        End If
        Return False
    End Function

    ' this function addProductToTheList is used to add item in the list 
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

    Private Function findIndexInTheListByObjectId(_objId As String) As Int32
        Dim foundidx As Int32 = -1
        Dim i As Int32 = 0
        For Each obj_1 As clsProduct In blProduct
            If obj_1.objectId = _objId Then
                foundidx = i
                Exit For
            End If
            i += 1
        Next
        Return foundidx
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
