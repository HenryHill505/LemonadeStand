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
            money = 20;
            lemonadeCupPrice = .25;
        }

        public void BuyItem(int userChoice)
        {
            Item chosenItem = inventory[userChoice];
            PrintItemBundles(chosenItem);
            Console.WriteLine("Done");
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
            selectedItem.amountOwned += selectedItem.bundleAndPrice[bundleChoice, 0];
            money -= selectedItem.bundleAndPrice[bundleChoice, 1];
            moneySpentToday -= selectedItem.bundleAndPrice[bundleChoice, 1];
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
            Console.WriteLine($"{selectedItem.name} ({selectedItem.amountOwned} in inventory): ");
            for (int i = 0; i < selectedItem.bundleAndPrice.GetLength(0); i++)
            {
                Console.WriteLine($"{i+1}.{selectedItem.bundleAndPrice[i,0]} {selectedItem.unit} for {selectedItem.bundleAndPrice[i,1]}");
            }
        }

        public void SellCup()
        {
            if (inventory[0].amountOwned > 0 && inventory[3].amountOwned > currentRecipe.icePerCup)
            {
                inventory[0].amountOwned--;
                inventory[3].amountOwned -= currentRecipe.icePerCup;
                cupsInPitcher--;
                money += lemonadeCupPrice;
                moneyEarnedToday += lemonadeCupPrice;
                cupsSoldThisPeriod++;
                customersServedThisPeriod++;
                cupsSoldToday++;
                customersServedToday++;
            }
        }

        public void ServeCustomer()
        {
            if (cupsInPitcher> 0)
            {
                SellCup();
            }
            else
            {
                if (MakePitcher())
                {
                    SellCup();
                }
            }
        }

        public void SetPrice()
        {
            Console.WriteLine($"Current Price: {lemonadeCupPrice}\nEnter new price per cup: ");
            lemonadeCupPrice = double.Parse(Console.ReadLine());
            Console.WriteLine($"Price set to {lemonadeCupPrice}");
            Console.ReadLine();
        }

        public void Shop()
        {
            UI.ClearPrint("Select an item by it's number, or type 'done'");
            PrintInventory();
            Console.WriteLine("Done");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "done")
            {
                try
                {
                    int userChoice = int.Parse(userInput)-1;
                    BuyItem(userChoice);
                    Shop();
                }
                catch
                {
                    Console.WriteLine("Error. Make sure you select the number of your choice.");
                    Shop();
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
