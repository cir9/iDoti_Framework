


Module MathUtil

    Public Function RandomPosition(w As Single, h As Single, r As Single) As Vec2
        Return New Vec2(Rnd() * (w - r * 2) + r, Rnd() * (h - r * 2) + r)
    End Function

    Public Function RandomVector(m As Single) As Vec2
        Dim deg As Double = 2 * Math.PI * Rnd()
        Return New Vec2(Math.Sin(deg) * m, Math.Cos(deg) * m)
    End Function

    Public Function RandomVector(minM As Single, maxM As Single) As Vec2
        Return RandomVector(Rnd() * (maxM - minM) + minM)
    End Function

    Public Function Precision(num As Single, n As Integer) As String
        Dim mul As String = 10 ^ Int(Math.Log10(num) - n + 1)
        Return String.Format("{0:" & mul.Replace("1"c, "0"c) & "}", num)
    End Function

    Public Function InRange(a As Single, b As Single, p As Single, v As Single) As Boolean
        Return (p >= a OrElse v > 0) AndAlso (p <= b OrElse v < 0)
    End Function

    Public Function InRange(a As Single, b As Single, p As Single, v As Single, r As Single) As Boolean
        Return (p + r >= a OrElse v > 0) AndAlso (p <= b + r OrElse v < 0)
    End Function


    Public Function CompressValue(num As Single, padding As Single) As Single
        Return num / (num + padding)
    End Function

    Public Function DecompressValue(compressedNum As Single, padding As Single) As Single
        Return (padding * compressedNum) / (1 - compressedNum)
    End Function

    Public Function LimitedIncrease(nowNum As Single, maxNum As Single, delta As Single, padding As Single) As Single
        nowNum /= maxNum
        Dim r As Single = 1 - nowNum
        Return (nowNum * padding + delta * r) * maxNum / (padding + delta * r)
    End Function

    Public Function ApproachTo(nowNum As Single, targetNum As Single, padding As Single) As Single
        Return nowNum + (targetNum - nowNum) / padding
    End Function

End Module





