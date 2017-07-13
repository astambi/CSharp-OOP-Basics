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

        protected override double FuelQuantity
        {
            //get { return base.FuelQuantity; }
            set
            {
                if (value > base.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                base.FuelQuantity = value;
            }
        }

        public override void Drive(double distance, bool hasAC)
        {
            double totalFuelConsumption = base.FuelConsumption;
            if (hasAC)
            {
                totalFuelConsumption += fuelConsumptionIncreaseByAC;
            }

            if (base.FuelQuantity < distance * totalFuelConsumption)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                base.FuelQuantity -= distance * totalFuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }
    }
}