


Imports iDoti



Public MustInherit Class GameObjectAnimation(Of T As GameObject(Of T))
    Inherits Animation(Of T)

    Public GameObject As T

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Public Sub New(et As Single, ease As EaseFunction, sender As T)
        Me.New(et, ease)
        GameObject = sender
    End Sub
    Public Overrides Sub Update()
        Update(GameObject)
    End Sub

End Class

Public MustInherit Class DotAnimation
    Inherits GameObjectAnimation(Of Dot)

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Public Sub New(et As Single, ease As EaseFunction, sender As Dot)
        MyBase.New(et, ease, sender)
    End Sub

End Class

Public Class DotZoomAnimation
    Inherits DotAnimation

    Public BeginZoom As Single
    Public EndZoom As Single = 1
    Public NowZoom As Single
    Public Radius As Single

    Public Sub New(et As Single, ease As EaseFunction)
        MyBase.New(et, ease)
    End Sub

    Public Sub New(et As Single, ease As EaseFunction, sender As Dot)
        MyBase.New(et, ease, sender)
    End Sub
    Protected Overrides Sub OnStart()
        NowZoom = BeginZoom
        Radius = GameObject.Size
    End Sub

    Protected Overrides Sub OnEnd(e As Dot)
        NowZoom = EndZoom
    End Sub

    Protected Overrides Sub Animate(e As Dot, t As Single)
        NowZoom = BeginZoom * (1 - t) + EndZoom * t
        e.Size = NowZoom * Radius
    End Sub

End Class
