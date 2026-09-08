Module Module1

    Sub Main()
        Dim n As Integer

        Console.WriteLine("Nombre d'itérations ?")
        n = Console.ReadLine()

        For i As Integer = 1 To n
            Console.WriteLine(2 * i)
        Next

        Console.ReadLine()
    End Sub

End Module