
Imports iDoti


Public Interface ITick
    Sub Tick(sender As Clock)
End Interface


''' <summary>
'''     Timing类指定一组时钟循环参数，使用Clock类执行Timing类指定的时钟循环。
'''     <para>Clock类将会按以下方式执行Timing类所指定的时钟循环：</para>
'''     <para>---Delay---{|---Duration---|[Tick]|---TickDelay---}*(Ticks-1)|---Duration---|[Tick]|</para>
''' </summary>
Public Class Timing
    Public Delay As Single
    Public Duration As Single
    Public TickDelay As Single
    Public Ticks As Integer


    Public Sub New()

    End Sub
    Public Sub New(delay As Single, duration As Single, tickDelay As Single, ticks As Single)
        Me.Delay = delay
        Me.Duration = duration
        Me.TickDelay = tickDelay
        Me.Ticks = ticks
    End Sub

    Public Function GetClock(ticker As ITick) As Clock
        Return New Clock(Me, ticker)
    End Function

    Public Shared Function Timer(delay As Single, interval As Single, ticks As Single) As Timing
        Return New Timing(delay * 0.001F, interval * 0.001F, 0F, ticks)
    End Function

    Public Shared Function Timer(delay As Single, interval As Single, tickDelay As Single, ticks As Single) As Timing
        Return New Timing(delay * 0.001F, interval * 0.001F, tickDelay * 0.001F, ticks)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0}|{1}|{2} [{3}]",
                             Delay, Duration, TickDelay, Ticks)
    End Function

End Class

''' <summary>
'''     Clock类执行Timing类指定的时钟循环，而Timing类指定一组时钟循环参数。
'''     <para>Clock类将会按以下方式执行时钟循环：</para>
'''     <para>---Delay---{|---Duration---|[Tick]|---TickDelay---}*(Ticks-1)|---Duration---|[Tick]|</para>
''' </summary>
Public Class Clock
    Implements ICleanable

    Public Timing As Timing
    Public TickIndex As Integer
    Public NowTime As Single
    Public Progress As Single
    Public TickProgress As Single

    Public Ticker As ITick

    Private _data As DynamicDictionary(Of Single)
    Public Data As Object

    Public IsRunning As Boolean

    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage
        Get
            Return Not IsRunning
        End Get
        Set(value As Boolean)
            IsRunning = Not IsGarbage
        End Set
    End Property


    Public Sub New()
        Timing = New Timing
    End Sub
    Public Sub New(timing As Timing, ticker As ITick)
        Me.Timing = timing
        Me.Ticker = ticker
    End Sub
    Public Sub New(delay As Single, duration As Single, tickDelay As Single, ticks As Single)
        Timing = New Timing(delay, duration, tickDelay, ticks)
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}, [{1}]{2:0.00}({3:0%})",
                             Timing, TickIndex, NowTime, Progress)
    End Function

    Public Function UseData() As Object
        _data = New DynamicDictionary(Of Single)
        Data = _data
        Return Data
    End Function

    Public Sub Start()
        NowTime = -Timing.Delay
        TickIndex = 1
        Progress = 0
        TickProgress = 0
        IsRunning = True
    End Sub

    Protected Sub Tick()
        Ticker?.Tick(Me)
    End Sub


    Public Sub Update() Implements ICleanable.Update
        Update(DeltaTime)
    End Sub

    Public Sub Update(dt As Single)
        If IsRunning Then
            NowTime += dt
            If NowTime > Timing.Duration Then
                NowTime -= Timing.Duration + Timing.TickDelay
                Progress = 1
                If TickIndex < Timing.Ticks Then
                    TickIndex += 1
                    TickProgress = TickIndex / Timing.Ticks
                    Tick()
                    Update(0)
                Else
                    TickIndex = Timing.Ticks
                    TickProgress = 1
                    Tick()
                    'TimeOut()
                    IsRunning = False
                End If
            ElseIf NowTime > 0 Then
                Progress = NowTime / Timing.Duration
            End If
        End If
    End Sub

End Class