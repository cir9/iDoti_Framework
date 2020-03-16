Imports SharpDX.Mathematics.Interop

Public Structure Color
    Public R As Single, G As Single, B As Single, A As Single

    Public Sub New(R As Single, G As Single, B As Single, A As Single)
        Me.R = R
        Me.G = G
        Me.B = B
        Me.A = A
    End Sub
    Public Shared Function FromRGBA(R As Single, G As Single, B As Single, A As Single) As Color
        Return New Color(R / 255, G / 255, B / 255, A)
    End Function
    Public Shared Function FromHex(hex As String) As Color
        Dim c As Integer = Val("&H" & hex)
        Dim r As Single, g As Single, b As Single, a As Single
        Select Case hex.Length
            Case 1
                r = c / 15
                g = r
                b = r
                a = 1
            Case 2
                r = c / 255
                g = r
                b = r
                a = 1
            Case 3
                r = ((c And &HF00) >> 8) / 15
                g = ((c And &HF0) >> 4) / 15
                b = (c And &HF) / 15
                a = 1
            Case 4
                r = ((c And &HF000) >> 12) / 15
                g = ((c And &HF00) >> 8) / 15
                b = ((c And &HF0) >> 4) / 15
                a = (c And &HF) / 15
            Case 6
                r = ((c And &HFF0000) >> 16) / 255
                g = ((c And &HFF00) >> 8) / 255
                b = (c And &HFF) / 255
                a = 1
            Case 8
                r = ((c And &HFF000000) >> 24) / 255
                g = ((c And &HFF0000) >> 16) / 255
                b = ((c And &HFF00) >> 8) / 255
                a = (c And &HFF) / 255
            Case Else
                r = 1
                g = 0
                b = 1
                a = 1
        End Select
        Return New Color(r, g, b, a)
    End Function

    Public Shared Narrowing Operator CType(s As String) As Color
        Return FromHex(s)
    End Operator

    Public Shared Narrowing Operator CType(f() As Single) As Color
        Select Case f.Count
            Case 1
                Return New Color(f(0) / 255, f(0) / 255, f(0) / 255, 1)
            Case 2
                Return New Color(f(0) / 255, f(0) / 255, f(0) / 255, f(1))
            Case 3
                Return New Color(f(0) / 255, f(1) / 255, f(2) / 255, 1)
            Case 4
                Return New Color(f(0) / 255, f(1) / 255, f(2) / 255, f(3))
            Case Else
                Return New Color(1, 0, 1, 1)
        End Select
    End Operator

    Public Shared Operator +(c1 As Color, c2 As Color) As Color
        Return New Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B, c1.A + c2.A)
    End Operator

    Public Shared Operator *(c As Color, m As Single) As Color
        Return New Color(c.R * m, c.G * m, c.B * m, c.A * m)
    End Operator


    Public Function ToRawColor4() As RawColor4
        Return New RawColor4(R, G, B, A)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("RGBA({0:0},{1:0},{2:0},{3:0.00})", R, G, B, A)
    End Function
End Structure

