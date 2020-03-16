


Module GeneratorPreset


    Public Generator1 As New LambdaGenerator(
        Sub(dots As DotList)
            Dim n = 100
            dots.CreateDotsFrom(NormalDot).
                    Position({100, 0}).
                    Speed({200, 0}).
            Repeat(n).EachRotate(360 / n).Deploy(ClientCenter)
        End Sub)

    Public Generators1 As New ParamGenerators(
        Sub(dots As DotList, params As Single())
            Dim n = 1000
            Dim point As New Vec2(params(0), params(1))
            For i = 1 To n
                'dots.CreateDotFrom(NormalDot).SetDetails(
                '   10.0F, point + RandomVector(250), RandomVector(100, 200))
            Next
        End Sub)

    Public Generator2 As New LambdaTickGenerator(Timing.Timer(500, 20, 50),
        Sub(dots As DotList, clock As Clock)
            Dim n = 3
            dots.CreateDotsFrom(NormalDot).
                Position({clock.TickProgress * 100, 0}).
                Speed({clock.TickProgress * 200 + 200, 0}).
                Update(clock.NowTime).
            Repeat(n).EachRotate(360 / n).Deploy(ClientCenter)
        End Sub)

    Public Generators2 As New ParamTickGenerators(Timing.Timer(500, 200, 50),
        Sub(dots As DotList, clock As Clock, params() As Single)
            Dim n As Single = 3 ' + clock.TickIndex / 20
            Dim point As New Vec2(params(0), params(1))
            Dim p As Vec2 = New Vec2(clock.TickProgress * 100, 0).Rotate(clock.TickIndex * 90 * params(2))
            dots.CreateDotsFrom(DaggerDot).
                Radius(10).
                Speed((point + p - ClientCenter).Normalize(clock.TickProgress + 1) * -200).
                Timeline(Dot_Timeline).
                Update(clock.NowTime).
            Repeat(n).EachRotate(360 / n).Deploy(point)
        End Sub)

    Public Wall As New ParamGenerators(
        Sub(dots As DotList, params() As Single)
            Dim moveSpeed As Single = params(0)
            Dim nowNum As Single = params(1)
            Dim density As Single = params(2)

            Dim position As Vec2
            Dim p As Vec2 = {ClientSize.X * (Rnd() * 2 - 0.5), -ClientSize.Y * (Rnd() * 0.5 + 0.2)}
            Dim q As Vec2 = {ClientSize.X * Rnd(), ClientSize.Y * (Rnd() * 0.5 + 0.2)}

            position = {0, density}
            dots.CreateDotsFrom(EnemyDot).
                Position(position).
                Speed((q - p).Normalize(moveSpeed) + {0F, 100.0F}).
            Repeat(nowNum).EachRotate(360 / nowNum).Deploy(p)

        End Sub)


    Public Dither As New ParamTickGenerators(Timing.Timer(500, 20, 100),
        Sub(clock As Clock)
            With clock.UseData
                .shift = 0
            End With
        End Sub,
        Sub(dots As DotList, clock As Clock, params() As Single)
            Dim shift As Single = clock.Data.shift
            Dim n = 3 + clock.TickProgress * 3
            shift += (Rnd() - 0.5) * 50

            dots.CreateDotsFrom(DaggerDot).
                Position({shift, 0}).
                Speed({0, clock.TickProgress * 200 + 100}).
                Update(clock.NowTime).
            Repeat(n).
                EachMove({800 / (n - 1), clock.TickProgress * 100}).
            Deploy({ClientCenter.X - 400, -400})

            clock.Data.shift = shift
        End Sub)


    Public Sub Init()

    End Sub
End Module
