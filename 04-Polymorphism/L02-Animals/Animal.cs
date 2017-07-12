using System;

public class Animal
{
    private string name;
    private string favouriteFood;

    protected Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }
    
    public virtual string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}{Environment.NewLine}";
    }
}