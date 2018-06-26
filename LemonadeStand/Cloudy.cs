using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Cloudy : Weather
    {
        public Cloudy()
        {
            priceModifier = 3;
            customerTrafficModifier = 10;
        }
    }
}
