


Imports SharpDX.Mathematics.Interop

Public Structure Vec2
    Public X As Single
    Public Y As Single

    Public Shared Identity As New Vec2(1, 1)
    Public Shared Zero As New Vec2(0, 0)


    Public Sub New(X As Single, Y As Single)
        Me.X = X
        Me.Y = Y
    End Sub

    Public Shared Function FromDegree(deg As Single, length As Single) As Vec2
        Dim arc As Double = deg * Math.PI / 180.0
        Return New Vec2(Math.Cos(arc) * length, Math.Sin(arc) * length)
    End Function
    Public Shared Function FromDegree(deg As Single) As Vec2
        Dim arc As Double = deg * Math.PI / 180.0
        Return New Vec2(Math.Cos(arc), Math.Sin(arc))
    End Function

    Public Function Transform(m As Matrix6) As Vec2
        Return New Vec2(m.M11 * X + m.M21 * Y + m.M31,
                        m.M12 * X + m.M22 * Y + m.M32)
    End Function



    Public Function Around(count As Integer, startDegree As Single, distance As Single) As Vec2()
        Dim res(count - 1) As Vec2
        Dim deg As Single
        For i = 0 To count - 1
            deg = startDegree + 360 * i / count
            res(i) = Me + FromDegree(deg, distance)
        Next
        Return res
    End Function


    Public Shared Narrowing Operator CType(s() As Single) As Vec2
        Return New RawVector2(s(0), s(1))
    End Operator

    Public Shared Narrowing Operator CType(v As Vec2) As RawVector2
        Return New RawVector2(v.X, v.Y)
    End Operator

    Public Shared Widening Operator CType(v As RawVector2) As Vec2
        Return New Vec2(v.X, v.Y)
    End Operator

    Public Shared Narrowing Operator CType(v As SharpDX.Size2F) As Vec2
        Return New RawVector2(v.Width, v.Height)
    End Operator

    Public Shared Operator +(v1 As Vec2, v2 As Vec2) As Vec2
        Return New Vec2(v1.X + v2.X, v1.Y + v2.Y)
    End Operator
    Public Shared Operator -(v1 As Vec2, v2 As Vec2) As Vec2
        Return New Vec2(v1.X - v2.X, v1.Y - v2.Y)
    End Operator
    Public Shared Operator *(v1 As Vec2, v2 As Vec2) As Single
        Return v1.X * v2.X + v1.Y * v2.Y
    End Operator
    Public Shared Operator *(v As Vec2, f As Single) As Vec2
        Return New Vec2(v.X * f, v.Y * f)
    End Operator
    Public Shared Operator /(v As Vec2, f As Single) As Vec2
        Return New Vec2(v.X / f, v.Y / f)
    End Operator
    Public Shared Operator /(v1 As Vec2, v2 As Vec2) As Vec2
        Return New Vec2(v1.X / v2.X, v1.Y / v2.Y)
    End Operator
    Public Shared Operator *(f As Single, v As Vec2) As Vec2
        Return New Vec2(v.X * f, v.Y * f)
    End Operator

    Public Shared Operator *(m As Matrix4, v As Vec2) As Vec2
        Return New Vec2(v.X * m.M11 + v.Y * m.M21, v.X * m.M12 + v.Y * m.M22)
    End Operator

    Public Shared Operator *(v As Vec2, m As Matrix4) As Vec2
        Return New Vec2(v.X * m.M11 + v.Y * m.M21, v.X * m.M12 + v.Y * m.M22)
    End Operator

    Public Shared Operator *(v As Vec2, m As Matrix6) As Vec2
        Return New Vec2(v.X * m.M11 + v.Y * m.M21 + m.M31,
                        v.X * m.M12 + v.Y * m.M22 + m.M32)
    End Operator
    Public Function Rotate(deg As Single) As Vec2
        Dim degv = FromDegree(deg)
        Return New Vec2(X * degv.X - Y * degv.Y, X * degv.Y + Y * degv.X)
    End Function

    Public Function Average() As Single
        Return (X + Y) * 0.5
    End Function
    Public Function Sum() As Single
        Return X + Y
    End Function
    Public Function Sum(multiply As Single) As Single
        Return (X + Y) * multiply
    End Function

    Public Function Square() As Single
        Return X * X + Y * Y
    End Function
    Public Function Multiply(zX As Single, zY As Single) As Vec2
        X *= zX
        Y *= zY
        Return Me
    End Function

    Public Function Multiply(v As Vec2) As Vec2
        X *= v.X
        Y *= v.Y
        Return Me
    End Function
    Public Function Normalize() As Vec2
        Dim d = Length()
        X /= d
        Y /= d
        Return Me
    End Function

    Public Function Normalize(s As Single) As Vec2
        Dim d = s / Length()
        X *= d
        Y *= d
        Return Me
    End Function

    Public Function Length() As Single
        Return Math.Sqrt(X * X + Y * Y)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("({0:0.000},{1:0.000})", X, Y)
    End Function

End Structure

