

Imports CFloat = iDoti.Customable(Of Single)
Imports CVec2 = iDoti.Customable(Of iDoti.Vec2)

Public Structure DotParameters

    Public Position As CVec2
    Public Speed As CVec2
    Public Size As CFloat

    Public Sub Deploy(dot As Dot)
        Position.SetValue(dot.Position)
        Speed.SetValue(dot.Speed)
        Size.SetValue(dot.Size)
    End Sub
End Structure


