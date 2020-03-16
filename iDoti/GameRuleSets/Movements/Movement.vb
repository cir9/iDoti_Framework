
Imports iDoti
Imports SharpDX.Mathematics.Interop


Public MustInherit Class Movement

    Public Position As Vec2

    Public MustOverride Function IsInRange(r As Rect4, rad As Single) As Boolean
    Public MustOverride Function Clone() As Movement
    Public MustOverride Sub Update()
    Public MustOverride Sub Update(dt As Single)

End Class


Public Class NullMovement
    Inherits Movement

    Public Overrides Sub Update()
    End Sub

    Public Overrides Sub Update(dt As Single)
    End Sub

    Public Overrides Function IsInRange(r As Rect4, rad As Single) As Boolean
        Return True
    End Function

    Public Overrides Function Clone() As Movement
        Return New NullMovement
    End Function
End Class


Public Class SimpleMovement
    Inherits Movement

    Public Speed As Vec2
    Public Sub New(p As Vec2, v As Vec2)
        Position = p
        Speed = v
    End Sub

    Public Sub New(v As Vec2)
        Speed = v
    End Sub

    Public Overrides Function Clone() As Movement
        Return New SimpleMovement(Position, Speed)
    End Function

    Public Overrides Sub Update()
        Position += Speed * DeltaTime
    End Sub
    Public Overrides Sub Update(dt As Single)
        Position += Speed * dt
    End Sub

    Public Overrides Function IsInRange(r As Rect4, rad As Single) As Boolean
        Return InRange(r.Left, r.Right, Position.X, Speed.X, rad) AndAlso
               InRange(r.Top, r.Bottom, Position.Y, Speed.Y, rad)
    End Function
End Class