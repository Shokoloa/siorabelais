Module Module1

    Sub Main()
        Dim note As Double
        Dim somme As Double = 0
        Dim nombreNotes As Integer = 0
        Dim nombreSup10 As Integer = 0
        Dim moyenne As Double
        Dim pourcentage As Double

        Console.WriteLine("Note ? (entre 0 et 20, -1 pour sortir)")
        note = Console.ReadLine()

        While note <> -1
            If (note < 0 Or note > 20) Then
                Console.WriteLine("La note doit être entre 0 et 20")
            Else
                somme = somme + note
                nombreNotes = nombreNotes + 1

                If note > 10 Then
                    nombreSup10 = nombreSup10 + 1
                End If
            End If

            Console.WriteLine("Note ? (entre 0 et 20, -1 pour sortir):")
            note = Console.ReadLine()
        End While

        If nombreNotes > 0 Then
            moyenne = somme / nombreNotes
            pourcentage = (nombreSup10 * 100) / nombreNotes

            Console.WriteLine("Somme : " + somme.ToString())
            Console.WriteLine("Compteur : " + nombreNotes.ToString())
            Console.WriteLine("Moyenne = " + moyenne.ToString("0.00"))
        Else
            Console.WriteLine("Aucune note saisie.")
        End If

        Console.ReadLine()
    End Sub

End Module