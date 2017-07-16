using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private Dictionary<string, double> energyRequirementMode;
    private Dictionary<string, double> oreOutputMode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = "Full";

        energyRequirementMode = new Dictionary<string, double>();
        this.energyRequirementMode["Full"] = 1.0;
        this.energyRequirementMode["Half"] = 0.6;
        this.energyRequirementMode["Energy"] = 0.0;

        oreOutputMode = new Dictionary<string, double>();
        this.oreOutputMode["Full"] = 1.0;
        this.oreOutputMode["Half"] = 0.5;
        this.oreOutputMode["Energy"] = 0.0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        // RegisterHarvester {type} {id} {oreOutput} {energyRequirement}
        // RegisterHarvester Sonic {id} {oreOutput} {energyRequirement} {sonicFactor}

        try
        {
            var harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters[harvester.Id] = harvester;

            return $"Successfully registered {harvester.GetTypeName()} - {harvester.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        // RegisterProvider {type} {id} {energyOutput}

        try
        {
            var provider = ProviderFactory.CreateProvider(arguments);
            this.providers[provider.Id] = provider;

            return $"Successfully registered {provider.GetTypeName()} - {provider.Id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        double summedOreOutput = 0;
        double energyRequirementModifier = this.energyRequirementMode[this.mode];
        double oreOutputModifier = this.oreOutputMode[this.mode];

        // Calc provided energy (providers are not affected by mode)
        var summedEnergyOutput = this.providers
                                     .Values
                                     .Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += summedEnergyOutput;

        // Calc required energy (modified by mode)
        var totalEnergyRequired = this.harvesters
                                      .Values
                                      .Sum(h => h.EnergyRequirement * energyRequirementModifier);

        // Calc produced ore (modified by mode)
        if (totalEnergyRequired <= this.totalStoredEnergy)
        {
            summedOreOutput = this.harvesters
                                  .Values
                                  .Sum(h => h.OreOutput * oreOutputModifier);
            this.totalMinedOre += summedOreOutput;
            this.totalStoredEnergy -= totalEnergyRequired;
        }

        var builder = new StringBuilder();
        builder
            .AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {summedEnergyOutput}")
            .AppendLine($"Plumbus Ore Mined: {summedOreOutput}");
        return builder.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        // Mode {mode}

        var modeParam = arguments[0];
        if (modeParam == "Full" || modeParam == "Half" || modeParam == "Energy")
        {
            this.mode = modeParam;
        }

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        // Check {id}

        var id = arguments[0];

        if (!harvesters.ContainsKey(id) &&
            !providers.ContainsKey(id))
        {
            return $"No element found with id - {id}";
        }

        if (harvesters.ContainsKey(id))
        {
            return harvesters[id].ToString();
        }

        return providers[id].ToString();
    }

    public string ShutDown()
    {
        var builder = new StringBuilder();
        builder
            .AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return builder.ToString().Trim();
    }
}