using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }    

    public double GetTotalPower()
    {
        var nationsPower = this.benders.Sum(b => b.GetPower());
        var bonusPercentage = this.monuments.Sum(m => m.GetMonumentBonus());
        nationsPower *= (1 + bonusPercentage / 100); 

        return nationsPower;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public override string ToString() 
    {
        var builder = new StringBuilder();

        // Append Benders
        builder.Append("Benders:");
        if (this.benders.Any())
        {
            builder
                .AppendLine()
                .AppendLine(string.Join(Environment.NewLine,
                    this.benders.Select(bender => $"###{bender}")));
        }
        else
        {
            builder.AppendLine(" None");
        }

        // Append Monuments
        builder.Append("Monuments:");
        if (this.monuments.Any())
        {
            builder
                .AppendLine()
                .AppendLine(string.Join(Environment.NewLine,
                    this.monuments.Select(monument => $"###{monument}"))); 
        }
        else
        {
            builder.AppendLine(" None");
        }

        return builder.ToString().Trim();
    }

    internal void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}
