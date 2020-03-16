Imports DX = SharpDX
Imports D2D = SharpDX.Direct2D1
Imports WIC = SharpDX.WIC
Imports DDW = SharpDX.DirectWrite
Imports DXGI = SharpDX.DXGI
Imports D3D = SharpDX.Direct3D11
Imports SharpDX.Mathematics.Interop

Module ResourceManager
    Public ResourceContext As D2D.DeviceContext

    Public DDWFactory As DDW.Factory
    Public D2DFactory As D2D.Factory
    Public WICFactory As WIC.ImagingFactory

    Private Sub CreateDependentResource(R As D2D.RenderTarget)
        ResourceContext = R.QueryInterface(Of D2D.DeviceContext)
    End Sub

    Public Sub CreateIndependentResource()
        DDWFactory = New DDW.Factory
        D2DFactory = New D2D.Factory
        WICFactory = New WIC.ImagingFactory
    End Sub

    Public Sub Init(R As D2D.RenderTarget)
        CreateDependentResource(R)

        BitmapResources.Init()
    End Sub

    Public Function LoadBitmap(fileName As String, Optional frameIndex As Integer = 0) As D2D.Bitmap
        Dim decoder As New WIC.BitmapDecoder(WICFactory, fileName, WIC.DecodeOptions.CacheOnLoad)

        If frameIndex > decoder.FrameCount - 1 OrElse frameIndex < 0 Then frameIndex = 0
        Dim source As WIC.BitmapFrameDecode = decoder.GetFrame(frameIndex)

        Dim converter = New WIC.FormatConverter(WICFactory)

        converter.Initialize(source, WIC.PixelFormat.Format32bppPBGRA)

        Return D2D.Bitmap.FromWicBitmap(ResourceContext, converter)
    End Function
End Module
