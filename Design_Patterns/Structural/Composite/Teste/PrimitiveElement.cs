﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Structural.Composite.Teste
{
    public class PrimitiveElement : DrawingElement
    {
        // Constructor
        public PrimitiveElement(string name)
            : base(name)
        {
        }

        public override void Add(DrawingElement c)
        {
            Console.WriteLine(
              "Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement c)
        {
            Console.WriteLine(
              "Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(
              new String('-', indent) + " " + _name);
        }
    }
}
