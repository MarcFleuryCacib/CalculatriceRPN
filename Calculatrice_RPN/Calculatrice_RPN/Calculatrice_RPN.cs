namespace Calculatrice_RPN
{
    public class Calculatrice_RPN
    {
        public int Index { get; set; }
        public double Value { get; set; }

        public Calculatrice_RPN(int index, double value)
        {
            Index = index;
            Value = value;
        }
    }
}
