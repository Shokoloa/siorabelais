Module Module1
    Const C As Integer = 300000

    Function DilatationTemps(ByVal t As Integer, ByVal v As Integer) As Double
        Return t / Math.Sqrt(1 - (Math.Pow(v, 2) / Math.Pow(C, 2)))
    End Function

    Function ContractionLongueurs(ByVal v As Integer, ByVal L As Integer) As Double
        Return L * Math.Sqrt(1 - (Math.Pow(v, 2) / Math.Pow(C, 2)))
    End Function

    Function CompositionVitesses(ByVal vFusee As Integer, ByVal vObus As Integer) As Long
        Return (vObus + vFusee) / 1 + ((vObus * vFusee) / Math.Pow(C, 2))
    End Function

    Sub Main()
        Dim choix, input1, input2 As Integer

        While choix <> 4
            Console.WriteLine("1. La dilatation du temps")
            Console.WriteLine("2. La contraction des longueurs")
            Console.WriteLine("3. Loi de composition des vitesses")
            Console.WriteLine("4. Quitter")

            choix = Console.ReadLine()

            Select Case choix
                Case 1
                    Console.WriteLine("Vitesse de la fusée (en km/s) ?")
                    input1 = Console.ReadLine()
                    Console.WriteLine("Durée écoulée dans la fusée (en secondes) ?")
                    input2 = Console.ReadLine()
                    Console.WriteLine("Durée écoulée sur terre = " + DilatationTemps(input1, input2).ToString())
                Case 2
                    Console.WriteLine("Vitesse de la fusée (en km/s) ?")
                    input1 = Console.ReadLine()
                    Console.WriteLine("Taille de la fusée (en kms) ?")
                    input2 = Console.ReadLine()
                    Console.WriteLine("Taille de la fusée vue de la terre = " + ContractionLongueurs(input1, input2).ToString())
                Case 3
                    Console.WriteLine("Vitesse de la fusée (en km/s) ?")
                    input1 = Console.ReadLine()
                    Console.WriteLine("Vitesse de l'obus, dans le repère de la fusée (en km/s) ?")
                    input2 = Console.ReadLine()
                    Console.WriteLine("Vitesse de l'obus par rapport à la terre = " + CompositionVitesses(input1, input2).ToString())
                Case 4
                    ' ignore
                Case Else
                    Console.WriteLine("Choix Erroné")
            End Select
        End While

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module