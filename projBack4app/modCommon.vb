Imports System.Text
Imports Newtonsoft.Json

Module modCommon

    Public Const AppId As String = "5vUD5SzypdFDZfa7Sxjya1yLliHMAJ52ML3sqBf6"

    Public Const RestApiKey As String = "sgyDDR9YYlvTfkZv1datnUu75nhnnjqejm2yMFNL"

    Public Function FirstDayOfMonth(dt As Date) As Date
        Dim dtFirst As Date = New Date(dt.Year, dt.Month, 1)
        Return dtFirst
    End Function

    Public Function LastDayOfMonth(dt As Date) As Date
        Dim dtFirst As Date = New Date(dt.Year, dt.Month, 1)
        Dim dtLast As Date = dtFirst.AddMonths(1).AddDays(-1)
        Return dtLast
    End Function

    Public Function FirstDayOfWeek(dt As Date) As Date
        ' Sunday is 0, Monday is 1, and so on
        Dim dtMonday As Date = dt
        For i As Int16 = 0 To 6
            If dtMonday.DayOfWeek = 1 Then
                Exit For
            End If
            dtMonday = dtMonday.AddDays(-1)
        Next
        Return dtMonday
    End Function

    Public Function LastDayOfWeek(dt As Date) As Date
        ' Sunday is 0, Monday is 1, and so on
        Dim dtSunday As Date = dt
        For i As Int16 = 0 To 6
            If dtSunday.DayOfWeek = 0 Then
                Exit For
            End If
            dtSunday = dtSunday.AddDays(1)
        Next
        Return dtSunday
    End Function

    ' Return positive or negative number
    Public Function getTimeZone() As Int32
        Dim tzi As TimeZoneInfo = TimeZoneInfo.Local
        Dim offset As TimeSpan = tzi.BaseUtcOffset
        Return offset.Hours
    End Function

    'Public Function ReadTheProductList() As Boolean
    '    Try
    '        Dim json As String = File.ReadAllText(pathOfMenu & "\labels.json")
    '        If json.IndexOf("lstMenu") = -1 Then 'Not found
    '            Dim objSF As New StringBuilder
    '            objSF.Append("{""lstMenu"":")
    '            objSF.Append(json)
    '            objSF.Append("}")
    '            json = objSF.ToString
    '        End If
    '        If objJMenu IsNot Nothing Then
    '            objJMenu = Nothing
    '        End If
    '        objJMenu = JsonConvert.DeserializeObject(Of clsJMenu)(json)
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function


End Module
