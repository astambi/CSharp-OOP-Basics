using System;

namespace E01_Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var tokens = Console.ReadLine()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0].ToLower();
                var vehicle = tokens[1].ToLower();
                var distanceOrLiters = double.Parse(tokens[2]);

                //switch (command)
                //{
                //    case "drive":
                //        if (vehicle == "car")           car.Drive(distanceOrLiters);
                //        else if (vehicle == "truck")    truck.Drive(distanceOrLiters);
                //        break;
                //    case "refuel":
                //        if (vehicle == "car")           car.Fuel(distanceOrLiters);
                //        else if (vehicle == "truck")    truck.Fuel(distanceOrLiters);
                //        break;
                //    default: break;
                //};

                switch (vehicle)
                {
                    case "car":     ExecuteAction(car, command, distanceOrLiters); break;
                    case "truck":   ExecuteAction(truck, command, distanceOrLiters); break;
                    default: break;
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double distanceOrLiters)
        {
            switch (command)
            {
                case "drive":   vehicle.Drive(distanceOrLiters); break;
                case "refuel":  vehicle.Refuel(distanceOrLiters); break;
                default: break;
            }
        }
    }
}
