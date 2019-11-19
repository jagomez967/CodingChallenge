using CodingChallenge.Data.Classes.Idiomas;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class IdiomaBuilder
    {
        private IIdioma _builder;
        public IdiomaBuilder() { _builder = new IdiomaEN(); }
        public IdiomaBuilder(IIdioma idioma)
        {
            _builder = idioma;            
        }
        public IIdioma CreateObject()
        {
            return _builder;
        }
    }
}
