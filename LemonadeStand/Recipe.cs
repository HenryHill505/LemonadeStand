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

        public void Print()
        {
            Console.WriteLine($"{lemonsPerPitcher} lemons per pitcher");
            Console.WriteLine($"{sugarPerPitcher} cups of sugar per pitcher");
            Console.WriteLine($"{icePerCup} ice cubes per cup");
        }
    }
}
