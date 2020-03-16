Module GameMeasure

    Public ClientSize As Vec2
    Public TransWidth As Single, TransHeight As Single
    Public ClientCenter As Vec2
    Public ClientDiagnoal As Single


    Public Sub Init(factory As Factory)
        ClientSize = factory.Size
        TransWidth = factory.TransWidth
        TransHeight = factory.TransHeight
        ClientCenter = ClientSize * 0.5F
        ClientDiagnoal = ClientSize.Length
    End Sub
End Module
