Module Module1

    Sub Main()
        Dim representant, choix As String, revenusMensuel As Integer = 0
        choix = ""

        While choix <> "N"
            Console.WriteLine("Nom du représentant ?")
            representant = Console.ReadLine()
            revenusMensuel = 0

            For i = 1 To 3
                Console.WriteLine("Semaine " + i.ToString() + ": Ventes H.T hebdomadaires (0 pour stopper la saisie) ?")
                Dim resultatUtilisateur As Integer
                resultatUtilisateur = Integer.Parse(Console.ReadLine())

                If (resultatUtilisateur < 0) Then
                    Console.WriteLine("Ventes ne peuvent être < 0")
                    revenusMensuel = revenusMensuel + Integer.Parse(Console.ReadLine())
                Else
                    revenusMensuel = revenusMensuel + resultatUtilisateur
                End If
            Next

            Console.WriteLine("Bilan pour " + representant)
            Console.WriteLine("Total des ventes H.T. = " + revenusMensuel.ToString())
            Console.WriteLine("Commission = " + (revenusMensuel * 0.1).ToString())

            Console.WriteLine("Autre représentant (O/N)")
            choix = Console.ReadLine()
        End While

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module