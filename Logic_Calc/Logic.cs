using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Logic_Calc
{
    public class Logic
    {
        public enum Corner { Degrees, Radians, Grads };
        public Corner СornerType = Corner.Degrees;
        public double Angle;
        public bool ReplaceNextTimeClick;
        public StringBuilder Expression = new StringBuilder("");
        public StringBuilder LastNumber = new StringBuilder("");
        public char[] OperatorPriorities;
        public char[] Operators = { '+', '-', '*', '/', '^', '!', '%' };
        public void ProcessingKey(double figure) // Перегрузка числа
        {
            if (ReplaceNextTimeClick)
            {
                LastNumber.Clear();
                ReplaceNextTimeClick = false;
            }

            Expression.Append(figure);
            LastNumber.Append(figure);
        }

        public void ProcessingKey(char chr) // Перегрузка разделителя дробной части числа
        {
            if (chr == ',')
            {
                Expression.Append(chr);
                LastNumber.Append(chr);
            } 
        }
        public void ProcessingKey(string text) // Перегрузка операторов
        {
            if (ReplaceNextTimeClick)
            {
                LastNumber.Clear();
                ReplaceNextTimeClick = false;
            }

            switch (text)
            {
                case "⟵":
                    if (LastNumber.Length != 0)
                    {
                        LastNumber.Remove(LastNumber.Length - 1, 1);
                        Expression.Remove(Expression.Length - 1, 1);
                    }
                    break;

                case "C":
                    LastNumber.Remove(LastNumber.Length - 1, 1);
                    Expression.Remove(Expression.Length - 1, 1);
                    break;

                case "CE":
                    Expression.Clear();
                    LastNumber.Clear();
                    ReplaceNextTimeClick = true;
                    break;

                case "±":
                    LastNumber = new StringBuilder(Int32.Parse(LastNumber.ToString()) * -1);
                    Expression.Insert(Expression.Length - LastNumber.Length, "-");
                    break;

                case "+":
                    Expression.Append(LastNumber);
                    Expression.Append("+");
                    ReplaceNextTimeClick = true;
                    break;

                case "-":
                    Expression.Append(LastNumber);
                    Expression.Append("-");
                    ReplaceNextTimeClick = true;
                    break;

                case "*":
                    Expression.Append(LastNumber);
                    Expression.Append("*");
                    ReplaceNextTimeClick = true;
                    break;

                case "/":
                    Expression.Append(LastNumber);
                    Expression.Append("/");
                    ReplaceNextTimeClick = true;
                    break;

                // ---------------------------------

                case "sin":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"sin({Angle})");
                    LastNumber = new StringBuilder(Math.Sin(Angle).ToString());
                    break;

                case "cos":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"cos({Angle})");
                    LastNumber = new StringBuilder(Math.Cos(Angle).ToString());
                    break;

                case "tan":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"tan({Angle})");
                    LastNumber = new StringBuilder(Math.Tan(Angle).ToString());
                    break;

                case "sinh":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"sin({Angle})");
                    LastNumber = new StringBuilder(Math.Sinh(Angle).ToString());
                    break;

                case "cosh":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"sin({Angle})");
                    LastNumber = new StringBuilder(Math.Cosh(Angle).ToString());
                    break;

                case "tanh":
                    Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
                    Expression.Append($"sin({Angle})");
                    LastNumber = new StringBuilder(Math.Tanh(Angle).ToString());
                    break;

                default:
                    Expression.Append(text);
                    break;
            }
        }

        public void CalculatingExpression()
        {
            foreach (var item in Expression.ToString())
            { 
                
            }
        }

        public static double ConvertingAngle(double angle, Corner cornerType)
        {
            switch (cornerType)
            {
                case Corner.Degrees:
                    return angle;

                case Corner.Radians:
                    return (angle * 180) / Math.PI;

                case Corner.Grads:
                    return angle * 0.9;

                default:
                    return angle;
            }
        }
    }
}
