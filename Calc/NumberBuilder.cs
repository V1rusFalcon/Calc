using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    
    internal class NumberBuilder
    {
        private enum Flags
        {
            @decimal,
            ENotation
        }
        Flags flags;
        private int pos = 0;


        public double Value { get; internal set; } = 0;
        public void Add(int dec)
        {
            if ((flags & Flags.ENotation) == Flags.ENotation)
            {
                Value *= Math.Pow(10, dec);
                return;
            }
            if (pos >= 0)
            {
                Value *= Math.Pow(10, pos++);
                Value += dec;
            }
            else
                Value += dec * Math.Pow(10, pos--);
            
        }
        public void Decimals()
        {
            flags |= Flags.@decimal;
            if (pos > 0) pos = -1;

        }
        public void ENotation()
        {
            flags |= Flags.ENotation;
        }
        public string toString() => Value.ToString();
    }
}
