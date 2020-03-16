

Module Testing

    Public Dot_Timeline As TimelinePreset(Of Dot)

    Public Sub Init()
        Dot_Timeline = DotTimelineBuilder.Create.
            Wait(0.2).
            Repeat(12).
                Spawn(PelletDot_2).Relative.Radius(10).
                    Speed({200, 0}).
                    Repeat(4).RotateFrom(-60).EachRotate(40).
                End_Spawn.
                Wait(0.5).
            End_Repeat().
        Preset

    End Sub

End Module

Public Structure ReverseComparator(Of T As IComparable)
    Implements IComparer(Of T)
    Public Function Compare(x As T, y As T) As Integer Implements IComparer(Of T).Compare
        Return y.CompareTo(x)
    End Function
End Structure

Public Class ReverseList(Of T As IComparable)
    Inherits List(Of T)

    Public Sub ReverseSort()
        Sort(New ReverseComparator(Of T))
    End Sub
End Class