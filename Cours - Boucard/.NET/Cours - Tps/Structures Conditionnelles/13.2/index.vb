Module Module1
    Sub AfficherMatrice(ByVal pMatrice(,) As Double)
        For i As Integer = 0 To pMatrice.GetLength(0) - 1
            For j As Integer = 0 To pMatrice.GetLength(1) - 1
                Console.Write(pMatrice(i, j) & vbTab)
            Next
            Console.WriteLine()
        Next
    End Sub


    Sub Echanger(ByRef pA As Double, ByRef pB As Double)
        Dim temp As Double
        temp = pA
        pA = pB
        pB = temp
    End Sub


    Sub InverserLignesMatrice(ByRef pMatrice(,) As Double)
        Dim n As Integer = pMatrice.GetLength(0)
        For i As Integer = 0 To n - 1
            For j As Integer = i + 1 To n - 1
                Echanger(pMatrice(i, j), pMatrice(j, i))
            Next
        Next
    End Sub

    Sub Main()
        Dim listeAInverser(,) As Double = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        }

        Console.WriteLine("Matrice avant inversion.")
        Console.WriteLine()

        AfficherMatrice(listeAInverser)

        Console.WriteLine()
        Console.WriteLine("Matrice après inversion.")
        Console.WriteLine()

        InverserLignesMatrice(listeAInverser)
        AfficherMatrice(listeAInverser)

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module
