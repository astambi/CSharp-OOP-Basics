using System;
using System.Text;

public abstract class Harvester : Participant
{
    //private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        //this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    //public string Id
    //{
    //    get { return this.id; }
    //    private set
    //    {
    //        this.id = value;
    //    }
    //}

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0) // NOT negative
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000) // NOT negative & NOT over 20000
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public override string GetTypeName()
    {
        var type = this.GetType().Name;
        var endIndex = type.IndexOf("Harvester");
        type = type.Insert(endIndex, " ");

        return type;
    }

    public override string ToString()
    {
        //var type = this.GetType().Name;
        //var endIndex = type.IndexOf("Harvester");
        //type = type.Substring(0, endIndex);

        var type = this.GetTypeName();

        var builder = new StringBuilder();
        builder
            //.AppendLine($"{type} Harvester - {this.Id}")
            .AppendLine($"{type} - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return builder.ToString().Trim();
    }
}