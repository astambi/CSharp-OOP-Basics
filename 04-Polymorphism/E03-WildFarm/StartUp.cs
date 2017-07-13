using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03_WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var animalTokens = input
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var foodTokens = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);







            }



        }
    }
}
