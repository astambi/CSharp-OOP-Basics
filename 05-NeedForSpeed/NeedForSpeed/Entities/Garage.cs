using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new List<int>();
    }

    public List<int> ParkedCars { get; /*private set;*/ }

    public void AddCar(int carId)
    {
        this.ParkedCars.Add(carId);
    }

    public void RemoveCar(int carId)
    {
        this.ParkedCars.Remove(carId);
    }
}