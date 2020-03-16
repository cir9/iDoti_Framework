

Imports SharpDX.Direct2D1
Module GameRuntime



    Public Sub Init()
        GameUI.Init()
        GameTime.Init()
        GameRunning.Init()
    End Sub


    Public Sub Render(R As RenderTarget)
        NowStage.Render(R)
        GameUI.Render(R)
    End Sub

    Public Sub Update()
        GameTime.Update()
        NowStage.Update()
        GameInput.Update()
        GameUI.Update()
        GameManager.Update()
    End Sub




End Module
