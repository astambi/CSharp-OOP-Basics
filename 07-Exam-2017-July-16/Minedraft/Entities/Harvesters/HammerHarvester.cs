public class HammerHarvester : Harvester
{
    private const int oreOutputIncrease = 200;
    private const int energyRequirementIncrease = 100;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *=           (1 + oreOutputIncrease / 100.0);
        this.EnergyRequirement *=   (1 + energyRequirementIncrease / 100.0);
    }
}
