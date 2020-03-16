
Imports iDoti

Public MustInherit Class Flow
    Public MustOverride Function Compile(f As IFlowController) As IExecutable
End Class

Public MustInherit Class FlowExecution(Of T As Flow)
    Implements IExecutable

    Public Definition As T
    Public FlowController As IFlowController
    Public IsReserved As Boolean
    Public Function ToExecutable(definition As T, f As IFlowController) As IExecutable
        FlowController = f
        Me.Definition = definition
        Return Me
    End Function
    Protected MustOverride Sub Init()
    Protected MustOverride Sub Execute(dt As Single)
    Private Sub _Execute(dt As Single) Implements IExecutable.Execute
        If Not IsReserved Then
            Init()
        End If
        Execute(dt)
    End Sub
End Class
