Imports DX = SharpDX
Imports D2D = SharpDX.Direct2D1
Imports WIC = SharpDX.WIC
Imports DDW = SharpDX.DirectWrite
Imports DXGI = SharpDX.DXGI
Imports D3D = SharpDX.Direct3D11
Imports SharpDX.Mathematics.Interop

Imports System.Text.RegularExpressions

Public Class Factory

    Public ReadOnly Property Width As Single
        Get
            Return R.PixelSize.Width
        End Get
    End Property
    Public ReadOnly Property Height As Single
        Get
            Return R.PixelSize.Height
        End Get
    End Property

    Public ReadOnly Property Size As Vec2
        Get
            Return New Vec2(R.PixelSize.Width, R.PixelSize.Height)
        End Get
    End Property

    Public RenderTarget As D2D.RenderTarget
    Protected R As D2D.RenderTarget
    Public TransWidth As Single, TransHeight As Single

    Public Sub BeginDraw()
        RenderTarget.BeginDraw()
    End Sub



    Public Sub EndDraw()
        RenderTarget.EndDraw()
    End Sub

    Public Sub New(Target As Control, width As Single, height As Single)
        CreateIndependentResource()

        Dim P As New D2D.PixelFormat(DXGI.Format.B8G8R8A8_UNorm, D2D.AlphaMode.Ignore)

        Dim H As New D2D.HwndRenderTargetProperties With {
            .Hwnd = Target.Handle,
            .PixelSize = New DX.Size2(width, height),
            .PresentOptions = D2D.PresentOptions.None
        }

        Dim RP As New D2D.RenderTargetProperties(D2D.RenderTargetType.Hardware,
                                                 P, 0, 0,
                                                 D2D.RenderTargetUsage.None,
                                                 D2D.FeatureLevel.Level_DEFAULT)

        R = New D2D.WindowRenderTarget(D2DFactory, RP, H)

        TransWidth = R.Size.Width / R.PixelSize.Width
        TransHeight = R.Size.Height / R.PixelSize.Height

        RenderTarget = R

    End Sub

End Class
