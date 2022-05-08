using Calc;

class Program
{
    private Program()
    {
        Console.WriteLine("Calculator made in c# by v1rus_falcon");
        do
        {
            Console.Write("arithmetic expression: ");
            string input = Console.ReadLine() + "=";
            var tree = new ExpressionEvaluator(new InputParser(input).GetValues());

            // BTree evaluate
            Console.WriteLine(tree.Eval());
        }
        while (true);
    }
    static Program istance;
    public static void Main()
    {
        if (istance == null) istance = new Program();
    }
}