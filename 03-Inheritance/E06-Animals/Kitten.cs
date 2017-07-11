namespace E06_Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, "Female")
        {
        }
        
        public override string ProduceSound()
        {
            return "Miau";
        }
    }
}
