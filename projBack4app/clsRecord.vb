Public Class clsRecord
    Public Property objectId As String
    Public Property objProduct As clsProduct
    Public Property weightInGram As Decimal
    Public Property sellingPrice As Decimal
    Public Property barcode As String
    Public Property packingDt As String

    Public Function mySerialize() As String

    End Function

    Public Function myDeserialize(ByVal json As String) As Boolean

    End Function

End Class
