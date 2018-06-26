using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon : Item
    {
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
