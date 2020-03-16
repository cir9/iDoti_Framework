Public Class ParamGenerators
    Protected _generate As Action(Of DotList, Single())

    Public Sub New(g As Action(Of DotList, Single()))
        _generate = g
    End Sub
    Public Function GetGeneratorWith(params As Single()) As LambdaGenerator
        Return New LambdaGenerator(Sub(d) _generate(d, params))
    End Function
End Class


Public Class ParamTickGenerators
    Public Timing As Timing
    Protected _generate As Action(Of DotList, Clock, Single())

    Protected _init As Action(Of Clock)
    Public Sub New(t As Timing, g As Action(Of DotList, Clock, Single()))
        Timing = t
        _generate = g
    End Sub
    Public Sub New(t As Timing, init As Action(Of Clock), g As Action(Of DotList, Clock, Single()))
        Me.New(t, g)
        _init = init
    End Sub
    Public Function GetGeneratorWith(params As Single()) As LambdaTickGenerator
        Return New LambdaTickGenerator(Timing, _init, Sub(d, c) _generate(d, c, params))
    End Function
End Class
