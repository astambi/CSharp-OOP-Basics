using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private DateTime birthdate;
    private List<FamilyMember> parents;
    private List<FamilyMember> children;

    public Person()
    {
        this.parents = new List<FamilyMember>();
        this.children = new List<FamilyMember>();
    }

    public Person(string name) : this()
    {
        this.name = name;
    }
    public Person(DateTime birthdate) : this()
    {
        this.birthdate = birthdate;
    }
    public Person(string name, DateTime birthdate) : this(name)
    {
        this.birthdate = birthdate;
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public DateTime Birthdate
    {
        get { return this.birthdate; }
        set { this.birthdate = value; }
    }

}
