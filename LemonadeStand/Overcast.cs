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
            name = "Overcast";
            priceModifier = .02;
            customerTrafficModifier = 5;
        }
    }
}
