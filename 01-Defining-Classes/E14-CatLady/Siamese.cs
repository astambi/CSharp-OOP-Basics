public class Siamese : Cat
{
    private int earSize;

    public Siamese(string breed, string name, int earSize) : base(breed, name)
    {
        this.earSize = earSize;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()} {this.earSize}";
    }
}
