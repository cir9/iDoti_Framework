
Imports iDoti

Imports SharpDX.Direct2D1

Public MustInherit Class DotTemplate
    Public MustOverride Function Create() As Dot
End Class

Public Class RoundDotTemplate
    Inherits DotTemplate

    Public ColorBoard As ColorBoard
    Public Radius As Single

    Public Property Color As Color
        Get
            Return ColorBoard.Color
        End Get
        Set(value As Color)
            ColorBoard.Color = value
            ColorBoard.UpdateBrush()
        End Set
    End Property

    Public Overrides Function Create() As Dot
        Return New Dot() With {
            .Sprite = New RoundSprite() With {.Color = ColorBoard},
            .Size = Radius
            }
    End Function

    Public Sub New(color As Color, radius As Single)
        ColorBoard = New ColorBoard(color)
        Me.Radius = radius
    End Sub
End Class

Public Class BitmapDotTemplate
    Inherits DotTemplate

    Public Bitmap As Bitmap
    Public Radius As Single
    Public Scaling As Single
    Public Overrides Function Create() As Dot
        Return New Dot() With {
            .Sprite = New BitmapSprite() With {.Bitmap = Bitmap, .Scaling = Scaling},
            .Size = Radius}
    End Function

    Public Sub New(bitmap As Bitmap, scaling As Single, radius As Single)
        Me.Bitmap = bitmap
        Me.Scaling = scaling
        Me.Radius = radius
    End Sub

End Class
