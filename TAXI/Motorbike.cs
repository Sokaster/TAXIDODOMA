using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Motorbike : Vehicle, ITaxi
    {
        private double _taxiTarif;
        public Motorbike(string modelOfMotorbike, double fuelConsumption, string governmentNumber, double tarif) : base(fuelConsumption, governmentNumber)
        {
            ModelOfMotorbike = modelOfMotorbike;   
            GovernmentNumber = governmentNumber;
            Tarif = tarif;
        }
        public string ModelOfMotorbike { get; set; }



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
            return $"Мотоцикл: {ModelOfMotorbike}, Гос номер: {GovernmentNumber}, Расход топлива: {FuelConsumption}, Цена(Тариф) :{Tarif}";
        }

        public override double GetPriceOfRide()
        {
            return Tarif;
        }

        public override void MakeRide(User user)
        {
            Console.WriteLine($"{user.Name} {user.Surname} совершил поездку на {ToString()}");
        }
    }
}
