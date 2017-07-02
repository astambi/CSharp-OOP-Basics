using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }
    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public string Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }
    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public override string ToString()
    {
        var builder = new StringBuilder()
            .AppendLine(this.Model + ":")
            .AppendLine($"  {this.Engine.Model}:")
            .AppendLine($"    Power: {this.Engine.Power}")
            .AppendLine($"    Displacement: {this.engine.Displacement}")
            .AppendLine($"    Efficiency: {this.engine.Efficiency}")
            .AppendLine($"  Weight: {this.weight}")
            .AppendLine($"  Color: {this.color}");
        return builder.ToString();
    }
}