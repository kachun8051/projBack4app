Imports Newtonsoft.Json

Public Class clsProduct
    Public Property objectId As String
    Public Property itemnum As String
    ' itemname is english name of product
    Public Property itemname As String
    ' itemname2 is chinese name of product
    Public Property itemname2 As String
    Public Property itemuom As String
    Public Property itemuom2 As Int32
    ' itemuom2 is equivalent gram of itemuom
    ' For example, itemuom is 100g. Then itemuoms is 100
    ' itemuom is 1kg. Then itemuom2 is 1000
    Public Property itemstandardweight As Int32
    Public Property itemprice As Decimal

    Public Function isValidated() As Boolean

        If itemnum.Length <> 6 Then
            Return False
        End If
        If IsNumeric(itemnum) = False Then
            Return False
        End If
        If itemname.Length < 10 Then
            Return False
        End If
        If IsNumeric(itemprice) = False Then
            Return False
        End If
        Return True

    End Function

    'Public Function myLinearize() As String
    '    ' Linearize is similiar to Serialize 
    '    ' Linearize NOT includes objectId
    '    ' Linearize is used for post or put
    '    Dim obj As New clsProduct With
    '    {
    '        .itemnum = itemnum,
    '        .itemname = itemname,
    '        .itemprice = itemprice,
    '        .itemuom = itemuom,
    '        .itemstandardweight = itemstandardweight
    '    }
    '    Try
    '        Dim json As String = JsonConvert.SerializeObject(obj)
    '        Return json
    '    Catch ex As Exception
    '        ' Null object
    '        Return "{}"
    '    End Try
    'End Function

    Public Function mySerialize() As String

        Dim obj As New clsProduct With
        {
            .objectId = objectId,
            .itemnum = itemnum,
            .itemname = itemname,
            .itemname2 = itemname2,
            .itemprice = itemprice,
            .itemuom = itemuom,
            .itemuom2 = itemuom2,
            .itemstandardweight = itemstandardweight
        }
        Try
            Dim json As String = JsonConvert.SerializeObject(obj)
            Return json
        Catch ex As Exception
            ' Null object
            Return "{}"
        End Try

    End Function

    Public Function myDeserialize(ByVal json As String) As Boolean
        Try
            Dim obj As clsProduct = JsonConvert.DeserializeObject(Of clsProduct)(json)
            With obj
                objectId = .objectId
                itemnum = .itemnum
                itemname = .itemname
                itemname2 = .itemname2
                itemprice = .itemprice
                itemuom = .itemuom
                itemuom2 = .itemuom2
                itemstandardweight = .itemstandardweight
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class

