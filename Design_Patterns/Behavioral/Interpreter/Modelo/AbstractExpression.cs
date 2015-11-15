using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Behavioral.Interpreter.Modelo
{
    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
}
