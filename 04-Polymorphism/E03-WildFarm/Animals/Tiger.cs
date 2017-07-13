using System;

namespace E03_WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, string type, double weight, int foodEaten, string livingRegion)
            : base(name, type, weight, foodEaten, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }
    }
}