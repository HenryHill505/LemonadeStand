using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Rain : Weather
    {
        public Rain()
        {
            name = "Raining";
            priceModifier = 0;
            customerTrafficModifier = 0;
        }
    }
}
