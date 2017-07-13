namespace E03_WildFarm.Models
{
    public abstract class Animal
    {
        public Animal(string name, string type, double weight, int foodEaten)
        {
            this.Name = name;
            this.Type = type;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        private string Name { get; set; }
        private string Type { get; set; }
        private double Weight { get; set; }
        private int FoodEaten { get; set; }
        
        public abstract string MakeSound();

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}