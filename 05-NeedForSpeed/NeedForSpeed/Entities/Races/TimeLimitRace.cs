using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int wonPrize;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    private int GoldTime { get; }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        var performance = this.Length * ((car.Horsepower / 100) * car.Acceleration);

        return performance;
    }

    private string GetEarnedTime(int performance)
    {
        var winnersPercentages = new Dictionary<string, int>();
        winnersPercentages["Gold"] = 100;
        winnersPercentages["Silver"] = 50;
        winnersPercentages["Bronze"] = 30;

        string earnedTime;
        if (performance <= this.GoldTime)           earnedTime = "Gold";
        else if (performance <= this.GoldTime + 15) earnedTime = "Silver";
        else                                        earnedTime = "Bronze";

        this.wonPrize = (this.PrizePool * winnersPercentages[earnedTime]) / 100;

        return earnedTime;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        // add all participants to the race but consider only the first one
        if (this.Participants.Count > 0)
        {
            var participant = this.Participants.FirstOrDefault();
            var performance = GetPerformance(participant.Key);
            var earnedTime = GetEarnedTime(performance);
            var participantCar = participant.Value;

            builder
                .AppendLine($"{this.Route} - {this.Length}")
                .AppendLine($"{participantCar.Brand} {participantCar.Model} - {performance} s.")
                .AppendLine($"{earnedTime} Time, ${this.wonPrize}.");
        }

        return builder.ToString().Trim();
    }
}