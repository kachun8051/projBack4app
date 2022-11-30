Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft

Public Class clsRecords
    ' blRecord is the data source of datagridview i.e. dgvProductionRecord
    ' Any change(s) to this list would automatically update datagridview i.e. data-binding
    Public Property blRecord As BindingList(Of clsRecord)

    Public Property newobjectId As String

    Public Sub New()
        blRecord = New BindingList(Of clsRecord)
        newobjectId = ""
    End Sub

    Public Event ListFilledDone(ByVal isSuccess As Boolean)

    Private Function getParam(i_date As String) As String
        Dim jobj_1 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
        jobj_1.Add("$gte", "13/11/2022 00:00:00+8:00")
        jobj_1.Add("$lt", "14/11/2022 00:00:00+8:00")
        Dim jobj_2 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
        jobj_2.Add("packingdt", jobj_1)
        Dim str As String = jobj_2.ToString(Json.Formatting.None)
        Diagnostics.Debug.WriteLine(str)
        Return str
    End Function

    Public Function getRecords(whichdate As String) As Boolean

        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Production?" &
            "where=" & getParam("") & "&order=itemnum"
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
            Console.WriteLine("clsRecords.getRecords: " & vbCrLf & ex.Message)
            RaiseEvent ListFilledDone(False)
            Return False
        End Try

    End Function

    ' event handler of web client inside function getProductData().
    ' It is triggered when DownloadStringAsync complete i.e. DownloadStringCompleted 
    Private Sub webClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim lstData As List(Of clsRecord) = Nothing
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsRecord)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsRecord)))(e.Result)
        jsonResultToDict.TryGetValue("results", lstData)
        ConvertToBindingList(lstData)
        Console.WriteLine("Event is triggered")
        RaiseEvent ListFilledDone(True)
        ' MsgBox("New record with objectId: " & newObjectId & " is added", "New Record Added")
    End Sub

    Private Sub ConvertToBindingList(ByRef lst As List(Of clsRecord))
        blRecord.Clear()
        If lst Is Nothing Then
            Return
        End If
        For Each obj As clsRecord In lst
            blRecord.Add(obj)
        Next

    End Sub

End Class
