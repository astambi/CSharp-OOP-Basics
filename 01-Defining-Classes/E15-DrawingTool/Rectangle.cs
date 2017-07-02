using System;
using System.Text;

public class Rectangle : CorDraw
{
    private int sizeA;
    private int sizeB;

    public Rectangle(int sizeA, int sizeB)
    {
        this.sizeA = sizeA;
        this.sizeB = sizeB;
    }

    public override void Draw()
    {
        var builder = new StringBuilder();
        builder.Append("|").Append(new string('-', sizeA)).AppendLine("|");
        for (int i = 0; i < this.sizeB - 2; i++)
        {
            builder.Append("|").Append(new string(' ', sizeA)).AppendLine("|");
        }
        if (sizeB > 1)
        {
            builder.Append("|").Append(new string('-', sizeA)).AppendLine("|");
        }
        Console.Write(builder.ToString());
    }
}
