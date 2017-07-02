using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var cars = GetCars();
        PrintFilteredCars(cars);
    }

    private static void PrintFilteredCars(List<Car> cars)
    {
        var cargoTypeFilter = Console.ReadLine();
        switch (cargoTypeFilter)
        {
            case "fragile":
                cars
                  .Where(c => c.IsFragile())
                  .ToList()
                  .ForEach(c => Console.WriteLine(c.Model)); break;
            case "flamable":
                cars
                    .Where(c => c.IsFlamable())
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model)); break;
            default: break;
        }
    }

    private static List<Car> GetCars()
    {
        var cars = new List<Car>();

        var numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = carInfo[0];

            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new List<Tire>();
            for (int tireCount = 0; tireCount < 4; tireCount++)
            {
                var tirePressure = double.Parse(carInfo[5 + tireCount]);
                var tireAge = int.Parse(carInfo[6 + tireCount * 2]);
                var tire = new Tire(tirePressure, tireAge * 2);
                tires.Add(tire);
            }

            var car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }

        return cars;
    }
}
