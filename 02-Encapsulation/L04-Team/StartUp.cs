using System;

public class Program
{
    public static void Main()
    {
        var team = new Team("Team");

        var lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var player = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    double.Parse(cmdArgs[3]));
            team.AddPlayer(player);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");
    }
}