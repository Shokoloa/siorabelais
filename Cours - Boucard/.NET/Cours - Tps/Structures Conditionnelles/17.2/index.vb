Module Module2
    Public Class Enseignant
        Const VALEURINDICE = 13.754
        Private numéro As String
        Private nom As String
        Private prenom As String
        Private adresse As String
        Private numTel As String
        Private dateNaiss As String
        Private indice As Integer
        Private nombreDHeures As Double

        Public Function GetNuméro() As String
            Return numéro
        End Function

        Public Function GetNom() As String
            Return nom
        End Function

        Public Sub SetNom(ByVal nouvNom As String)
            nom = nouvNom
        End Sub

        Public Function GetPrenom() As String
            Return prenom
        End Function

        Public Sub SetPrenom()
    End Class

    Sub Main()

    End Sub
End Module
