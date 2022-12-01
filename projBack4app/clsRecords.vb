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

    ' The input date MUST be in format yyyyMMdd
    Private Function getParam(i_date As Date) As String
        'Dim str As String = i_date.Substring(0, 4) & "-" & i_date.Substring(4, 6) & i_date.Substring(6)
        'Dim today_1 As Date = i_date
        Dim tomorrow_1 As Date = i_date.AddDays(1)
        Dim strtoday As String = i_date.Day.ToString.PadLeft(2, "0"c) & "/" &
            i_date.Month.ToString.PadLeft(2, "0"c) & "/" &
            i_date.Year.ToString.PadLeft(4, "0"c) & " 00:00:00+8:00"
        Dim strTomorrow As String = tomorrow_1.Day.ToString.PadLeft(2, "0"c) & "/" &
            tomorrow_1.Month.ToString.PadLeft(2, "0"c) & "/" &
            tomorrow_1.Year.ToString.PadLeft(4, "0"c) & " 00:00:00+8:00"
        Dim jobj_1 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
        jobj_1.Add("$gte", strtoday)
        jobj_1.Add("$lt", strTomorrow)
        Dim jobj_2 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
        jobj_2.Add("packingdt", jobj_1)
        Dim strOutput As String = jobj_2.ToString(Json.Formatting.None)
        Diagnostics.Debug.WriteLine(strOutput)
        Return strOutput
    End Function

    ' the input date MUST be in Date type
    Public Function getRecords(whichdate As Date) As Boolean
        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Production?" &
            "where=" & getParam(whichdate) & "&order=itemnum"
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
