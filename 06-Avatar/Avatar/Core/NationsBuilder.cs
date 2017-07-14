using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>();
        nations["Air"] = new Nation();
        nations["Water"] = new Nation();
        nations["Fire"] = new Nation();
        nations["Earth"] = new Nation();

        this.warHistoryRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var bender = CreateBender(benderArgs);
        this.nations[benderType].AddBender(bender);
    }

    private Bender CreateBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);

        switch (benderType)
        {
            case "Air": return new AirBender(name, power, secondaryParameter);
            case "Fire": return new FireBender(name, power, secondaryParameter);
            case "Water": return new WaterBender(name, power, secondaryParameter);
            case "Earth": return new EarthBender(name, power, secondaryParameter);
            default: throw new ArgumentException("Invalid bender");
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        var monument = CreateMonument(monumentArgs);
        this.nations[monumentType].AddMonument(monument);
    }

    private Monument CreateMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (monumentType)
        {
            case "Air": return new AirMonument(name, affinity);
            case "Fire": return new FireMonument(name, affinity);
            case "Water": return new WaterMonument(name, affinity);
            case "Earth": return new EarthMonument(name, affinity);
            default: throw new ArgumentException("Invalid monument");
        }
    }

    public string GetStatus(string nationsType)
    {
        var builder = new StringBuilder();
        builder
            .AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);

        return builder.ToString();
    }

    public void IssueWar(string nationsType)
    {
        var winningNation = nations.Max(n => n.Value.GetTotalPower());
        foreach (var nation in this.nations.Values)
        {
            if (nation.GetTotalPower() != winningNation)
            {
                nation.DeclareDefeat();
            }
        }
        // Add war record
        this.warHistoryRecord
            .Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.warHistoryRecord);
    }
}
