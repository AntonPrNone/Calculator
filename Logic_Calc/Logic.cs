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
        public bool ReplaceNextTimeClick;
        public StringBuilder Expression = new StringBuilder("");
        public StringBuilder LastNumber = new StringBuilder("");
        public char[] OperatorPriorities;
        public char[] Operators = { '+', '-', '*', '/', '^', '!', '%' };
        public void ProcessingKey(int figure)
        {
            if (ReplaceNextTimeClick)
            {
                LastNumber.Clear();
                ReplaceNextTimeClick = false;
            } 
            
            LastNumber.Append(figure);
        }

        public void ProcessingKey(string text)
        {
            if (ReplaceNextTimeClick)
            {
                LastNumber.Clear();
                ReplaceNextTimeClick = false;
            }

            switch (text)
            {
                case "B":
                    if (Expression.Length !=0)
                        Expression.Remove(Expression.Length - 1, 1);
                    break;

                case "⟵":
                    if (Expression.Length != 0)
                        Expression.Remove(Expression.Length - 1, 1);
                    break;

                case "C":
                    LastNumber = new StringBuilder("0");
                    ReplaceNextTimeClick = true;
                    break;

                case "CE":
                    Expression.Clear();
                    LastNumber = new StringBuilder("0");
                    ReplaceNextTimeClick = true;
                    break;

                case "±":
                    LastNumber = new StringBuilder(Int32.Parse(LastNumber.ToString()) * -1);
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
