namespace E02_VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;
        private const double fuelEfficiency = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + fuelConsumptionIncrease, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * fuelEfficiency);
        }
    }
}