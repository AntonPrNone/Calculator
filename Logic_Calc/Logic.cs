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

				case "!":
					double LNumber = Double.Parse(LastNumber.ToString());
					if (LNumber % 1 == 0) Factorial((int)LNumber);
					else
					{ 
						LastNumber = new StringBuilder(Math.Log(Factorial((int)(LNumber))) + (LNumber - (int)(LNumber)) * Math.Log((int)LNumber + 1));
					} 
						break;

				//default:
				//    Expression.Append(text);
				//    break;
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
