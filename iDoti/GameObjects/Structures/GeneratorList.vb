Imports iDoti

Public Class GeneratorList
    Inherits StageRelatedList(Of Generator)

    Public Sub New(stage As Stage)
        MyBase.New(stage)
    End Sub

    Public Sub AddGenerator(g As Generator)
        g.list = Stage.Dots
        If Not g.IsRunning Then Add(g)
        g.Start()
    End Sub

End Class
