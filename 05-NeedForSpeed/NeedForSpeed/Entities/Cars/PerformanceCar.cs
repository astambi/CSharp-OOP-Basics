using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PerformanceCar : Car
{
    private const int horsepowerIncrease = 50;
    private const int suspensionDecrease = 25;   

    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Horsepower = horsepower + horsepower * horsepowerIncrease / 100;
        this.Suspension = suspension - suspension * suspensionDecrease / 100;
        this.addOns = new List<string>();
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        var builder = new StringBuilder(base.ToString());
        builder
            .Append($"Add-ons: ")
            .AppendLine(this.addOns.Any()
                        ? string.Join(", ", this.addOns)
                        : "None");
        return builder.ToString().Trim();
    }
}