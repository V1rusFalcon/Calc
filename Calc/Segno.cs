using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    internal class Segno : Nodo
    {
        public enum sign
        {
            plus = 0,
            minus = 2,
            mul = 4,
            div = 8,
            pm = plus|minus,
            md = div|mul,
            equal = 128
        }
        public static sign Parse(char c) => c switch { '+' => sign.plus, '-' => sign.minus, '*' => sign.mul, '/' => sign.div, _ => throw new NotImplementedException() };
        public sign Sign;
        public override double value
        {
            get {
                return Sign switch
                {
                    sign.plus => left.value+right.value,
                    sign.minus => left.value - right.value,
                    sign.mul => left.value * right.value,
                    sign.div => left.value / right.value
                };
            }
        }
        public override string ToString()
        {
            if(left != null && right != null) return "("+left.ToString() + Sign switch { sign.plus => '+', sign.minus => '-', sign.mul => '*', sign.div => '/'} + right.ToString()+")";
            return Sign switch { sign.plus => "+", sign.minus => "-", sign.mul => "*", sign.div => "/" };
        }
    }
}