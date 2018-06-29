﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        public double maxPrice;
        public int actualIceDesired;
        public int actualLemonsDesired;
        public int actualSugarDesired;
        public int baseIceDesired = 2;
        public int baseLemonsDesired = 1;
        public int baseSugarDesired = 1;
        public int cupsDesired;

        public Customer(Random randomizer)
        {
            actualIceDesired = baseIceDesired + randomizer.Next(0, 4);
            actualLemonsDesired = baseLemonsDesired + randomizer.Next(0, 5);
            actualSugarDesired = baseSugarDesired + randomizer.Next(0, 5);
            maxPrice = SetMaxPrice(randomizer);
            cupsDesired = SetCupsDesired(randomizer);
        }

        public int GetSatisfaction(int lemon, int sugar, int ice)
        {
            return (lemon-actualLemonsDesired) + (sugar-actualSugarDesired) + (ice-actualIceDesired);
        }

        public int SetCupsDesired(Random randomizer)
        {
            if (randomizer.Next(0, 4) < 1)
            {
                return randomizer.Next(1, 4);
            }
            return 1;
            
        }

        public double SetMaxPrice(Random randomizer)
        {
            double basePrice = randomizer.Next(0, 2) * .1 + randomizer.Next(0, 10) * .01;
            return basePrice;
        }
    }
}
