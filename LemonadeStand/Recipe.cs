using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public int lemonsPerPitcher;
        public int sugarPerPitcher;
        public int icePerCup;

        public Recipe()
        {
            lemonsPerPitcher = 4;
            sugarPerPitcher = 4;
            icePerCup = 4;
        }

        public void Print()
        {
            Console.WriteLine($"1: {lemonsPerPitcher} lemons per pitcher");
            Console.WriteLine($"2: {sugarPerPitcher} cups of sugar per pitcher");
            Console.WriteLine($"3: {icePerCup} ice cubes per cup");
        }

        public void Rewrite(string choice)
        {
            if(choice == "1" || choice == "lemons")
            {
                Console.WriteLine("How many lemons per pitcher?");
                lemonsPerPitcher = int.Parse(Console.ReadLine());
            }
            else if (choice == "2" || choice == "sugar")
            {
                Console.WriteLine("How many cups of sugar per pitcher?");
                sugarPerPitcher = int.Parse(Console.ReadLine());
            }
            else if (choice == "3" || choice == "ice")
            {
                Console.WriteLine("How many ice cubes per cup?");
                icePerCup = int.Parse(Console.ReadLine());
            }
        }
    }
}
