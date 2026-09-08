Module Module1
    Const C As Integer = 300000

    Function DilatationTemps(ByVal t As Integer, ByVal v As Integer) As Integer
        Return t / Math.Sqrt(1 - (Math.Pow(v, 2) / Math.Pow(C, 2)))
    End Function

    Function ContractionLongueurs(ByVal v As Integer, ByVal L As Integer) As Integer
        Return L * Math.Sqrt(1 - (Math.Pow(v, 2) / Math.Pow(C, 2)))
    End Function

    Function CompositionVitesses(ByVal vFusee As Integer, ByVal vObus As Integer)
        Return (vObus + vFusee) / 1 + ((vObus * vFusee) / Math.Pow(C, 2))
    End Function

    Sub Main()
        Dim choix As Integer

        Console.WriteLine("1. La dilatation du temps")
        Console.WriteLine("2. La contraction des longueurs")
        Console.WriteLine("3. Loi de composition des vitesses")
        Console.WriteLine("4. Quitter")

        choix = Console.ReadLine()

        Select Case choix
            Case 1
                Console.WriteLine(DilatationTemps(60, 299999))
        End Select

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module