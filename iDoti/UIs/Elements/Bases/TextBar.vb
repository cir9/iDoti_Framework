Imports iDoti
Imports SharpDX.Direct2D1
Imports DDW = SharpDX.DirectWrite
Imports RectF = SharpDX.Mathematics.Interop.RawRectangleF

Public Class TextBar
    Inherits UIElement
    Public Overridable Property Color As ColorBoard '= brush_White
    Public Overridable Property Text As String

    Public TextFormat As DDW.TextFormat = debug_format

    Public Overrides Sub Draw(R As RenderTarget)
        R.DrawText(Text, TextFormat, LayoutRect, Color.Brush)
    End Sub

    Public Overrides Sub Update()

    End Sub
End Class

Public Class OutlineTextBar
    Inherits TextBar

    Private renderer As New OutlineTextRenderer()
    Public Overrides Property Color As ColorBoard
        Get
            Return renderer.FillColor
        End Get
        Set(value As ColorBoard)
            renderer.FillColor = value
        End Set
    End Property
    Public Property OutlineColor As ColorBoard
        Get
            Return renderer.OutlineColor
        End Get
        Set(value As ColorBoard)
            renderer.OutlineColor = value
        End Set
    End Property
    Public Property StrokeWidth As Single
        Get
            Return renderer.StrokeWidth
        End Get
        Set(value As Single)
            renderer.StrokeWidth = value
        End Set
    End Property

    Public Layout As DDW.TextLayout

    Public Overrides Sub Draw(R As RenderTarget)
        renderer.BeginDraw(R)
        Layout.Draw(renderer, LayoutRect.Left, LayoutRect.Top)
    End Sub
    Public Overrides Sub Update()
        Layout?.Dispose()
        Layout = New DDW.TextLayout(DDWFactory, Text, TextFormat,
                                    LayoutRect.Right - LayoutRect.Left,
                                    LayoutRect.Bottom - LayoutRect.Top)
    End Sub
End Class

Public Class BindTextBar
    Inherits TextBar

    Public BindText As Customable(Of String)
    Public Overrides Property Text As String
        Get
            Return BindText
        End Get
        Set(value As String)
            BindText = value
        End Set
    End Property
    Public Property LambdaText As Func(Of String)
        Get
            Return BindText.Lambda
        End Get
        Set(value As Func(Of String))
            BindText = value
        End Set
    End Property
End Class

Public Class BindOutlineTextBar
    Inherits OutlineTextBar

    Public BindText As Customable(Of String)
    Public Overrides Property Text As String
        Get
            Return BindText
        End Get
        Set(value As String)
            BindText = value
        End Set
    End Property
    Public Property LambdaText As Func(Of String)
        Get
            Return BindText.Lambda
        End Get
        Set(value As Func(Of String))
            BindText = value
        End Set
    End Property
End Class