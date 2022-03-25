using Calc;

class Program
{
    private Program()
    {
        Console.WriteLine("Calculator made in c# by v1rus_falcon");
        do
        {
            Console.Write("arithmetic expression: ");
            List<dynamic> values = new List<dynamic>();
            string input = Console.ReadLine() + "=";
            #region input parsing
            int? value = null;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsNumber(input[i]))
                {
                    if (value == null) value = 0;
                    value *= 10;
                    value += int.Parse(input[i].ToString());
                }
                else
                {
                    if (value != null)
                        values.Add(value);
                    values.Add(
                        input[i] switch
                        {
                            '+' => Segno.sign.plus,
                            '-' => Segno.sign.minus,
                            '/' => Segno.sign.div,
                            '*' => Segno.sign.mul,
                            '=' => Segno.sign.equal,
                            _ => throw new NotImplementedException()
                        }
                    );
                    value = null;
                }
            }
            values.RemoveAt(values.Count - 1);
            #endregion
            #region BTree building
            Nodo tree = null;
            for (int i = 0; i < values.Count; i++)
                Populate(ref tree, values[i]);

            #endregion

            // BTree evaluate
            Console.WriteLine(tree.value);
        }
        while (true);
    }
    static Program istance;
    public static void Main()
    {
        if (istance == null) istance = new Program();
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
    void Populate(ref Nodo root, float value)
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