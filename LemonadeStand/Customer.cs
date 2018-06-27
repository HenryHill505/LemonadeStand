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
        public int cupsDesired;

        public Customer(Random randomizer)
        {

            maxPrice = SetMaxPrice(randomizer);
            cupsDesired = SetCupsDesired();
        }

        public int SetCupsDesired()
        {
            return 1;
        }

        public double SetMaxPrice(Random randomizer)
        {
            double basePrice = randomizer.Next(0, 6) * .1 + randomizer.Next(0, 10) * .01;
            return basePrice;
        }
    }
}
