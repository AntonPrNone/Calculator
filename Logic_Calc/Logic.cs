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
        public StringBuilder Expression = new StringBuilder("");
        public char[] OperatorPriorities;
        public char[] Operators = { '+', '-', '*', '/', '^', '!', '%' };
        public void ProcessingKey(int figure)
        {
            Expression.Append(figure);
        }
        public void ProcessingKey(char simvol)
        {
            if (simvol == 'B')
                Expression.Remove(Expression.Length - 1, 1);
            else Expression.Append(simvol);
        }

        public void ProcessingKey(string text)
        {
            Expression.Append(text);
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
