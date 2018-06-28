using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
        public static void ClearPrint(string input)
        {
            Console.Clear();
            Console.WriteLine(input);
        }
    }
}
