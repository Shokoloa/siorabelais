Module Module1
    ReadOnly devises() As String = {"ATS", "BEF", "DEM", "ESP", "FRF", "IEP", "ITL", "FIM", "LUF", "NLG", "GRD", "SIT", "PTE", "CYP", "MTL", "SKK"}
    ReadOnly taux() As Double = {13.76, 40.33, 1.95, 166.38, 6.55, 0.78, 1936.27, 5.94, 40.33, 2.2, 340.75, 239.64, 200.48, 0.58, 0.42, 30.12}

    Function ConvertToOldMoney(ByVal euros As Integer, ByVal devise As String) As Double
        Return euros * taux(Array.IndexOf(devises, devise))
    End Function

    Sub Main()
        Dim montant As Integer = -1, devise As String

        While montant <> 0
            Console.WriteLine("Montant en euros ou 0")
            montant = Console.ReadLine()

            Console.WriteLine("Code devise ?")
            devise = Console.ReadLine()

            If Array.IndexOf(devises, devise) >= 0 Then
                Console.WriteLine("Montant dans l'ancienne monnaie nationale : " + ConvertToOldMoney(montant, devise).ToString())
            Else
                Console.WriteLine("Devise non trouvée")
            End If

            Console.WriteLine("//////////////////////////////////")
        End While

        Console.WriteLine("Au revoir")
        Console.ReadLine()
    End Sub

End Module
