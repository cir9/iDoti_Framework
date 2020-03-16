
Imports SharpDX.DirectWrite
Imports SharpDX.Direct2D1
Imports SharpDX
Imports SharpDX.Mathematics.Interop

Public Class OutlineTextRenderer
    Implements TextRenderer

    Private R As RenderTarget
    Public OutlineColor As ColorBoard
    Public FillColor As ColorBoard
    Public StrokeWidth As Single

    Public Property Shadow As IDisposable Implements ICallbackable.Shadow

    Public Sub BeginDraw(R As RenderTarget)
        Me.R = R
    End Sub


    Public Function DrawGlyphRun(clientDrawingContext As Object,
                                 baselineOriginX As Single, baselineOriginY As Single,
                                 measuringMode As MeasuringMode,
                                 glyphRun As GlyphRun, glyphRunDescription As GlyphRunDescription,
                                 clientDrawingEffect As ComObject) As Result Implements TextRenderer.DrawGlyphRun
        Using pathGeometry As New PathGeometry(D2DFactory)
            Using sink As GeometrySink = pathGeometry.Open()
                glyphRun.FontFace.GetGlyphRunOutline(
                    glyphRun.FontSize,
                    glyphRun.Indices,
                    glyphRun.Advances,
                    glyphRun.Offsets,
                    glyphRun.IsSideways,
                    False,
                    sink)
                sink.Close()
                Dim m As New RawMatrix3x2(1.0F, 0F, 0F, 1.0F, baselineOriginX, baselineOriginY)
                Using transformedGeometry As New TransformedGeometry(
                                                 D2DFactory, pathGeometry, m)

                    R.DrawGeometry(transformedGeometry, OutlineColor.Brush, StrokeWidth)
                    R.FillGeometry(transformedGeometry, FillColor.Brush)
                End Using
            End Using
        End Using
    End Function

    Public Function DrawUnderline(clientDrawingContext As Object, baselineOriginX As Single, baselineOriginY As Single, ByRef underline As Underline, clientDrawingEffect As ComObject) As Result Implements TextRenderer.DrawUnderline
        Throw New NotImplementedException()
    End Function

    Public Function DrawStrikethrough(clientDrawingContext As Object, baselineOriginX As Single, baselineOriginY As Single, ByRef strikethrough As Strikethrough, clientDrawingEffect As ComObject) As Result Implements TextRenderer.DrawStrikethrough
        Throw New NotImplementedException()
    End Function

    Public Function DrawInlineObject(clientDrawingContext As Object, originX As Single, originY As Single, inlineObject As InlineObject, isSideways As Boolean, isRightToLeft As Boolean, clientDrawingEffect As ComObject) As Result Implements TextRenderer.DrawInlineObject
        Throw New NotImplementedException()
    End Function

    Public Function IsPixelSnappingDisabled(clientDrawingContext As Object) As Boolean Implements PixelSnapping.IsPixelSnappingDisabled
        Return False
    End Function

    Public Function GetCurrentTransform(clientDrawingContext As Object) As RawMatrix3x2 Implements PixelSnapping.GetCurrentTransform
        Return R.Transform
    End Function

    Public Function GetPixelsPerDip(clientDrawingContext As Object) As Single Implements PixelSnapping.GetPixelsPerDip
        Return R.DotsPerInch.Width / 96
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
            End If
            Shadow.Dispose()
            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class