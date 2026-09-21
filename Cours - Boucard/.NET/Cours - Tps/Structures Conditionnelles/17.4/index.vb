Module Module1
    Public Class CompteurElectricite
        Private numeroSerie As String
        Private indexKWh As Double
        Private Const PRIXKWH As Double = 0.22

        Public Sub New(ByVal nouvNumeroSerie As String)
            Me.numeroSerie = nouvNumeroSerie
            Me.indexKWh = 0
        End Sub

        Public Function GetIndexKWh() As Double
            Return Me.indexKWh
        End Function

        Public Sub SetIndexKWh(ByVal valeur As Double)
            If valeur >= Me.indexKWh Then
                Me.indexKWh = valeur
            Else
                Throw New Exception("L'index ne peut pas diminuer.")
            End If

        End Sub

        Public Function GetNumeroSerie() As String
            Return Me.numeroSerie
        End Function

        Public Function CalculerMontantFacture() As Double
            Return Me.indexKWh * PRIXKWH
        End Function

        Public Overrides Function ToString() As String
            Return "Compteur n°" & Me.numeroSerie & " (Index: " & Me.indexKWh & " kWh)"
        End Function

    End Class

    Public Class Client
        Private nom As String
        Private compteur As CompteurElectricite

        ' Constructeur
        Public Sub New(ByVal nouvNom As String, ByVal numeroSerieCompteur As String)
            Me.nom = nouvNom
            Me.compteur = New CompteurElectricite(numeroSerieCompteur)
        End Sub

        Public Function GetNom() As String
            Return Me.nom
        End Function

        Public Function GetCompteur() As CompteurElectricite
            Return Me.compteur
        End Function

        Public Function RetournerFacture() As String
            Dim facture As String = ""

            facture &= "----- FACTURE -----" & vbCrLf
            facture &= "Client : " & Me.nom & vbCrLf
            facture &= Me.compteur.ToString() & vbCrLf
            facture &= "TOTAL : " &
                       Me.compteur.CalculerMontantFacture() &
                       " euros" & vbCrLf
            facture &= "-------------------"
            Return facture
        End Function

        Public Overrides Function ToString() As String
            Return "Client : " & Me.nom.ToString() + " - Compteur : " + Me.compteur.GetNumeroSerie().ToString()
        End Function

    End Class

    Dim lesClients(9) As Client
    Dim posLibre As Integer = 0

    Function RechercherClient(ByVal pNumSerie As String) As Client
        For i As Integer = 0 To posLibre - 1
            If lesClients(i).GetCompteur().GetNumeroSerie() = pNumSerie Then
                Return lesClients(i)
            End If
        Next

        Return Nothing
    End Function

    Function ChiffreDAffaires() As Double
        Dim total As Double = 0

        For i As Integer = 0 To posLibre - 1
            total += lesClients(i).GetCompteur().CalculerMontantFacture()
        Next

        Return total
    End Function

    Sub AfficherMenu()
        Console.WriteLine()
        Console.WriteLine("1. Ajout un nouveau client")
        Console.WriteLine("2. Mettre à jour un index (pour n° série)")
        Console.WriteLine("3. Facture détaillée (pour n° série)")
        Console.WriteLine("4. Afficher chiffre d'affaires total et nombre d'abonnés")
        Console.WriteLine("5. Quitter")
        Console.WriteLine()
        Console.WriteLine("Choix ?")
    End Sub

    Sub Main()
        Dim choix As Integer = 0

        Do
            AfficherMenu()
            If Integer.TryParse(Console.ReadLine(), choix) = False Then
                Console.WriteLine("Choix invalide.")
                Continue Do
            End If

            Select Case choix
                Case 1
                    If posLibre >= lesClients.Length Then
                        Console.WriteLine("Erreur : le tableau est plein.")
                    Else
                        Console.WriteLine()
                        Console.WriteLine("Nom du client :")
                        Dim nom As String = Console.ReadLine()

                        Console.WriteLine()
                        Console.WriteLine("Numéro de série du compteur :")
                        Dim numeroSerie As String = Console.ReadLine()

                        If RechercherClient(numeroSerie) IsNot Nothing Then
                            Console.WriteLine("Erreur : ce numéro de série existe déjà.")
                        Else
                            lesClients(posLibre) = New Client(nom, numeroSerie)

                            posLibre += 1

                            Console.WriteLine()
                            Console.WriteLine("Ajout OK.")
                        End If
                    End If
                Case 2
                    Console.WriteLine()
                    Console.WriteLine("n° de série ?")

                    Dim numeroSerie As String = Console.ReadLine()
                    Dim client As Client = RechercherClient(numeroSerie)

                    If client Is Nothing Then
                        Console.WriteLine("Client introuvable.")
                    Else
                        Dim compteur As CompteurElectricite = client.GetCompteur()

                        Console.WriteLine()
                        Console.WriteLine("Nouvel index (actuel: " + compteur.GetIndexKWh().ToString() + ") :")

                        Dim nouvelIndex As Double

                        If Double.TryParse(Console.ReadLine(), nouvelIndex) = False Then
                            Console.WriteLine("Erreur : valeur incorrecte.")
                        Else
                            Try
                                compteur.SetIndexKWh(nouvelIndex)
                            Catch ex As Exception
                                Console.WriteLine("Erreur : " & ex.Message)
                            End Try
                        End If
                    End If
                Case 3
                    Console.WriteLine()
                    Console.WriteLine("Entrez le n° de série :")

                    Dim numeroSerie As String = Console.ReadLine()
                    Dim client As Client = RechercherClient(numeroSerie)

                    If client Is Nothing Then
                        Console.WriteLine()
                        Console.WriteLine("Client introuvable.")
                    Else
                        Console.WriteLine()
                        Console.WriteLine(client.RetournerFacture())
                    End If

                Case 4
                    Console.WriteLine()
                    Console.WriteLine("Nombre d'abonnés : " + posLibre.ToString())
                    Console.WriteLine("Chiffre d'affaire : " + ChiffreDAffaires().ToString() + " euros")
                Case 5
                    Console.WriteLine()
                    Console.WriteLine("Au revoir !")
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Choix invalide.")
            End Select
        Loop While choix <> 5
    End Sub
End Module