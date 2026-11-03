Module Module1

    Sub Main()
        Dim heuresTravaillees As Integer, tauxHoraire, majoration As Double

        Console.WriteLine("Nombre d'heures travaillées hebdomadaire ?")
        heuresTravaillees = Console.ReadLine()

        If (heuresTravaillees < 39) Then
            Console.WriteLine("Vous ne travaillez pas assez !")
            Console.WriteLine("Salaire hebdomadaire : 0")
        Else
            Console.WriteLine("Taux horaire ?")
            tauxHoraire = Console.ReadLine()

            If (heuresTravaillees = (39 + 8)) Then
                majoration = 1.25
            ElseIf (heuresTravaillees > (39 + 8)) Then
                majoration = 1.5
            Else
                majoration = 1
            End If

            Console.WriteLine("Salaire hebdomadaire : " + (heuresTravaillees * (tauxHoraire * majoration)).ToString())
        End If

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module
