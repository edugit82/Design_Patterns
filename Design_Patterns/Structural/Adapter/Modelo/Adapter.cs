﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Structural.Adapter.Modelo
{
    public class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            _adaptee.SpecificRequest();
        }
    }
}
