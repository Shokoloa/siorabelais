Module Module2
    Public Class Compteur
        Private valeur As Integer

        Public Sub New(ByVal pValeur As Integer)
            valeur = pValeur
        End Sub

        Public Function GetValeur() As Integer
            Return valeur
        End Function

        Public Sub PlusUn()
            valeur += 1
        End Sub

        Public Sub Raz()
            valeur = 0
        End Sub

        Public Sub IncrementeDe(ByVal pValeur As Integer)
            If (pValeur > 0) Then
                valeur += pValeur
            End If
        End Sub

        Public Sub DecrementeDe(ByVal pValeur As Integer)
            If (pValeur > 0) Then
                valeur -= pValeur
            End If
        End Sub
    End Class

    Sub Main()
        Dim cA As New Compteur(10)

        cA.PlusUn()
        Console.WriteLine("Après +1 : " & cA.GetValeur())

        cA.IncrementeDe(10)
        Console.WriteLine("Après +10 : " & cA.GetValeur())

        cA.DecrementeDe(5)
        Console.WriteLine("Après -5 : " & cA.GetValeur())

        cA.IncrementeDe(-10)
        Console.WriteLine("Après IncrementeDe(-10) : " & cA.GetValeur())

        cA.Raz()
        Console.WriteLine("Après Raz : " & cA.GetValeur())

        ' Création de deux compteurs
        Dim cB As New Compteur(50)
        Dim cC As New Compteur(0)

        ' Avant la copie
        Console.WriteLine()
        Console.WriteLine("Avant cC = cB :")
        Console.WriteLine("cB = " & cB.GetValeur())
        Console.WriteLine("cC = " & cC.GetValeur())

        ' Copie de cB dans cC
        cC = cB

        ' Après la copie
        Console.WriteLine()
        Console.WriteLine("Après cC = cB :")
        Console.WriteLine("cB = " & cB.GetValeur())
        Console.WriteLine("cC = " & cC.GetValeur())

        ' Modification de cB
        cB.PlusUn()

        ' Affichage après modification
        Console.WriteLine()
        Console.WriteLine("Après cB.PlusUn() :")
        Console.WriteLine("cB = " & cB.GetValeur())
        Console.WriteLine("cC = " & cC.GetValeur())

        Console.ReadLine()
    End Sub

End Module