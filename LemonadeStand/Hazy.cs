using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Hazy : Weather
    {
        public Hazy()
        {
            name = "Hazy";
            priceModifier = 4;
            customerTrafficModifier = 15;
        }
    }
}
