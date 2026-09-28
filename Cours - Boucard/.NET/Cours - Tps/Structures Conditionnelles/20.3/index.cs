using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class MatriceCarree
    {
        int[,] coefficients;
        int ordre;

        public MatriceCarree(int pOrdre, int pMin, int pMax)
        {
            ordre = pOrdre;
            coefficients = new int[ordre, ordre];
            Random rand = new Random();
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    coefficients[i, j] = rand.Next(pMin, pMax + 1);
                }
            }
        }

        public MatriceCarree(int[,] pTableau)
        {
            ordre = pTableau.GetLength(0);
            coefficients = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    coefficients[i, j] = pTableau[i, j];
                }
            }
        }

        public MatriceCarree MultiplierParScalaire(int scalaire)
        {
            int[,] nouveauTableau = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    nouveauTableau[i, j] = coefficients[i, j] * scalaire;
                }
            }
            return new MatriceCarree(nouveauTableau);
        }

        public MatriceCarree Addition(MatriceCarree m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (m.ordre != ordre) throw new ArgumentException("Les matrices doivent avoir le même ordre.", nameof(m));
    
            int[,] nouveauTableau = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    nouveauTableau[i, j] = coefficients[i, j] + m.coefficients[i, j];
                }
            }
            return new MatriceCarree(nouveauTableau);
        }

        public MatriceCarree Sosutraction(MatriceCarree m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (m.ordre != ordre) throw new ArgumentException("Les matrices doivent avoir le même ordre.", nameof(m));

            int[,] nouveauTableau = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    nouveauTableau[i, j] = coefficients[i, j] - m.coefficients[i, j];
                }
            }
            return new MatriceCarree(nouveauTableau);
        }

        public MatriceCarree Multiplication(MatriceCarree m)
        {
            if (m == null) throw new ArgumentNullException(nameof(m));
            if (m.ordre != ordre) throw new ArgumentException("Les matrices doivent avoir le même ordre.", nameof(m));
            int[,] nouveauTableau = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    int somme = 0;
                    for (int k = 0; k < ordre; k++)
                    {
                        somme += coefficients[i, k] * m.coefficients[k, j];
                    }
                    nouveauTableau[i, j] = somme;
                }
            }
            return new MatriceCarree(nouveauTableau);
        }

        public void Transposer()
        {
            int[,] nouveauTableau = new int[ordre, ordre];
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    nouveauTableau[i, j] = coefficients[j, i];
                }
            }
            coefficients = nouveauTableau;
        }

        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ordre; i++)
            {
                for (int j = 0; j < ordre; j++)
                {
                    sb.Append(coefficients[i, j].ToString().PadLeft(5));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }

    internal class Program
    {

        static void Main()
        {
            Console.WriteLine("Génération et affichage de deux matrices 3x3");
            Console.WriteLine();

            MatriceCarree A = new MatriceCarree(3, 0, 4);
            MatriceCarree B = new MatriceCarree(3, 0, 4);

            Console.WriteLine("A :");
            Console.WriteLine(A);

            Console.WriteLine("B :");
            Console.WriteLine(B);

            Console.WriteLine("////////////////////////");
            Console.WriteLine();

            Console.WriteLine("A multipliée par le scalaire 10 :");
            Console.WriteLine(A.MultiplierParScalaire(10));

            Console.WriteLine("A + B :");
            Console.WriteLine(A.Addition(B));

            Console.WriteLine("A - B :");
            Console.WriteLine(A.Sosutraction(B));

            Console.WriteLine("A x B :");
            Console.WriteLine(A.Multiplication(B));

            Console.WriteLine("////////////////////////");
            Console.WriteLine();

            Console.WriteLine("A :");
            Console.WriteLine(A);

            A.Transposer();

            Console.WriteLine("Transposée de A :");
            Console.WriteLine(A);

            Console.WriteLine("Au revoir !");
            Console.ReadLine();
        }
    }
}