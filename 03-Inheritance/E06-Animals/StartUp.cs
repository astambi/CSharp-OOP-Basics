using System;

namespace E06_Animals
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                var animalType = Console.ReadLine();
                if (animalType == "Beast!") break;

                try
                {
                    Animal animal = GetAnimal(animalType);
                    Console.Write(animal.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Animal GetAnimal(string animalType)
        {
            var tokens = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var animalName = tokens[0];
            var animalAge = int.Parse(tokens[1]);

            switch (animalType)
            {
                case "Cat":     return new Cat(animalName, animalAge, tokens[2]);
                case "Dog":     return new Dog(animalName, animalAge, tokens[2]);
                case "Frog":    return new Frog(animalName, animalAge, tokens[2]);
                case "Kitten":  return new Kitten(animalName, animalAge);
                case "Tomcat":  return new Tomcat(animalName, animalAge);
                default:        throw new ArgumentException("Invalid input!"); // NB!
            }
        }
    }
}
