using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Car : Vehicle, ITaxi
    {
        private double _taxiTarif;
        public Car(string modelOfCar, double fuelConsumption, string governmentNumber, double tarif) : base(fuelConsumption, governmentNumber)
        {
            ModelOfCar = modelOfCar;
            Tarif = tarif;
        }
        public string ModelOfCar { get; set; }

        public double Tarif
        {
            get
            {
                return _taxiTarif;
            }
            set
            {
                if (value <= 0)
                {
                    _taxiTarif = 1;
                }
                else
                {
                    _taxiTarif = value;
                }
            }
        }
        public override string ToString()
        {
            return $"Автомобиль {ModelOfCar}, Гос. номер: {GovernmentNumber}, Расход топлива: {FuelConsumption}, Цена(тариф): {Tarif}";
        }

        public override double GetPriceOfRide()
        {
            return Tarif;
        }

        public override void MakeRide(User user)
        {
            Console.WriteLine($"{user.Name} {user.Surname} Совершил поездку на {ToString()}");
        }
    }
}
