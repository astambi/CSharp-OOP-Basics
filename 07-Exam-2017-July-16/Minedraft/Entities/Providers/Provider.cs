using System;
using System.Text;

public abstract class Provider : Participant
{
    //private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        //this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    //public string Id
    //{
    //    get { return this.id; }
    //    private set { this.id = value; }
    //}

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value <= 0 || value >= 10000) // positive && less than 10000
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public override string GetTypeName()
    {
        var type = this.GetType().Name;
        var endIndex = type.IndexOf("Provider");
        type = type.Insert(endIndex, " ");

        return type;
    }

    public override string ToString()
    {
        //var type = this.GetType().Name;
        //var endIndex = type.IndexOf("Provider");
        //type = type.Substring(0, endIndex);

        var type = this.GetTypeName();

        var builder = new StringBuilder();
        builder
            //.AppendLine($"{type} Provider - {this.Id}")
            .AppendLine($"{type} - {this.Id}")
            .AppendLine($"Energy Output: {this.EnergyOutput}");

        return builder.ToString().Trim();
    }
}
