Module Module1

    Sub Main()
        Dim joursLocation As Integer, distance As Double

        Console.WriteLine("Nombre de jours de location ?")
        joursLocation = Console.ReadLine()

        Console.WriteLine("Distance à parcourir (en kms) ?")
        distance = Console.ReadLine()

        Dim prixFinalEssence, prixFinalDiesel As Double
        prixFinalEssence = joursLocation * 30 + distance * 0.85
        prixFinalDiesel = joursLocation * 35 + distance * 0.65

        If (prixFinalEssence < prixFinalDiesel) Then
            Console.WriteLine("Meilleur choix : Essence")
        ElseIf (prixFinalEssence > prixFinalDiesel) Then
            Console.WriteLine("Meilleur choix : Diesel")
        Else
            Console.WriteLine("Il n'y a pas de meilleur choix.")
        End If

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module
