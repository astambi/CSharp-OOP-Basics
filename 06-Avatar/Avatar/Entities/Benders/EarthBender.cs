public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    private double GroundSaturation { get; /*private set;*/ }

    public override double GetPower()
    {
        return base.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}