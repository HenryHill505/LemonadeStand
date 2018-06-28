using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UI
    {
        public static void PrintClear(string input)
        {
            Console.WriteLine(input);
            Console.ReadKey();
            Console.Clear();

        }
    }
}
