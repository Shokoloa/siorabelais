Module Module1
    Const MAXSALLES As Integer = 10
    Const MAXJOURS As Integer = 6
    Const MAXTRANCHES As Integer = 10

    Sub Initialiser(ByRef pTab(,,) As Integer)
        For noSalle As Integer = 1 To MAXSALLES
            For noJour As Integer = 1 To MAXJOURS
                For noTranche As Integer = 1 To MAXTRANCHES
                    pTab(noSalle, noJour, noTranche) = 0
                Next
            Next
        Next
    End Sub

    Sub Main()
        Dim capaciteLue, heureLue, jourLu As Integer
        Dim occupation(MAXSALLES, MAXJOURS, MAXTRANCHES) As Integer
        Dim capacité() As Integer = {20, 40, 30, 20, 10, 50, 10, 20, 20, 25}
        Initialiser(occupation)

        occupation(3, 2, 4) = 1
        occupation(1, 1, 1) = 1
        occupation(1, 2, 1) = 1
        occupation(4, 5, 1) = 1
        occupation(2, 2, 4) = 1
        occupation(8, 3, 2) = 1
        occupation(5, 3, 3) = 1

        Do
            Console.Write("Entrez le jour (1 à 6) : ")
            jourLu = CInt(Console.ReadLine())
            If jourLu < 1 Or jourLu > MAXJOURS Then
                Console.WriteLine("Erreur : le jour doit être compris entre 1 et 6.")
            End If
        Loop While jourLu < 1 Or jourLu > MAXJOURS

        Do
            Console.Write("Entrez la tranche horaire (1 à 10) : ")
            heureLue = CInt(Console.ReadLine())
            If heureLue < 1 Or heureLue > MAXTRANCHES Then
                Console.WriteLine("Erreur : la tranche doit être comprise entre 1 et 10.")
            End If
        Loop While heureLue < 1 Or heureLue > MAXTRANCHES

        Do
            Console.Write("Entrez la capacité minimale souhaitée : ")
            capaciteLue = CInt(Console.ReadLine())
            If capaciteLue < 1 Or capaciteLue > 50 Then
                Console.WriteLine("Erreur : la capacité doit être comprise entre 1 et 50.")
            End If
        Loop While capaciteLue < 1 Or capaciteLue > 50

        Console.WriteLine()
        Console.WriteLine("Salles libres correspondant aux critères :")

        Dim trouve As Boolean = False

        For noSalle As Integer = 1 To MAXSALLES
            If occupation(noSalle, jourLu, heureLue) = 0 _
               And capacité(noSalle - 1) >= capaciteLue Then
                Console.WriteLine("Salle " + noSalle.ToString() + " - capacité : " + capacité(noSalle - 1).ToString())
                trouve = True
            End If
        Next

        If trouve = False Then
            Console.WriteLine("Aucune salle ne correspond aux critères.")
        End If

        Console.ReadLine()
    End Sub

End Module