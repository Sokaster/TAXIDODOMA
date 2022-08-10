using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal abstract class Vehicle
    {
        public Vehicle(double fuelConsumption, string governmentNumber)
        {
            FuelConsumption = fuelConsumption;
            GovernmentNumber = governmentNumber;
        }
        public double FuelConsumption { get; set; }
        public string GovernmentNumber { get; set; }
        public abstract double GetPriceOfRide();
        public abstract void MakeRide(User user);

    }
}
