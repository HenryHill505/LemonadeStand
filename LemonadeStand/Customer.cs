using System;
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
        public int baseIceDesired = 3;
        public int baseLemonsDesired = 2;
        public int baseSugarDesired = 2;
        public int cupsDesired;

        public Customer(Random randomizer)
        {
            actualIceDesired = baseIceDesired + randomizer.Next(0, 4);
            actualLemonsDesired = baseLemonsDesired + randomizer.Next(0, 4);
            actualSugarDesired = baseSugarDesired + randomizer.Next(0, 4);
            maxPrice = SetMaxPrice(randomizer);
            cupsDesired = SetCupsDesired();
        }

        public int GetSatisfaction(int lemon, int sugar, int ice)
        {
            return (actualLemonsDesired-lemon) + (actualSugarDesired-sugar) + (actualIceDesired-ice);
        }

        public int SetCupsDesired()
        {
            return 1;
        }

        public double SetMaxPrice(Random randomizer)
        {
            double basePrice = randomizer.Next(0, 2) * .1 + randomizer.Next(0, 10) * .01;
            return basePrice;
        }
    }
}
