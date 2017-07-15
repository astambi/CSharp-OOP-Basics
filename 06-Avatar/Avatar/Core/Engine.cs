using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.isRunning = true;
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var inputCommand = this.ReadInput();
            var commandArgs = this.ParseInput(inputCommand);
            this.DistributeCommand(commandArgs);
        }
    }

    private void DistributeCommand(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.Skip(1).ToList();

        switch (command)
        {
            case "Bender":
                this.nationsBuilder.AssignBender(commandArgs);
                break;
            case "Monument":
                this.nationsBuilder.AssignMonument(commandArgs);
                break;
            case "Status":
                var status = this.nationsBuilder.GetStatus(commandArgs[0]);
                this.OutputWriter(status);
                break;
            case "War":
                this.nationsBuilder.IssueWar(commandArgs[0]);
                break;
            case "Quit":
                var warsRecord = this.nationsBuilder.GetWarsRecord();
                this.OutputWriter(warsRecord);
                this.isRunning = false;
                break;
            default: break;
        }
    }

    private void OutputWriter(string status)
    {
        Console.WriteLine(status);
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }
}
