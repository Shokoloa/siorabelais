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

        Console.ReadLine()
    End Sub
End Module