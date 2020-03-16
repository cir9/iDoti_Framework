


Imports SharpDX.Mathematics.Interop

Public Structure Matrix6
    Public M11 As Single, M12 As Single
    Public M21 As Single, M22 As Single
    Public M31 As Single, M32 As Single


    Public Shared Identity As New Matrix6(1, 0, 0, 1, 0, 0)

    Public Sub New(m11 As Single, m12 As Single,
                   m21 As Single, m22 As Single,
                   m31 As Single, m32 As Single)
        Me.M11 = m11
        Me.M12 = m12
        Me.M21 = m21
        Me.M22 = m22
        Me.M31 = m31
        Me.M32 = m32
    End Sub

    Public Sub Move(v As Vec2)
        M31 += v.X
        M32 += v.Y
    End Sub

    Public Function ToMatrix4() As Matrix4
        Return New Matrix4(M11, M12, M21, M22)
    End Function

    Public Function RotateTo(v As Vec2) As Matrix6
        v.Normalize()
        Return New Matrix4(v.X, v.Y, -v.Y, v.X) * me
    End Function

    Public Shared Function FromRotation(deg As Single) As Matrix6
        Dim arc As Double = deg * Math.PI / 180
        Dim c As Double = Math.Cos(arc)
        Dim s As Double = Math.Sin(arc)
        Return New Matrix6(c, s, -s, c, 0, 0)
    End Function

    Public Shared Operator *(a As Matrix6, b As Matrix6) As Matrix6
        Return New Matrix6(a.M11 * b.M11 + a.M21 * b.M12,
                           a.M12 * b.M11 + a.M22 * b.M12,
                           a.M11 * b.M21 + a.M21 * b.M22,
                           a.M12 * b.M21 + a.M22 * b.M22,
                           a.M11 * b.M31 + a.M21 * b.M32 + a.M31,
                           a.M12 * b.M31 + a.M22 * b.M32 + a.M32)
    End Operator
    Public Shared Operator *(a As Matrix4, b As Matrix6) As Matrix6
        Return New Matrix6(a.M11 * b.M11 + a.M21 * b.M12,
                           a.M12 * b.M11 + a.M22 * b.M12,
                           a.M11 * b.M21 + a.M21 * b.M22,
                           a.M12 * b.M21 + a.M22 * b.M22,
                           a.M11 * b.M31 + a.M21 * b.M32,
                           a.M12 * b.M31 + a.M22 * b.M32)
    End Operator


End Structure
