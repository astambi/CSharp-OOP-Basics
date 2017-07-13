namespace E03_WildFarm.Animals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, string type, double weight, string livingRegion) 
            : base(name, type, weight, livingRegion)
        {
        }
    }
}