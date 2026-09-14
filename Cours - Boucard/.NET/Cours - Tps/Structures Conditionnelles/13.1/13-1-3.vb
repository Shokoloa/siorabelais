Module Module1

    Function ConvertToBase(ByVal number As Integer, ByVal base As Integer) As String
        Dim result As String = ""

        While number > 0
            Dim reste As Integer = number Mod base
            result = reste.ToString() & result
            number = number \ base
        End While

        Return result
    End Function

    Sub Main()
        Dim numberToConvert, baseToConvert As Integer

        Do
            Console.WriteLine("Entrez le nombre à convertir")
            numberToConvert = Console.ReadLine()
        Loop Until numberToConvert >= 0 And numberToConvert <= 255

        Do
            Console.WriteLine("Entrez la base vers laquelle faire la conversion")
            baseToConvert = Console.ReadLine()
        Loop Until baseToConvert = 2 Or baseToConvert = 8

        Console.WriteLine("Affichage nombre = tableau résultat")
        Console.WriteLine(ConvertToBase(numberToConvert, baseToConvert))

    End Sub

End Module
