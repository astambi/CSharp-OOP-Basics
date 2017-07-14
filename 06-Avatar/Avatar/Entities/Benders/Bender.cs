public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    private string Name { get; /*private set;*/ }
    protected int Power { get; /*private set;*/ }
    
    public abstract double GetPower();

    public override string ToString()
    {
        var benderType = this.GetType().Name;
        var typeEndIndex = benderType.IndexOf("Bender");
        benderType = benderType.Insert(typeEndIndex, " "); // {Type} Bender

        return $"{benderType}: {this.Name}, Power: {this.Power}";
    }
}