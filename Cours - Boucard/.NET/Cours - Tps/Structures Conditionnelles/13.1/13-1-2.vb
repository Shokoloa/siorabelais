Module Module1
    Const SIZE = 9

    Sub MinMax(tab() As Double)
        Dim min As Double = tab(0)
        Dim max As Double = tab(0)

        For i As Integer = 1 To SIZE
            If tab(i) < min Then
                min = tab(i)
            End If

            If tab(i) > max Then
                max = tab(i)
            End If
        Next

        Console.WriteLine("Min = " & min)
        Console.WriteLine("Max = " & max)

    End Sub

    Sub Main()
        Dim nombres(SIZE) As Double

        For i = 1 To SIZE
            Console.WriteLine("Nombre n°" + i.ToString() + " ?")
            nombres(i) = Console.ReadLine()
        Next

        MinMax(nombres)

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module