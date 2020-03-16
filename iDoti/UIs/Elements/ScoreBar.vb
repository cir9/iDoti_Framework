


Imports SharpDX.Direct2D1
Imports DDW = SharpDX.DirectWrite
Imports RectF = SharpDX.Mathematics.Interop.RawRectangleF



Public Class ScoreBar
    Inherits BindTextBar


    Public Impact As New ImpactAnimation(0.4, Ease.Back.EaseOut) With {.BeginZoom = 2, .EndZoom = 1}

    Public ImpactColor As ImpactColorBoard




    Public Overrides Sub Draw(R As RenderTarget)
        If Impact.IsRunning Then

            TransformManager.Deploy(R, Impact.Transform)
            MyBase.Draw(R)
            TransformManager.Restore(R)
        Else
            MyBase.Draw(R)
        End If


    End Sub


    Public Sub PointIncrease(v As Single)
        Impact.Increase(v)
        ImpactColor.Increase(v)
    End Sub


    Public Overrides Sub Update()
        MyBase.Update()
        If Impact.IsRunning Then Impact.Update(Me)

        DebugPrintf("Zoom: {0:0.000}x ({1:0.000}x)", Impact.NowZoom, Impact.BeginZoom)

    End Sub


    Public Sub New(size As Vec2)
        ImpactColor = New ImpactColorBoard("f00", "f", 0.5, Ease.Quad.EaseOut, False)
        Color = ImpactColor
        LayoutRect = New RectF(0, 0, size.X, size.X * 0.3)
        TextFormat = CreateTextFormat("Segoe UI", 50)
        TextFormat.TextAlignment = DDW.TextAlignment.Center
        TextFormat.ParagraphAlignment = DDW.ParagraphAlignment.Center
        Parallax = 100
    End Sub

End Class