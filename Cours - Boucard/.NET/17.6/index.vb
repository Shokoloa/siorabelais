Module Module1
    Public Class Pile
        Private Const MAX As Integer = 100
        Private tabPile(MAX) As String
        Private positionLibre As Integer

        Public Sub New()
            positionLibre = 0
        End Sub

        Public Function Empiler(ByVal valeur As String) As Boolean
            If (positionLibre > MAX) Then
                Return False
            End If

            tabPile(positionLibre) = valeur
            positionLibre += 1

            Return True
        End Function

        Public Function Dépiler() As String
            If EstVide() Then
                Return Nothing
            End If

            positionLibre -= 1

            Dim valeur As String = tabPile(positionLibre)
            tabPile(positionLibre) = Nothing

            Return valeur
        End Function

        Public Function EstVide() As Boolean
            Return positionLibre = 0
        End Function

        Public Function NombreDElements() As Integer
            Return positionLibre
        End Function

        Public Overrides Function ToString() As String
            Dim resultat As String = ""

            For i As Integer = positionLibre - 1 To 0 Step -1
                resultat &= "-----" & vbCrLf
                resultat &= tabPile(i) & vbCrLf
            Next

            If positionLibre > 0 Then
                resultat &= "-----"
            End If

            Return resultat
        End Function
    End Class

    Sub Main()
        Dim maPile As New Pile()
        Dim choix As String

        Do
            Console.WriteLine()
            Console.WriteLine("1. Empiler")
            Console.WriteLine("2. Dépiler")
            Console.WriteLine("3. Tester si la Pile est vide")
            Console.WriteLine("4. Nombre d'éléments dans la Pile")
            Console.WriteLine("5. Contenu de la Pile")
            Console.WriteLine("6. Quitter")
            Console.WriteLine()
            Console.Write("Choix ? ")
            choix = Console.ReadLine()

            Select Case choix
                Case "1"
                    Console.WriteLine()
                    Console.WriteLine("Entrer l'élément à empiler.")
                    Dim valeur As String = Console.ReadLine()
                    If maPile.Empiler(valeur) Then
                        Console.WriteLine("OK")
                    Else
                        Console.WriteLine("La pile est pleine.")
                    End If
                Case "2"
                    Dim valeur As String = maPile.Dépiler()
                    If valeur Is Nothing Then
                        Console.WriteLine("La pile est vide.")
                    Else
                        Console.WriteLine()
                        Console.WriteLine("Valeur extraite de la pile : " + valeur.ToString())
                    End If
                Case "3"
                    Console.WriteLine()
                    If maPile.EstVide() Then
                        Console.WriteLine("La Pile est vide")
                    Else
                        Console.WriteLine("La Pile n'est pas vide")
                    End If
                Case "4"
                    Console.WriteLine()
                    Console.WriteLine("Nombre d'élément dans la pile : " + maPile.NombreDElements().ToString())
                Case "5"
                    Console.WriteLine()
                    Console.WriteLine(maPile.ToString())
                Case "6"
                    Console.WriteLine()
                    Console.WriteLine("Au revoir !")
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Choix incorrect.")
            End Select

            If choix <> "6" Then
                Console.WriteLine()
                Console.WriteLine(". . . Rappel Menu . . .")
            End If
        Loop While choix <> "6"
    End Sub
End Module