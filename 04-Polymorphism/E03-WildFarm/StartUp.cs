using E03_WildFarm.Animals;
using E03_WildFarm.Factories;
using E03_WildFarm.Foods;
using System;

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

                Animal animal = GetAnimal(input);
                Food food = GetFood();

                if (animal == null) continue;

                try
                {
                    Console.WriteLine(animal.MakeSound());
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food GetFood()
        {
            var foodTokens = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Food food = FoodFactory.GetFood(foodTokens);
            return food;
        }

        private static Animal GetAnimal(string input)
        {
            var animalTokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Animal animal = AnimalFactory.GetAnimal(animalTokens);
            return animal;
        }
    }
}