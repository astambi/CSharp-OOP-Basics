public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    private double HeatAggression { get; /*private set;*/ }

    public override double GetPower()
    {
        return base.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Heat Aggression: {this.HeatAggression:f2}";
    }
}
