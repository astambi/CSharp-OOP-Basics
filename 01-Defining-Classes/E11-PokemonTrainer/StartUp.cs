using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var trainers = GetTrainers();
        trainers = UpdateTrainers(trainers);
        PrintTrainers(trainers);
    }

    private static void PrintTrainers(List<Trainer> trainers)
    {
        trainers
            .OrderByDescending(t => t.NumberOfBadges)
            .ToList()
            .ForEach(t => Console.WriteLine(t.ToString()));
    }

    private static List<Trainer> UpdateTrainers(List<Trainer> trainers)
    {
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "End") break;

            // Update number of badges of matching trainers
            trainers
                .Where(t => t.Pokemons.Any(p => p.Element == command))
                .ToList()
                .ForEach(t => t.NumberOfBadges++);

            // Update pokemons of nonmatching trainers
            var nonmatchingTrainers = trainers
                                    .Where(t => t.Pokemons.All(p => p.Element != command));
            foreach (var trainer in nonmatchingTrainers)
            {
                trainer.Pokemons.ForEach(p => p.Health -= 10);
                trainer.Pokemons = trainer.Pokemons
                                   .Where(p => p.Health > 0)
                                   .ToList();
            }
        }
        return trainers;
    }

    private static List<Trainer> GetTrainers()
    {
        var trainers = new List<Trainer>();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "Tournament") break;

            // <TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trainerName = tokens[0];
            var pokemonName = tokens[1];
            var pokemonElement = tokens[2];
            var pokemonHealth = int.Parse(tokens[3]);

            var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }
            trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }
        return trainers;
    }
}
