public class Cymric : Cat
{
    public double furLength;

    public Cymric(string breed, string name, double furLength) : base(breed, name)
    {
        this.furLength = furLength;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()} {this.furLength:f2}";
    }
}
