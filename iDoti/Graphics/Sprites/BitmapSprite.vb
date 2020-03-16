


Imports SharpDX.Direct2D1




Public Class BitmapSprite
    Inherits Sprite

    Private _radius As Single
    Public Overrides Property Radius As Single
        Get
            Return _radius
        End Get
        Set(value As Single)
            Dim scaling As Single = value / (SourceSize.Sum(0.25F) * Me.Scaling)
            Size = SourceSize * scaling
            _radius = value
        End Set
    End Property

    Public Scaling As Single = 1.0F

    Public Overrides Property Size As Vec2

    Public Overrides ReadOnly Property SourceSize As Vec2
        Get
            Return Bitmap.Size
        End Get
    End Property

    Public Bitmap As Bitmap


    Public Overrides Sub Draw(R As RenderTarget)
        TransformManager.Deploy(R, Me)
        R.DrawBitmap(Bitmap, 1, BitmapInterpolationMode.Linear)
        If IsGraphicsDebugging Then
            TransformManager.Restore(R)
            R.DrawEllipse(New Ellipse(Position, Radius, Radius), debug_brush)
        End If
    End Sub

    Public Overrides Function HitTest(pos As Vec2) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
