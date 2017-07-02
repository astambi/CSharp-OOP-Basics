using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var persons = GetPersons();
        PrintPerson(persons);
    }

    private static List<Person> GetPersons()
    {
        var persons = new List<Person>();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            var person = persons.FirstOrDefault(p => p.Name == name);
            if (person == null)
            {
                person = new Person(name);
                persons.Add(person);
            }

            var subclass = tokens[1];
            switch (subclass)
            {
                case "company": // <Name> company <companyName> <department> <salary>      
                    person.Company = new Company(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                    break;
                case "pokemon": // <Name> pokemon <pokemonName> <pokemonType>     
                    person.Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                    break;
                case "parents": // <Name> parents <parentName> <parentBirthday>     
                    person.Parents.Add(new FamilyMember(tokens[2], tokens[3]));
                    break;
                case "children": // <Name> children <childName> <childBirthday>
                    person.Children.Add(new FamilyMember(tokens[2], tokens[3]));
                    break;
                case "car": // <Name> car <carModel> <carSpeed>    
                    person.Car = new Car(tokens[2], int.Parse(tokens[3]));
                    break;
                default: break;
            }
        }
        return persons;
    }

    private static void PrintPerson(List<Person> persons)
    {
        var filterName = Console.ReadLine();
        var person = persons.FirstOrDefault(p => p.Name == filterName);
        if (person != null)
        {
            Console.Write(person.ToString());
        }
    }
}