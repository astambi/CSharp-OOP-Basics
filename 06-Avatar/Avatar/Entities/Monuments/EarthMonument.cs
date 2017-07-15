public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    private int EarthAffinity { get; /*private set;*/ }

    public override double GetAffinity()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Earth Affinity: {this.EarthAffinity}";
    }
}
