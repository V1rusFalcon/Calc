using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    internal class Costante : Nodo
    {
        float _value;

        public Costante(float value)
        {
            _value = value;
        }

        public override float value => _value;
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
