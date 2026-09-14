Module Module1
    Const MAX As Integer = 10

    Structure TMatériel
        Dim noSerie As String
        Dim modèle As String
        Dim type As String
        Dim annéeDAchat As Integer
    End Structure

    Sub Main()
        Dim lesMatériels(MAX - 1) As TMatériel
        Dim posLibre As Integer = 0
        Dim choix As Integer
        Dim matériel As TMatériel
        Dim index As Integer
        Dim noSerie As String

        Do
            Console.WriteLine()
            Console.WriteLine("1. Ajouter un matériel dans le tableau.")
            Console.WriteLine("2. Supprimer un matériel (saisie index)")
            Console.WriteLine("3. Supprimer un matériel (saisie n° série).")
            Console.WriteLine("4. Lister à l'écran tous les matériels.")
            Console.WriteLine("5. Quitter.")
            Console.WriteLine()
            Console.Write("Choix ? ")
            choix = Convert.ToInt32(Console.ReadLine())

            Select Case choix
                Case 1
                    matériel = SaisirMatériel()

                    If AjouterUnMatériel(matériel, lesMatériels, posLibre) Then
                        Console.WriteLine("Ajout effectué.")
                    Else
                        Console.WriteLine("Ajout impossible : le tableau est plein.")
                    End If
                Case 2
                    Console.Write("Index du matériel à supprimer ? ")
                    index = Convert.ToInt32(Console.ReadLine())
                    If SupprimerParIndex(index, lesMatériels, posLibre) Then
                        Console.WriteLine("Suppression réussie.")
                    Else
                        Console.WriteLine("Suppression impossible.")
                    End If
                Case 3
                    Console.Write("n° de série du matériel à supprimer ? ")
                    noSerie = Console.ReadLine()
                    If SupprimerParNoSérie(noSerie, lesMatériels, posLibre) Then
                        Console.WriteLine("Suppression réussie.")
                    Else
                        Console.WriteLine("N° de série inexistant.")
                    End If
                Case 4
                    Console.WriteLine()
                    Console.WriteLine("Listes des matériels :")
                    AfficherLesMatériels(lesMatériels, posLibre)
                Case 5
                    Console.WriteLine("Au revoir.")
                Case Else
                    Console.WriteLine("Choix invalide.")
            End Select

            If choix <> 5 Then
                Console.WriteLine()
                Console.WriteLine(". . . Rappel Menu . . .")
            End If
        Loop While choix <> 5
    End Sub

    Function SaisirMatériel() As TMatériel
        Dim matériel As TMatériel

        Console.Write("n° de série ? ")
        matériel.noSerie = Console.ReadLine()

        Console.Write("Modèle ? ")
        matériel.modèle = Console.ReadLine()

        Console.Write("Type ? ")
        matériel.type = Console.ReadLine()

        Console.Write("Année d'achat ? ")
        matériel.annéeDAchat = Convert.ToInt32(Console.ReadLine())

        Return matériel
    End Function

    Sub AfficherUnMatériel(ByVal pUnMatériel As TMatériel)
        Console.WriteLine("n° de série : " & pUnMatériel.noSerie)
        Console.WriteLine("Modèle : " & pUnMatériel.modèle)
        Console.WriteLine("Type : " & pUnMatériel.type)
        Console.WriteLine("Année d'achat : " & pUnMatériel.annéeDAchat)
        Console.WriteLine()
    End Sub

    Sub AfficherLesMatériels(ByVal pLesMatériels() As TMatériel, ByVal pPosLibre As Integer)
        If pPosLibre = 0 Then
            Console.WriteLine("Aucun matériel dans le parc.")
        Else
            For i As Integer = 0 To pPosLibre - 1
                AfficherUnMatériel(pLesMatériels(i))
            Next
        End If
    End Sub

    Function AjouterUnMatériel(ByVal pMatériel As TMatériel, ByRef pLesMatériels() As TMatériel, ByRef pPosLibre As Integer) As Boolean
        If pPosLibre >= pLesMatériels.Length Then
            Return False
        End If
        pLesMatériels(pPosLibre) = pMatériel
        pPosLibre += 1
        Return True
    End Function

    Function SupprimerParIndex(ByVal pIndex As Integer, ByRef pLesMatériels() As TMatériel, ByRef pPosLibre As Integer) As Boolean
        If pIndex < 0 OrElse pIndex >= pPosLibre Then
            Return False
        End If

        For i As Integer = pIndex To pPosLibre - 2
            pLesMatériels(i) = pLesMatériels(i + 1)
        Next
        pPosLibre -= 1
        Return True
    End Function

    Function SupprimerParNoSérie(ByVal pNoSérie As String, ByRef pLesMatériels() As TMatériel, ByRef pPosLibre As Integer) As Boolean
        Dim indexTrouvé As Integer = -1
        For i As Integer = 0 To pPosLibre - 1
            If pLesMatériels(i).noSerie = pNoSérie Then
                indexTrouvé = i
                Exit For
            End If
        Next

        If indexTrouvé = -1 Then
            Return False
        End If

        Return SupprimerParIndex(indexTrouvé, pLesMatériels, pPosLibre)
    End Function
End Module
