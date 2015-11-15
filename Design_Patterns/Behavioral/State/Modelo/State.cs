using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behavioral.State.Modelo
{
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
}
