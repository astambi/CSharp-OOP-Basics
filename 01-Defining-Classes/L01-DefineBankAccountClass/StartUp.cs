using System;

public class StartUp
{
    public static void Main()
    {
        var acc = new BankAccount();
        acc.ID = 1;
        acc.Balance = 15;

        Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
    }
}