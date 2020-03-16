

Imports iDoti
Public Class JumpFlow
    Inherits Flow

    Public Index As Integer
    Public Sub New(index As Integer)
        Me.Index = index
    End Sub
    Public Overrides Function Compile(f As IFlowController) As IExecutable
        Return New JumpFlowExecution().ToExecutable(Me, f)
    End Function

    Public Class JumpFlowExecution
        Inherits FlowExecution(Of JumpFlow)
        Protected Overrides Sub Execute(dt As Single)
            FlowController.JumpTo(Definition.Index, dt)
        End Sub

        Protected Overrides Sub Init()
            IsReserved = True
        End Sub
    End Class
End Class
Public Class LoopFlow
    Inherits Flow

    Public LoopCount As Integer
    Public Index As Integer

    Public Sub New(loopCount As Integer, index As Integer)
        Me.LoopCount = loopCount
        Me.Index = index
    End Sub
    Public Overrides Function Compile(f As IFlowController) As IExecutable
        Return New LoopFlowExecution().ToExecutable(Me, f)
    End Function

    Public Class LoopFlowExecution
        Inherits FlowExecution(Of LoopFlow)

        Public Counter As Integer
        Protected Overrides Sub Init()
            Counter = 0
            IsReserved = True
        End Sub
        Protected Overrides Sub Execute(dt As Single)
            Counter += 1

            If Counter < Definition.LoopCount Then
                FlowController.JumpTo(Definition.Index, dt)
            Else
                IsReserved = False
            End If
        End Sub
    End Class
End Class
Public Class JudgeFlow
    Inherits Flow

    Public Judge As Func(Of Boolean)
    Public FalseIndex As Integer

    Public Sub New(judge As Func(Of Boolean), falseIndex As Integer)
        Me.Judge = judge
        Me.FalseIndex = falseIndex
    End Sub
    Public Overrides Function Compile(f As IFlowController) As IExecutable
        Return New JudgeFlowExecution().ToExecutable(Me, f)
    End Function

    Public Class JudgeFlowExecution
        Inherits FlowExecution(Of JudgeFlow)
        Protected Overrides Sub Execute(dt As Single)
            If Not Definition.Judge() Then
                FlowController.JumpTo(Definition.FalseIndex, dt)
            End If
        End Sub
        Protected Overrides Sub Init()
            IsReserved = True
        End Sub
    End Class
End Class

