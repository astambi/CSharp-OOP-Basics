using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var cars = GetCars();
        cars = DriveCars(cars);
        PrintCars(cars);
    }

    private static void PrintCars(Dictionary<string, Car> cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine(car.Value.ToString());
        }
    }

    private static Dictionary<string, Car> DriveCars(Dictionary<string, Car> cars)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carModel = args[1];
            var amountKm = int.Parse(args[2]);
            if (cars.ContainsKey(carModel))
            {
                cars[carModel].Drive(amountKm);
            }
        }
        return cars;
    }

    private static Dictionary<string, Car> GetCars()
    {
        var cars = new Dictionary<string, Car>();
        var numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine()
                         .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(
                        carInfo[0],
                        double.Parse(carInfo[1]),
                        double.Parse(carInfo[2]));
            if (!cars.ContainsKey(car.Model))
            {
                cars[car.Model] = car;
            }
        }
        return cars;
    }
}
