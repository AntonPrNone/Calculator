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
                case "(":
                    Expression.Append("(");
                    ReplaceNextTimeClick = true;
                    break;

                case ")":
                    Expression.Append(")");
                    ReplaceNextTimeClick = true;
                    break;

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
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder((Double.Parse(LastNumber.ToString()) * -1).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "+":
					Expression.Append("+");
					ReplaceNextTimeClick = true;
					break;

				case "-":
					Expression.Append("-");
					ReplaceNextTimeClick = true;
					break;

				case "*":
					Expression.Append("*");
					ReplaceNextTimeClick = true;
					break;

				case "/":
					Expression.Append("/");
					ReplaceNextTimeClick = true;
					break;

                case "Mod":
                    Expression.Append("%");
                    ReplaceNextTimeClick = true;
                    break;

                case "π":
                    Expression.Append(Math.PI);
					LastNumber = new StringBuilder(Math.PI.ToString());
                    ReplaceNextTimeClick = true;
                    break;

                // ---------------------------------

                case "sin":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Sin(Angle));
					LastNumber = new StringBuilder(Math.Sin(Angle).ToString());
					break;

				case "cos":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Cos(Angle));
					LastNumber = new StringBuilder(Math.Cos(Angle).ToString());
					break;

				case "tan":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Tan(Angle));
					LastNumber = new StringBuilder(Math.Tan(Angle).ToString());
					break;

				case "sinh":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Sinh(Angle));
					LastNumber = new StringBuilder(Math.Sinh(Angle).ToString());
					break;

				case "cosh":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Cosh(Angle));
					LastNumber = new StringBuilder(Math.Cosh(Angle).ToString());
					break;

				case "tanh":
					Angle = ConvertingAngle(Double.Parse(LastNumber.ToString()), СornerType);
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					Expression.Append(Math.Tanh(Angle));
					LastNumber = new StringBuilder(Math.Tanh(Angle).ToString());
					break;

				// ---------------------------------

				case "n!":
					double LNumber = Double.Parse(LastNumber.ToString());
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					if (LNumber % 1 == 0)
					{
						LastNumber = new StringBuilder(Factorial((int)LNumber).ToString());
					}
					
					else
					{ 
						LastNumber = new StringBuilder((int)(Math.Log(Factorial((int)(LNumber))) + (LNumber - (int)(LNumber)) * Math.Log((int)LNumber + 1)));
					}
					Expression.Append(LastNumber);

                    break;

                case "√":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Pow(Double.Parse(LastNumber.ToString()), 1.0 / 2.0).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "1/x":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder((1 / Double.Parse(LastNumber.ToString())).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "x^2":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					LastNumber = new StringBuilder(Math.Pow(Double.Parse(LastNumber.ToString()), 2).ToString());
                    Expression.Append(LastNumber);
					break;

                case "x^3":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Pow(Double.Parse(LastNumber.ToString()), 3).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "10^x":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Pow(10, Double.Parse(LastNumber.ToString())).ToString());
                    Expression.Append(LastNumber);
                    break;

				case "3√x":
					Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
					LastNumber = new StringBuilder(Math.Pow(Double.Parse(LastNumber.ToString()), 1.0 / 3.0).ToString());
					Expression.Append(LastNumber);
					break;

                case "log":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Log(Double.Parse(LastNumber.ToString())).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "In":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Log10(Double.Parse(LastNumber.ToString())).ToString());
                    Expression.Append(LastNumber);
                    break;

                case "Exp":
                    Expression.Remove(Expression.Length - LastNumber.Length, LastNumber.Length);
                    LastNumber = new StringBuilder(Math.Exp(Double.Parse(LastNumber.ToString())).ToString());
                    Expression.Append(LastNumber);
                    break;

                    //default:
                    //    Expression.Append(text);
                    //    break;
            }
		}

        public void CalculatingExpression(string exp)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < exp.Length; i++) list.Add(exp[i].ToString());

            int upBracket = (from p in list where p == ("(") select p).Count();
            int downBracket = (from p in list where p == (")") select p).Count();

            for (int i = 0; i < upBracket; i++)
            {
                int indexBracket = list.LastIndexOf("(");
                list.RemoveAt(indexBracket);
                list.Insert(indexBracket, $"su{i}");
            }

            for (int i = 0; i < downBracket; i++)
            {
                int indexBracket = list.IndexOf(")");
                list.RemoveAt(indexBracket);
                list.Insert(indexBracket, $"sd{i}");
            }

            Console.WriteLine(String.Join("", list));
        }

        public static double ConvertingAngle(double angle, Corner cornerType)
		{
			switch (cornerType)
			{
				case Corner.Degrees:
					return angle * (Math.PI / 180);

				case Corner.Radians:
					return angle;

				case Corner.Grads:
					return (angle * (Math.PI / 180)) * 0.9;

				default:
					return angle;
			}
		}

		public static int Factorial(int number)
		{
			if (number == 1 || number == 0) return 1;

			return number * Factorial(number - 1);
		}
	}
}
