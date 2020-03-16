


Public Structure RandomDegree

    Public Degree As Single
    Private dDegree As Single
    Private lastChange As Single, thisChange As Single


    Public Scope As Single
    Public ApproachRate As Single
    Public Frequency As Single
    Public Stability As Single

    Public Sub New(scope As Single, approach As Single, stab As Single)
        Me.Scope = scope
        ApproachRate = approach
        Stability = stab
    End Sub

    Public Sub Randomize()
        Degree = Rnd() * 360
        lastChange = Degree
        dDegree = Math.Abs(Rnd() - 0.5) * (Rnd() + 0.5) * Scope * ApproachRate
    End Sub

    Public Function GetNext() As Single
        If Rnd() > Stability * If(thisChange > 120, (240 - thisChange) / 120, 1) Then
            dDegree = Math.Abs(Rnd() - 0.5) * (Rnd() + 0.5) * Scope * ApproachRate
            lastChange = Degree
        End If
        Degree += dDegree * Scope
        thisChange = Math.Abs(Degree - lastChange)
        Return Degree
    End Function
    Public Function GetNextVector() As Vec2
        Return Vec2.FromDegree(GetNext)
    End Function



End Structure
