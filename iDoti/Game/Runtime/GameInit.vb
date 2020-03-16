

Imports D2D = SharpDX.Direct2D1
Imports DDW = SharpDX.DirectWrite
Imports SharpDX.Mathematics.Interop

Module GameDim

    Public TheFactory As Factory

    Public Sub Init(factory As Factory)
        TheFactory = factory
    End Sub

End Module


Module Defaults
    Public solid_brush As D2D.SolidColorBrush
    Public debug_brush As D2D.SolidColorBrush
    Public render_target As D2D.RenderTarget
    Public debug_format As DDW.TextFormat

    Public Function CreateTextFormat(font As String, size As Single) As DDW.TextFormat
        Return New DDW.TextFormat(DDWFactory, font, size)
    End Function

    Public Sub Init(R As D2D.RenderTarget)
        render_target = R

        solid_brush = New D2D.SolidColorBrush(R)
        debug_brush = New D2D.SolidColorBrush(R, New RawColor4(0, 1, 0, 1))
        debug_format = New DDW.TextFormat(DDWFactory, "Consolas", 14.0F)
    End Sub


End Module

Module GameInit
    Public Sub Init(target As Control, width As Single, height As Single)
        Dim factory = New Factory(target, width, height)
        GameDim.Init(factory)
        GameMeasure.Init(factory)

        ResourceManager.Init(R)
        Defaults.Init(R)

        GameRender.Init()
        GameManager.Init()
        GamePreset.Init()



        GameRuntime.Init()

    End Sub
End Module