﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class ClearAndSunny : Weather
    {
        public ClearAndSunny()
        {
            name = "Clear and Sunny";
            priceModifier = 5;
            customerTrafficModifier = 20;
        }
    }
}
