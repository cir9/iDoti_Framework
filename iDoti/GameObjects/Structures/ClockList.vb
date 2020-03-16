

Public Class ClockList
    Inherits ClearList(Of Clock)

    Public Sub AddClock(clock As Clock)
        clock.Start()
        Add(clock)
    End Sub
End Class
