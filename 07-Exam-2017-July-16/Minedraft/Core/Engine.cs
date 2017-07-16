using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private DraftManager manager;

    public Engine()
    {
        this.isRunning = true;
        this.manager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var inputCommand = Console.ReadLine();
            var commandArgs = ParseInput(inputCommand);
            DistributeCommands(commandArgs);
        }
    }

    private void DistributeCommands(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.Skip(1).ToList();
        string output;

        switch (command)
        {
            case "RegisterHarvester":
                output = this.manager.RegisterHarvester(commandArgs);
                Console.WriteLine(output);
                break;
            case "RegisterProvider":
                output = this.manager.RegisterProvider(commandArgs);
                Console.WriteLine(output);
                break;
            case "Day":
                output = this.manager.Day();
                Console.WriteLine(output);
                break;
            case "Mode":
                output = this.manager.Mode(commandArgs);
                Console.WriteLine(output);
                break;
            case "Check":
                output = this.manager.Check(commandArgs);
                Console.WriteLine(output);
                break;
            case "Shutdown":
                output = this.manager.ShutDown();
                Console.WriteLine(output);
                isRunning = false;
                break;
            default: break;
        }
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand
             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .ToList();
    }
}

