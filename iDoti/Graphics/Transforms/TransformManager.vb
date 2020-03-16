
Imports SharpDX.Mathematics.Interop
Imports SharpDX.Direct2D1


Public Class TransformManager

    Protected Shared SimpleTrans As New Stack(Of SimpleTransform)


    Public Shared CurrentTrans As SimpleTransform

    Public Shared IsDeployed As Boolean

    Public Shared Sub Init()
        CurrentTrans = New SimpleTransform(TransWidth, TransHeight, 0, 0)
        SimpleTrans.Push(CurrentTrans)
    End Sub

    Public Shared Sub Push(R As RenderTarget, trans As SimpleTransform)
        CurrentTrans = SimpleTrans.Peek * trans
        SimpleTrans.Push(CurrentTrans)
        R.Transform = CurrentTrans.ToMatrix
        IsDeployed = False
    End Sub

    Public Shared Sub Pop(R As RenderTarget)
        SimpleTrans.Pop()
        CurrentTrans = SimpleTrans.Peek
        R.Transform = CurrentTrans.ToMatrix
        IsDeployed = False
    End Sub

    Public Shared Sub Deploy(R As RenderTarget, trans As RawMatrix3x2)
        R.Transform = CurrentTrans.DeployMatrix(trans)
        IsDeployed = True
    End Sub
    Public Shared Sub Deploy(R As RenderTarget, sprite As Sprite)
        Dim D = sprite.Direction.Normalize
        Dim P = sprite.Position
        Dim S = sprite.Size
        Dim M = S / sprite.SourceSize
        R.Transform = CurrentTrans.DeployMatrix(
            New RawMatrix3x2(D.X * M.X, D.Y * M.X,
                             -D.Y * M.Y, D.X * M.Y,
                             (-D.X * S.X + D.Y * S.Y) * 0.5F + P.X,
                             (-D.Y * S.X - D.X * S.Y) * 0.5F + P.Y))
        IsDeployed = True
    End Sub

    Public Shared Sub Deploy(R As RenderTarget, offset As Vec2)
        R.Transform = CurrentTrans.DeployOffset(offset)
        IsDeployed = True
    End Sub
    Public Shared Sub Restore(R As RenderTarget)
        If IsDeployed Then
            R.Transform = CurrentTrans.ToMatrix
            IsDeployed = False
        End If
    End Sub

End Class



