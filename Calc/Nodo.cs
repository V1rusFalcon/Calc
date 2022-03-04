namespace Calc
{
#nullable enable
    internal abstract class Nodo
    {
        public Nodo left, right;
        public abstract float value { get; }
        public abstract string ToString();

    }
#nullable disable
}
