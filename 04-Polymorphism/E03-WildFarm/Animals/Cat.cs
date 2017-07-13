using System;

namespace E03_WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, string type, double weight, string livingRegion, string breed)
            : base(name, type, weight, livingRegion)
        {
            this.Breed = breed;
        }

        private string Breed { get; set; }

        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.Name}, {this.Breed}, {base.Weight}, {base.LivingRegion}, {this.FoodEaten}]";
        }
    }
}