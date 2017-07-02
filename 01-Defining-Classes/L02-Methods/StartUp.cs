using System;

public class StartUp
{
    public static void Main()
    {
        var acc = new BankAccount();
        acc.ID = 1;
        acc.Deposit(15);
        acc.Withdraw(5);

        Console.WriteLine(acc.ToString());
    }
}