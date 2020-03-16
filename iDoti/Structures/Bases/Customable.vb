
Public Structure Customable(Of T)
    Public Value As T
    Public Lambda As Func(Of T)

    Public ReadOnly Property IsCustome As Boolean
        Get
            Return Type <> CustomeType.Default
        End Get
    End Property

    Public Type As CustomeType
    Public Enum CustomeType
        [Default]
        Value
        Lambda
    End Enum
    Public Sub New(v As T)
        Value = v
        Type = CustomeType.Value
    End Sub
    Public Sub New(v As Func(Of T))
        Lambda = v
        Type = CustomeType.Lambda
    End Sub

    Public Shared Narrowing Operator CType(v As T) As Customable(Of T)
        Return New Customable(Of T)(v)
    End Operator
    Public Shared Narrowing Operator CType(v As Func(Of T)) As Customable(Of T)
        Return New Customable(Of T)(v)
    End Operator
    Public Shared Narrowing Operator CType(v As Customable(Of T)) As T
        Select Case v.Type
            Case CustomeType.Value
                Return v.Value
            Case CustomeType.Lambda
                Return v.Lambda()
            Case Else
                Return v.Value
        End Select
    End Operator

    Public Sub SetValue(ByRef v As T)
        If IsCustome Then v = Me
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("{0}, IsCustome={1}", Value, IsCustome)
    End Function
End Structure

