using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    public interface IForma
    {
        decimal CalcularArea(decimal lado);
        decimal CalcularPerimetro(decimal lado);
        string ObtenerNombre(IIdioma idioma);

    }
}
