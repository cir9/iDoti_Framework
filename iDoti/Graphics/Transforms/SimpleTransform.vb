



Imports SharpDX.Mathematics.Interop


Public Structure SimpleTransform
    Public ZoomX As Single
    Public ZoomY As Single
    Public DeltaX As Single
    Public DeltaY As Single

    Public Property Delta As Vec2
        Get
            Return New Vec2(DeltaX, DeltaY)
        End Get
        Set(value As Vec2)
            DeltaX = value.X
            DeltaY = value.Y
        End Set
    End Property

    Public Sub New(zX As Single, zY As Single, dX As Single, dY As Single)
        ZoomX = zX
        ZoomY = zY
        DeltaX = dX
        DeltaY = dY
    End Sub

    Public Shared Operator *(left As SimpleTransform, right As SimpleTransform) As SimpleTransform
        Return New SimpleTransform(left.ZoomX * right.ZoomX,
                                   left.ZoomY * right.ZoomY,
                                   left.ZoomX * right.DeltaX + left.DeltaX,
                                   left.ZoomY * right.DeltaY + left.DeltaY)
    End Operator

    Public Function ToMatrix() As RawMatrix3x2
        Return New RawMatrix3x2(ZoomX, 0, 0, ZoomY, DeltaX, DeltaY)
    End Function

    Public Function DeployMatrix(transform As RawMatrix3x2) As RawMatrix3x2
        Return New RawMatrix3x2(ZoomX * transform.M11, ZoomX * transform.M12,
                                ZoomY * transform.M21, ZoomY * transform.M22,
                                ZoomX * transform.M31 + DeltaX,
                                ZoomY * transform.M32 + DeltaY)
    End Function
    Public Function DeployOffset(offset As Vec2) As RawMatrix3x2
        Return New RawMatrix3x2(ZoomX, 0, 0, ZoomY,
                                ZoomX * offset.X + DeltaX,
                                ZoomY * offset.Y + DeltaY)
    End Function
End Structure
