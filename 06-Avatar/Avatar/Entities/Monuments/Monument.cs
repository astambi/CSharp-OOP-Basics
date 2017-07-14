public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    private string Name { get; /*private set;*/ }

    public abstract double GetMonumentBonus();

    public override string ToString()
    {
        var monumentType = this.GetType().Name;
        var typeEndIndex = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(typeEndIndex, " "); // {Type} Monument

        return $"{monumentType}: {this.Name}";
    }
}