

Imports Matrix3x2 = SharpDX.Mathematics.Interop.RawMatrix3x2


Public Class Transforms



    Public Shared Identity As New Matrix3x2(1.0F, 0F, 0F, 1.0F, 0F, 0F)

    Public Shared Function Rotate(theta As Double, X As Single, Y As Single) As Matrix3x2
        Dim sin As Single, cos As Single
        sin = Math.Sin(theta)
        cos = Math.Cos(theta)
        Return New Matrix3x2(cos, -sin, sin, cos, X - X * cos - Y * sin, Y + X * sin - Y * cos)
    End Function
    Public Shared Function Skew(k As Single, q As Single, X As Single, Y As Single) As Matrix3x2
        Return New Matrix3x2(1.0F + k * q, q, k, 1.0F, -k * q * X - k * Y, -q * X)
    End Function
    Public Shared Function Zoom(t As Single, X As Single, Y As Single) As Matrix3x2
        Return New Matrix3x2(t, 0F, 0F, t, X - t * X, Y - t * Y)
    End Function
    Public Shared Function Rotate(theta As Double) As Matrix3x2
        Dim sin As Single, cos As Single
        sin = Math.Sin(theta)
        cos = Math.Cos(theta)
        Return New Matrix3x2(cos, -sin, sin, cos, 0F, 0F)
    End Function
    Public Shared Function Skew(k As Single, q As Single) As Matrix3x2
        Return New Matrix3x2(1.0F + k * q, q, k, 1.0F, 0F, 0F)
    End Function
    Public Shared Function Zoom(t As Single) As Matrix3x2
        Return New Matrix3x2(t, 0F, 0F, t, 0F, 0F)
    End Function

    Public Shared Function Move(X As Single, Y As Single) As Matrix3x2
        Return New Matrix3x2(1.0F, 0F, 0F, 1.0F, X, Y)
    End Function
End Class