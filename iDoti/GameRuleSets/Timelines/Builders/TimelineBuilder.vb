

Imports CFloat = iDoti.Customable(Of Single)
Imports CVec2 = iDoti.Customable(Of iDoti.Vec2)



Public Class TimelineBuilderWrapper(Of T, V As {TimelineBuilderWrapper(Of T, V), New})

    Public Preset As New TimelinePreset(Of T)


    Protected NowTime As Single
    Protected NowIndex As Integer
    Protected Marks As New Dictionary(Of String, Integer)
    Protected Flows As New Stack(Of Integer)

    Protected IsGapped As Boolean

    Public Function BindTo(e As T) As Timeline(Of T)
        Return Preset.Compile(e)
    End Function
    Protected Sub Add(e As EventDefinition(Of T))
        Preset.Append(NowTime, e)
        IsGapped = False
        NowIndex += 1
    End Sub
    Protected Sub Add(e As Flow)
        Preset.Append(NowTime, New FlowEvent(Of T)(e))
        IsGapped = False
        NowIndex += 1
    End Sub

    Private Sub CheckGap()
        If IsGapped Then
            Add(New EmptyEvent(Of T))
        End If
    End Sub
    Public Function Mark(name As String) As V
        Marks.Add(name, NowIndex)
        CheckGap()
        Return Me
    End Function
    Public Function JumpTo(mark As String) As V
        Add(New JumpFlow(Marks(mark)))
        Return Me
    End Function
    Public Function Repeat(times As Integer) As V
        Flows.Push(NowIndex)
        Flows.Push(times)
        CheckGap()
        Return Me
    End Function
    Public Function End_Repeat() As V
        Add(New LoopFlow(Flows.Pop, Flows.Pop))
        Return Me
    End Function

    Public Function Wait(t As Single) As V
        NowTime += t
        IsGapped = True
        Return Me
    End Function
    Public Function Time(t As Single) As V
        NowTime = t
        IsGapped = True
        Return Me
    End Function
    Public Function Print(text As String) As V
        Add(New DebugEvent(Of T)(text))
        Return Me
    End Function

    Public Function Update(action As Action) As V
        Add(New UpdateEvent(Of T)(action))
        Return Me
    End Function

    Public Shared Function Create() As V
        Return New V
    End Function
End Class

Public Class TimelineBuilder(Of T)
    Inherits TimelineBuilderWrapper(Of T, TimelineBuilder(Of T))
End Class

Public Class TimelineBuilder
    Inherits TimelineBuilderWrapper(Of Nullable, TimelineBuilder)
    Public Function Compile() As Timeline(Of Nullable)
        Return BindTo(Nothing)
    End Function
End Class



