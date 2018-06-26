using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Overcast : Weather
    {
        Overcast()
        {
            priceModifier = 2;
            customerTrafficModifier = 5;
        }
    }
}
