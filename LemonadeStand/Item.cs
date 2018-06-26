using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        public int amountOwned;
        public int[,] amountAndPrice;
        public string name;
        public string unit;

        public abstract void Spoil();
    }
}
