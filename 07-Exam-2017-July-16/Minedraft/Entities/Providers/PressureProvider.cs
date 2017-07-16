public class PressureProvider : Provider
{
    private const int energyOutputIncrease = 50;

    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput *= (1 + energyOutputIncrease / 100.0);
    }
}
