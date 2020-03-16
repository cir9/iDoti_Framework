


Imports iDoti

Public MustInherit Class Generator
    Implements ICleanable
    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage

    Public IsRunning As Boolean

    Protected Friend list As DotList



    Public Overridable Sub Start()
        IsGarbage = False
    End Sub

    Public MustOverride Sub Update() Implements ICleanable.Update

End Class


Public MustInherit Class ImmediateGenerator
    Inherits Generator
    Public MustOverride Sub Generate()

    Public Overrides Sub Update()
        Generate()
        IsGarbage = True
    End Sub
End Class


Public MustInherit Class ClockGenerator
    Inherits Generator
    Implements ITick

    Public Timing As Timing
    Public Clocks As New ClockList
    Public Sub New(timing As Timing)
        Me.Timing = timing
    End Sub

    Public Overrides Sub Start()
        MyBase.Start()
        IsRunning = True
        Dim c = Timing.GetClock(Me)
        Clocks.AddClock(c)
        WhenStart(c)
    End Sub

    Public MustOverride Sub WhenStart(clock As Clock)
    Public MustOverride Sub WhenUpdate(clock As Clock)
    Public MustOverride Sub WhenTicked(clock As Clock) Implements ITick.Tick
    Public Overrides Sub Update()
        For Each clock In Clocks.All
            DebugPrint(clock.ToString)
            clock.Update(DeltaTime)
            If clock.IsRunning Then
                WhenUpdate(clock)
            Else
                clock.IsGarbage = True
            End If
        Next
        If Clocks.Count = 0 Then
            IsGarbage = True
            IsRunning = False
        End If
    End Sub


End Class
