

Imports System.Threading
Imports SharpDX.Direct2D1
Imports SharpDX.Mathematics.Interop

Module GameRender
    Public ReadOnly Property R As RenderTarget
        Get
            Return TheFactory.RenderTarget
        End Get
    End Property

    Public Sub Init()

        TransformManager.Init()
    End Sub
    Public Sub StartRender()
        Dim thread As New Thread(
            Sub()
                Do
                    Render()
                Loop
            End Sub) With {.IsBackground = True，
                           .Name = "Render_Thread"}
        thread.Start()
    End Sub

    Public Sub Render()
        Static backgroundColor As New RawColor4(0.1, 0.1, 0.1, 1)
        TheFactory.BeginDraw()
        R.Clear(backgroundColor)
        GameRuntime.Update()
        GameRuntime.Render(R)
        If IsDebugging Then
            PrintDebug(R)
        End If
        TheFactory.EndDraw()
    End Sub
End Module
