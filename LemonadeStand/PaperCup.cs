using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class PaperCup : Item
    {
        public PaperCup()
        {
            bundleAndPrice = new double[,] { { 100, .98 }, { 250, 2.05 }, { 500, 3.91 } };
            name = "Paper Cup";
            unit = "Paper Cups";
        }
    }
}
