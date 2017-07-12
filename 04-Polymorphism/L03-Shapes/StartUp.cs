using System;

public class StartUp
{
    public static void Main()
    {
        Shape rect = new Rectangle(3.0, 4.0);
        Shape circle = new Circle(4.0);

        Console.WriteLine(rect.CalculateArea());
        Console.WriteLine(circle.CalculateArea());

        Console.WriteLine(rect.CalculatePerimeter());
        Console.WriteLine(circle.CalculatePerimeter());

        Console.WriteLine(rect.Draw());
        Console.WriteLine(circle.Draw());
    }
}