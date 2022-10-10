Imports System.Net
Imports Newtonsoft.Json

Public Class dlgProduct

    Private mapUom As Dictionary(Of Int16, String)
    ' operation is either [show, add, edit]
    Private m_operation As String
    ' For operation show or edit, the obj should not be nothing!
    Private m_obj As clsProduct
    ' This resulting object is returned to main form if post or put is successful
    Private m_objResult As clsProduct

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_operation = ""
        m_obj = Nothing
        mapUom = New Dictionary(Of Short, String)
        mapUom.Add(0, "Choose uom...")
        mapUom.Add(1, "100g")
        mapUom.Add(2, "kg")
        mapUom.Add(3, "gram")
        cbxUom.Items.Clear()

        For Each key_1 As Int16 In mapUom.Keys
            Dim val_1 As String = ""
            mapUom.TryGetValue(key_1, val_1)
            cbxUom.Items.Add(val_1)
        Next
        cbxUom.SelectedIndex = 0
    End Sub

    Public Sub setOperation(op As String)
        m_operation = op.ToLower
        Select Case m_operation
            Case "show"
                lblTitle.Text = "Show Product"
                MakeUIReadOnly()
            Case "add"
                lblTitle.Text = "Add Product"
            Case "edit"
                lblTitle.Text = "Edit Product"
            Case Else
                Me.Close()
        End Select
    End Sub

    Public Sub setObject(ByRef o As clsProduct)
        m_obj = o
        fillTheUi()
    End Sub

    Public Function getResultingObject() As clsProduct
        Return m_objResult
    End Function

    Private Sub dlgProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If m_operation = "add" Then
            Dim isposted As Boolean = Await postProductData()
            If isposted = True Then
                Me.DialogResult = DialogResult.OK
            End If
        End If

    End Sub

    Private Function fillTheUi() As Boolean
        If m_obj Is Nothing Then
            Return False
        End If
        If m_operation = "add" Then
            ' add by copied object
            txtObjectId.Text = ""
            txtItemnum.Text = ""
        Else
            txtObjectId.Text = m_obj.objectId
            txtItemnum.Text = m_obj.itemnum
        End If
        ' txtObjectId.Text = m_obj.objectId
        ' txtItemnum.Text = m_obj.itemnum
        txtDesc.Text = m_obj.itemname
        txtDesc2.Text = m_obj.itemname2
        cbxUom.SelectedIndex = getKeyFromValue(m_obj.itemuom)
        txtStdWeight.Text = m_obj.itemstandardweight
        txtPrice.Text = m_obj.itemprice
        Return True
    End Function

    Private Sub MakeUIReadOnly()
        txtObjectId.Enabled = False
        txtItemnum.Enabled = False
        txtDesc.Enabled = False
        txtDesc2.Enabled = False
        cbxUom.SelectedIndex = getKeyFromValue(m_obj.itemuom)
        cbxUom.Enabled = False
        txtStdWeight.Enabled = False
        txtPrice.Enabled = False
    End Sub

    Private Function getKeyFromValue(val As String) As Int32
        Dim val_1 As String = ""
        For Each key_1 As Int32 In mapUom.Keys
            If mapUom.TryGetValue(key_1, val_1) = True Then
                If val_1 = val Then
                    Return key_1
                End If
            End If
        Next
        Return 0
    End Function



    Private Async Function postProductData() As Task(Of Boolean)

        ' using TLS 1.2
        System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)
        Dim myurl As String = "https://parseapi.back4app.com/classes/Product"
        Dim objProduct As New clsProduct With
        {
            .itemnum = txtItemnum.Text,
            .itemname = txtDesc.Text,
            .itemname2 = txtDesc2.Text,
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
            JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)
            ' {"objectId":"QCZJdyiTFi","createdAt":"2022-10-03T01:55:03.254Z"}
            Dim newObjectId As String = ""
            jsonResultToDict.TryGetValue("objectId", newObjectId)
            m_objResult = New clsProduct With
            {
                .objectId = newObjectId,
                .itemname = objProduct.itemname,
                .itemname2 = objProduct.itemname2,
                .itemuom = objProduct.itemuom,
                .itemstandardweight = objProduct.itemstandardweight,
                .itemprice = objProduct.itemprice
            }
            Dim msgPrompt As String = "New record with objectId: " & newObjectId & " is added"
            Dim msgTitle As String = "New Record Added"
            MsgBox(msgPrompt, MsgBoxStyle.Information, msgTitle)
            Return True
        Catch ex As Exception
            Console.WriteLine("dlgProductAdd.postProductData: " & vbCrLf & ex.Message)
            Return False
        End Try
        'Dim sendData As String = 

    End Function

End Class