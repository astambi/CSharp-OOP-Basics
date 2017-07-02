using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<FamilyMember> parents;
    private List<FamilyMember> children;
    private List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
        this.parents = new List<FamilyMember>();
        this.children = new List<FamilyMember>();
        this.pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }
    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }
    public List<FamilyMember> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }
    public List<FamilyMember> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }
    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(this.name);

        builder.AppendLine("Company:");
        if (company != null) builder.AppendLine(company.ToString());

        builder.AppendLine("Car:");
        if (car != null) builder.AppendLine(car.ToString());

        builder.AppendLine("Pokemon:");
        this.pokemons.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Parents:");
        this.parents.ForEach(p => builder.AppendLine(p.ToString()));

        builder.AppendLine("Children:");
        this.children.ForEach(ch => builder.AppendLine(ch.ToString()));

        return builder.ToString();
    }
}
