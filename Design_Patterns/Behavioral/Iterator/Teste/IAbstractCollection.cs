﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behavioral.Iterator.Teste
{
    public interface IAbstractCollection
    {
        Iterator CreateIterator();
    }
}