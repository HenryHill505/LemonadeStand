using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Item
    {
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
