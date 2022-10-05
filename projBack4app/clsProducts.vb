Imports Newtonsoft
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
        dtProduct.Columns.Add("itemnum", GetType(System.String))
        dtProduct.Columns.Add("itemdesc", GetType(System.String))
        dtProduct.Columns.Add("itemuom", GetType(System.String))
        dtProduct.Columns.Add("itemprice", GetType(System.Decimal))
        dtProduct.Columns.Add("itemstandardweight", GetType(System.Int32))
        'Adding the Rows.
        For Each obj_1 As clsProduct In lstProduct
            Dim newrow As DataRow = dtProduct.NewRow()
            newrow("itemnum") = obj_1.itemnum
            newrow("itemdesc") = obj_1.itemname
            newrow("itemuom") = obj_1.itemuom
            newrow("itemprice") = obj_1.itemprice
            newrow("itemstandardweight") = obj_1.itemstandardweight
            dtProduct.Rows.Add(newrow)
        Next
    End Sub

    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsProduct)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsProduct)))(e.Result)
        ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
        ' Dim newObjectId As String = ""
        jsonResultToDict.TryGetValue("results", lstProduct)
        ConvertToDataTable()
        Console.WriteLine("Event is triggered")
        RaiseEvent ListFilledDone(True)
        ' MsgBox("New record with objectId: " & newObjectId & " is added", "New Record Added")
    End Sub

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

End Class
