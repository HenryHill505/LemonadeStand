using System;
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
        public Recipe oldRecipe;
        public Recipe currentRecipe;

        public LemonadeStandOwner()
        {
            currentRecipe = new Recipe();
            inventory = new List<Item> { new PaperCup(), new Lemon(), new Sugar(), new Ice()};
            money = 20;
        }

        public void BuyItem(int userChoice)
        {
            Item chosenItem = inventory[userChoice];
            PrintItemBundles(chosenItem);
            Console.WriteLine("Done");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "done")
            {
                int bundleChoice = int.Parse(userInput);
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

        public void MakePitcher()
        {
            if (inventory[1].amountOwned >= currentRecipe.lemonsPerPitcher && inventory[2].amountOwned >= currentRecipe.sugarPerPitcher)
            {
                inventory[1].amountOwned -= currentRecipe.lemonsPerPitcher;
                inventory[2].amountOwned -= currentRecipe.sugarPerPitcher;
                cupsInPitcher = 10;
            }
        }

        public void ManageStand()
        {
            Console.WriteLine("What would you like to manage?\nShop\nRecipe\nPrice\nStart");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "shop":
                    Shop();
                    ManageStand();
                    break;
                case "recipe":
                    writeRecipe();
                    ManageStand();
                    break;
                case "price":
                    writeRecipe();
                    ManageStand();
                    break;
                case "start":
                    break;
                default:
                    Console.WriteLine("Not a valid command. Please pick Shop, Recipe, Price, or Start");
                    ManageStand();
                    break;
            }
        }

        public void PrintInventory()
        {
            for (int i = 0; i<inventory.Count; i++)
            {
                Item item = inventory[i];
                Console.WriteLine($"{i}.{item.name}: {item.amountOwned} {item.unit}");
            }
        }

        public void PrintItemBundles(Item selectedItem)
        {
            Console.WriteLine($"{selectedItem.name}: ");
            for (int i = 0; i < selectedItem.bundleAndPrice.GetLength(0); i++)
            {
                Console.WriteLine($"{selectedItem.bundleAndPrice[i,0]} {selectedItem.unit} for {selectedItem.bundleAndPrice[i,1]}");
            }
        }

        public void SellCup()
        {
            inventory[0].amountOwned--;
            inventory[3].amountOwned -= currentRecipe.icePerCup;
            money += lemonadeCupPrice;
            moneyEarnedToday += lemonadeCupPrice;
            if (cupsInPitcher<= 0)
            {
                MakePitcher();
            }
        }

        public void SetPrice()
        {
            Console.WriteLine("Enter new price per cup: ");
            lemonadeCupPrice = int.Parse(Console.ReadLine());
            Console.WriteLine($"Price set to {lemonadeCupPrice}");
            Console.ReadLine();
        }

        public void Shop()
        {
            PrintInventory();
            Console.WriteLine("Done");
            string userInput = Console.ReadLine();
            if (userInput != "Done")
            {
                int userChoice = int.Parse(userInput);
                BuyItem(userChoice);
                Shop();
            }
        }

        public void writeRecipe()
        {
            currentRecipe.Print();
            Console.WriteLine("Done");
            string userInput = Console.ReadLine().ToLower();
            if (userInput != "Done")
            {
                currentRecipe.Rewrite(userInput);                
                writeRecipe();
            }
        }
    }
}
