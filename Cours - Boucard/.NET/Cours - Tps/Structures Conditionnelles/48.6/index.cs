using Newtonsoft.Json.Linq; // NuGet : Newtonsoft.Json
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIWeb
{
    // ---------- Classes de mappage (normalement dans Model/, ici dans le même fichier) ----------

    public class Etablissement
    {
        public string Siret { get; set; }
        public string Libelle_commune { get; set; }
        public string Libelle_activite_principale { get; set; }
        public string Nom_raison_sociale { get; set; }
    }

    public class Departement
    {
        public string Nom { get; set; }
        public string Code { get; set; }
        public string CodeRegion { get; set; }
    }

    public class Commune
    {
        public string Nom { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; } // entier (nullable : certaines communes n'ont pas de population)
    }

    internal class Program
    {
        private static HttpClient client;

        // API « Sirene données ouvertes »
        private static async Task<string> GetEnreprises(string nom)
        {
            var donnees = string.Empty;
            var reponse = await client.GetAsync("https://entreprise.data.gouv.fr/api/sirene/v1/full_text/" + nom);
            if (reponse.IsSuccessStatusCode)
            {
                donnees = await reponse.Content.ReadAsStringAsync();
            }
            return donnees;
        }

        // API Découpage Administratif : départements
        private static async Task<string> GetLesDepartements()
        {
            var donnees = string.Empty;
            var reponse = await client.GetAsync("https://geo.api.gouv.fr/departements");
            if (reponse.IsSuccessStatusCode)
            {
                donnees = await reponse.Content.ReadAsStringAsync();
            }
            return donnees;
        }

        // API Découpage Administratif : communes (on ne demande que les champs utiles)
        private static async Task<string> GetLesCommunes()
        {
            var donnees = string.Empty;
            var reponse = await client.GetAsync("https://geo.api.gouv.fr/communes?fields=nom,code,population");
            if (reponse.IsSuccessStatusCode)
            {
                donnees = await reponse.Content.ReadAsStringAsync();
            }
            return donnees;
        }

        private static void Main(string[] args)
        {
            client = new HttpClient();

            ////// EXEMPLE 1 : 1 objet JSON (racine = '{') //////
            var lesEntreprisesJSON = GetEnreprises("Airbus").GetAwaiter().GetResult();
            var premierEtablissement = JObject.Parse(lesEntreprisesJSON)
                .SelectToken("etablissement").ToObject<List<Etablissement>>().First();

            Console.WriteLine("/// PREMIER ETABLISSEMENT AYANT POUR NOM AIRBUS : ");
            Console.WriteLine(premierEtablissement.Nom_raison_sociale);
            Console.WriteLine(premierEtablissement.Siret);
            Console.WriteLine(premierEtablissement.Libelle_activite_principale);
            Console.WriteLine(premierEtablissement.Libelle_commune);
            Console.ReadLine();

            ////// EXEMPLE 2 : tableau d'objets JSON (racine = '[') //////
            var lesDepartementsJSON = GetLesDepartements().GetAwaiter().GetResult();
            var lesDepartements = JArray.Parse(lesDepartementsJSON).ToObject<List<Departement>>();

            var premierDepartement = lesDepartements.First();
            Console.WriteLine("\n/// PREMIER DEPARTEMENT : ");
            Console.WriteLine(premierDepartement.Nom);
            Console.WriteLine(premierDepartement.Code);
            Console.WriteLine(premierDepartement.CodeRegion);

            Console.WriteLine("\n/// LES DEPARTEMENTS BRETONS : ");
            var lesDepartementsBretons = from dep in lesDepartements
                                         where dep.CodeRegion == "53"
                                         select new { dep.Nom, dep.Code, dep.CodeRegion };
            foreach (var departement in lesDepartementsBretons)
            {
                Console.WriteLine(departement);
            }
            Console.ReadLine();

            ////// TRAVAIL A FAIRE 48.6 : communes de plus de 500 000 habitants //////
            Console.WriteLine("\n/// COMMUNES DE PLUS DE 500000 HABITANTS : ");
            var lesCommunes = JArray.Parse(GetLesCommunes().GetAwaiter().GetResult())
                .ToObject<List<Commune>>();

            var grandesCommunes = from c in lesCommunes
                                  where c.Population > 500000 // false si Population est null
                                  orderby c.Population descending
                                  select new { c.Nom, c.Code, c.Population };
            foreach (var commune in grandesCommunes)
            {
                Console.WriteLine(commune);
            }
            Console.ReadLine();
        }
    }
}
