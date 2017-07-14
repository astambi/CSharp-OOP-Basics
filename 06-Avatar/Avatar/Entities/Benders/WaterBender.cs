using System;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    private double WaterClarity { get; /*private set;*/ }

    public override double GetPower()
    {
        return base.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Water Clarity: {this.WaterClarity:f2}";
    }
}
