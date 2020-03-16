





Public Class DotSet
    Protected dotBuilder As DotBuilder

    Public RepeatTimes As Integer

    Public InitTransform As Matrix6 = Matrix6.Identity
    Public RepeatTransform As Matrix6 = Matrix6.Identity
    Public CurrentTransform As Matrix6 = Matrix6.Identity

    Public Sub New(db As DotBuilder, n As Integer)
        dotBuilder = db
        RepeatTimes = n
    End Sub

    Public Function RotateFrom(deg As Single) As DotSet
        InitTransform = Matrix6.FromRotation(deg) * RepeatTransform
        Return Me
    End Function

    Public Function EachRotate(deg As Single) As DotSet
        RepeatTransform = Matrix6.FromRotation(deg) * RepeatTransform
        Return Me
    End Function

    Public Function EachMove(vec As Vec2) As DotSet
        RepeatTransform.Move(vec)
        Return Me
    End Function

    Public Function Deploy(offset As Vec2) As DotSet
        CurrentTransform = InitTransform
        dotBuilder.Transform(CurrentTransform).Deploy(offset)
        For i = 2 To RepeatTimes
            CurrentTransform = RepeatTransform * CurrentTransform
            dotBuilder.CreateDot.Transform(CurrentTransform).Deploy(offset)
        Next
        Return Me
    End Function
    Public Function End_Spawn() As DotTimelineBuilder
        Return dotBuilder.timelineBuilder.Spawn(Me)
    End Function
    Public Function Deploy(dot As Dot, dt As Single) As DotSet
        CurrentTransform = InitTransform
        dotBuilder.Update(dt).Transform(CurrentTransform).Deploy(dot)
        For i = 2 To RepeatTimes
            CurrentTransform = RepeatTransform * CurrentTransform
            dotBuilder.Transform(CurrentTransform).Deploy(dot)
        Next
        Return Me
    End Function


End Class
