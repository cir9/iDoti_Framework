

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        GameInit.Init(Me, ClientSize.Width, ClientSize.Height)
        StartRender()

        Testing.Init()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Score += 1
        GameUI.ScoreBar.PointIncrease(1)
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        GameInput.MouseMove(e)
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        'NowStage.Generate(Wall.GetGeneratorWith({20, 50, 20}))
        'NowStage.Generate(Generators2.GetGeneratorWith({e.X, e.Y, Rnd() - 0.5}))
        NowStage.Generate(Generators2.GetGeneratorWith({e.X, e.Y, Rnd() - 0.5}))
    End Sub

    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        Cursor.Hide()
    End Sub
    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Cursor.Show()
    End Sub
End Class
