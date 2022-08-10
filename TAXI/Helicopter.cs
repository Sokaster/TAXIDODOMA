using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Helicopter : Vehicle, ITaxi
    {

        private double _taxiTarif;
        public Helicopter(string modelOfHelicopter, double fuelConsumption, string governmentNumber, double tarif) : base(fuelConsumption, governmentNumber)
        {
            ModelOfHelicopter= modelOfHelicopter;
            Tarif = tarif;
        }
        public string ModelOfHelicopter { get; set; }



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
            return $"Вертолет \"{ModelOfHelicopter}\", гос. номер :{GovernmentNumber}, Расход топлива: {FuelConsumption}, Цена(Тариф): {Tarif}";
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
