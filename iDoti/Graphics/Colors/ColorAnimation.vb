

Public Class ColorAnimation
    Inherits Animation(Of AnimatedColorBoard)

    Public BeginColor As Color
    Public EndColor As Color

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Public Overrides Sub Update()
    End Sub
    Protected Overrides Sub OnStart()
    End Sub

    Protected Overrides Sub OnEnd(e As AnimatedColorBoard)
        e.Color = EndColor
    End Sub

    Protected Overrides Sub Animate(e As AnimatedColorBoard, t As Single)
        e.Color = BeginColor * (1 - t) + EndColor * t
    End Sub

End Class
Public Class ImpactColorAnimation
    Inherits ColorAnimation


    Public Impacter As New Impacter(3, 1)

    Protected impact As Single, nowProgress As Single = 1.0F

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Public Sub Increase(v As Single)
        impact = Impacter.Increase(v, 1 - nowProgress)
    End Sub


    Protected Overrides Sub Animate(e As AnimatedColorBoard, t As Single)
        nowProgress = 1 + (t - 1) * impact
        e.Color = BeginColor * (1 - nowProgress) + EndColor * nowProgress
    End Sub
End Class