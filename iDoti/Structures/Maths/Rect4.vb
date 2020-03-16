

Imports SharpDX.Mathematics.Interop

Public Class Rect4
    Public Left As Single
    Public Top As Single
    Public Right As Single
    Public Bottom As Single
    Public Sub New(l As Single, t As Single, r As Single, b As Single)
        Left = l
        Top = t
        Right = r
        Bottom = b
    End Sub

    Public Function Contains(point As Vec2) As Boolean
        Return point.X > Left AndAlso point.X < Right AndAlso
               point.Y > Top AndAlso point.Y < Bottom
    End Function

    Public Function Contains(point As Vec2, r As Single) As Boolean
        Return point.X + r > Left AndAlso point.X < Right + r AndAlso
               point.Y + r > Top AndAlso point.Y < Bottom + r
    End Function


    Public Shared Function FromSize(size As Vec2) As Rect4
        Return New Rect4(0, 0, size.X, size.Y)
    End Function

    Public Shared Narrowing Operator CType(f() As Single) As Rect4
        Select Case f.Count
            Case 4
                Return New Rect4(f(0), f(1), f(2), f(3))
            Case 1
                Return New Rect4(-f(0), -f(0), f(0), f(0))
            Case 2
                Return New Rect4(0, 0, f(0), f(1))
            Case Else
                Return New Rect4(0, 0, 0, 0)
        End Select
    End Operator

    Public Shared Narrowing Operator CType(r As Rect4) As RawRectangleF
        Return New RawRectangleF(r.Left, r.Top, r.Right, r.Bottom)
    End Operator

    Public Shared Widening Operator CType(r As RawRectangleF) As Rect4
        Return New Rect4(r.Left, r.Top, r.Right, r.Bottom)
    End Operator

End Class
