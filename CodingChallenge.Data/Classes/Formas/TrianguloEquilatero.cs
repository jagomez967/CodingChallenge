using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : IForma
    {
        private static int counter=0;
        public TrianguloEquilatero()
        {
            counter++;
        }
        public decimal CalcularArea(decimal lado)
        {
            return ((decimal)Math.Sqrt(3) / 4) * lado * lado;
        }

        public decimal CalcularPerimetro(decimal lado)
        {
            return lado * 3;
        }

        public string ObtenerNombre(IIdioma idioma)
        {
            if (counter <= 0)
                return idioma.SingleTriangle();
            else
                return idioma.MultiTriangle();
        }
    }
}
