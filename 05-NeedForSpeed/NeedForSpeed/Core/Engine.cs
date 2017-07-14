using System;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "Cops Are Here") break;

            var commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ExecuteCommand(commandArgs);
        }
    }

    public void ExecuteCommand(string[] commandArgs)
    {
        var command = commandArgs[0];
        int id;
        string type;

        switch (command)
        {
            case "register":
                id = int.Parse(commandArgs[1]);
                type = commandArgs[2];
                string brand = commandArgs[3];
                string model = commandArgs[4];
                int yearOfProduction = int.Parse(commandArgs[5]);
                int horsepower = int.Parse(commandArgs[6]);
                int acceleration = int.Parse(commandArgs[7]);
                int suspension = int.Parse(commandArgs[8]);
                int durability = int.Parse(commandArgs[9]);
                manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                id = int.Parse(commandArgs[1]);
                Console.WriteLine(manager.Check(id));
                break;
            case "open":
                id = int.Parse(commandArgs[1]);
                type = commandArgs[2];
                int length = int.Parse(commandArgs[3]);
                string route = commandArgs[4];
                int prizePool = int.Parse(commandArgs[5]);

                if (commandArgs.Length > 6)
                {
                    int specialParam = int.Parse(commandArgs[6]);
                    manager.Open(id, type, length, route, prizePool, specialParam);
                }
                else
                {
                    manager.Open(id, type, length, route, prizePool);
                }

                break;
            case "participate":
                var carId = int.Parse(commandArgs[1]);
                var raceId = int.Parse(commandArgs[2]);
                manager.Participate(carId, raceId);
                break;
            case "start":
                raceId = int.Parse(commandArgs[1]);
                Console.WriteLine(manager.Start(raceId));
                break;
            case "park":
                carId = int.Parse(commandArgs[1]);
                manager.Park(carId);
                break;
            case "unpark":
                carId = int.Parse(commandArgs[1]);
                manager.Unpark(carId);
                break;
            case "tune":
                int tuneIndex = int.Parse(commandArgs[1]);
                string addOn = commandArgs[2];
                manager.Tune(tuneIndex, addOn);
                break;
            default: break;
        }
    }
}