using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice : Item
    {
        public override void Spoil()
        {
            amountOwned = 0;
            Console.WriteLine("All your ice has melted.");
        }
    }

    
}
