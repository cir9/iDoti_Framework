

Imports SharpDX.Direct2D1


Public Class RoundSprite
    Inherits GeometricSprite

    Public Overrides Property Radius As Single
        Get
            Return Ellipse.RadiusX
        End Get
        Set(value As Single)
            Ellipse.RadiusX = value
            Ellipse.RadiusY = value
        End Set
    End Property

    Public Overrides Property Size As Vec2
        Get
            Return New Vec2(Ellipse.RadiusX, Ellipse.RadiusY)
        End Get
        Set(value As Vec2)
            Ellipse.RadiusX = value.X
            Ellipse.RadiusY = value.Y
        End Set
    End Property


    Public Ellipse As Ellipse
    Public Overrides Sub Draw(R As RenderTarget)
        TransformManager.Restore(R)
        Ellipse.Point = Position
        R.FillEllipse(Ellipse, Color.Brush)
    End Sub

    Public Overrides Function HitTest(pos As Vec2) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
