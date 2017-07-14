using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    protected int Length { get; /*set;*/ }
    protected string Route { get; /*set;*/ }
    protected int PrizePool { get; /*set;*/ }

    public Dictionary<int, Car> Participants { get; set; }

    public abstract int GetPerformance(int id);

    public virtual Dictionary<int, Car> GetWinners()
    {
        var winners = this.Participants
                          .OrderByDescending(p => this.GetPerformance(p.Key))
                          .Take(3)
                          .ToDictionary(p => p.Key, p => p.Value);
        return winners;
    }

    public List<int> GetPrizes()
    {
        var prizePoolShares = new int[] { 50, 30, 20 };
        var winnersCount = GetWinners().Count;

        var prizes = new List<int>();
        for (int i = 0; i < winnersCount; i++)
        {
            prizes.Add((this.PrizePool * prizePoolShares[i]) / 100);
        }
        return prizes;
    }

    public override string ToString()
    {
        var winners = GetWinners();
        var prizes = GetPrizes();

        var builder = new StringBuilder();
        builder.AppendLine($"{this.Route} - {this.Length}");

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);
            builder.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {this.GetPerformance(car.Key)}PP - ${prizes[i]}");
        }
        return builder.ToString().Trim();
    }
}