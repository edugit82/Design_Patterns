using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Creational.Prototype.Modelo
{
    public class Client
    {
        private Prototype _prototype;

        public Prototype Operation(Prototype objeto) 
        {
            _prototype = objeto;
            return _prototype.Clone();
        }
    }
}
