using System;

namespace E03_WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, string type, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, type, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        private string Breed { get; set; }

        public override string MakeSound()
        {
            return "Meowwww";
        }
    }
}