using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Collection
    {
        private Entrée[] tableau;
        private int positionLibre;

        public Collection()
        {
            this.tableau = new Entrée[10];
            this.positionLibre = 0;
        }

        public bool Ajouter(string clé, object valeur)
        {
            if (this.positionLibre < 10)
            {
                this.tableau[this.positionLibre] = new Entrée();
                this.tableau[this.positionLibre].Entrer(clé, valeur);
                this.positionLibre++;
                return true;
            }
            return false;
        }

        public object Retourner(string clé)
        {
            for (int i = 0; i < this.positionLibre; i++)
            {
                if (this.tableau[i] != null && this.tableau[i].GetCle().Equals(clé))
                {
                    return this.tableau[i].GetValeur();
                }
            }
            return null;
        }

        public bool Supprimer(string clé)
        {
            for (int i = 0; i < this.positionLibre; i++)
            {
                if (this.tableau[i] != null && this.tableau[i].GetCle().Equals(clé))
                {
                    for (int j = i; j < this.positionLibre - 1; j++)
                    {
                        this.tableau[j] = this.tableau[j + 1];
                    }
                    this.positionLibre--;
                    return true;
                }
            }
            return false;
        }

        public bool Existe(string clé)
        {
            for (int i = 0; i < this.positionLibre; i++)
            {
                if (this.tableau[i] != null && this.tableau[i].GetCle().Equals(clé))
                {
                    return true;
                }
            }
            return false;
        }

        public void Vider()
        {
            this.positionLibre = 0;
        }

        public int NomBreDElements()
        {
            return this.positionLibre;
        }

        override public string ToString()
        {
            string result = "";
            for (int i = 0; i < this.positionLibre; i++)
            {
                if (this.tableau[i] != null)
                {
                    result += this.tableau[i].ToString() + Environment.NewLine;
                }
            }
            return result;
        }
    }

    class Entrée
    {
        private string cle;
        private object valeur;

        public void Entrer(string pCle, object pValeur)
        {
            this.cle = pCle;
            this.valeur = pValeur;
        }

        public string GetCle()
        {
            return this.cle;
        }

        public object GetValeur()
        {
            return this.valeur;
        }

        override public string ToString()
        {
            return this.cle + " : " + this.valeur.ToString();
        }
    }

    internal class Program
    {

        static void Main()
        {
            Collection MaCollection;
            MaCollection = new Collection();
            MaCollection.Ajouter("22", "Côtes d'armor"); // retourne True
            MaCollection.Ajouter("35", "Ille Et Vilaine"); // retourne True
            MaCollection.Ajouter("29", "Finistère"); // retourne True
            MaCollection.Ajouter("56", "Morbihan"); // retourne True

            Console.WriteLine(MaCollection.Retourner("29"));
            // Sortie console : Finistère

            Console.WriteLine(MaCollection.ToString());
            // Sortie console :
            // 22 : Côtes d'Armor
            // 35 : Ille et Vilaine
            // 29 : Finistère
            // 56 : Morbihan

            Console.WriteLine(MaCollection.NomBreDElements());
            // Sortie console : 4

            Console.WriteLine(MaCollection.Existe("89"));
            // Sortie console : False

            Console.WriteLine(MaCollection.Existe("35"));
            // Sortie console : True

            Console.WriteLine(MaCollection.Supprimer("22")); // retourne True
            Console.WriteLine(MaCollection.Supprimer("29")); // retourne True
            Console.WriteLine(MaCollection.Supprimer("45")); // retourne False

            Console.WriteLine(MaCollection.ToString());
            // Sortie console :
            // 35 : Ille et Vilaine
            // 56 : Morbihan

            MaCollection.Vider();
            Console.WriteLine(MaCollection.ToString());
            // Sortie console :
            // Rien, la collection doit être vide

            Console.WriteLine("Au revoir !");
            Console.ReadLine();
        }
    }
}