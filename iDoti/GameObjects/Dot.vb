



Imports iDoti

Public Class Dot
    Inherits GameObject(Of Dot)



    Public Stage As Stage

    Public EaseInAnimation As New DotZoomAnimation(0.1, Ease.Linear.Ease, Me)



    Public Function IsInRange(r As Rect4) As Boolean
        Return InRange(r.Left, r.Right, Sprite.Position.X, Speed.X, Sprite.Radius) AndAlso
               InRange(r.Top, r.Bottom, Sprite.Position.Y, Speed.Y, Sprite.Radius)
    End Function



    Public Sub DeployFinished(stage As Stage)
        Me.Stage = stage
        stage.StartAnimation(EaseInAnimation)
        Timeline?.Start()
    End Sub

    Public Overrides Sub Update(dt As Single)
        Position += Speed * dt
        Direction = Speed
        Timeline?.Update(dt)
    End Sub
End Class



