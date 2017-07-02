public class Cat
{
    private string breed;
    private string name;

    public Cat(string breed, string name)
    {
        this.breed = breed;
        this.name = name;
    }

    public string Name => this.name;

    public override string ToString()
    {
        return $"{this.breed} {this.name}";
    }
}