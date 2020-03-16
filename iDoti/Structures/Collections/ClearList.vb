

Public Class ClearList(Of T As ICleanable)
    Inherits List(Of T)


    Public Sub New()
        MyBase.New
    End Sub

    Public Sub New(capacity As Integer)
        MyBase.New(capacity)
    End Sub

    Public Function All() As IEnumerable(Of T)
        Return New ClearEnumerable(Me)
    End Function

    Public Function Slice(startIndex As Integer, count As Integer) As IEnumerable(Of T)
        Return New SliceEnumerable(Me, startIndex, count)
    End Function


    Public Structure ClearEnumerable
        Implements IEnumerable(Of T)

        Private enumerator As ClearEnumerator

        Public Sub New(l As List(Of T))
            enumerator = New ClearEnumerator(l)
        End Sub
        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return enumerator
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return enumerator
        End Function
    End Structure
    Public Structure ClearEnumerator
        Implements IEnumerator(Of T)

        Private currentIndex As Integer
        Private list As List(Of T)
        Public Sub New(l As List(Of T))
            currentIndex = -1
            list = l
        End Sub
        Public ReadOnly Property Current As T Implements IEnumerator(Of T).Current
            Get
                Return list(currentIndex)
            End Get
        End Property
        Private ReadOnly Property IEnumerator_Current As Object Implements IEnumerator.Current
            Get
                Return list(currentIndex)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
        Public Sub Reset() Implements IEnumerator.Reset
            currentIndex = -1
        End Sub
        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            currentIndex += 1
            Do
                If currentIndex >= list.Count Then
                    Return False
                ElseIf list(currentIndex).IsGarbage Then
                    list.RemoveAt(currentIndex)
                Else
                    Return True
                End If
            Loop
        End Function
    End Structure

    Public Structure SliceEnumerable
        Implements IEnumerable(Of T)

        Private enumerator As SliceEnumerator
        Public Sub New(l As List(Of T), f As Single, t As Single)
            enumerator = New SliceEnumerator(l, f, t)
        End Sub

        Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return enumerator
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return enumerator
        End Function
    End Structure

    Public Structure SliceEnumerator
        Implements IEnumerator(Of T)


        Private fromIndex As Integer
        Private toIndex As Integer

        Private currentIndex As Integer
        Private list As List(Of T)
        Public Sub New(l As List(Of T), f As Integer, t As Integer)
            currentIndex = -1
            list = l
            FromIndex1 = f - 1
            ToIndex1 = f + t
        End Sub

        Public Sub Reset(f As Integer, t As Integer)

        End Sub
        Public ReadOnly Property Current As T Implements IEnumerator(Of T).Current
            Get
                Return list(currentIndex)
            End Get
        End Property

        Public Property FromIndex1 As Integer
            Get
                Return fromIndex
            End Get
            Set(value As Integer)
                fromIndex = value
            End Set
        End Property

        Public Property ToIndex1 As Integer
            Get
                Return toIndex
            End Get
            Set(value As Integer)
                toIndex = value
            End Set
        End Property

        Private ReadOnly Property IEnumerator_Current As Object Implements IEnumerator.Current
            Get
                Return list(currentIndex)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
        End Sub
        Public Sub Reset() Implements IEnumerator.Reset
            currentIndex = FromIndex1
        End Sub
        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            currentIndex += 1
            Return currentIndex < ToIndex1 AndAlso currentIndex < list.Count
        End Function
    End Structure
End Class
