/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        private readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();
            IIdioma _idiomaClass;

            if (idioma == Castellano)
            {
                _idiomaClass = new Castellano();
            }else
            {
                _idiomaClass = new Ingles();
            }


            var IdiomaBuild = new IdiomaBuilder(_idiomaClass);
            var oIdioma = IdiomaBuild.CreateObject();

            if (!formas.Any())
            {
                sb.Append(oIdioma.EmptyList());
 //                   sb.Append("<h1>Lista vacía de formas!</h1>");
 //                   sb.Append("<h1>Empty list of shapes!</h1>");
                return sb.ToString();
            }

            // Hay por lo menos una forma
            // HEADER
            sb.Append(oIdioma.Header());

            //    sb.Append("<h1>Reporte de Formas</h1>");
            //    sb.Append("<h1>Shapes report</h1>");
            var GeoFormBuilder = new GeometricBuilder();
            for (var i = 0; i < formas.Count; i++)
            {
                IGeometricForm geometricForm;
                if (formas[i].Tipo == Cuadrado)
                {
                    geometricForm = new Rectangulo();
                }//ETC
                else
                {
                    geometricForm = new Circulo();
                }

                GeoFormBuilder.CreateObject(geometricForm);
            }

            foreach (string linea in GeoFormBuilder.GetLines())
            {
                sb.Append(linea);
            }

//          sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
//          sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
//          sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

            // FOOTER
            sb.Append(oIdioma.Total().ToUpper() + ":<br/>");
            
            //sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
            //sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
            //sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            
            return sb.ToString();
        }

       

       

        //public decimal CalcularArea()
        //{
        //    switch (Tipo)
        //    {
        //        case Cuadrado: return _lado * _lado;
        //        case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        //        case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        //        default:
        //            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        //    }
        //}

        //public decimal CalcularPerimetro()
        //{
        //    switch (Tipo)
        //    {
        //        case Cuadrado: return _lado * 4;
        //        case Circulo: return (decimal)Math.PI * _lado;
        //        case TrianguloEquilatero: return _lado * 3;
        //        default:
        //            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        //    }
        //}
    }
}
