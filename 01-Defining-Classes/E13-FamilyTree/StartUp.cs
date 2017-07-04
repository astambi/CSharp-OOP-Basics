using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();
        var searchedPersonParam = Console.ReadLine();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            if (input.Contains("-")) // Create Parent-Child ties
            {
                var tokens = input
                            .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();
                var parentToken = tokens[0];
                var childToken = tokens[1];

                // Create Parent
                var parent = CreatePerson(parentToken);

                // Create Child
                var child = CreatePerson(childToken);

                // Add Parent if missing
                AddParentIfMissing(people, parent);

                // Append Child to Parent
                if (parent.Name != null)
                {
                    people.FirstOrDefault(p => p.Name == parent.Name)
                          .AddChild(child);
                }
                else
                {
                    people.FirstOrDefault(p => p.Birthdate == parent.Birthdate)
                          .AddChild(child);
                }
            }
            else // Update Person Info
            {
                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var birthdate = tokens[2];
                var isExistingPerson = false;

                for (int i = 0; i < people.Count; i++)
                {
                    // Update Parent birthdate
                    if (people[i].Name == name)
                    {
                        people[i].Birthdate = birthdate;
                        isExistingPerson = true;
                    }
                    // Update Parent name
                    if (people[i].Birthdate == birthdate)
                    {
                        people[i].Name = name;
                        isExistingPerson = true;
                    }
                    // Update Child info
                    people[i].AddChildrenInfo(name, birthdate);
                }

                // Add Person if not found 
                if (!isExistingPerson)
                {
                    people.Add(new Person(name, birthdate));
                }
            }
        }

        PrintParentsAndChildren(people, searchedPersonParam);
    }

    private static Person CreatePerson(string personParam)
    {
        var person = new Person();
        if (IsDate(personParam))
        {
            person.Birthdate = personParam;
        }
        else
        {
            person.Name = personParam;
        }
        return person;
    }

    private static void PrintParentsAndChildren(List<Person> people, string personParam)
    {
        Person person = people.FirstOrDefault(p => p.Birthdate == personParam ||
                                                   p.Name == personParam);
        var builder = new StringBuilder();

        // Append Person
        builder.AppendLine($"{person.Name} {person.Birthdate}");

        // Append Parents
        builder.AppendLine("Parents:");
        people.Where(p => p.FindChild(person.Name) != null)
              .ToList()
              .ForEach(p => builder.AppendLine($"{p.Name} {p.Birthdate}"));

        // Append Children
        builder.AppendLine("Children:");
        person.Children
              .ToList()
              .ForEach(c => builder.AppendLine($"{c.Name} {c.Birthdate}"));

        Console.WriteLine(builder);
    }

    private static void AddParentIfMissing(List<Person> people, Person parent)
    {
        if ((parent.Name != null && people.Any(p => p.Name == parent.Name)) ||
            (parent.Birthdate != null & people.Any(p => p.Birthdate == parent.Birthdate)))
        {
            return;
        }

        people.Add(parent);
    }

    public static bool IsDate(string s)
    {
        return s.Contains("/");
    }
}