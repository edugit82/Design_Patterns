﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Creational.Abstract_Factory.Modelo
{
    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }
}
