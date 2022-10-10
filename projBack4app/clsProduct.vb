Imports Newtonsoft.Json

Public Class clsProduct

    Public Property objectId As String
    Public Property itemnum As String
    ' itemname is english name of product
    Public Property itemname As String
    ' itemname2 is chinese name of product
    Public Property itemname2 As String
    Public Property itemprice As Decimal
    Public Property itemuom As String
    Public Property itemstandardweight As Int32


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

    Public Function mySerialize() As String

        Dim obj As New clsProduct With
        {
            .objectId = objectId,
            .itemnum = itemnum,
            .itemname = itemname,
            .itemname2 = itemname2,
            .itemprice = itemprice,
            .itemuom = itemuom,
            .itemstandardweight = itemstandardweight
        }
        Return JsonConvert.SerializeObject(obj)

    End Function

End Class

