
Public Class KeyFrame(Of T)
    Public Time As Single
    Public [Event] As EventDefinition(Of T)

    Public Sub New(time As Single, [event] As EventDefinition(Of T))
        Me.Time = time
        Me.Event = [event]
    End Sub
End Class

Public Class CompiledKeyFrame
    Public Time As Single
    Public Executable As IExecutable
    Public Sub New(time As Single, e As IExecutable)
        Me.Time = time
        Executable = e
    End Sub

    ''' <summary>
    ''' 执行编译的可执行对象。
    ''' </summary>
    ''' <param name="nextTime">正在执行的这一更新帧的结束时间</param>
    Public Sub Execute(nextTime As Single)
        Executable.Execute(nextTime - Time)
    End Sub
End Class

Public Class TimelinePreset(Of T)
    Inherits List(Of KeyFrame(Of T))
    Public Function Append(time As Single, e As EventDefinition(Of T)) As TimelinePreset(Of T)
        Add(New KeyFrame(Of T)(time, e))
        Return Me
    End Function

    Public Function Compile(bindTo As T) As Timeline(Of T)
        Dim t As New Timeline(Of T)(bindTo)
        For Each e In Me
            t.Timeline.Add(New CompiledKeyFrame(e.Time, e.Event.Compile(t)))
        Next
        Return t
    End Function

End Class

Public Interface IFlowController
    Sub JumpTo(index As Integer, dt As Single)
End Interface
