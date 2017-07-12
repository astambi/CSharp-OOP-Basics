namespace E01_Vehicles
{
    public class Truck : Vehicle
    {
        private double fuelEfficiency = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + 1.6)
        {
        }

        public override void Fuel(double liters)
        {
            base.Fuel(liters * fuelEfficiency);
        }
    }
}
