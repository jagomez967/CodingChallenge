using CodingChallenge.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class IdiomaBuilder
    {
        private IIdioma _Idioma;
        public IdiomaBuilder(IIdioma idioma) 
        {
            _Idioma = idioma;
        }
        public IIdioma CreateObject()
        {
            return _Idioma;
        }
    }
}
