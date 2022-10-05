Imports System.Text
Imports Newtonsoft.Json

Module modCommon

    Public Const AppId As String = "5vUD5SzypdFDZfa7Sxjya1yLliHMAJ52ML3sqBf6"

    Public Const RestApiKey As String = "sgyDDR9YYlvTfkZv1datnUu75nhnnjqejm2yMFNL"

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
