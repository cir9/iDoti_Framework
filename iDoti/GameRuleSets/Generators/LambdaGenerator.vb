
Imports iDoti

Public Class LambdaGenerator
    Inherits ImmediateGenerator

    Protected _generate As Action(Of DotList)

    Public Sub New(g As Action(Of DotList))
        _generate = g
    End Sub

    Public Overrides Sub Generate()
        _generate(list)
    End Sub
End Class

Public Class LambdaTickGenerator
    Inherits ClockGenerator

    Protected _generate As Action(Of DotList, Clock)
    Protected _init As Action(Of Clock)
    Public Sub New(timing As Timing)
        MyBase.New(timing)
    End Sub
    Public Sub New(timing As Timing, init As Action(Of Clock), g As Action(Of DotList, Clock))
        MyBase.New(timing)
        _init = init
        _generate = g
    End Sub

    Public Sub New(timing As Timing, g As Action(Of DotList, Clock))
        MyBase.New(timing)
        _generate = g
    End Sub
    Public Overrides Sub WhenStart(clock As Clock)
        _init?(clock)
    End Sub
    Public Overrides Sub WhenUpdate(clock As Clock)
    End Sub

    Public Overrides Sub WhenTicked(clock As Clock)
        _generate(list, clock)
    End Sub

End Class


