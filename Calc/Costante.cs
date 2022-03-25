using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    internal class Costante : Nodo
    {
        double _value;

        public Costante(double value)
        {
            _value = value;
        }

        public override double value => _value;
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
