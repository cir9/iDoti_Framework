Public Class StageRelatedList(Of T As ICleanable)
    Inherits ClearList(Of T)

    Public Stage As Stage

    Public Sub New(stage As Stage)
        MyBase.New()
        Me.Stage = stage
    End Sub

    Public Sub New(stage As Stage, capacity As Integer)
        MyBase.New(capacity)
        Me.Stage = stage
    End Sub

    Public Sub Update()
        Static clearEnumerable As New ClearEnumerable(Me)
        For Each e In clearEnumerable
            e.Update()
        Next
    End Sub
End Class
