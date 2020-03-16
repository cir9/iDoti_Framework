Imports iDoti
Imports SharpDX.Direct2D1




Public MustInherit Class GameObject(Of T)
    Implements IDrawable, ICleanable

    Public Timeline As Timeline(Of T)

    Public Sprite As Sprite

    Public Property Position As Vec2
        Get
            Return Sprite.Position
        End Get
        Set(value As Vec2)
            Sprite.Position = value
        End Set
    End Property

    Public Speed As Vec2
    Public Property Direction As Vec2
        Get
            Return Sprite.Direction
        End Get
        Set(value As Vec2)
            Sprite.Direction = value
        End Set
    End Property
    Public Property Size As Single
        Get
            Return Sprite.Radius
        End Get
        Set(value As Single)
            Sprite.Radius = value
        End Set
    End Property


    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage
    Public Overridable Sub Draw(R As RenderTarget) Implements IDrawable.Draw
        Sprite.Draw(R)
    End Sub
    Public Overridable Sub Update() Implements ICleanable.Update
        Update(DeltaTime)
    End Sub
    Public MustOverride Sub Update(dt As Single)

End Class
