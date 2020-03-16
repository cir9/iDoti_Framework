

Imports System.Text
Imports SharpDX.Direct2D1
Imports SharpDX.Mathematics.Interop

Module GameDebug

    Public Plu_Dot As New Plural("dot", "dots")
    Public Plu_Animation As New Plural("animation", "animations")
    Public Plu_Generator As New Plural("generator", "generators")
    Public Plu_Color As New Plural("color", "colors")

    Public IsDebugging As Boolean = True
    Public IsGraphicsDebugging As Boolean = False
    Public DebugString As New StringBuilder
    Public Sub DebugPrintfh(format As String, ParamArray args() As Object)
        DebugString.AppendFormat(format, args)
    End Sub
    Public Sub DebugPrintf(format As String, ParamArray args() As Object)
        DebugString.AppendFormat(format, args)
        DebugString.AppendLine("")
    End Sub
    Public Sub DebugPrinth(text As String)
        DebugString.Append(text)
    End Sub
    Public Sub DebugPrint(text As String)
        DebugString.AppendLine(text)
    End Sub
    Public Sub PrintDebug(R As RenderTarget)
        Static debug_rect As New RawRectangleF(0, 0, 10000, R.Size.Height)
        If IsDebugging Then
            R.DrawText(DebugString.ToString, Defaults.debug_format, debug_rect, Defaults.debug_brush)
        End If
        DebugString.Clear()
        DebugPrint("iDoti v0.2")
    End Sub


End Module