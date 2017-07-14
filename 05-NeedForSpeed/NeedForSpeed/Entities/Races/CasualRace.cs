public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override int GetPerformance(int id)
    {
        var car = this.Participants[id];
        var performance = (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);

        return performance;
    }
}