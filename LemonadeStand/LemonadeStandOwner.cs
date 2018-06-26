using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LemonadeStandOwner
    {
        double lemonadeCupPrice;
        double money;
        double moneyEarnedToday;
        double moneyEarnedTotal;
        double moneySpentToday;
        double moneySpentTotal;
        int cupsSoldToday;
        List<Item> inventory;
        string name;
        Recipe todayRecipe;
        Recipe yesterdayRecipe;
    }
}
