using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    private int Laps { get; }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        var performance = (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);

        return performance;
    }

    private int GetPrize(int wonPlace)
    {
        var prizePercentages = new int[] { 40, 30, 20, 10 };
        return (this.PrizePool * prizePercentages[wonPlace]) / 100;
    }

    public override Dictionary<int, Car> GetWinners()
    {
        return this.Participants
                   .OrderByDescending(p => this.GetPerformance(p.Key))
                   .Take(4)
                   .ToDictionary(p => p.Key, p => p.Value);
    }

    private void UpdateParticipantsDurability()
    {
        this.Participants
            .ToList()
            .ForEach(p => p.Value.Durability -= this.Laps * Length * Length);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        if (this.Participants.Count > 0)
        {
            UpdateParticipantsDurability();
            var winners = GetWinners();

            for (int i = 0; i < winners.Count; i++)
            {
                var participant = winners.ElementAt(i);
                var participantCarId = participant.Key;
                var participantCar = participant.Value;
                var performance = GetPerformance(participantCarId);

                builder
                    .AppendLine($"{i + 1}. {participantCar.Brand} {participantCar.Model} {performance}PP - ${GetPrize(i)}");
            }
        }

        return builder.ToString().Trim();
    }
}
