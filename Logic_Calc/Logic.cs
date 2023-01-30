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
        public string Expression = "";
        public static Key[] KeysNumbers = { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9 };
        public static Key[] KeysSigns = { Key.Enter, Key.OemPlus,  };

        public static void ProcessingKey(Key key, bool Shift)
        { 
            
        }
    }
}
