﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class LemonadeStandOwner
    {
        public double lemonadeCupPrice;
        public double money;
        public double moneyEarnedToday;
        public double moneyEarnedTotal;
        public double moneySpentToday;
        public double moneySpentTotal;
        public int cupsInPitcher;
        public int cupsSoldToday;
        public List<Item> inventory;
        public string name;
        public Recipe todayRecipe;
        public Recipe yesterdayRecipe;

        public LemonadeStandOwner()
        {
            inventory = new List<Item> { new PaperCup(), new Lemon(), new Sugar(), new Ice()};
            money = 20;
        }

        public void MakePitcher()
        {
            if (inventory[1].amountOwned >= todayRecipe.lemonsPerPitcher && inventory[2].amountOwned >= todayRecipe.sugarPerPitcher)
            {
                inventory[1].amountOwned -= todayRecipe.lemonsPerPitcher;
                inventory[2].amountOwned -= todayRecipe.sugarPerPitcher;
                cupsInPitcher = 10;
            }
        }

        public void SellCup()
        {
            inventory[0].amountOwned--;
            inventory[3].amountOwned -= todayRecipe.icePerCup;
            money += lemonadeCupPrice;
            moneyEarnedToday += lemonadeCupPrice;
            if (cupsInPitcher<= 0)
            {
                MakePitcher();
            }
        }
    }
}
