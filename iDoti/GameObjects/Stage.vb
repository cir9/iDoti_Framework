

Imports SharpDX.Direct2D1

Public Class Stage

    Public Property Name As String

    Public Width As Single, Height As Single
    Public ActiveArea As Rect4

    Public Dots As New DotList(Me, 1024)
    Public Generators As New GeneratorList(Me)
    Public Animations As New AnimationList(Me)


    Public Player As Dot
    Public Sub New(size As Vec2)
        Width = size.X
        Height = size.Y
        ActiveArea = Rect4.FromSize(size)
        Player = PlayerDot.Create()
    End Sub

    Public Sub Generate(g As Generator)
        Generators.AddGenerator(g)
    End Sub

    Public Sub StartAnimation(Of T As ICleanable)(a As Animation(Of T))
        Animations.StartAnimation(a)
    End Sub

    Public Sub Update()
        Dim HitCount As Integer

        Player.Position = GameInput.Cursor


        Dots.Update()
        Generators.Update()
        Animations.Update()

        DebugPrintf("Stage {0}: ", Name)

        DebugPrintf("    {0}, {1}, {2}", Plu_Dot(Dots.Count),
                                         Plu_Animation(Animations.Count),
                                         Plu_Generator(Generators.Count))

        CheckInactive()

        If HitCount > 0 Then
            Score += HitCount
            GameUI.ScoreBar.PointIncrease(HitCount)
        End If
    End Sub

    Public Sub Render(R As RenderTarget)
        For Each dot In Dots
            dot.Draw(R)
        Next
        Player.Draw(R)
    End Sub


    Public Sub CheckInactive()
        Static nowIndex As Integer = 0
        Static sliceSize = 0
        Dim inas As Integer
        If Dots.Count > 0 Then
            sliceSize = Math.Max(20, Dots.Count / 60)
            nowIndex += sliceSize
            nowIndex = nowIndex Mod Dots.Count
            DebugPrintf("    clean from [{0:0000}] +{1:00}", nowIndex, sliceSize)
            For Each dot In Dots.Slice(nowIndex, sliceSize)
                If Not dot.IsInRange(ActiveArea) Then
                    dot.IsGarbage = True
                    inas += 1
                End If
            Next
            ScoreIncrease(inas)
        End If
    End Sub




End Class