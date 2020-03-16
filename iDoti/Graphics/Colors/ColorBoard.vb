
Imports SharpDX.Direct2D1


Public Class ColorBoard
    Public Color As Color

    Public Brush As SolidColorBrush

    Public Sub New(c As Color)
        Color = c
        UpdateBrush()
    End Sub
    Public Sub New(R As Single, G As Single, B As Single, A As Single)
        Color.R = R
        Color.G = G
        Color.B = B
        Color.A = A
        UpdateBrush()
    End Sub


    Public Sub UpdateBrush()
        Brush?.Dispose()
        Brush = New SolidColorBrush(ResourceContext, Color.ToRawColor4)
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("RGBA({0:0},{1:0},{2:0},{3:0.00})", Color.R, Color.G, Color.B, Color.A)
    End Function
    Public Shared Function FromRGBA(R As Single, G As Single, B As Single, A As Single) As ColorBoard
        Return New ColorBoard(R / 255, G / 255, B / 255, A)
    End Function
    Public Shared Function FromHex(hex As String) As ColorBoard
        Return New ColorBoard(Color.FromHex(hex))
    End Function

End Class

Public Class AnimatedColorBoard
    Inherits ColorBoard
    Implements ICleanable
    Public Property IsGarbage As Boolean Implements ICleanable.IsGarbage

    Public ColorAnimation As ColorAnimation


    Public Sub New(bc As Color, ec As Color, animation As ColorAnimation, a As Boolean)
        MyBase.New(ec)
        ColorAnimation = animation
        ColorAnimation.BeginColor = bc
        ColorAnimation.EndColor = ec
        If a Then Start()
    End Sub

    Public Sub New(bc As String, ec As String, animation As ColorAnimation, a As Boolean)
        Me.New(Color.FromHex(bc), Color.FromHex(ec), animation, a)
    End Sub


    Public Sub New(bc As String, ec As String, et As Single, ease As EaseFunction, a As Boolean)
        Me.New(Color.FromHex(bc), Color.FromHex(ec), New ColorAnimation(et, ease), a)
    End Sub

    Public Sub Start()
        IsGarbage = False
        If Not ColorAnimation.IsRunning Then AddColor(Me)
        ColorAnimation.Start()
    End Sub

    Public Sub Update() Implements ICleanable.Update
        If ColorAnimation.Update(Me) Then
            UpdateBrush()
        Else
            IsGarbage = True
        End If
    End Sub

End Class

Public Class ImpactColorBoard
    Inherits AnimatedColorBoard


    Public ImpactColorAnimation As ImpactColorAnimation
    Public Sub New(bc As Color, ec As Color, animation As ImpactColorAnimation, a As Boolean)
        MyBase.New(bc, ec, animation, a)
        ImpactColorAnimation = animation
    End Sub
    Public Sub New(bc As String, ec As String, et As Single, ease As EaseFunction, a As Boolean)
        Me.New(Color.FromHex(bc), Color.FromHex(ec), New ImpactColorAnimation(et, ease), a)
    End Sub

    Public Sub Increase(v As Single)
        ImpactColorAnimation.Increase(v)
        Start()
    End Sub
End Class