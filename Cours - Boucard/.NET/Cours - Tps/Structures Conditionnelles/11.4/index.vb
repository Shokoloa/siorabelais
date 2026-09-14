Module Module1

    Function Triangle(ByVal lines As Integer) As String
        For i = 1 To lines
            ' Espaces avant les étoiles
            For j = 1 To lines - i
                Console.Write(" ")
            Next

            ' Étoiles
            For j = 1 To (2 * i - 1)
                Console.Write("*")
            Next

            Console.WriteLine()
        Next

        Return ""
    End Function

    Sub Main()
        Dim choix As Integer
        choix = -1

        While choix < 0
            Console.WriteLine("Combien de lignes pour votre triangle ? (>=0)")
            choix = Console.ReadLine()
        End While

        If choix >= 0 Then
            Triangle(choix)
        End If

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module