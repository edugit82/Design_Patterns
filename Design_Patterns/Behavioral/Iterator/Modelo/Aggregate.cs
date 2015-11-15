using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behavioral.Iterator.Modelo
{
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
}
