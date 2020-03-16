
Imports System.Dynamic

Public Class DynamicDictionary(Of T)
    Inherits DynamicObject
    Public Dictionary As New Dictionary(Of String, T)
    ReadOnly Property Count As Integer
        Get
            Return Dictionary.Count
        End Get
    End Property
    Public Function Remove(key As String) As Boolean
        Return Dictionary.Remove(key)
    End Function
    Public Sub Clear()
        Dictionary.Clear()
    End Sub
    Public Overrides Function TryGetMember(binder As GetMemberBinder, ByRef result As Object) As Boolean
        Return Dictionary.TryGetValue(binder.Name, result)
    End Function
    Public Overrides Function TrySetMember(binder As SetMemberBinder, value As Object) As Boolean
        Dictionary(binder.Name) = value
        Return True
    End Function
End Class