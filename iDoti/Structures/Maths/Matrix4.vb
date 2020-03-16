


Imports SharpDX.Mathematics.Interop

Public Structure Matrix4
    Public M11 As Single, M12 As Single
    Public M21 As Single, M22 As Single


    Public Sub New(m11 As Single, m12 As Single,
                   m21 As Single, m22 As Single)
        Me.M11 = m11
        Me.M12 = m12
        Me.M21 = m21
        Me.M22 = m22
    End Sub

    Public Shared Identity  = New Matrix4(1,0,0,1)

    Public Shared Function FromRotation(deg As Single) As Matrix4
        Dim arc As Double = deg * Math.PI / 180
        Dim c As Double = Math.Cos(arc)
        Dim s As Double = Math.Sin(arc)
        Return New Matrix4(c, s, -s, c)
    End Function

    Public Shared Operator *(a As Matrix4, b As Matrix4) As Matrix4
        Return New Matrix4(a.M11 * b.M11 + a.M21 * b.M12,
                           a.M12 * b.M11 + a.M22 * b.M12,
                           a.M11 * b.M21 + a.M21 * b.M22,
                           a.M12 * b.M21 + a.M22 * b.M22)

    End Operator

    Public Overrides Function ToString() As String
        Return String.Format("{0}  {1}{2}{3}  {4}", M11, M21, vbCrLf, M12, M22)
    End Function
End Structure
