using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        double maxPrice;
        int cupsDesired;

        public Customer()
        {
            maxPrice = SetMaxPrice();
            cupsDesired = SetCupsDesired();
        }

        public int SetCupsDesired()
        {
            return 1;
        }

        public double SetMaxPrice()
        {
            Random randomObject = new Random();
            double basePrice = randomObject.Next(0, 6) * .1 + randomObject.Next(0, 10) * .01;
            return basePrice;
        }
    }
}
