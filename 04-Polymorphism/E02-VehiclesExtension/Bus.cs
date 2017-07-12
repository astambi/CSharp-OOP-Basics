using System;

namespace E02_VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncreaseByAC = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelQuantity
        {
            get { return base.FuelQuantity; }
            protected set
            {
                if (base.FuelQuantity > base.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                base.FuelQuantity = value;
            }
        }

        public override void Fuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (base.FuelQuantity + liters > base.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }
            base.FuelQuantity += liters;
        }

        public void DriveWithAC(double distance)
        {
            if (base.FuelQuantity < distance * (base.FuelConsumption + fuelConsumptionIncreaseByAC))
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                base.FuelQuantity -= distance * (base.FuelConsumption + fuelConsumptionIncreaseByAC);
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

    }
}
