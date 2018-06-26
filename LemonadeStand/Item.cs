using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        int amountOwned;
        int[,] amountAndPrice;
        string name;
        string unit;

        public abstract void Spoil();
    }
}
