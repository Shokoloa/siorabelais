Module Module1
    Const PI As Double = 3.1416

    Function PérimètreCercle(ByVal pRayon As Double) As Double
        Return 2 * PI * pRayon
    End Function

    Function SurfaceCercle(ByVal pRayon As Double) As Double
        Return PI * pRayon * pRayon
    End Function

    Function PérimètreRectangle(ByVal pLongueur As Double, ByVal pLargeur As Double) As Double
        Return 2 * (pLongueur + pLargeur)
    End Function

    Function SurfaceRectangle(ByVal pLongueur As Double, ByVal pLargeur As Double) As Double
        Return pLongueur * pLargeur
    End Function

    Sub Main()
        Dim userChoice As Integer

        While userChoice <> 5
            Console.WriteLine("1. Calcul du périmètre d'un cercle.")
            Console.WriteLine("2. Calcul de la surface d'un cercle.")
            Console.WriteLine("3. Calcul du périmètre d'un rectangle.")
            Console.WriteLine("4. Calcul de la surface d'un rectangle.")
            Console.WriteLine("5. Quitter.")

            Console.WriteLine("Choix ?")
            userChoice = Console.ReadLine()

            Select Case userChoice
                Case 1
                    Dim pRayon As Double
                    Console.WriteLine("Rayon du cercle ? (Rayon > 0)")
                    pRayon = Console.ReadLine()
                    If (pRayon < 0) Then
                        Console.WriteLine("Rayon > 0")
                        pRayon = Console.ReadLine()
                    Else
                        Console.WriteLine("Périmètre : " + PérimètreCercle(pRayon).ToString())
                    End If
                Case 2
                    Dim pRayon As Double
                    Console.WriteLine("Rayon du cercle ? (Rayon > 0)")
                    pRayon = Console.ReadLine()
                    If (pRayon < 0) Then
                        Console.WriteLine("Rayon > 0")
                        pRayon = Console.ReadLine()
                    Else
                        Console.WriteLine("Surface : " + SurfaceCercle(pRayon).ToString())
                    End If
                Case 3
                    Dim pLongueur As Double
                    Console.WriteLine("Longueur du rectangle ? (Longueur > 0")
                    pLongueur = Console.ReadLine()
                    If (pLongueur < 0) Then
                        Console.WriteLine("Longueur > 0")
                        pLongueur = Console.ReadLine()
                    Else
                        Dim pLargeur As Double
                        Console.WriteLine("Largeur du rectangle ? (Largeur > 0")
                        pLargeur = Console.ReadLine()
                        If (pLargeur < 0) Then
                            Console.WriteLine("Largeur > 0")
                            pLargeur = Console.ReadLine()
                        Else
                            Console.WriteLine("Périmètre : " + PérimètreRectangle(pLongueur, pLargeur).ToString())
                        End If
                    End If
                Case 4
                    Dim pLongueur As Double
                    Console.WriteLine("Longueur du rectangle ? (Longueur > 0")
                    pLongueur = Console.ReadLine()
                    If (pLongueur < 0) Then
                        Console.WriteLine("Longueur > 0")
                        pLongueur = Console.ReadLine()
                    Else
                        Dim pLargeur As Double
                        Console.WriteLine("Largeur du rectangle ? (Largeur > 0")
                        pLargeur = Console.ReadLine()
                        If (pLargeur < 0) Then
                            Console.WriteLine("Largeur > 0")
                            pLargeur = Console.ReadLine()
                        Else
                            Console.WriteLine("Surface : " + SurfaceRectangle(pLongueur, pLargeur).ToString())
                        End If
                    End If
                Case 5
                    ' Quitter (géré par While)
                Case Else
                    Console.WriteLine("Choix Erroné")
            End Select
        End While

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module