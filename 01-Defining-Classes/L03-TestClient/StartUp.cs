using System;
using System.Collections.Generic;

public class StartUp
{
    public static Dictionary<int, BankAccount> accounts;

    public static void Main()
    {
        accounts = new Dictionary<int, BankAccount>();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = args[0];

            switch (command)
            {
                case "Create": Create(args, accounts); break;
                case "Deposit": Deposit(args, accounts); break;
                case "Withdraw": Withdraw(args, accounts); break;
                case "Print": Print(args, accounts); break;
                default: break;
            }
        }
    }

    private static void Print(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist"); return;
        }

        Console.WriteLine(accounts[id].ToString());
    }

    private static void Withdraw(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist"); return;
        }

        var amount = double.Parse(args[2]);
        accounts[id].Withdraw(amount);
    }

    private static void Deposit(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist"); return;
        }

        var amount = double.Parse(args[2]);
        accounts[id].Deposit(amount);
    }

    private static void Create(string[] args, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(args[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists"); return;
        }

        accounts[id] = new BankAccount { ID = id };
    }
}

