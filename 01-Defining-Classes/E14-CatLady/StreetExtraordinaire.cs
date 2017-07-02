public class StreetExtraordinaire : Cat
{
    private int decibels;

    public StreetExtraordinaire(string breed, string name, int decibels) : base(breed, name)
    {
        this.decibels = decibels;
    }       

    public override string ToString()
    {
        return $"{base.ToString()} {this.decibels}";
    }
}
