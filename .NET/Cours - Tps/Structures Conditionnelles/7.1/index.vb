Module Module1

    Sub Main()
        Dim montant, remise As Double

        Console.WriteLine("Veuillez taper votre montant")
        montant = Console.ReadLine()

        If (montant >= 2000 And montant <= 5000) Then
            remise = 0.01
        ElseIf (montant >= 5000) Then
            remise = 0.02
        End If

        If (remise) Then
            Console.WriteLine("La remise est de " + (remise * 100).ToString() + "%")
            Console.WriteLine("Le montant net est : " + (montant - (montant * remise)).ToString())
        Else
            Console.WriteLine("Pas de remise")
            Console.WriteLine("Le montant net est : " + montant.ToString())
        End If

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module
