using System;

namespace E03_WildFarm.Models.Animals
{
    public class Zebra : Mammal
    {
        public Zebra(string name, string type, double weight, int foodEaten, string livingRegion)
            : base(name, type, weight, foodEaten, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "Zs";
        }
    }
}