Module Module1

    Sub Main()
        Dim mois() As String = {"Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"}, numero As Integer

        Console.Write("Entrez le numéro du mois (1 à 12) : ")
        numero = Console.ReadLine()

        If (numero >= 1 And numero <= 12) Then
            Console.WriteLine("Le mois correspondant est : " + mois(numero - 1))
        Else
            Console.WriteLine("Erreur : le numéro doit être compris entre 1 et 12.")
        End If
    End Sub

End Module