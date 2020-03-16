Module GameInput


    Public Cursor As Vec2

    Public Parallax As New Vec2Approacher(16)

    Public Sub MouseMove(e As MouseEventArgs)
        Cursor.X = e.X
        Cursor.Y = e.Y
        Parallax.TargetValue = (ClientCenter - Cursor).Multiply(1.5, 1) * (0.5F / ClientDiagnoal)
    End Sub

    Public Sub Update()
        Parallax.Update()
    End Sub

End Module
