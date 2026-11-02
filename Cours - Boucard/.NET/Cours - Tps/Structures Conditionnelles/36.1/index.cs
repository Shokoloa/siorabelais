
using Npgsql;

class Program
{
    // À adapter selon ta configuration PostgreSQL
    private static string connectionString =
        "Host=localhost;Port=5432;Database=biblio;Username=postgres;Password=ton_mot_de_passe";

    static void Main()
    {
        int choix;

        do
        {
            Console.WriteLine("\n===== GESTION BIBLIO =====");
            Console.WriteLine("1. Afficher les éditeurs");
            Console.WriteLine("2. Ajouter un éditeur");
            Console.WriteLine("3. Supprimer un titre");
            Console.WriteLine("4. Ajouter un titre");
            Console.WriteLine("5. Quitter");
            Console.Write("\nVotre choix : ");

            if (!int.TryParse(Console.ReadLine(), out choix))
                choix = 0;

            switch (choix)
            {
                case 1:
                    AfficherEditeurs();
                    break;

                case 2:
                    AjouterEditeur();
                    break;

                case 3:
                    SupprimerTitre();
                    break;

                case 4:
                    AjouterTitre();
                    break;

                case 5:
                    Console.WriteLine("Au revoir !");
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

        } while (choix != 5);
    }

    // 1. Afficher les éditeurs commençant par une lettre
    static void AfficherEditeurs()
    {
        Console.Write("Saisissez une lettre : ");
        string lettre = Console.ReadLine() ?? "";

        if (lettre.Length != 1)
        {
            Console.WriteLine("Veuillez saisir une seule lettre.");
            return;
        }

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string sql = @"
            SELECT pub_id, name
            FROM publishers
            WHERE name ILIKE @lettre
            ORDER BY pub_id";

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("lettre", lettre + "%");

        using var reader = command.ExecuteReader();

        Console.WriteLine("\n--- ÉDITEURS ---");

        while (reader.Read())
        {
            Console.WriteLine(
                $"ID : {reader["pub_id"]} | Nom : {reader["name"]}");
        }
    }

    // 2. Ajouter un éditeur
    static void AjouterEditeur()
    {
        Console.Write("Nom : ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Adresse : ");
        string address = Console.ReadLine() ?? "";

        Console.Write("Ville : ");
        string city = Console.ReadLine() ?? "";

        Console.Write("Code postal : ");
        string zip = Console.ReadLine() ?? "";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string sql = @"
            INSERT INTO publishers (name, address, city, zip)
            VALUES (@name, @address, @city, @zip)
            RETURNING pub_id";

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("name", name);
        command.Parameters.AddWithValue("address", address);
        command.Parameters.AddWithValue("city", city);
        command.Parameters.AddWithValue("zip", zip);

        object? id = command.ExecuteScalar();

        Console.WriteLine($"Éditeur ajouté avec succès ! ID : {id}");
    }

    // 3. Supprimer un titre
    static void SupprimerTitre()
    {
        Console.Write("ISBN du titre à supprimer : ");
        string isbn = Console.ReadLine() ?? "";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string sql = "DELETE FROM titles WHERE isbn = @isbn";

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("isbn", isbn);

        int lignes = command.ExecuteNonQuery();

        if (lignes > 0)
            Console.WriteLine("Titre supprimé avec succès !");
        else
            Console.WriteLine("Aucun titre trouvé avec cet ISBN.");
    }

    // 4. Ajouter un titre, un auteur et un éditeur
    static void AjouterTitre()
    {
        Console.Write("ISBN : ");
        string isbn = Console.ReadLine() ?? "";

        Console.Write("Titre : ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Type : ");
        string type = Console.ReadLine() ?? "";

        Console.Write("ID de l'auteur : ");
        string authorId = Console.ReadLine() ?? "";

        Console.Write("ID de l'éditeur : ");
        string publisherId = Console.ReadLine() ?? "";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string sql = @"
            INSERT INTO titles (isbn, title, type, pub_id)
            VALUES (@isbn, @title, @type, @pub_id)";

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("isbn", isbn);
        command.Parameters.AddWithValue("title", title);
        command.Parameters.AddWithValue("type", type);
        command.Parameters.AddWithValue("pub_id", publisherId);

        command.ExecuteNonQuery();

        // Association du titre avec son auteur
        string sqlAuthor = @"
            INSERT INTO titleauthor (au_id, isbn)
            VALUES (@au_id, @isbn)";

        using var commandAuthor =
            new NpgsqlCommand(sqlAuthor, connection);

        commandAuthor.Parameters.AddWithValue("au_id", authorId);
        commandAuthor.Parameters.AddWithValue("isbn", isbn);

        commandAuthor.ExecuteNonQuery();

        Console.WriteLine("Titre ajouté avec succès !");
    }
}
