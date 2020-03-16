

Public Structure FpsCalculator

    Public FPS As Single

    Public TimeQueue As CircularQueue(Of Single)

    Public Sub New(count As Integer)
        TimeQueue = New CircularQueue(Of Single)(count)
    End Sub

    Public Sub NewFrame()
        Dim totalTime As Single
        TimeQueue.CircularEnqueue(DeltaTime)
        TimeQueue.ForEach(Sub(e) totalTime += e)
        FPS = TimeQueue.Count / totalTime
    End Sub

End Structure






Module GameTime

    Private stopWatch As New Stopwatch

    Public DeltaTime As Single


    Public FpsCalc As New FpsCalculator(60)

    Public Sub Update()
        Static ot As Single, nt As Single
        nt = stopWatch.ElapsedTicks / Stopwatch.Frequency
        DeltaTime = nt - ot
        ot = nt

        FpsCalc.NewFrame()
    End Sub

    Public Sub Init()
        stopWatch.Start()
    End Sub

End Module
