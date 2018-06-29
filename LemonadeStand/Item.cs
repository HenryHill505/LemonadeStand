using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        public double amountOwned;
        public double[,] bundleAndPrice;
        public string name;
        public string unit;

        //Constructor is here to streamline testing. Delete upon project completion
        public Item()
        {
            amountOwned = 0;
        }

        public virtual void Spoil() { }
    }
}
