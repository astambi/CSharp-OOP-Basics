using System;

public class StartUp
{
    public static void Main()
    {
        var data = new StackOfStrings();
        data.Push("one");

        Console.WriteLine(data.IsEmpty());
        try
        {
            Console.WriteLine(data.Pop());
            Console.WriteLine(data.Peek());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}