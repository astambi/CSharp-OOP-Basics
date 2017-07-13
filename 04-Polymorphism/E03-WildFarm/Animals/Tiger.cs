using E03_WildFarm.Foods;
using System;

namespace E03_WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, string type, double weight, string livingRegion)
            : base(name, type, weight, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
            base.Eat(food);
        }
    }
}