using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("Invalid operation: List is empty!");
        }

        var lastIndex = data.Count - 1;
        var lastElem = this.data[lastIndex];
        this.data.RemoveAt(lastIndex);
        return lastElem;
    }

    public string Peek()
    {
        if (this.IsEmpty())
        {
            throw new InvalidOperationException("Invalid operation: List is empty!");
        }

        return this.data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}