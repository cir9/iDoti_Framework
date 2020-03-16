Module GameScore


    Public Score As Single

    Public Sub ScoreIncrease(inc As Single)
        Score += inc
        GameUI.ScoreBar.PointIncrease(inc)
    End Sub


End Module
