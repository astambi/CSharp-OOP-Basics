using System.Collections.Generic;
using System.Linq;

public class Person
{
    private List<Person> children;

    public Person()
    {
        this.children = new List<Person>();
    }

    public Person(string name, string birthdate) : this()
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }

    public IReadOnlyList<Person> Children => this.children.AsReadOnly();

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }

    public void AddChildrenInfo(string name, string birthdate)
    {
        if (this.children.FirstOrDefault(c => c.Name == name) != null)
        {
            this.children
                .FirstOrDefault(c => c.Name == name)
                .Birthdate = birthdate;
            return;
        }
        if (this.children.FirstOrDefault(c => c.Birthdate == birthdate) != null)
        {
            this.children
                .FirstOrDefault(c => c.Birthdate == birthdate)
                .Name = name;
        }
    }

    public Person FindChild(string childName)
    {
        return this.children.FirstOrDefault(c => c.Name == childName);
    }
}
