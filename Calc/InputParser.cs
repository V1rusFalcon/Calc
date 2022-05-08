using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator
{
    public class InputParser
    {
        List<dynamic> values;
        public InputParser(string expression)
        {
            NumberBuilder value = null;
            values = new List<dynamic>();
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case char digit when char.IsDigit(expression[i]):
                        if (value == null) value = new NumberBuilder();

                        value.Add(int.Parse(expression[i].ToString()));
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
                        if (value != null) values.Add(value.Value);
                        values.Add(Segno.Parse(expression[i]));
                        value = null;
                        break;
                    case '=': values.Add(value.Value); break;
                }
            }
        }
        public dynamic[] GetValues() => values.ToArray();
    }
}
