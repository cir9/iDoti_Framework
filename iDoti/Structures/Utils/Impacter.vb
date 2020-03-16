


Public Structure Impacter

    Public MaxValue As Single

    Public PaddingValue As Single

    Public Sub New(p As Single, m As Single)
        MaxValue = m
        PaddingValue = p
    End Sub

    Public Function Increase(v As Single, n As Single) As Single
        Return LimitedIncrease(n, MaxValue, v, PaddingValue)
    End Function

End Structure
