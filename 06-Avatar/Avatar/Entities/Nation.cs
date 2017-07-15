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
        var nationsTotalPower = this.benders.Sum(b => b.GetPower());
        var bonusPercentage = this.monuments.Sum(m => m.GetAffinity());
        nationsTotalPower *= (1 + bonusPercentage / 100);

        return nationsTotalPower;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }
    
    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    private void AppendBendersToString(StringBuilder builder)
    {
        builder.Append("Benders:");
        if (this.benders.Any())
        {
            builder.AppendLine()
                   .AppendLine(string.Join(Environment.NewLine,
                    this.benders.Select(bender => $"###{bender}")));
        }
        else
        {
            builder.AppendLine(" None");
        }
    }

    private void AppendMonumentsToString(StringBuilder builder)
    {
        builder.Append("Monuments:");
        if (this.monuments.Any())
        {
            builder.AppendLine()
                   .AppendLine(string.Join(Environment.NewLine,
                    this.monuments.Select(monument => $"###{monument}")));
        }
        else
        {
            builder.AppendLine(" None");
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        AppendBendersToString(builder);
        AppendMonumentsToString(builder);

        return builder.ToString().Trim();
    }
}