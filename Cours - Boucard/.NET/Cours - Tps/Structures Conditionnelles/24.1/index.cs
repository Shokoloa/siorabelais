using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Produit
    {
        private string designation;
        private double prixHT;
        private double tauxTVA;

        public Produit(string pDesignation, double pPrixHT, double pTauxTVA)
        {
            designation = pDesignation;
            prixHT = pPrixHT;
            tauxTVA = pTauxTVA;
        }

        public void AugmenterPrix(double pourcentage)
        {
            prixHT = prixHT + pourcentage / 100d * prixHT;
        }


        public void BaisserPrix(double pourcentage)
        {
            prixHT = prixHT - pourcentage / 100d * prixHT;
        }

        public double GetPrixHT()
        {
            return prixHT;
        }

        public string GetDesignation()
        {
            return designation;
        }

        public double GetTauxTVA()
        {
            return tauxTVA;
        }

        public void SetTauxTVA(double nouvTauxTVA)
        {
            tauxTVA = nouvTauxTVA;
        }

        public double GetPrixTTC()
        {
            return prixHT + tauxTVA * prixHT / 100d;
        }

        public override string ToString()
        {
            return "\nDésignation : " + designation + "\nPrix HT : " + prixHT.ToString() + "\nTaux TVA : " + tauxTVA.ToString() + "\nPrix TTC : " + GetPrixTTC().ToString();
        }
    }

    internal class Program
    {
        static Hashtable catalogue = new Hashtable();

        static void Main()
        {
            int choix = 0;

            while (choix != 10)
            {
                Console.WriteLine("\n. . . Rappel Menu . . .");
                Console.WriteLine("1. Ajouter un produit au catalogue");
                Console.WriteLine("2. Augmenter le prix HT d'un produit");
                Console.WriteLine("3. Baisser le prix HT d'un produit");
                Console.WriteLine("4. Modifier le taux de TVA d'un produit");
                Console.WriteLine("5. Augmenter tous les produits du catalogue");
                Console.WriteLine("6. Supprimer un produit du catalogue");
                Console.WriteLine("7. Afficher toutes les informations sur tous les produits");
                Console.WriteLine("8. Afficher toutes les informations sur un produit");
                Console.WriteLine("9. Vider le catalogue");
                Console.WriteLine("10. Quitter");

                Console.Write("\nChoix ? ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Console.WriteLine("\nSaisir la désignation du produit.");
                        string designation = Console.ReadLine();

                        Console.WriteLine("Saisir le prix HT du produit.");
                        double prixHT = double.Parse(Console.ReadLine());

                        Console.WriteLine("Saisir le taux de TVA du produit.");
                        double tauxTVA = double.Parse(Console.ReadLine());

                        Console.WriteLine("Saisir la référence du produit.");
                        string reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            Console.WriteLine("Cette référence existe déjà.");
                        }
                        else
                        {
                            Produit produit = new Produit(designation, prixHT, tauxTVA);
                            catalogue.Add(reference, produit);
                        }

                        break;
                    case 2:
                        Console.WriteLine("\nSaisir la référence du produit.");
                        reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            Produit produit = (Produit)catalogue[reference];

                            Console.WriteLine("Pourcentage d'augmentation ?");
                            double pourcentage = double.Parse(Console.ReadLine());

                            produit.AugmenterPrix(pourcentage);
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.");
                        }

                        break;
                    case 3:
                        Console.WriteLine("\nSaisir la référence du produit.");
                        reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            Produit produit = (Produit)catalogue[reference];

                            Console.WriteLine("Pourcentage de baisse ?");
                            double pourcentage = double.Parse(Console.ReadLine());

                            produit.BaisserPrix(pourcentage);
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.");
                        }

                        break;
                    case 4:
                        Console.WriteLine("\nSaisir la référence du produit.");
                        reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            Produit produit = (Produit)catalogue[reference];

                            Console.WriteLine("Nouveau taux de TVA ?");
                            double nouveauTauxTVA = double.Parse(Console.ReadLine());

                            produit.SetTauxTVA(nouveauTauxTVA);
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.");
                        }

                        break;
                    case 5:
                        Console.WriteLine("\nPourcentage d'augmentation ?");
                        double augmentation = double.Parse(Console.ReadLine());

                        foreach (Produit produit in catalogue.Values)
                        {
                            produit.AugmenterPrix(augmentation);
                        }

                        break;
                    case 6:
                        Console.WriteLine("\nSaisir la référence du produit.");
                        reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            catalogue.Remove(reference);
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.");
                        }

                        break;
                    case 7:
                        foreach (DictionaryEntry element in catalogue)
                        {
                            string referenceProduit = (string)element.Key;
                            Produit produit = (Produit)element.Value;

                            Console.WriteLine("\nRéférence du produit. " + referenceProduit);
                            Console.WriteLine("Désignation du produit. " + produit.GetDesignation());
                            Console.WriteLine("Prix HT du produit. " + produit.GetPrixHT());
                            Console.WriteLine("Taux de TVA du produit. " + produit.GetTauxTVA());
                            Console.WriteLine("Prix TTC du produit. " + produit.GetPrixTTC());
                        }

                        break;
                    case 8:
                        Console.WriteLine("\nSaisir la référence du produit.");
                        reference = Console.ReadLine();

                        if (catalogue.ContainsKey(reference))
                        {
                            Produit produit = (Produit)catalogue[reference];

                            Console.WriteLine("\nRéférence du produit. " + reference);
                            Console.WriteLine("Désignation du produit. " + produit.GetDesignation());
                            Console.WriteLine("Prix HT du produit. " + produit.GetPrixHT());
                            Console.WriteLine("Taux de TVA du produit. " + produit.GetTauxTVA());
                            Console.WriteLine("Prix TTC du produit. " + produit.GetPrixTTC());
                        }
                        else
                        {
                            Console.WriteLine("Produit introuvable.");
                        }

                        break;
                    case 9:
                        catalogue.Clear();
                        break;
                    case 10:
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
        }
    }
}