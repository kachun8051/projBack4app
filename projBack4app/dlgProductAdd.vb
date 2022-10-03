Imports System.Net
Imports Newtonsoft

Public Class dlgProductAdd

    Private mapUom As Dictionary(Of Int16, String)

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Await postProductData()
    End Sub

    Private Sub dlgProductAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mapUom = New Dictionary(Of Short, String)
        mapUom.Add(0, "Choose uom...")
        mapUom.Add(1, "100 g")
        mapUom.Add(2, "kg")
        mapUom.Add(3, "gram")
        cbxUom.Items.Clear()

        For Each key_1 As Int16 In mapUom.Keys
            Dim val_1 As String = ""
            mapUom.TryGetValue(key_1, val_1)
            cbxUom.Items.Add(val_1)
        Next

    End Sub

    Private Async Function postProductData() As Task(Of Boolean)

        ' using TLS 1.2
        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product"
        Dim objProduct As New clsProduct With
        {
            .itemnum = txtItemnum.Text,
            .itemname = txtDesc.Text,
            .itemuom = cbxUom.Text,
            .itemstandardweight = txtStdWeight.Text,
            .itemprice = txtPrice.Text
        }
        Dim isValid As Boolean = objProduct.isValidated()
        If isValid = False Then
            Return False
        End If
        Dim web As New WebClient
        web.Headers.Add(HttpRequestHeader.Accept, "application/json")
        web.Headers.Add(HttpRequestHeader.ContentType, "application/json")
        web.Headers.Add("X-Parse-Application-Id", modCommon.AppId)
        web.Headers.Add("X-Parse-REST-API-Key", modCommon.RestApiKey)
        Try
            Dim response As String = Await web.UploadStringTaskAsync(myurl, objProduct.mySerialize)
            Dim jsonResultToDict As Dictionary(Of String, String) =
                Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)
            ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
            Dim newObjectId As String = ""
            jsonResultToDict.TryGetValue("objectId", newObjectId)
            MsgBox("New record with objectId: " & newObjectId & " is added", "New Record Added")
            Return True
        Catch ex As Exception
            Console.WriteLine("dlgProductAdd.postProductData: " & vbCrLf & ex.Message)
            Return False
        End Try
        'Dim sendData As String = 

    End Function

End Class