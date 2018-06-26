using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Overcast : Weather
    {
        public Overcast()
        {
            priceModifier = 2;
            customerTrafficModifier = 5;
        }
    }
}
