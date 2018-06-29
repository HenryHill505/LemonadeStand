using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class GameMaster
    {
        Customer customer;
        Day today;
        int baseDailyCustomerTraffic;
        int dayCounter;
        int dayLimit;
        int periodsPerDay;
        int todayCustomerTraffic;
        List<LemonadeStandOwner> players;
        Random randomizer;

        public GameMaster()
        {
            baseDailyCustomerTraffic = 60;
            dayCounter = 1;
            periodsPerDay = 4;
            randomizer = new Random();
        }

        private void ShortageAlert(LemonadeStandOwner player)
        {
            if (player.inventory[0].amountOwned <= 0)
            {
                Console.WriteLine("You're out of cups!");
            }
            if (player.inventory[1].amountOwned < player.currentRecipe.lemonsPerPitcher)
            {
                Console.WriteLine("You don't have enough lemons to make another pitcher!");
            }
            if (player.inventory[2].amountOwned < player.currentRecipe.sugarPerPitcher)
            {
                Console.WriteLine("You don't have enough sugar to make another pitcher!");
            }
            if (player.inventory[3].amountOwned < player.currentRecipe.icePerCup)
            {
                Console.WriteLine("You don't have enough ice to pour another cup!");
            }
        }

        private void ChangePrice(LemonadeStandOwner player)
        {
            Console.WriteLine("Change the price of lemonade before the period begins? (Yes/No))");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "yes":
                    try
                    {
                        player.SetPrice();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error. Enter new price in decimal format");
                        ChangePrice(player);
                    }
                    
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Please Enter Yes or No");
                    ChangePrice(player);
                    break;
            }
        }

        private void DisplayRules()
        {
            Console.WriteLine("You have a limited number of days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies. Buy your ingredients, set your recipe, and start selling!The first thing you’ll have to worry about is your recipe. At first, go with the default recipe, but try to experiment a little bit and see if you can find a better one. Make sure you buy enough of all your ingredients, or you won’t be able to sell! You’ll also have to deal with the weather, which will play a big part when customers are deciding whether or not to buy your lemonade. Read the weather report every day! When the temperature drops, or the weather turns bad(overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly. Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade. The other major factor which comes into play is your customer’s satisfaction. As you sell your lemonade, people will decide how much they like or dislike it. This will make your business more or less popular. If your popularity is low, fewer people will want to buy your lemonade, even if the weather is hot and sunny.But if you’re popularity is high, you’ll do okay, even on a rainy day! At the end of the day limit you’ll see how much money you made.");
            Console.ReadLine();
        }

        private void GetPlayerCount()
        {
            Console.WriteLine("Is this a 1 or 2 player game");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    players = new List<LemonadeStandOwner> { new LemonadeStandOwner() };
                    break;
                case "2":
                    players = new List<LemonadeStandOwner> { new LemonadeStandOwner(), new LemonadeStandOwner() };
                    break;
                default:
                    Console.WriteLine("Error. Enter either 1 or 2 for the player count");
                    break;
            }
        }
        private void GetDayLimit()
        {   

            Console.WriteLine("How many days should the game last?");
            string dayInput = Console.ReadLine();
            int dayValue;
            while (!int.TryParse(dayInput, out dayValue) || dayValue <= 0)
            {
                Console.WriteLine("Invalid input. Enter a positive whole number for the number of days the game should last");
                dayInput = Console.ReadLine();
            }
            dayLimit = dayValue;
        }

        private void GetPlayerName()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"Player {i+1}, enter your name:");
                players[i].name = Console.ReadLine();
            }
        }

        public bool ManageStand(LemonadeStandOwner player)
        {
            string weatherForecast = $"Weather Forecast: {today.forecastWeather.name}\nTemperature Forecast: {today.forecastTemperature}\n";
            UI.ClearPrint(weatherForecast);
            Console.WriteLine("What would you like to do?\n(S)hop for Supplies\nChange (R)ecipe\nSet (P)rice\nStart (D)ay\nDeclare (B)ankruptcy");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "s":
                    player.Shop(weatherForecast);
                    return ManageStand(player);
                case "r":
                    player.writeRecipe();
                    return ManageStand(player);
                case "p":
                    player.SetPrice();
                    return ManageStand(player);
                case "d":
                    return false;
                case "b":
                    UI.ClearPrint($"You declare bankruptcy! {player.name}'s lemonade stand is finished!");
                    return true;
                default:
                    Console.WriteLine("Not a valid command. Please pick S, R, P, D, or B");
                    Console.ReadLine();
                    return ManageStand(player);
            }
        }

        private void PrintDayResults(LemonadeStandOwner player)
        {
            UI.ClearPrint($"Day {dayCounter} results");
            Console.WriteLine($"You sold {player.cupsSoldToday} cups to {player.customersServedToday} customers.\n");
            Console.WriteLine($"Today's revenue: ${player.moneyEarnedToday}\nToday's costs: ${player.moneySpentToday}\nToday's net profit: ${player.moneyEarnedToday - player.moneySpentToday}");
            Console.WriteLine($"Total revenue: ${player.moneyEarnedTotal}\nTotal costs: ${player.moneySpentTotal}\nTotal net profit: ${player.moneyEarnedTotal - player.moneySpentTotal}");
            Console.WriteLine($"Today's Customer Satisfaction: {player.todayCustomerSatisfaction}\nPopularity: {player.popularity}");
        }

        private void PrintGameResults()
        {
            foreach (LemonadeStandOwner player in players)
            {
                Console.WriteLine("End of Season Report");
                Console.WriteLine($"Total Revenue: {player.moneyEarnedTotal}\nTotal Costs: {player.moneySpentTotal}\nNet Profit/Loss: {player.moneyEarnedTotal - player.moneySpentTotal}");
                Console.ReadLine();
            }
        }

        private void PrintPeriodResults(int periodNumber, int customersServed, int TotalCustomers, int cupsSold, LemonadeStandOwner player)
        {
            
            Console.WriteLine($"{TotalCustomers} people pass {player.name}'s Lemonade Stand.");
            Console.WriteLine($"{customersServed} people purchase your lemonade.\nThey buy {cupsSold} cups of lemonade, bringing your funds to {player.money}\n");
            player.PrintInventory();
            Console.ReadLine();
        }
        private void PrintWinner()
        {
            if (players.Count > 1)
            {
                double topScore = 0;
                string winner = "";
                foreach (LemonadeStandOwner player in players)
                {
                    if (player.Money > topScore)
                    {
                        topScore = player.Money;
                        winner = player.name;
                    }
                }
                Console.WriteLine($"{winner} won with ${topScore}!");
            }
        }

        private double SetCustomerPrice()
        {
            double finalMaxPrice = customer.maxPrice + today.actualWeather.priceModifier;
            double temperatureImpact = ((Convert.ToDouble(today.actualTemperature) - 50) / 200);
            finalMaxPrice += temperatureImpact;
            return finalMaxPrice;

        }

        public void StartPeriod(int periodNumber, LemonadeStandOwner player)
        {
            UI.ClearPrint($"Begin Period {periodNumber}");
            Console.WriteLine($"It is {today.actualWeather.name}\nIt is {today.actualTemperature} degrees");
            ChangePrice(player);
        }

        public void RunGame()
        {
            DisplayRules();
            GetDayLimit();
            GetPlayerName();
            
            while (dayCounter <= dayLimit)
            {
                RunDay();
            }
            PrintGameResults();
            PrintWinner();
        }

        public void RunDay()
        {
            today = new Day();
            foreach (LemonadeStandOwner player in players)
            {
                if (!player.isBankrupt) { ManageStand(player); }
            }
 
            todayCustomerTraffic = baseDailyCustomerTraffic + today.actualWeather.customerTrafficModifier + (today.actualTemperature - 50);
            Console.WriteLine($"Begin Day {dayCounter}");
            Console.ReadLine();
            foreach (LemonadeStandOwner player in players)
            {
                if (!player.isBankrupt) { RunPeriods(player); }
            }
            foreach (LemonadeStandOwner player in players)
            {
                if (!player.isBankrupt) { WrapUpDay(player); }
            }
            Console.ReadLine();
        }

        public void RunPeriods(LemonadeStandOwner player)
        {
            Console.WriteLine($"{player.name}'s turn.");
            Console.ReadLine();
            for (int i = 1; i <= periodsPerDay; i++)
            {
                StartPeriod(i, player);
                ShortageAlert(player);
                //customer loop
                for (int j = 0; j < (todayCustomerTraffic + player.popularity) / periodsPerDay; j++)
                {
                    customer = new Customer(randomizer);

                    if (player.lemonadeCupPrice <= SetCustomerPrice())
                    {
                        player.ServeCustomer(customer.cupsDesired);
                        player.todayCustomerSatisfaction = customer.GetSatisfaction(player.currentRecipe.lemonsPerPitcher, player.currentRecipe.sugarPerPitcher, player.currentRecipe.icePerCup);
                    }
                }
                WrapUpPeriod(i, player);
            }
        }

        public void WrapUpDay(LemonadeStandOwner player)
        {
            player.moneyEarnedTotal += player.moneyEarnedToday;
            player.moneySpentTotal += player.moneySpentToday;
            player.popularity += player.todayCustomerSatisfaction;
            PrintDayResults(player);
            player.SpoilItems();
            player.moneyEarnedToday = 0;
            player.moneySpentToday = 0;
            player.cupsSoldToday = 0;
            player.customersServedToday = 0;
            player.todayCustomerSatisfaction = 0;
            dayCounter++;
        }
        public void WrapUpPeriod(int periodNumber, LemonadeStandOwner player)
        {
            PrintPeriodResults(periodNumber, player.customersServedThisPeriod, todayCustomerTraffic / periodsPerDay, player.cupsSoldThisPeriod, player);
            
            player.customersServedThisPeriod = 0;
            player.cupsSoldThisPeriod = 0;
        }
    }
}
