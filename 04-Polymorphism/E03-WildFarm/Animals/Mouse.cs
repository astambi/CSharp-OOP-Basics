using System;

namespace E03_WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, string type, double weight, int foodEaten, string livingRegion) 
            : base(name, type, weight, foodEaten, livingRegion)
        {
        }

        public override string MakeSound()
        {
            return "SQUEEEAAAK!";
        }
    }
}