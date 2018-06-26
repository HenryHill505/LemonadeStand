using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon : Item
    {
        public Lemon()
        {
            bundleAndPrice = new double[,] { { 10, .8 }, { 30, 2.36 }, { 75, 4.21 } };
        }
        public override void Spoil()
        {
            Random randomObject = new Random();
            if (randomObject.Next(0, 3) < 1)
            {
                int amountSpoiled = randomObject.Next(1, 5);
                amountOwned -= amountSpoiled;
                Console.WriteLine($"{amountSpoiled} of your lemons spoiled.");
            }
        }
    }
}
