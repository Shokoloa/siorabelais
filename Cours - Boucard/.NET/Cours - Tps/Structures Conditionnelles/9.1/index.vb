Module Module1

    Sub Main()
        Dim note As Double
        Dim somme As Double = 0
        Dim nombreNotes As Integer = 0
        Dim nombreSup10 As Integer = 0
        Dim moyenne As Double
        Dim pourcentage As Double

        Console.WriteLine("Entrez une note (-1 pour fin) :")
        note = Console.ReadLine()

        While note <> -1
            somme = somme + note
            nombreNotes = nombreNotes + 1

            If note > 10 Then
                nombreSup10 = nombreSup10 + 1
            End If

            Console.WriteLine("Entrez une note (-1 pour fin) :")
            note = Console.ReadLine()
        End While

        If nombreNotes > 0 Then
            moyenne = somme / nombreNotes
            pourcentage = (nombreSup10 * 100) / nombreNotes

            Console.WriteLine("Vous avez " & pourcentage & " % de notes > à 10")
            Console.WriteLine("Votre moyenne est de " & moyenne.ToString("0.00"))
        Else
            Console.WriteLine("Aucune note saisie.")
        End If

        Console.ReadLine()
    End Sub

End Module