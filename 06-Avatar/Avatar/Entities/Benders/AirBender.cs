using System;

public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    private double AerialIntegrity { get; /*private set;*/ }

    public override double GetPower()
    {
        return base.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {        
        return $"{base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}