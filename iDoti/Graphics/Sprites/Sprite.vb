

Imports SharpDX.Direct2D1


Imports iDoti
Public MustInherit Class Sprite
    Implements IDrawable

    Public Position As Vec2
    Public Direction As Vec2


    Public MustOverride Property Size As Vec2
    Public MustOverride Property Radius As Single
    Public MustOverride ReadOnly Property SourceSize As Vec2

    Public MustOverride Sub Draw(R As RenderTarget) Implements IDrawable.Draw

    Public MustOverride Function HitTest(pos As Vec2) As Boolean
End Class


Public MustInherit Class GeometricSprite
    Inherits Sprite

    Public Color As ColorBoard
    Public Overrides ReadOnly Property SourceSize As Vec2
        Get
            Return Size
        End Get
    End Property
End Class

