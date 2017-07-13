using System;

namespace E02_VehiclesExtension
{
    public class StartUp
    {
        public static void Main()
        {
            var carInfo =   Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var busInfo =   Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numberOfCommands = int.Parse(Console.ReadLine());

            var car =   new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus =   new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            for (int i = 0; i < numberOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0].ToLower();
                var vehicle = tokens[1].ToLower();
                var distanceOrLiters = double.Parse(tokens[2]);

                try
                {                   
                    switch (vehicle)
                    {
                        case "car":     ExecuteAction(car, command, distanceOrLiters); break;
                        case "truck":   ExecuteAction(truck, command, distanceOrLiters); break;
                        case "bus":     ExecuteAction(bus, command, distanceOrLiters); break;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double distanceOrLiters)
        {
            switch (command)
            {
                case "drive":       vehicle.Drive(distanceOrLiters); break;
                case "refuel":      vehicle.Refuel(distanceOrLiters); break;
                case "driveempty":  vehicle.Drive(distanceOrLiters, false); break; // AC off
                default: break;
            }
        }
    }
}
