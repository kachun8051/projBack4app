Imports Newtonsoft

Public Class clsProduct
    Public Property itemnum As String
    Public Property itemname As String
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
            .itemnum = itemnum,
            .itemname = itemname,
            .itemprice = itemprice,
            .itemuom = itemuom,
            .itemstandardweight = itemstandardweight
        }
        Return Newtonsoft.Json.JsonConvert.SerializeObject(obj)

    End Function

End Class

