using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);

        //var pesho = new Person();
        //pesho.name = "Pesho";
        //pesho.age = 18;

        //var gosho = new Person("Gosho", 22);
        //Console.WriteLine();
    }
}