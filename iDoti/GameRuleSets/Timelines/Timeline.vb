

Imports iDoti

Public Class Timeline(Of T)

    Implements ICleanable, IFlowController

    Public Timeline As New List(Of CompiledKeyFrame)

    Public Parent As T
    Public CurrentIndex As Integer
    Public CurrentFrame As CompiledKeyFrame
    Public IsRunning As Boolean
    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage
        Get
            Return Not IsRunning
        End Get
        Set(value As Boolean)
            IsRunning = Not value
        End Set
    End Property
    Public Sub New(bindTo As T)
        Parent = bindTo
    End Sub

#Region "<private>"
    Private Function SelectFrame(index As Integer) As Boolean
        CurrentIndex = index
        If CurrentIndex >= Timeline.Count Then
            IsRunning = False
            CurrentFrame = Nothing
            Return False
        Else
            CurrentFrame = Timeline(CurrentIndex)
            Return True
        End If
    End Function
    Private Function NextFrame() As Boolean
        Return SelectFrame(CurrentIndex + 1)
    End Function
#End Region
    Public Sub Start()
        IsRunning = True
        NowTime = 0F
        SelectFrame(0)
    End Sub
    Public Sub JumpTo(index As Integer, dt As Single) Implements IFlowController.JumpTo
        If SelectFrame(index) Then
            NowTime = CurrentFrame.Time
            nextTime = NowTime + dt
        End If
        CurrentIndex -= 1
    End Sub

    Public NowTime As Single
    Private nextTime As Single

    Public Sub Update(dt As Single)
        If IsRunning Then
            nextTime = NowTime + dt
            Do
                If nextTime >= CurrentFrame.Time Then
                    CurrentFrame.Execute(nextTime)
                Else
                    Exit Do
                End If
            Loop While NextFrame()
            NowTime = nextTime
        End If
    End Sub

    Public Sub Update() Implements ICleanable.Update
        Update(DeltaTime)
    End Sub

End Class

