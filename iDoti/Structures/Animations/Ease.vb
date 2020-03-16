
Public Class EaseFunction
    Public Ease As Func(Of Single, Single)
    Public Sub New(tEase As Func(Of Single, Single))
        Ease = tEase
    End Sub
End Class


Namespace Ease
    Public Module Linear
        Public Ease As New EaseFunction(Function(t As Single) t)
    End Module
    Public Module Quad
        Public EaseIn As New EaseFunction(Function(t As Single) As Single
                                              Return t * t
                                          End Function)
        Public EaseOut As New EaseFunction(Function(t As Single) As Single
                                               t = 1 - t
                                               Return 1 - t * t
                                           End Function)
        Public EaseInOut As New EaseFunction(Function(t As Single) As Single
                                                 t *= 2
                                                 If t < 1 Then Return t * t * 0.5
                                                 t = 2 - t
                                                 Return 1 - t * t * 0.5
                                             End Function)
    End Module
    Public Module Quart
        Public EaseIn As New EaseFunction(Function(t As Single) As Single
                                              Return t * t * t * t
                                          End Function)
        Public EaseOut As New EaseFunction(Function(t As Single) As Single
                                               t = 1 - t
                                               Return 1 - t * t * t * t
                                           End Function)
        Public EaseInOut As New EaseFunction(Function(t As Single) As Single
                                                 t *= 2
                                                 If t < 1 Then Return t * t * t * t * 0.5
                                                 t = 2 - t
                                                 Return 1 - t * t * t * t * 0.5
                                             End Function)
    End Module

    Public Module Sept
        Public EaseIn As New EaseFunction(Function(t As Single) As Single
                                              Return t * t * t * t * t * t * t
                                          End Function)
        Public EaseOut As New EaseFunction(Function(t As Single) As Single
                                               t = 1 - t
                                               Return 1 - t * t * t * t * t * t * t
                                           End Function)
    End Module

    Public Module Back
        Private s = 1.70158
        Public EaseIn As New EaseFunction(Function(t As Single)
                                              Return t * t * ((s + 1) * t - s)
                                          End Function)
        Public EaseOut As New EaseFunction(Function(t As Single)
                                               t = t - 1
                                               Return t * t * ((s + 1) * t + s) + 1
                                           End Function)



    End Module


    Public Module Blend
        Public Function ByWeight(e1 As EaseFunction, w1 As Single, e2 As EaseFunction, w2 As Single) As EaseFunction
            Return New EaseFunction(Function(t As Single) As Single
                                        Return (e1.Ease(t) * w1 + e2.Ease(t) * w2) / (w1 + w2)
                                    End Function)
        End Function
        Public Function ByWeight(e() As EaseFunction, w() As Single) As EaseFunction
            Return New EaseFunction(Function(t As Single) As Single
                                        Dim totalWeight As Single
                                        Dim res As Single
                                        For i = 0 To e.Count - 1
                                            res += e(i).Ease(t) * w(i)
                                            totalWeight += w(i)
                                        Next
                                        Return res / totalWeight
                                    End Function)
        End Function
        Public Function FromOneToOne(e1 As EaseFunction, e2 As EaseFunction) As EaseFunction
            Return New EaseFunction(Function(t As Single) As Single
                                        Return e1.Ease(t) * (1.0F - t) + e2.Ease(t) * t
                                    End Function)
        End Function
        Public Function FromOneToOne(e1 As EaseFunction, e2 As EaseFunction, compEase As EaseFunction) As EaseFunction
            Return New EaseFunction(Function(t As Single) As Single
                                        Dim rt As Single = compEase.Ease(t)
                                        Return e1.Ease(t) * (1.0F - rt) + e2.Ease(t) * rt
                                    End Function)
        End Function
        Public Function Compound(e1 As EaseFunction, e2 As EaseFunction) As EaseFunction
            Return New EaseFunction(Function(t As Single) As Single
                                        Return e1.Ease(e2.Ease(t))
                                    End Function)
        End Function
    End Module
End Namespace

