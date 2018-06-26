using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Hazy : Weather
    {
        Hazy()
        {
            priceModifier = 4;
            customerNumberModifier = 15;
        }
    }
}
