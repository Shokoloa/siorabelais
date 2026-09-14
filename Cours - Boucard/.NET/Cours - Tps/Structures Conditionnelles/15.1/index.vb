Module Module1
    Const MAX As Integer = 2

    Structure TClient
        Dim code As String
        Dim nom As String
        Dim adresse As String
    End Structure

    Structure TCommande
        Dim numéro As Integer
        Dim dateC As String
        Dim montant As Double
        Dim codeClient As String
    End Structure

    Sub AfficherUnClient(ByVal pUnClient As TClient)
        Console.WriteLine("Code client : " & pUnClient.code)
        Console.WriteLine("Nom : " & pUnClient.nom)
        Console.WriteLine("Adresse : " & pUnClient.adresse)
    End Sub

    Function ClientPourUneCommande(ByVal pNuméroCommande As Integer, ByVal pTabCommandes() As TCommande, ByVal pTabClients() As TClient) As TClient
        Dim clientVide As New TClient With {
            .code = "X"
        }
        For i As Integer = 0 To pTabCommandes.Length - 1
            If pTabCommandes(i).numéro = pNuméroCommande Then
                For j As Integer = 0 To pTabClients.Length - 1
                    If pTabClients(j).code = pTabCommandes(i).codeClient Then
                        Return pTabClients(j)
                    End If
                Next
            End If
        Next

        Return clientVide
    End Function

    Function MontantCommandé(ByVal pCodeClient As String, ByVal pTabCommandes() As TCommande) As Double
        Dim total As Double = 0
        For i As Integer = 0 To pTabCommandes.Length - 1
            If pTabCommandes(i).codeClient = pCodeClient Then
                total += pTabCommandes(i).montant
            End If
        Next

        Return total
    End Function

    Sub Main()
        Dim lesClients(MAX) As TClient
        Dim lesCommandes(MAX) As TCommande

        lesClients(0).code = "C01"
        lesClients(0).nom = "NomC01"
        lesClients(0).adresse = "AdresseC01"

        lesClients(1).code = "C02"
        lesClients(1).nom = "NomC02"
        lesClients(1).adresse = "AdresseC02"

        lesClients(2).code = "C03"
        lesClients(2).nom = "NomC03"
        lesClients(2).adresse = "AdresseC03"

        lesCommandes(0).numéro = 1
        lesCommandes(0).dateC = "01-01-01"
        lesCommandes(0).montant = 100
        lesCommandes(0).codeClient = "C02"

        lesCommandes(1).numéro = 22
        lesCommandes(1).dateC = "02-01-02"
        lesCommandes(1).montant = 200
        lesCommandes(1).codeClient = "C01"

        lesCommandes(2).numéro = 42
        lesCommandes(2).dateC = "02-01-03"
        lesCommandes(2).montant = 300
        lesCommandes(2).codeClient = "C02"

        Dim choix As Integer = 0

        While choix <> 3
            Console.WriteLine()
            Console.WriteLine("1. Montant total des commandes d'un client")
            Console.WriteLine("2. Détails d'un client pour une commande")
            Console.WriteLine("3. Quitter")
            Console.WriteLine()
            Console.Write("Choix ? ")
            choix = Integer.Parse(Console.ReadLine())

            Select Case choix
                Case 1
                    Console.Write("Code client ? ")
                    Dim codeClient As String = Console.ReadLine()
                    Dim total As Double = MontantCommandé(codeClient, lesCommandes)
                    Dim clientExiste As Boolean = False

                    For i As Integer = 0 To lesClients.Length - 1
                        If lesClients(i).code = codeClient Then
                            clientExiste = True
                        End If
                    Next

                    If clientExiste Then
                        Console.WriteLine("Montant commandé : " & total)
                    Else
                        Console.WriteLine("Client non trouvé")
                    End If
                Case 2
                    Console.Write("Numéro commande ? ")
                    Dim numéroCommande As Integer = Integer.Parse(Console.ReadLine())
                    Dim client As TClient = ClientPourUneCommande(numéroCommande, lesCommandes, lesClients)
                    If client.code = "X" Then
                        Console.WriteLine("Client ou commande non trouvé(e)")
                    Else
                        AfficherUnClient(client)
                    End If
                Case 3
                    Console.WriteLine("Au revoir !")
                Case Else
                    Console.WriteLine("Choix invalide")
            End Select
        End While

        Console.ReadLine()
    End Sub

End Module