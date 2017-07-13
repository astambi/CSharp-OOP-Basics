namespace E03_WildFarm.Models
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, string type, double weight, int foodEaten, string livingRegion) 
            : base(name, type, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; set; }
    }
}