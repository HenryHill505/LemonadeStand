using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Item
    {
        public Sugar()
        {
            bundleAndPrice = new double[,] { { 8, .54 }, { 20, 1.74 }, { 48, 3.26 } };
        }
        public override void Spoil()
        {
            Random randomObject = new Random();
            if (randomObject.Next(0, 5) < 1)
            {
                amountOwned = 0;
                Console.WriteLine("Bugs in the sugar. You've lost it all!");
            }
        }
    }
}
