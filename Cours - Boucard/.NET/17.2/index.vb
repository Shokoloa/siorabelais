Module Module1
    Public Class Enseignant
        Const VALEURINDICE = 13.754
        Private numéro As String
        Private nom As String
        Private prenom As String
        Private adresse As String
        Private numTel As String
        Private dateNaiss As String
        Private indice As Integer
        Private nombreDHeures As Double

        Public Sub New(ByVal numéro As String, ByVal nom As String, ByVal prenom As String, ByVal adresse As String, ByVal numTel As String, ByVal dateNaiss As String, ByVal indice As Integer, ByVal nombreDHeures As Double)
            Me.numéro = numéro
            Me.nom = nom
            Me.prenom = prenom
            Me.adresse = adresse
            Me.numTel = numTel
            Me.dateNaiss = dateNaiss
            Me.indice = indice
            Me.nombreDHeures = nombreDHeures
        End Sub

        Public Function GetNuméro() As String
            Return numéro
        End Function

        Public Function GetNom() As String
            Return nom
        End Function

        Public Sub SetNom(ByVal nouvNom As String)
            nom = nouvNom
        End Sub

        Public Function GetPrenom() As String
            Return prenom
        End Function

        Public Sub SetPrenom(ByVal nouvPrenom As String)
            prenom = nouvPrenom
        End Sub

        Public Function GetNumTel() As String
            Return numTel
        End Function

        Public Sub SetNumTel(ByVal nouvNumTel As String)
            numTel = nouvNumTel
        End Sub

        Public Function GetAdresse() As String
            Return adresse
        End Function

        Public Sub SetAdresse(ByVal nouvAdresse As String)
            adresse = nouvAdresse
        End Sub

        Public Function GetDateNaiss() As String
            Return dateNaiss
        End Function

        Public Function AugmenterIndice(ByVal nouvIndice As Integer) As Boolean
            If (indice > nouvIndice) Then Return False
            indice = nouvIndice
            Return True
        End Function

        Public Function GetIndice() As Integer
            Return indice
        End Function

        Public Sub SetNombreDHeures(ByVal nouvNombreDHeures As Integer)
            nombreDHeures = nouvNombreDHeures
        End Sub

        Public Function GetNombreDHeures() As Integer
            Return nombreDHeures
        End Function

        Public Function SalaireMensuel() As Double
            Return nombreDHeures * indice * VALEURINDICE
        End Function

        Public Overrides Function ToString() As String
            Return "Numéro : " & numéro & vbCrLf &
           "Nom : " & nom & vbCrLf &
           "Prénom : " & prenom & vbCrLf &
           "Adresse : " & adresse & vbCrLf &
           "n° de téléphone : " & numTel & vbCrLf &
           "Date de naissance : " & dateNaiss & vbCrLf &
           "Indice : " & indice & vbCrLf &
           "Nombre d'heures : " & nombreDHeures
        End Function
    End Class

    Public Class Eleve
        Const MAXNOTES As Integer = 9
        Private numéro As String
        Private nom As String
        Private prenom As String
        Private adresse As String
        Private numTel As String
        Private dateNaiss As String
        Private numClasse As String
        Private tabNotes(MAXNOTES) As Double

        Public Sub New(ByVal numéro As String, ByVal nom As String, ByVal prenom As String, ByVal adresse As String, ByVal numTel As String, ByVal dateNaiss As String, ByVal numClasse As String)
            Me.numéro = numéro
            Me.nom = nom
            Me.prenom = prenom
            Me.adresse = adresse
            Me.numTel = numTel
            Me.dateNaiss = dateNaiss
            Me.numClasse = numClasse

            For i As Integer = 0 To MAXNOTES
                tabNotes(i) = -1
            Next
        End Sub

        Public Function GetNuméro() As String
            Return numéro
        End Function

        Public Function GetNom() As String
            Return nom
        End Function

        Public Sub SetNom(ByVal nouvNom As String)
            nom = nouvNom
        End Sub

        Public Function GetPrenom() As String
            Return prenom
        End Function

        Public Sub SetPrenom(ByVal nouvPrenom As String)
            prenom = nouvPrenom
        End Sub

        Public Function GetNumTel() As String
            Return numTel
        End Function

        Public Sub SetNumTel(ByVal nouvNumTel As String)
            numTel = nouvNumTel
        End Sub

        Public Function GetAdresse() As String
            Return adresse
        End Function

        Public Sub SetAdresse(ByVal nouvAdresse As String)
            adresse = nouvAdresse
        End Sub

        Public Function GetDateNaiss() As String
            Return dateNaiss
        End Function

        Public Function GetNumClasse() As String
            Return numClasse
        End Function

        Public Sub SetNumClasse(ByVal nouvNumClasse As String)
            numClasse = nouvNumClasse
        End Sub

        Public Function Moyenne() As Double
            Dim somme As Double = 0
            Dim nombreNotes As Integer = 0

            For i As Integer = 0 To MAXNOTES - 1
                If tabNotes(i) <> -1 Then
                    somme += tabNotes(i)
                    nombreNotes += 1
                End If
            Next

            If nombreNotes = 0 Then
                Return 0
            End If

            Return somme / nombreNotes
        End Function

        Public Sub SetNote(ByVal noMatiere As Integer, ByVal note As Double)
            If noMatiere >= 0 AndAlso noMatiere < MAXNOTES Then
                tabNotes(noMatiere) = note
            End If
        End Sub

        Public Overrides Function ToString() As String
            Dim resultat As String = ""

            resultat &= "*** SORTIE méthode ToString() ***" & vbCrLf & vbCrLf
            resultat &= "Numéro : " & numéro & vbCrLf & vbCrLf
            resultat &= "Nom: " & nom & vbCrLf & vbCrLf
            resultat &= "Prenom: " & prenom & vbCrLf & vbCrLf
            resultat &= "Adresse: " & adresse & vbCrLf & vbCrLf
            resultat &= "n° de telephone: " & numTel & vbCrLf & vbCrLf
            resultat &= "Date de naissance: " & dateNaiss & vbCrLf & vbCrLf
            resultat &= "n° de la Classe : " & numClasse & vbCrLf & vbCrLf

            resultat &= "Notes : "

            For i As Integer = 0 To MAXNOTES
                resultat &= tabNotes(i) & " | "
            Next

            Return resultat
        End Function
    End Class

    Sub Main()
        Dim cEnseignant = New Enseignant("E0112", "Dupont", "Pierre", "1, rue de la Paix - 7500 PARIS", "0145045540", "1/10/1980", 8, 20)

        Console.WriteLine("//////// TEST CLASSE ENSEIGNANT //////////")
        Console.WriteLine("*** SORTIE méthode ToString() ***")
        Console.WriteLine("")
        Console.WriteLine(cEnseignant.ToString())
        Console.WriteLine("*** FIN SORTIE méthode ToString() ***")
        Console.WriteLine("")
        Console.WriteLine("Salaire Mensuel : " + cEnseignant.SalaireMensuel().ToString())
        Console.WriteLine("")
        Console.WriteLine("Au fait passer l'indice à 2 (contre 8 précédemment)")
        If (cEnseignant.AugmenterIndice(2)) Then
            Console.WriteLine("Augmentation d'indice enregistrée")
        Else
            Console.WriteLine("L'indice ne peut pas être baissé")
        End If
        Console.WriteLine("Au fait passer l'indice à 10 (contre 8 précédemment)")
        If (cEnseignant.AugmenterIndice(10)) Then
            Console.WriteLine("Augmentation d'indice enregistrée")
        Else
            Console.WriteLine("L'indice ne peut pas être baissé")
        End If
        Console.WriteLine("")
        Console.WriteLine("Indice : " + cEnseignant.GetIndice().ToString())
        Console.WriteLine("Salaire Mensuel : " + cEnseignant.SalaireMensuel().ToString())


        Dim cEleve = New Eleve("112", "Martin", "Pierre", "7, rue de la Paix 77000 MELUN", "0164024532", "23/07/02", "BTSSIO1")

        Console.WriteLine("")
        Console.WriteLine("//////// TEST CLASSE ELEVE //////////")
        Console.WriteLine("*** SORTIE méthode ToString() ***")
        Console.WriteLine(cEleve.ToString())
        Console.WriteLine("*** FIN SORTIE méthode ToString() ***")
        Console.WriteLine("Aucune note: impossible de calculer la moyenne générale")
        Console.WriteLine("")
        Console.WriteLine("On renseigne 10 notes - arbitrairement - pour l'élève")
        cEleve.SetNote(1, 12)
        cEleve.SetNote(2, 15)
        cEleve.SetNote(3, 20)
        cEleve.SetNote(4, 18)
        cEleve.SetNote(5, 11)
        cEleve.SetNote(6, 13)
        cEleve.SetNote(7, 16)
        cEleve.SetNote(8, 13)
        cEleve.SetNote(9, 7)
        Console.WriteLine("Moyenne générale de Martin, Pierre : " + cEleve.Moyenne().ToString())
    End Sub
End Module