using System;
using System.Text;

public class Square : CorDraw
{
    private int size;

    public Square(int size)
    {
        this.size = size;
    }

    public override void Draw()
    {
        var builder = new StringBuilder();
        builder.Append("|").Append(new string('-', size)).AppendLine("|");
        for (int i = 0; i < this.size - 2; i++)
        {
            builder.Append("|").Append(new string(' ', size)).AppendLine("|");
        }
        if (size > 1)
        {
            builder.Append("|").Append(new string('-', size)).AppendLine("|");
        }
        Console.Write(builder.ToString());
    }
}
