


Module GameRunning

    Public NowStage As Stage

    Public Sub Init()
        NowStage = New Stage(ClientSize) With {.Name = "MainStage"}
        'NowStage.Generate(Generator1)
    End Sub

End Module
