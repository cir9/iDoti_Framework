

Imports SharpDX.Direct2D1


Module GameUI

    Public UIs As New List(Of UIElement)

    Public ScoreBar As ScoreBar

    Public FpsBar As FpsBar

    Public Sub Init()
        ScoreBar = New ScoreBar(ClientSize) With {.LambdaText = Function() Score}
        FpsBar = New FpsBar(ClientSize) With
            {.LambdaText = Function() String.Format("{3}{1}{0:0} fps{1}{2} ms",
                                                    FpsCalc.FPS, vbCrLf,
                                                    Precision(1000 / FpsCalc.FPS, 2),
                                                    Plu_Dot(NowStage.Dots.Count))}
        UIs.Add(ScoreBar)
        UIs.Add(FpsBar)
    End Sub

    Public Sub Update()
        For Each e In UIs
            e.Update()
        Next
    End Sub

    Public Sub Render(R As RenderTarget)
        Static parall As New SimpleTransform(1, 1, 0, 0) With {.Delta = Parallax.NowValue * 100}
        For Each e In UIs
            parall.Delta = Parallax.NowValue * e.Parallax
            TransformManager.Push(R, parall)
            e.Draw(R)
            TransformManager.Pop(R)
        Next
    End Sub


End Module
