
Public MustInherit Class Approacher(Of T)

    Protected Function PaddingToAPS(padding As Single) As Single
        Return (1 - 1 / padding) ^ 60
    End Function
    Public MustOverride Sub Update()
End Class

Public Class FloatApproacher
    Inherits Approacher(Of Single)

    Public NowValue As Single
    Public TargetValue As Single
    Public ApproachPerSecond As Single
    Public Sub New(n As Single, t As Single, aps As Single)
        NowValue = n
        TargetValue = t
        ApproachPerSecond = PaddingToAPS(aps)
    End Sub
    Public Overrides Sub Update()
        Dim apv As Single = ApproachPerSecond ^ DeltaTime
        NowValue = NowValue * apv + TargetValue * (1 - apv)
    End Sub
End Class

Public Class Vec2Approacher
    Inherits Approacher(Of Vec2)

    Public NowValue As Vec2
    Public TargetValue As Vec2
    Public ApproachPerSecond As Single
    Public Sub New(aps As Single)
        ApproachPerSecond = PaddingToAPS(aps)
    End Sub
    Public Sub New(n As Vec2, t As Vec2, aps As Single)
        NowValue = n
        TargetValue = t
        ApproachPerSecond = PaddingToAPS(aps)
    End Sub
    Public Overrides Sub Update()
        Dim apv As Single = ApproachPerSecond ^ DeltaTime
        NowValue = NowValue * apv + TargetValue * (1 - apv)
    End Sub
End Class
