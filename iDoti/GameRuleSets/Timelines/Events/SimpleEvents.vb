


Imports iDoti

Public Class DebugEvent(Of T)
    Inherits SimpleEvent(Of T)
    Implements IExecutable

    Public Text As String

    Public Sub New(text As String)
        Me.Text = text
    End Sub
    Public Overrides Sub Execute(dt As Single) Implements IExecutable.Execute
        Debug.Print(String.Format("[dt={1:0.000}] {0}", Text, dt))
    End Sub
    Public Overrides Function Compile(t As Timeline(Of T)) As IExecutable
        Return Me
    End Function
End Class

Public Class EmptyEvent(Of T)
    Inherits SimpleEvent(Of T)
    Implements IExecutable

    Public Overrides Sub Execute(dt As Single) Implements IExecutable.Execute

    End Sub

    Public Overrides Function Compile(t As Timeline(Of T)) As IExecutable
        Return Me
    End Function
End Class


Public Class UpdateEvent(Of T)
    Inherits SimpleEvent(Of T)
    Implements IExecutable

    Public Update As Action

    Public Sub New(action As Action)
        Update = action
    End Sub
    Public Overrides Sub Execute(dt As Single) Implements IExecutable.Execute
        Update()
    End Sub
    Public Overrides Function Compile(t As Timeline(Of T)) As IExecutable
        Return Me
    End Function
End Class