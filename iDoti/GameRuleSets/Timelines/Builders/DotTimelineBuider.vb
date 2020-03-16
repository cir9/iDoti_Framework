
Imports DotEvents = iDoti.Timeline.Event.Dot


Public Class DotTimelineBuilder
    Inherits TimelineBuilderWrapper(Of Dot, DotTimelineBuilder)

    Private dotBuilder As DotBuilder
    ''' <summary>
    ''' 内部方法，不要使用！！
    ''' </summary>
    ''' <param name="d">填Me就行</param>
    ''' <returns>一个新的DotTimelineBuilder</returns>
    Public Overloads Shared Function Create(d As DotBuilder) As DotTimelineBuilder
        Return New DotTimelineBuilder With {.dotBuilder = d}
    End Function
    Public Function End_Timeline() As DotBuilder
        Return dotBuilder.Timeline(Preset)
    End Function
    Public Function Spawn(dotTemplate As DotTemplate) As DotBuilder
        Return New DotBuilder(dotTemplate, Me)
    End Function
    Public Function Spawn(dotbuilder As DotBuilder) As DotTimelineBuilder
        Add(New DotEvents.Spawn(dotbuilder))
        Return Me
    End Function
    Public Function Spawn(dotSet As DotSet) As DotTimelineBuilder
        Add(New DotEvents.SymmeticSpawn(dotSet))
        Return Me
    End Function
End Class