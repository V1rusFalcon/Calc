using MathEvaluator;

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
