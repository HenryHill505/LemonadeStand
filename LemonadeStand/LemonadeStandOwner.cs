using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class LemonadeStandOwner
    {
        public bool isBankrupt;
        public double lemonadeCupPrice;
        public double money;
        public double moneyEarnedToday;
        public double moneyEarnedTotal;
        public double moneySpentToday;
        public double moneySpentTotal;
        public int cupsInPitcher;
        public int cupsSoldThisPeriod;
        public int cupsSoldToday;
        public int customersServedThisPeriod;
        public int customersServedToday;
        public int popularity;
        public int todayCustomerSatisfaction;
        public List<Item> inventory;
        public string name;
        public Recipe oldRecipe;
        public Recipe currentRecipe;

        public LemonadeStandOwner()
        {
            currentRecipe = new Recipe();
            inventory = new List<Item> { new PaperCup(), new Lemon(), new Sugar(), new Ice()};
            isBankrupt = false;
            money = 20;
            lemonadeCupPrice = .25;
        }

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = Math.Round(value, 2);
            }
        }

        public void BuyItem(int userChoice)
        {
            Item chosenItem = inventory[userChoice];
            PrintItemBundles(chosenItem);
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "done")
            {
                int bundleChoice = int.Parse(userInput)-1;
                BuyItemBundle(chosenItem, bundleChoice);
                BuyItem(userChoice);
            }
        }

        public void BuyItemBundle(Item selectedItem, int bundleChoice)
        {
            if (money > selectedItem.bundleAndPrice[bundleChoice, 1])
            {
                selectedItem.amountOwned += selectedItem.bundleAndPrice[bundleChoice, 0];
                Money -= selectedItem.bundleAndPrice[bundleChoice, 1];
                moneySpentToday += selectedItem.bundleAndPrice[bundleChoice, 1];
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy that!");
            }
        }

        public bool CanSellCup()
        {
            if (cupsInPitcher > 0 && inventory[0].amountOwned > 0 && inventory[3].amountOwned > currentRecipe.icePerCup)
            {
                return true;
            }
            return false;
        }

        public virtual void ChangePrice()
        {
            Console.WriteLine("Change the price of lemonade before the period begins? (Yes/No))");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "yes":
                    try
                    {
                        SetPrice();
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

        public bool MakePitcher()
        {
            if (inventory[1].amountOwned >= currentRecipe.lemonsPerPitcher && inventory[2].amountOwned >= currentRecipe.sugarPerPitcher)
            {
                inventory[1].amountOwned -= currentRecipe.lemonsPerPitcher;
                inventory[2].amountOwned -= currentRecipe.sugarPerPitcher;
                cupsInPitcher = 10;
                return true;
            }
            return false;
        }

        public void ManageStand(string weatherForecast)
        {
            UI.ClearPrint(weatherForecast);
            Console.WriteLine("What would you like to do?\n(S)hop for Supplies\nChange (R)ecipe\nSet (P)rice\nStart (D)ay\nDeclare (B)ankruptcy");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "s":
                    Shop(weatherForecast);
                    ManageStand(weatherForecast);
                    break;
                case "r":
                    writeRecipe();
                    ManageStand(weatherForecast);
                    break;
                case "p":
                    SetPrice();
                    ManageStand(weatherForecast);
                    break;
                case "d":
                    break;
                case "b":
                    UI.ClearPrint($"You declare bankruptcy! {name}'s lemonade stand is finished!");
                    isBankrupt = true;
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Not a valid command. Please pick S, R, P, D, or B");
                    Console.ReadLine();
                    ManageStand(weatherForecast);
                    break;
            }
        }

        public void PrintInventory()
        {
            for (int i = 0; i<inventory.Count; i++)
            {
                Item item = inventory[i];
                Console.WriteLine($"{i+1}: {item.name}: {item.amountOwned} {item.unit} owned");
            }
        }

        public void PrintItemBundles(Item selectedItem)
        {
            Console.WriteLine($"${money} Remaining");
            Console.WriteLine($"{selectedItem.name} ({selectedItem.amountOwned} in inventory): ");
            for (int i = 0; i < selectedItem.bundleAndPrice.GetLength(0); i++)
            {
                Console.WriteLine($"{i+1}: {selectedItem.bundleAndPrice[i,0]} {selectedItem.unit} for {selectedItem.bundleAndPrice[i,1]}");
            }
        }

        public void SellCup()
        {
                inventory[0].amountOwned--;
                inventory[3].amountOwned -= currentRecipe.icePerCup;
                cupsInPitcher--;
                Money += lemonadeCupPrice;
                moneyEarnedToday += lemonadeCupPrice;
                cupsSoldThisPeriod++;
                cupsSoldToday++;
        }

        public void ServeCustomer(int cupsToSell)
        {
            if (CanSellCup())
            {
                customersServedThisPeriod++;
                customersServedToday++;
            }

            for (int i = 0; i < cupsToSell; i++)
            {
                if (CanSellCup())
                {
                    SellCup();
                }

                else
                {
                    if (MakePitcher())
                    {
                        if (CanSellCup())
                        {
                            customersServedThisPeriod++;
                            customersServedToday++;
                            for (int k = 0; k < cupsToSell; k++)
                            {
                                SellCup();
                            }
                        }
                    }
                }
            }
        }

        public void SetPrice()
        {
            try
            {
                Console.WriteLine($"Current Price: {lemonadeCupPrice}\nEnter new price per cup: ");
                lemonadeCupPrice = double.Parse(Console.ReadLine());
                Console.WriteLine($"Price set to {lemonadeCupPrice}");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error. Price must be an integer");
                SetPrice();
            }
        }

        public virtual void Shop(string weatherForecast)
        {
            UI.ClearPrint(weatherForecast);
            Console.WriteLine($"Select an item by it's number, or type 'done'\n${money} Remaining");
            PrintInventory();
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "done")
            {
                try
                {
                    int userChoice = int.Parse(userInput)-1;
                    BuyItem(userChoice);
                    Shop(weatherForecast);
                }
                catch
                {
                    Console.WriteLine("Error. Make sure you select the number of your choice.");
                    Shop(weatherForecast);
                }
            }
        }

        public void SpoilItems()
        {
            foreach(Item item in inventory)
            {
                item.Spoil();
            }
        }

        public void writeRecipe()
        {
            Console.WriteLine("Select which part of the recipe to edit, or type 'done'");
            currentRecipe.Print();            
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "done")
            {
                currentRecipe.Rewrite(userInput);                
                writeRecipe();
            }
        }
    }
}
