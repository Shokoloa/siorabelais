using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Complexe
    {
        private double x;
        private double y;

        public Complexe(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Complexe()
        {
            this.x = 0;
            this.y = 0;
        }

        public double GetPartieReele()
        {
            return this.x;
        }

        public double GetPartieImaginaire()
        {
            return this.y;
        }

        public Complexe Addition(Complexe nombre)
        {
            return new Complexe(this.x + nombre.x, this.y + nombre.y);
        }

        public Complexe Soustraction(Complexe nombre)
        {
            return new Complexe(this.x - nombre.x, this.y - nombre.y);
        }

        public Complexe Produit(Complexe nombre)
        {
            return new Complexe(this.x * nombre.x - this.y * nombre.y, this.x * nombre.y + this.y * nombre.x);
        }

        public Complexe Inverse()
        {
            double denominateur = this.x * this.x + this.y * this.y;
            return new Complexe(this.x / denominateur, -this.y / denominateur);
        }

        public double GetModule()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        override public string ToString()
        {
            return "Partie Reelle : " + this.x.ToString() + "\nPartie Imaginaire : " + this.y.ToString();
        }
    }

    internal class Program
    {
        static Complexe SaisirComplexe()
        {
            Console.Write("Entrez la partie réelle : ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Entrez la partie imaginaire : ");
            double y = double.Parse(Console.ReadLine());

            return new Complexe(x, y);
        }

        static void Main()
        {
            int choix = 0;

            Complexe[] tableau = new Complexe[100];
            int nombreComplexes = 0;

            while (choix != 8)
            {
                Console.WriteLine("1. Afficher la somme de deux nombres complexes saisis par l'utilsiateur");
                Console.WriteLine("2. Afficher la soustraction de deux nombres complexes saisis par l'utilsiateur");
                Console.WriteLine("3. Afficher le produit de deux nombres complexes saisis par l'utilsiateur");
                Console.WriteLine("4. Afficher l'inverse d'un nombre complexe saisi par l'utilsiateur");
                Console.WriteLine("5. Afficher le module d'un nombre complexe saisi par l'utilsiateur");
                Console.WriteLine("6. Ajouter un Complexe dans un tableau");
                Console.WriteLine("7. Faire la somme des nombres complexes du tableau");
                Console.WriteLine("8. Quitter");

                Console.Write("Entrez votre choix : ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                    {
                        Console.WriteLine("\nPremier nombre complexe :");
                        Complexe nombre1 = SaisirComplexe();

                        Console.WriteLine("\nDeuxième nombre complexe :");
                        Complexe nombre2 = SaisirComplexe();

                        Complexe resultat = nombre1.Addition(nombre2);

                        Console.WriteLine("\nRésultat :");
                        Console.WriteLine(resultat);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("\nPremier nombre complexe :");
                        Complexe nombre1 = SaisirComplexe();

                        Console.WriteLine("\nDeuxième nombre complexe :");
                        Complexe nombre2 = SaisirComplexe();

                        Complexe resultat = nombre1.Soustraction(nombre2);

                        Console.WriteLine("\nRésultat :");
                        Console.WriteLine(resultat);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("\nPremier nombre complexe :");
                        Complexe nombre1 = SaisirComplexe();

                        Console.WriteLine("\nDeuxième nombre complexe :");
                        Complexe nombre2 = SaisirComplexe();

                        Complexe resultat = nombre1.Produit(nombre2);

                        Console.WriteLine("\nRésultat :");
                        Console.WriteLine(resultat);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("\nNombre complexe :");
                        Complexe nombre = SaisirComplexe();

                        if (nombre.GetPartieReele() == 0 && nombre.GetPartieImaginaire() == 0)
                        {
                            Console.WriteLine("Impossible de calculer l'inverse de 0.");
                        }
                        else
                        {
                            Complexe resultat = nombre.Inverse();

                            Console.WriteLine("\nRésultat :");
                            Console.WriteLine(resultat);
                        }
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("\nNombre complexe :");
                        Complexe nombre = SaisirComplexe();

                        Console.WriteLine("\nModule : " + nombre.GetModule());

                        break;
                    }
                    case 6:
                    {
                        if (nombreComplexes >= tableau.Length)
                        {
                            Console.WriteLine("Le tableau est plein.");
                            break;
                        }

                        Console.WriteLine("\nNouveau nombre complexe :");
                        Complexe nombre = SaisirComplexe();

                        tableau[nombreComplexes] = nombre;
                        nombreComplexes++;

                        Console.WriteLine("Le nombre complexe a été ajouté au tableau.");

                        break;
                    }
                    case 7:
                    {
                        if (nombreComplexes == 0)
                        {
                            Console.WriteLine("Le tableau est vide.");
                            break;
                        }

                        Complexe somme = new Complexe();

                        for (int i = 0; i < nombreComplexes; i++)
                        {
                            somme = somme.Addition(tableau[i]);
                        }

                        Console.WriteLine("\nSomme des nombres complexes du tableau :");
                        Console.WriteLine(somme);

                        break;
                    }
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

            Console.WriteLine("Au revoir !");
            Console.ReadLine();
        }
    }
}