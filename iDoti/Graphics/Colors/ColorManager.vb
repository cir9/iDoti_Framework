
Imports iDoti
Imports SharpDX.Direct2D1

Module ColorManager
    Public brush_White As ColorBoard = HexColor("F")

    Public color_NormalDot As ColorBoard = HexColor("71c7d5")

    Public AnimatedColors As New ClearList(Of AnimatedColorBoard)

    Public Function HexColor(hex As String) As ColorBoard
        Return ColorBoard.FromHex(hex)
    End Function

    Public Sub AddColor(color As ColorBoard)
        'If Not AnimatedColors.Contains(color) Then
        AnimatedColors.Add(color)
        'End If
    End Sub


    Public Sub Update()
        For Each ac In AnimatedColors.all
            ac.Update()
        Next
        DebugPrintf("{0}", Plu_Color(AnimatedColors.Count, "animated"))
    End Sub

    Public Sub Init()
    End Sub
End Module