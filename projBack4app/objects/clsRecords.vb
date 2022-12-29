Imports System.ComponentModel
Imports System.Net
Imports Newtonsoft

Public Class clsRecords

    Public Event ListFilledDone(ByVal isSuccess As Boolean)

    Public Event RangeListFilledDone(ByVal isSuccess As Boolean)

    ' blRecord is the data source of datagridview i.e. dgvProductionRecord
    ' Any change(s) to this list would automatically update datagridview i.e. data-binding
    Public Property blRecord As BindingList(Of clsRecord)
    Public Property newobjectId As String

    Public Sub New()
        blRecord = New BindingList(Of clsRecord)
        newobjectId = ""
    End Sub

    Private Function getISODate(i_date As Date) As String
        Dim timeZoneHour As Int32 = modCommon.getTimeZone
        Dim strdt As String = i_date.Year.ToString.PadLeft(4, "0"c) & "-" &
            i_date.Month.ToString.PadLeft(2, "0"c) & "-" &
            i_date.Day.ToString.PadLeft(2, "0"c)
        Dim dt As Date = DateTime.Parse(strdt)
        dt = dt.AddHours(-timeZoneHour)
        Dim dt_1 As String = dt.ToString("yyyy-MM-dd HH:mm:ss").Replace(" ", "T") & "Z"
        Diagnostics.Debug.WriteLine("ISO Date: " & dt_1)
        Return dt_1
    End Function

    Private Function getParam(i_date As Date) As String
        Dim jobj_1a As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
            {"__type", "Date"},
            {"iso", getISODate(i_date)}
        }
        Dim jobj_1b As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
            {"__type", "Date"},
            {"iso", getISODate(i_date.AddDays(1))}
        }
        Dim jobj_1 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
            {"$gte", jobj_1a},
            {"$lt", jobj_1b}
        }
        Dim jobj_2 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
            {"packedAt", jobj_1}
        }
        Dim strOutput As String = jobj_2.ToString(Json.Formatting.None)
        Diagnostics.Debug.WriteLine(strOutput)
        Return strOutput
    End Function

    Private Function getParams(i_from As Date, i_to As Date) As String

        If isTwoDatesEqual(i_from, i_to) Then
            Return getParam(i_from)
        Else
            Dim jobj_3F As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
                {"__type", "Date"},
                {"iso", getISODate(i_from)}
            }
            Dim jobj_3T As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
                {"__type", "Date"},
                {"iso", getISODate(i_to)}
            }
            Dim jobj_1 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
                {"$gte", jobj_3F},
                {"$lt", jobj_3T}
            }
            Dim jobj_2 As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject From {
                {"packedAt", jobj_1}
            }
            Dim strOutput As String = jobj_2.ToString(Json.Formatting.None)
            Diagnostics.Debug.WriteLine(strOutput)
            Return strOutput
        End If

    End Function

    ' the input date MUST be in Date type
    Public Function getRecords(whichdate As Date) As Boolean
        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Production?" &
            "where=" & getParam(whichdate) & "&order=pickedAt"
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

    ' https://stackoverflow.com/questions/30327847/how-to-pass-current-date-to-a-curl-query-using-shell-script
    Public Function getRangeRecords(fromdate As Date, todate As Date) As Boolean
        ' using TLS 1.2
        ' System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Production?" &
            "where=" & getParams(fromdate, todate) & "&order=pickedAt"
        Diagnostics.Debug.WriteLine("Url: " & myurl)
        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        web.Encoding = System.Text.Encoding.UTF8
        'Add the event handler here
        AddHandler web.DownloadStringCompleted, AddressOf webClient_DownloadStringCompleted2
        Try
            Dim objuri As Uri = New Uri(myurl)
            web.DownloadStringAsync(objuri)
            Return True
        Catch ex As Exception
            Console.WriteLine("clsRecords.getRangeRecords: " & vbCrLf & ex.Message)
            RaiseEvent RangeListFilledDone(False)
            Return False
        End Try
    End Function

    Private Function isTwoDatesEqual(dt1 As Date, dt2 As Date) As Boolean
        If dt1.Year <> dt2.Year Then
            Return False
        End If
        If dt1.Month <> dt2.Month Then
            Return False
        End If
        If dt1.Day <> dt2.Day Then
            Return False
        End If
        Return True
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

    Private Sub webClient_DownloadStringCompleted2(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)
        Console.WriteLine(e.Result)
        Dim lstData As List(Of clsRecord) = Nothing
        Dim jsonResultToDict As Dictionary(Of String, List(Of clsRecord)) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of clsRecord)))(e.Result)
        jsonResultToDict.TryGetValue("results", lstData)
        ConvertToBindingList(lstData)
        Console.WriteLine("Event is triggered")
        RaiseEvent RangeListFilledDone(True)
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
