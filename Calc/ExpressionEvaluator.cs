using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    internal class ExpressionEvaluator
    {
        Nodo Tree;
        public ExpressionEvaluator(dynamic[] values)
        {
            Populate(values);
        }
        public ExpressionEvaluator() { }
        public void Populate(dynamic[] values)
        {
            for (int i = 0; i < values.Count(); i++)
                Populate(ref Tree, values[i]);
        }

        public double Eval()
        {
            return Tree.value;
        }

        /**
     * function to build the tree
     * 
     * if the tree is null it create a node(Costante) which rappresents a number
     * and use it as the root. with the second input, which has to be a sign,
     * move the Costante to the left and the
     * root become a node(Segno) and the next elements are added to the right.
     * 
     * if a sign with the same weight is added, the root become the left leaf of
     * the new sign excpect when the sign added is with higher priority,
     * like mul(*) or div(/), which it steal the right leaf of the root and
     * makes it the left leaf of the new sign and is added to the right of the root.
     */
        void Populate(ref Nodo root, double value)
        {
            if (root == null)
            {
                root = new Costante(value);
                return;
            }

            if (root.right is Segno)
                Populate(ref root.right, value);
            else root.right = new Costante(value);

        }
        void Populate(ref Nodo root, Segno.sign sign)
        {
            if ((sign & Segno.sign.pm) == sign || root is not Segno || (((Segno)root).Sign & Segno.sign.md) != 0b0)
            {
                Segno s = new Segno() { Sign = sign };
                s.left = root;
                root = s;
            }
            else
            {
                Segno s = new Segno() { Sign = sign };
                s.left = root.right;
                root.right = s;
            }
        }
    }
}
