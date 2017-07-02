using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var engines = GetEngines();
        var cars = GetCars(engines);
        PrintCars(cars);
    }

    private static void PrintCars(List<Car> cars)
    {
        cars.ForEach(c => Console.Write(c.ToString()));
    }

    private static List<Car> GetCars(List<Engine> engines)
    {
        var cars = new List<Car>();
        var numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(carInfo[0], engines.FirstOrDefault(e => e.Model == carInfo[1]));
            if (carInfo.Length > 3)
            {
                car.Weight = carInfo[2];
                car.Color = carInfo[3];
            }
            else if (carInfo.Length > 2)
            {
                var colorOrWeight = carInfo[2];
                double result;
                bool isNumber = double.TryParse(colorOrWeight, out result);
                if (isNumber) // NB!
                {
                    car.Weight = colorOrWeight;
                }
                else
                {
                    car.Color = colorOrWeight;
                }
            }
            cars.Add(car);
        }
        return cars;
    }

    private static List<Engine> GetEngines()
    {
        var engines = new List<Engine>();
        var numberOfEngines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfEngines; i++)
        {
            var engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = new Engine(engineInfo[0], double.Parse(engineInfo[1]));
            if (engineInfo.Length > 3)
            {
                engine.Displacement = engineInfo[2];
                engine.Efficiency = engineInfo[3];
            }
            else if (engineInfo.Length > 2)
            {
                var displacementOrEfficiency = engineInfo[2];
                double result;
                bool isNumber = double.TryParse(displacementOrEfficiency, out result);
                if (isNumber)
                {
                    engine.Displacement = displacementOrEfficiency;
                }
                else
                {
                    engine.Efficiency = displacementOrEfficiency;
                }
            }
            engines.Add(engine);
        }
        return engines;
    }
}