using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class EmptyForm : IForma
    {
        public decimal CalcularArea(decimal lado)
        {
            throw new NotImplementedException();
        }

        public decimal CalcularPerimetro(decimal lado)
        {
            throw new NotImplementedException();
        }

        public string ObtenerNombre(IIdioma idioma)
        {
            throw new NotImplementedException();
        }
    }
}
