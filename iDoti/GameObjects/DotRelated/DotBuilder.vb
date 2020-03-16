
Imports CFloat = iDoti.Customable(Of Single)
Imports CVec2 = iDoti.Customable(Of iDoti.Vec2)
Imports CMovement = iDoti.Customable(Of iDoti.Movement)

Public Class DotBuilder

    Public Stage As Stage
    Public Dots As DotList
    Public Dot As Dot
    Public DotTemplate As DotTemplate

    Protected _position As CVec2

    Protected _speed As CVec2

    Protected _radius As CFloat



    Protected _deltaTime As CFloat

    Protected Friend timelineBuilder As DotTimelineBuilder
    Protected _timeline As TimelinePreset(Of Dot)

    Public IsRelativePosition As Boolean


    Public Sub New(dotTemplate As DotTemplate)
        Me.DotTemplate = dotTemplate
    End Sub
    Public Sub New(t As DotTemplate, b As DotTimelineBuilder)
        DotTemplate = t
        timelineBuilder = b
    End Sub

    Public Function End_Spawn() As DotTimelineBuilder
        Return timelineBuilder.Spawn(Me)
    End Function

    Public Function CreateOn(stage As Stage) As DotBuilder
        Me.Stage = stage
        Dots = stage.Dots
        Dot = Dots.CreateDotFrom(DotTemplate)
        Return Me
    End Function

    Public Function Position(p As Vec2) As DotBuilder
        _position = p
        Return Me
    End Function
    Public Function Position(p As Func(Of Vec2)) As DotBuilder
        _position = p
        Return Me
    End Function
    Public Function Relative() As DotBuilder
        IsRelativePosition = True
        Return Me
    End Function

    Public Function Speed(v As Vec2) As DotBuilder
        _speed = v
        Return Me
    End Function
    Public Function Speed(v As Func(Of Vec2)) As DotBuilder
        _speed = v
        Return Me
    End Function
    Public Function Radius(r As Single) As DotBuilder
        _radius = r
        Return Me
    End Function
    Public Function Radius(r As Func(Of Single)) As DotBuilder
        _radius = r
        Return Me
    End Function
    Public Function Timeline() As DotTimelineBuilder
        Return DotTimelineBuilder.Create(Me)
    End Function
    Public Function Timeline(t As TimelinePreset(Of Dot)) As DotBuilder
        _timeline = t
        Return Me
    End Function

    Public Function ToDot() As Dot
        Return Dot
    End Function

    Public Function Update(dt As Single) As DotBuilder
        _deltaTime = dt
        Return Me
    End Function

    Public Function Repeat(n As Integer) As DotSet
        Return New DotSet(Me, n)
    End Function

    Public Function CreateDot() As DotBuilder
        Dot = Dots.CreateDotFrom(DotTemplate)
        Return Me
    End Function

    Public Function SetProperty() As DotBuilder
        _position.SetValue(Dot.Position)
        _speed.SetValue(Dot.Speed)
        _radius.SetValue(Dot.Size)
        Return Me
    End Function

    Protected _transform As Matrix6 = Matrix6.Identity
    Public IsTransformed As Boolean

    Public Function Transform(m As Matrix6) As DotBuilder
        _transform = m
        IsTransformed = True
        Return Me
    End Function

    Public Function ClearTransform() As DotBuilder
        IsTransformed = False
        Return Me
    End Function

    Private Sub DeployTrasnform()
        If IsTransformed Then
            Dot.Position *= _transform
            Dot.Speed *= _transform
        End If
    End Sub


    Public Function Deploy(offset As Vec2) As DotBuilder
        SetProperty()
        DeployTrasnform()
        Dot.Position += offset


        If _deltaTime.IsCustome Then
            Dot.Update(_deltaTime)
        End If

        Dot.Timeline = _timeline?.Compile(Dot)

        Dot.DeployFinished(Stage)
        Return Me
    End Function

    Public Function Deploy() As DotBuilder
        Return Deploy(Vec2.Zero)
    End Function

    Public Function Deploy(dot As Dot) As DotBuilder
        CreateOn(dot.Stage)
        If IsRelativePosition Then
            If IsTransformed Then
                _transform = _transform.RotateTo(dot.Speed)
                Deploy(dot.Position)
            Else
                _transform = _transform.RotateTo(dot.Speed)
                IsTransformed = True
                Deploy(dot.Position)
                _transform = Matrix6.Identity
                IsTransformed = False
            End If
        Else
            Deploy()
        End If
        Return Me
    End Function



End Class
