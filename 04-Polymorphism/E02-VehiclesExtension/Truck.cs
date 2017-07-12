namespace E02_VehiclesExtension
{
    public class Truck : Vehicle
    {
        private double fuelEfficiency = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Fuel(double liters)
        {
            base.Fuel(liters * fuelEfficiency);
        }
    }
}