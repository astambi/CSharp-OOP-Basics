using System;

public class StartUp
{
    public static void Main()
    {
        var randomList = new RandomList();
        randomList.Add("one");
        randomList.Add("two");
        randomList.Add("three");

        Console.WriteLine(randomList.RandomString());
    }
}