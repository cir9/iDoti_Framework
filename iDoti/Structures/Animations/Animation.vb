


Imports iDoti

Public MustInherit Class Animation(Of T As ICleanable)
    Implements ICleanable

    Public EaseFunction As EaseFunction

    Public Clock As New Clock()

    Public IsRunning As Boolean

    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage
        Get
            Return Not IsRunning
        End Get
        Set(value As Boolean)
            IsRunning = Not value
        End Set
    End Property

    Protected MustOverride Sub OnStart()
    Protected MustOverride Sub OnEnd(e As T)
    Protected MustOverride Sub Animate(e As T, t As Single)

    Public MustOverride Sub Update() Implements ICleanable.Update

    Public Sub New(et As Single, ease As EaseFunction)
        Clock.Timing.Duration = et
        EaseFunction = ease
    End Sub
    Public Overridable Sub Start()
        Clock.Start()
        IsRunning = True
        OnStart()
    End Sub


    Public Function Update(e As T) As Boolean
        If e.IsGarbage Then
            IsRunning = False
        End If
        If Not IsRunning Then Return False

        Clock.Update(DeltaTime)
        If Clock.IsRunning Then
            Animate(e, EaseFunction.Ease(Clock.Progress))
        Else
            Animate(e, EaseFunction.Ease(1))
            OnEnd(e)
            IsRunning = False
        End If
        Return True
    End Function

End Class

