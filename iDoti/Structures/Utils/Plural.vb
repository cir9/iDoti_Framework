Public Class Plural

    Public Singular As String
    Public Plural As String

    Public Sub New(ParamArray str() As String)
        Singular = str(0)
        Plural = str(1)
    End Sub

    Default Public ReadOnly Property Count(num As Integer) As String
        Get
            Return String.Format("{0} {1}", num, If(num = 1, Singular, Plural))
        End Get
    End Property

    Default Public ReadOnly Property Count(num As Integer, fix As String) As String
        Get
            Return String.Format("{0} {1} {2}", num, fix, If(num = 1, Singular, Plural))
        End Get
    End Property
End Class
