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

    Public Function getRecords(whichdate As String) As Boolean

        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Production?" &
            String.Format("where={""packingdt"":{""{0}gt"":""{1}"",""{2}lt"":""{3}""}}",
                          Chr(36), "23/11/2022 00:00:00+08:00", Chr(36), "24/11/2022 00:00:00+08:00")
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
