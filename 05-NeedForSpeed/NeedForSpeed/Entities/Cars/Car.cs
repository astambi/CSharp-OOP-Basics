using System.Text;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; /*private set;*/ }
    public string Model { get; /*private set;*/ }
    private int YearOfProduction { get; /*private set;*/ }
    public int Horsepower { get; protected set; }
    public int Acceleration { get; /*private set; */}
    public int Suspension { get; protected set; }
    public int Durability { get; /*private set;*/ }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder
            .AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        return builder.ToString();
    }
}