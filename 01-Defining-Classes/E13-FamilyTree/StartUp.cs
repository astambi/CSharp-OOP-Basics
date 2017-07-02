using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        // TODO

        var personInfo = Console.ReadLine();
        Person person;
        if (IsDate(personInfo))
        {
            person = new Person(DateTime.ParseExact(personInfo, "dd/MM/yyyy", CultureInfo.InvariantCulture));
        }
        else
        {
            person = new Person(personInfo);
        }

        var persons = new List<Person>();
        persons.Add(person);

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            if (input.Contains("-")) // create dependency
            {
                var tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (IsDate(tokens[0]))
                {

                }
            }
            else // udpate person
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0] + " " + tokens[1];
                var birthdate = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var personToUpdate = persons.FirstOrDefault(p => p.Name == name || p.Birthdate == birthdate);
                if (personToUpdate == null)
                {
                    persons.Add(new Person(name, birthdate));
                }
                else
                {
                    personToUpdate.Name = name;
                    personToUpdate.Birthdate = birthdate;
                }
            }
        }
    }

    public static bool IsDate(string s)
    {
        return s.Contains("/");
    }
}
