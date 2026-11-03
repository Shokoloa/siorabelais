using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    abstract class Vehicule
    {
        private string code;
        private string libelle;
        private double prixJour;

        public Vehicule(string code, string libelle, double prixJour)
        {
            this.code = code;
            this.libelle = libelle;
            this.prixJour = prixJour;
        }

        public string GetCode()
        {
            return code;
        }

        public string GetLibelle()
        {
            return libelle;
        }

        public double GetPrixJour()
        {
            return prixJour;
        }

        public void SetPrixJour(double nouvPrixJour)
        {
            prixJour = nouvPrixJour;
        }

        public double CoutLocation(double nombreJours)
        {
            return prixJour * nombreJours;
        }

        public override string ToString()
        {
            return "Code catégorie : " + code +
                   "\nLibellé catégorie : " + libelle +
                   "\nPrix location journalière : " + prixJour;
        }
    }

    class VehiculeUtilitaire : Vehicule
    {
        private double chargeUtile;
        private double longueur;
        private double largeur;
        private double hauteur;

        public VehiculeUtilitaire(
            string code,
            string libelle,
            double prixJour,
            double chargeUtile,
            double longueur,
            double largeur,
            double hauteur
        ) : base(code, libelle, prixJour)
        {
            this.chargeUtile = chargeUtile;
            this.longueur = longueur;
            this.largeur = largeur;
            this.hauteur = hauteur;
        }

        public double GetChargeUtile()
        {
            return chargeUtile;
        }

        public double GetLongueur()
        {
            return longueur;
        }

        public double GetLargeur()
        {
            return largeur;
        }

        public double GetHauteur()
        {
            return hauteur;
        }

        public double GetVolume()
        {
            return longueur * largeur * hauteur;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nCharge utile : " + chargeUtile +
                   "\nLongueur : " + longueur +
                   "\nLargeur : " + largeur +
                   "\nHauteur : " + hauteur +
                   "\nVolume : " + GetVolume();
        }
    }

    class VehiculeTourisme : Vehicule
    {
        private int nombrePortes;
        private int nombrePassagers;
        private bool climatisation;

        public VehiculeTourisme(
            string code,
            string libelle,
            double prixJour,
            int nombrePortes,
            int nombrePassagers,
            bool climatisation
        ) : base(code, libelle, prixJour)
        {
            this.nombrePortes = nombrePortes;
            this.nombrePassagers = nombrePassagers;
            this.climatisation = climatisation;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nNombre de portes : " + nombrePortes +
                   "\nNombre de passagers : " + nombrePassagers +
                   "\nClimatisation : " + climatisation;
        }
    }

    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("\n\n///TEST VEHICULE UTILITAIRE////");

            VehiculeUtilitaire vu = new VehiculeUtilitaire(
                "VU10",
                "Citroën Jumpy I",
                100,
                1000,
                4.5,
                3,
                2
            );

            Console.WriteLine(vu);
            Console.WriteLine("Coût location : " + vu.CoutLocation(10));

            Console.WriteLine("\n\n///TEST VEHICULE TOURISME////");

            VehiculeTourisme vt = new VehiculeTourisme(
                "VU22",
                "Simca Aronde",
                50,
                5,
                4,
                false
            );

            Console.WriteLine(vt);
            Console.WriteLine("Coût location : " + vt.CoutLocation(10));
        }
    }
}