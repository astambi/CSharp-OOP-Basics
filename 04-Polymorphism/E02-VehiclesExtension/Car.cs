using System;

namespace E02_VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
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
    }
}
