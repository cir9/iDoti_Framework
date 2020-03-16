



Imports iDoti
Imports SharpDX.Direct2D1
Imports DDW = SharpDX.DirectWrite
Imports RectF = SharpDX.Mathematics.Interop.RawRectangleF



Public MustInherit Class UIElement
    Implements IDrawable, ICleanable

    Public LayoutRect As RectF

    Public Parallax As Single

    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage

    Public MustOverride Sub Draw(R As RenderTarget) Implements IDrawable.Draw


    Public MustOverride Sub Update() Implements ICleanable.Update
End Class




