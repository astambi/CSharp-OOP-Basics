using System;
using System.Collections.Generic;
using System.Linq;

namespace E06_FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END") break;

                var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length < 2) continue;

                try
                {
                    var command = tokens[0];
                    var teamName = tokens[1];

                    if (command == "Team")
                    {
                        teams.Add(new Team(teamName));
                        continue;
                    }

                    var team = teams.FirstOrDefault(t => t.Name == teamName);
                    if (team == null)
                    {
                        Console.WriteLine("Team {0} does not exist.", teamName);
                        continue;
                    }

                    switch (command)
                    {
                        case "Add":
                            team.AddPlayer(new Player(tokens[2],
                                                      tokens.Skip(3).Select(int.Parse).ToArray()));
                            break;
                        case "Remove":
                            team.RemovePlayerByName(tokens[2]);
                            break;
                        case "Rating":
                            Console.WriteLine("{0} - {1}", team.Name, team.GetRating());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
