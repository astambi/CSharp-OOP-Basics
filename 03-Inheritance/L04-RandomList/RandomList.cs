using System;
using System.Collections;

class RandomList : ArrayList
{
    private Random random;

    public RandomList()
    {
        this.random = new Random();
    }

    public string RandomString()
    {
        if (this.Count == 0) return string.Empty;

        var index = random.Next(0, this.Count);
        var element = this[index];
        this.RemoveAt(index);
        return element.ToString();
    }
}
