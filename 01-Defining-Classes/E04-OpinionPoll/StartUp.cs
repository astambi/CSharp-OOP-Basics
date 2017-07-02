using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        GetPersons()
            .Where(p => p.Age > 30)
            .OrderBy(p => p.Name)
            .ToList()
            .ForEach(p => Console.WriteLine(p.ToString()));
    }

    private static List<Person> GetPersons()
    {
        var persons = new List<Person>();
        var numberOfPersons = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfPersons; i++)
        {
            var personInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var person = new Person(personInfo[0], int.Parse(personInfo[1]));
            persons.Add(person);
        }
        return persons;
    }
}