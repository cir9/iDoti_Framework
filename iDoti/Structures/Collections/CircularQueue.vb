


Public Class CircularQueue(Of T)
    Private Datas() As T

    Public Front As Integer
    Public Rear As Integer
    Public Count As Integer

    Private _capacity As Integer
    Public Property Capacity As Integer
        Get
            Return _capacity
        End Get
        Set(value As Integer)
            _capacity = value
            ReDim Datas(value - 1)
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(capacity As Integer)
        Me.Capacity = capacity
    End Sub

    Public Sub Enqueue(item As T)
        Datas(Rear) = item
        Rear = (Rear + 1) Mod _capacity
        Count += 1
    End Sub

    Public Function CircularEnqueue(item As T) As T
        Dim res As T
        If Count = _capacity Then
            res = Dequeue()
        End If
        Enqueue(item)
        Return res
    End Function

    Public Function Dequeue() As T
        Dim res As T = Datas(Front)
        Front = (Front + 1) Mod _capacity
        Count -= 1
        Return res
    End Function

    Public Sub ForEach(action As Action(Of T))
        For Each e In Datas
            action(e)
        Next
    End Sub


End Class
