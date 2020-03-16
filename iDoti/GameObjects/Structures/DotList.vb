

Public Class DotList
    Inherits StageRelatedList(Of Dot)

    Public Sub New(stage As Stage, capacity As Single)
        MyBase.New(stage, capacity)
    End Sub

    Public Function CreateDotsFrom(template As DotTemplate) As DotBuilder
        Return New DotBuilder(template).CreateOn(Stage)
    End Function

    Public Function CreateDotFrom(template As DotTemplate) As Dot
        Dim dot = template.Create()
        Add(dot)
        Return dot
    End Function
End Class
