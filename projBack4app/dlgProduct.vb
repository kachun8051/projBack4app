Imports System.Net
Imports Newtonsoft.Json

Public Class dlgProduct

    Private mapUom As Dictionary(Of Int16, String)
    Private mapUom2 As Dictionary(Of Int16, Int32)
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

        mapUom = New Dictionary(Of Short, String) From
            {{0, "Choose uom..."}, {1, "100g"}, {2, "kg"}, {3, "gram"}}
        mapUom2 = New Dictionary(Of Short, Int32) From
            {{0, 0}, {1, 100}, {2, 1000}, {3, 1}}
        txtUom2.Enabled = False
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
            Dim isposted As Boolean = Await TryInsertProduct()
            If isposted = True Then
                Me.DialogResult = DialogResult.OK
            End If
            Return
        End If
        If m_operation = "edit" Then
            Dim isput As Boolean = Await TryEditProduct()
            If isput = True Then
                Me.DialogResult = DialogResult.OK
            End If
            Return
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
        If m_obj Is Nothing Then
            cbxUom.SelectedIndex = 0
        Else
            cbxUom.SelectedIndex = getKeyFromValue(m_obj.itemuom)
        End If
        cbxUom.Enabled = False
        txtUom2.Enabled = False
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

    Private Async Function TryInsertProduct() As Task(Of Boolean)

        Dim objProduct As New clsProduct With
        {
            .itemnum = txtItemnum.Text,
            .itemname = txtDesc.Text,
            .itemname2 = txtDesc2.Text,
            .itemuom = cbxUom.Text,
            .itemuom2 = txtUom2.Text,
            .itemstandardweight = txtStdWeight.Text,
            .itemprice = txtPrice.Text
        }
        Dim isValid As Boolean = objProduct.isValidated()
        If isValid = False Then
            Return False
        End If
        If frmMain.objProducts Is Nothing Then
            Return False
        End If
        Dim json As String = objProduct.mySerialize
        Dim ret As Boolean = Await frmMain.objProducts.postProductData(json)
        Dim newObjectId As String = frmMain.objProducts.newobjectId
        ' Assign the resulting clsProduct
        m_objResult = New clsProduct With
        {
            .objectId = newObjectId,
            .itemnum = objProduct.itemnum,
            .itemname = objProduct.itemname,
            .itemname2 = objProduct.itemname2,
            .itemuom = objProduct.itemuom,
            .itemuom2 = objProduct.itemuom2,
            .itemstandardweight = objProduct.itemstandardweight,
            .itemprice = objProduct.itemprice
         }
        Return ret

    End Function

    Private Async Function TryEditProduct() As Task(Of Boolean)
        ' Edit object with objectId
        Dim objProduct As New clsProduct With
        {
            .objectId = txtObjectId.Text,
            .itemnum = txtItemnum.Text,
            .itemname = txtDesc.Text,
            .itemname2 = txtDesc2.Text,
            .itemuom = cbxUom.Text,
            .itemuom2 = txtUom2.Text,
            .itemstandardweight = txtStdWeight.Text,
            .itemprice = txtPrice.Text
        }
        Dim isValid As Boolean = objProduct.isValidated()
        If isValid = False Then
            Return False
        End If
        Dim json As String = objProduct.mySerialize
        Dim ret As Boolean = Await frmMain.objProducts.putProductData(json)
        If ret Then
            ' Assign the resulting clsProduct
            m_objResult = New clsProduct With
            {
                .objectId = objProduct.objectId,
                .itemnum = objProduct.itemnum,
                .itemname = objProduct.itemname,
                .itemname2 = objProduct.itemname2,
                .itemuom = objProduct.itemuom,
                .itemuom2 = objProduct.itemuom2,
                .itemstandardweight = objProduct.itemstandardweight,
                .itemprice = objProduct.itemprice
             }
        End If
        Return ret
    End Function

    Private Sub cbxUom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxUom.SelectedIndexChanged
        Dim idx As Integer = cbxUom.SelectedIndex
        Dim val As Int32 = 0
        mapUom2.TryGetValue(idx, val)
        If val = 0 Then
            txtUom2.Text = ""
        Else
            txtUom2.Text = val
        End If
    End Sub
End Class