using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice : Item
    {
        public Ice()
            : base()
        {
            bundleAndPrice = new double[,] { { 100, .98 }, { 250, 2.05 }, { 500, 3.91 } };
            name = "Ice";
            unit = "Ice Cubes";
        }
        public override void Spoil()
        {
            amountOwned = 0;
            Console.WriteLine("All your ice has melted.");
        }
    }

    
}
