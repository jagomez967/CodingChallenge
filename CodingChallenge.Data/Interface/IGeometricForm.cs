using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interface
{
    public interface IGeometricForm
    {
        decimal GetArea();
        decimal GetPerimeter();
        string GetNombre(IIdioma idioma);
    }
}
