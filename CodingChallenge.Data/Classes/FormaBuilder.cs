using CodingChallenge.Data.Classes.Formas;
using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    //Crear clase geometrica y agregarlo al CASE del constructor
    public class FormaBuilder
    {
        private static int counter = 0;
        private IForma _builder;
        public FormaBuilder() { _builder = new EmptyForm(); }
        public FormaBuilder(IForma forma)
        {
            counter++;
            _builder = forma;
        }      
        public IForma CreateObject(decimal lado) 
        {
            return _builder;
        }
        public int GetCantidad() 
        {
            return counter;
        }       
    }
}
