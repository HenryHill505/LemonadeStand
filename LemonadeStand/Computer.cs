﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Computer : LemonadeStandOwner
    {
        Random randomizer;
        public Computer(Random randomizer) 
            :base()
        {
            this.randomizer = randomizer;
        }

        public override void ChangePrice()
        {

        }

        public override void GetName()
        {
            name = "Computer";
        }

        public override void ManageStand(string weatherForecast)
        {
            Shop();

        }

        public override void SetPrice()
        {
            lemonadeCupPrice = 5 + randomizer.Next(0, 26);
        }
        public void Shop()
        {
            foreach (Item item in inventory)
            {
                if (item.amountOwned < item.bundleAndPrice[0, 0])
                {
                    int buyIndex = randomizer.Next(1, 3);
                    if (money > item.bundleAndPrice[buyIndex, 1])
                    BuyItemBundle(item, buyIndex);
                }
            }
        }
    }
}
