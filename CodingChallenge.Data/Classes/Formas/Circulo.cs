using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class Circulo : IForma
    {
        public decimal CalcularArea(decimal lado)
        {
            return (decimal)Math.PI * (lado / 2) * (lado / 2);
        }

        public decimal CalcularPerimetro(decimal lado)
        {
            return (decimal)Math.PI * lado;
        }

        public string ObtenerNombre(IIdioma idioma)
        {
            throw new NotImplementedException();
        }
    }
}



public class Singleton
{
    private static Singleton instance;

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}