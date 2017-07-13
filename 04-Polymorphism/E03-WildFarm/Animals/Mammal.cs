using E03_WildFarm.Foods;
using System;

namespace E03_WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.Name}, {base.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}