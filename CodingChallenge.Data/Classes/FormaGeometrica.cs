/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Classes.Formas;
using CodingChallenge.Data.Classes.Idiomas;
using CodingChallenge.Data.Interfaces;
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

            IIdioma IdiomaConstructor;
            switch (idioma) //AGREGO LOS IDIOMAS AQUI
            {
                case Castellano:
                    IdiomaConstructor = new IdiomaES();
                    break;
                case Ingles:
                    IdiomaConstructor = new IdiomaEN();
                    break;
                default:
                    IdiomaConstructor = new IdiomaEN();
                    break;
            }

            var IdiomaFactory = new IdiomaBuilder(IdiomaConstructor);
            var oIdioma = IdiomaFactory.CreateObject();

            if (!formas.Any())
            {
                sb.Append(oIdioma.EmptyList());
                return sb.ToString();
            }

            // Hay por lo menos una forma
            // HEADER
            sb.Append(oIdioma.Header());
            List<IForma> FormasGeometricaList = new List<IForma>();
            foreach(var forma in formas)
            {
                IForma FormaConstructor; 
                switch (forma.Tipo) //AGREGO LOS NUEVOS TIPOS DE FORMAS GEOMETRICAS AQUI
                {
                    case Cuadrado:
                        FormaConstructor= new Cuadrado();
                        break;
                    case Circulo:
                        FormaConstructor = new Circulo();
                        break;
                    case TrianguloEquilatero:
                        FormaConstructor = new TrianguloEquilatero();
                        break;
                    case Trapecio:
                        FormaConstructor = new EmptyForm();
                        break;
                    default:
                        FormaConstructor = new EmptyForm();
                        break;
                };
                var FormaFactory = new FormaBuilder(FormaConstructor);
                var oFormaGeometrica = FormaFactory.CreateObject(forma._lado);
                FormasGeometricaList.Add(oFormaGeometrica);
            }

            var grouping = FormasGeometricaList.GroupBy(s => s.ObtenerNombre(oIdioma));



       /* sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
            sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
            sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

            // FOOTER
            sb.Append("TOTAL:<br/>");
            sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
            sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
            sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
         */   

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
