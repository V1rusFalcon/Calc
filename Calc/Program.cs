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
            NumberBuilder value = null;
            for (int i = 0; i < input.Length; i++)
            {
                switch(input[i])
                {
                    case char digit when char.IsDigit(input[i]):
                        if (value == null) value = new NumberBuilder();
                        
                        value.Add(int.Parse(input[i].ToString()));
                        break;
                    case '.' when value != null: value.Decimals(); break;
                    case 'E' when value != null:
                    case 'e' when value != null:
                        value.ENotation();
                        break;
                    case '+': 
                    case '-':
                    case '*':
                    case '/':
                        if(value != null) values.Add(value.Value);
                        values.Add(Segno.Parse(input[i]));
                        value = null;
                        break;
                    case '=': values.Add(value.Value); break;
                }
            }
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