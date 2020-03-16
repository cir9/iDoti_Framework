Imports iDoti

Public Class AnimationList
    Inherits StageRelatedList(Of ICleanable)

    Public Sub StartAnimation(Of T As ICleanable)(e As Animation(Of T))
        e.Start()
        Add(e)
    End Sub

    Public Sub New(stage As Stage)
        MyBase.New(stage)
    End Sub
End Class
