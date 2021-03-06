﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behavioral.Strategy.Modelo
{
    public class Context
    {
        private Strategy _strategy;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
}
