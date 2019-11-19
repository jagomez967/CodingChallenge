using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Interfaces
{
    public interface IIdioma
    {
        //"<h1>Lista vacía de formas!</h1>"
        //"<h1>Empty list of shapes!</h1>"
        string EmptyList();

        //"<h1>Reporte de Formas</h1>"
        //"<h1>Shapes report</h1>"
        string Header();

        #region Cuadrado
        string SingleSquare();
        string MultiSquare();
        #endregion

        #region TrianguloEquilatero
        string SingleTriangle();
        string MultiTriangle();
        #endregion
        
        #region Circulo
        string SingleCircle();
        string MultiCircle();
        #endregion
        
        #region Trapecio
        string SingleTrapezium();
        string MultiTrapezium();
        #endregion
    }
}
