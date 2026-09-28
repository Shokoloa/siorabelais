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

        public double GetPartieReelle()
        {
            return this.x;
        }

        public double GetPartieImaginaire()
        {
            return this.y;
        }

        public Complexe Addition(Complexe nombre)
        {
            return new Complexe(this.x + nombre.GetPartieReelle(), this.y + nombre.GetPartieImaginaire());
        }

        public Complexe Soustraction(Complexe nombre)
        {
            return new Complexe(this.x - nombre.GetPartieReelle(), this.y - nombre.GetPartieImaginaire());
        }

        public Complexe Produit(Complexe nombre)
        {
            return new Complexe(this.x * nombre.GetPartieReelle() - this.y * nombre.GetPartieImaginaire(), this.x * nombre.GetPartieImaginaire() + this.y * nombre.GetPartieReelle());
        }

        public Complexe Inverse()
        {
            double denominateur = this.x * this.x + this.y * this.y;
            if (denominateur == 0)
            {
                throw new DivideByZeroException("Cannot compute the inverse of a complex number with zero modulus.");
            }
            return new Complexe(this.x / denominateur, -this.y / denominateur);
        }

        public double GetModule()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        override public string ToString()
        {
            return $"{this.x} + {this.y}i";
        }
    }

    internal class Program
    {

        static void Main()
        {
        }
    }
}