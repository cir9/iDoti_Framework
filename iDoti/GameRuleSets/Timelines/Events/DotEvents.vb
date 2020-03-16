
Public MustInherit Class DotEvent
    Inherits ObjectEvent(Of Dot)
End Class

Namespace Timeline.Event.Dot

    Public Class Spawn
        Inherits DotEvent
        Public DotBuilder As DotBuilder
        Public Sub New(d As DotBuilder)
            DotBuilder = d
        End Sub

        Public Overrides Sub Execute(e As iDoti.Dot, dt As Single)
            DotBuilder.Update(dt).Deploy(e)
        End Sub
    End Class


    Public Class SymmeticSpawn
        Inherits DotEvent

        Public FromDegree As Single
        Public ToDegree As Single
        Public Count As Integer
        Public DotSet As DotSet
        Public Sub New(d As DotSet)
            DotSet = d
        End Sub
        Public Overrides Sub Execute(e As iDoti.Dot, dt As Single)
            DotSet.Deploy(e, dt)
        End Sub
    End Class


End Namespace






