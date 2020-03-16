Imports DX = SharpDX
Imports D2D = SharpDX.Direct2D1
Imports WIC = SharpDX.WIC
Imports DDW = SharpDX.DirectWrite
Imports DXGI = SharpDX.DXGI
Imports D3D = SharpDX.Direct3D11
Imports SharpDX.Mathematics.Interop


Public Class SwitchRender
    Public R(1) As D2D.BitmapRenderTarget
    Public NowIndex As Integer

    Protected NormalTransform As RawMatrix3x2
    Protected RenderTransform As RawMatrix3x2

    Public ReadOnly Property RenderTarget As D2D.RenderTarget
        Get
            Return R(NowIndex)
        End Get
    End Property

    Public ReadOnly Property Bitmap As D2D.Bitmap
        Get
            Return R(NowIndex).Bitmap
        End Get
    End Property

    Public Sub Switch()
        NowIndex = 1 - NowIndex
    End Sub

    Public Sub RenderFading()
        RenderTarget.Transform = RenderTransform
        RenderTarget.DrawBitmap(R(1 - NowIndex).Bitmap, 0.7, 1)
        RenderTarget.Transform = NormalTransform
    End Sub



    Public Sub New(RT As D2D.RenderTarget)
        NormalTransform = RT.Transform
        RenderTransform = New RawMatrix3x2(1, 0, 0, 1, 0, 0)
        For i = 0 To 1
            R(i) = New D2D.BitmapRenderTarget(RT, D2D.CompatibleRenderTargetOptions.None)
        Next
    End Sub
End Class

