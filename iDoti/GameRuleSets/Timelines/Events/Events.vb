


Imports iDoti

Public Interface IExecutable
    Sub Execute(dt As Single)
End Interface
Public MustInherit Class EventDefinition(Of T)
    Public MustOverride Function Compile(t As Timeline(Of T)) As IExecutable
End Class
Public MustInherit Class SimpleEvent(Of T)
    Inherits EventDefinition(Of T)
    Public MustOverride Sub Execute(dt As Single)
End Class
Public MustInherit Class ObjectEvent(Of T)
    Inherits EventDefinition(Of T)
    Public MustOverride Sub Execute(e As T, dt As Single)
    Public Overrides Function Compile(t As Timeline(Of T)) As IExecutable
        Return New ObjectEventExecution(Of T, ObjectEvent(Of T))(t, Me)
    End Function
End Class

Public Class ObjectEventExecution(Of T, V As ObjectEvent(Of T))
    Implements IExecutable

    Private parent As T
    Public Definition As V
    Public Sub New(t As Timeline(Of T), def As V)
        Definition = def
        parent = t.Parent
    End Sub
    Public Sub Execute(dt As Single) Implements IExecutable.Execute
        Definition.Execute(parent, dt)
    End Sub
End Class

Public Class FlowEvent(Of T)
    Inherits EventDefinition(Of T)

    Public Flow As Flow
    Public Sub New(flow As Flow)
        Me.Flow = flow
    End Sub
    Public Overrides Function Compile(t As Timeline(Of T)) As IExecutable
        Return Flow.Compile(t)
    End Function
End Class
