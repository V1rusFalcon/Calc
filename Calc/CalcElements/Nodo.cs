namespace MathEvaluator.CalcElements
{
#nullable enable
    internal abstract class Nodo
    {
        public Nodo left, right;
        public abstract double value { get; }
        public abstract string ToString();

    }
#nullable disable
}
