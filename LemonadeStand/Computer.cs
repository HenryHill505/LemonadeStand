﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Computer : LemonadeStandOwner
    {
        Random randomizer;
        public Computer(Random randomizer) 
            :base()
        {
            this.name = "Computer";
            this.randomizer = randomizer;
        }

        public override void Shop(string weatherForecast)
        {
            foreach (Item item in inventory)
            {
                if (item.amountOwned < item.bundleAndPrice[0, 0])
                {
                    int buyIndex = randomizer.Next(0, 4);
                    if (buyIndex <= 0 && money > item.bundleAndPrice[buyIndex, 1])
                    BuyItemBundle(item, buyIndex);
                }
            }
        }

        public override void ChangePrice()
        {
            
        }
    }
}
