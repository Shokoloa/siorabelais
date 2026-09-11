Module Module1
    Function Factorielle(ByVal n As Integer) As Long
        If n > 1 Then
            Return n * Factorielle(n - 1)
        Else
            Return 1
        End If
    End Function

    Sub Main()
        Dim choix As Integer = 0

        While choix <> -1
            Console.WriteLine("Saisir un nombre >= 0")
            choix = Console.ReadLine()
            If (choix < 0) Then
                Console.WriteLine("n > 0")
                choix = Console.ReadLine()
            End If
            Console.WriteLine("La factorielle de ce nombre est " + Factorielle(choix).ToString())
        End While

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module