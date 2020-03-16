Imports iDoti
Imports Matrix3x2 = SharpDX.Mathematics.Interop.RawMatrix3x2



Public MustInherit Class TransformAnimation
    Inherits Animation(Of UIElement)

    Public Transform As Matrix3x2

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub


    Public Overrides Sub Update()

    End Sub
End Class

Public Class ZoomAnimation
    Inherits TransformAnimation

    Public BeginZoom As Single
    Public EndZoom As Single
    Public NowZoom As Single

    Protected Overrides Sub OnStart()
        NowZoom = BeginZoom
    End Sub
    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Protected Overrides Sub OnEnd(e As UIElement)
        NowZoom = EndZoom
    End Sub
    Protected Overrides Sub Animate(e As UIElement, t As Single)
        NowZoom = BeginZoom * (1 - t) + EndZoom * t
        Dim r = e.LayoutRect
        Transform = Transforms.Zoom(NowZoom,
                                    (r.Left + r.Right) * 0.5F,
                                    (r.Top + r.Bottom) * 0.5F)
    End Sub

End Class

Public Class ImpactAnimation
    Inherits ZoomAnimation

    Public Impacter As New Impacter(4, 2.5)

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
        NowZoom = 1.0F
    End Sub

    Public Sub Increase(v As Single)
        BeginZoom = Impacter.Increase(v, NowZoom)
        Start()
    End Sub

End Class



