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
        public Corner cornerType = Corner.Degrees;
        public string Expression = "";
        public static Key[] KeysNumbers = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9 };
        public static Key[] KeysSigns = { Key.Enter, Key.OemPlus, Key.OemMinus };

        public static void ProcessingKey(Char simvol)
        { 
            
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
