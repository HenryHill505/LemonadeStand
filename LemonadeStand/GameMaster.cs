using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class GameMaster
    {
        Day today;
        int baseDailyCustomerTraffic;
        int dayCounter;
        int dayLimit;
        int periodsPerDay;
        int todayCustomerTraffic;
        LemonadeStandOwner player1;
        Random randomizer;

        public GameMaster()
        {
            baseDailyCustomerTraffic = 60;
            dayCounter = 1;
            periodsPerDay = 4;
            player1 = new LemonadeStandOwner();
            randomizer = new Random();
        }

        private void ChangePrice()
        {
            Console.WriteLine("Change the price of lemonade before the next period begins? (Yes/No))");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "yes":
                    try
                    {
                        player1.SetPrice();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error. Enter new price in decimal format");
                        ChangePrice();
                    }
                    
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Please Enter Yes or No");
                    ChangePrice();
                    break;
            }
        }

        private void DisplayRules()
        {
            Console.WriteLine("You have 7, 14, or 21 days to make as much money as possible, and you’ve decided to open a lemonade stand! You’ll have complete control over your business, including pricing, quality control, inventory control, and purchasing supplies. Buy your ingredients, set your recipe, and start selling!The first thing you’ll have to worry about is your recipe. At first, go with the default recipe, but try to experiment a little bit and see if you can find a better one.Make sure you buy enough of all your ingredients, or you won’t be able to sell! You’ll also have to deal with the weather, which will play a big part when customers are deciding whether or not to buy your lemonade. Read the weather report every day!When the temperature drops, or the weather turns bad(overcast, cloudy, rain), don’t expect them to buy nearly as much as they would on a hot, hazy day, so buy accordingly.Feel free to set your prices higher on those hot, muggy days too, as you’ll make more profit, even if you sell a bit less lemonade. The other major factor which comes into play is your customer’s satisfaction. As you sell your lemonade, people will decide how much they like or dislike it.  This will make your business more or less popular.If your popularity is low, fewer people will want to buy your lemonade, even if the weather is hot and sunny.But if you’re popularity is high, you’ll do okay, even on a rainy day! At the end of 7, 14, or 21 days you’ll see how much money you made.Play again, and try to beat your high score!");
            Console.ReadLine();
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
            Console.WriteLine("Enter your name:");
            player1.name = Console.ReadLine();
        }

        private void PrintDayResults()
        {
            Console.WriteLine($"Day {dayCounter} results");
            Console.WriteLine($"You sold {player1.cupsSoldToday} cups  to {player1.customersServedToday}.\n");
            Console.WriteLine($"Today's revenue: {player1.moneyEarnedToday}\nToday's costs: {player1.moneySpentToday}\nToday's net profit: {player1.moneyEarnedToday - player1.moneySpentToday}");
            Console.WriteLine($"Total revenue: {player1.moneyEarnedTotal}\nTotal costs: {player1.moneySpentTotal}\nTotal net profit: {player1.moneyEarnedTotal - player1.moneySpentTotal}");
            Console.WriteLine($"Today's Customer Satisfaction: {player1.todayCustomerSatisfaction}\nPopularity: {player1.popularity}");
        }

        private void PrintGameResults()
        {
            Console.WriteLine("End of Season Report");
            Console.WriteLine($"Total Revenue: {player1.moneyEarnedTotal}\nTotal Costs: {player1.moneySpentTotal}\nNet Profit/Loss: {player1.moneyEarnedTotal - player1.moneySpentTotal}");
            Console.ReadLine();
        }

        private void PrintPeriodResults(int periodNumber, int customersServed, int TotalCustomers, int cupsSold)
        {
            Console.WriteLine($"{TotalCustomers} people pass {player1.name}'s Lemonade Stand.");
            Console.WriteLine($"{customersServed} people purchase your lemonade.\nThey buy {cupsSold} cups of lemonade, bring your funds to {player1.money}\n");
            player1.PrintInventory();
            Console.ReadLine();
        }

        public void RunGame()
        {
            DisplayRules();
            GetPlayerName();
            GetDayLimit();
            while (dayCounter <= dayLimit)
            {
                today = new Day();
                Console.WriteLine($"Weather Forecast: {today.forecastWeather.name}\nTemperature Forecast: {today.forecastTemperature}\n");
                player1.ManageStand();
                todayCustomerTraffic = baseDailyCustomerTraffic + today.actualWeather.customerTrafficModifier + (today.actualTemperature - 50);
                Console.WriteLine($"Begin Day {dayCounter}");
                Console.ReadLine();
                //period loop
                for (int i = 1; i <= periodsPerDay; i++)
                {
                    Console.WriteLine($"Begin Period {i}");
                    //customer loop
                    for (int j = 0; j < todayCustomerTraffic/periodsPerDay; j++)
                    {
                        Customer customer = new Customer(randomizer);
                        if (player1.lemonadeCupPrice <= customer.maxPrice)
                        {
                            for (int k = 0; k < customer.cupsDesired; k++)
                            {
                                player1.ServeCustomer();
                                player1.todayCustomerSatisfaction = customer.GetSatisfaction(player1.currentRecipe.lemonsPerPitcher, player1.currentRecipe.sugarPerPitcher, player1.currentRecipe.icePerCup);
                            }
                        }
                    }
                    WrapUpPeriod(i);                    
                }
                WrapUpDay();
                Console.ReadLine();
            }
            PrintGameResults();
        }

        public void WrapUpDay()
        {
            player1.moneyEarnedTotal += player1.moneyEarnedToday;
            player1.moneySpentTotal += player1.moneySpentToday;
            player1.popularity = player1.todayCustomerSatisfaction / 4;
            PrintDayResults();
            player1.SpoilItems();
            player1.moneyEarnedToday = 0;
            player1.moneySpentToday = 0;
            player1.cupsSoldToday = 0;
            player1.customersServedToday = 0;
            player1.todayCustomerSatisfaction = 0;
            dayCounter++;
        }
        public void WrapUpPeriod(int periodNumber)
        {
            PrintPeriodResults(periodNumber, player1.customersServedThisPeriod, todayCustomerTraffic / periodsPerDay, player1.cupsSoldThisPeriod);
            ChangePrice();
            player1.customersServedThisPeriod = 0;
            player1.cupsSoldThisPeriod = 0;
        }
    }
}
