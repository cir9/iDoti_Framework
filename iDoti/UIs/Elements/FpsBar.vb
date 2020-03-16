
Imports SharpDX.DirectWrite
Imports RectF = SharpDX.Mathematics.Interop.RawRectangleF
Public Class FpsBar
    Inherits BindOutlineTextBar

    Public Sub New(size As Vec2)
        TextFormat = CreateTextFormat("Consolas", 16.0F)
        TextFormat.ParagraphAlignment = ParagraphAlignment.Far
        TextFormat.TextAlignment = TextAlignment.Trailing
        LayoutRect = New RectF(size.X - 100, size.Y - 100,
                               size.X, size.Y)
        Color = brush_White
        OutlineColor = New ColorBoard("0f70ae")
        StrokeWidth = 1.5F
    End Sub

End Class
