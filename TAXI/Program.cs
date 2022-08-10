using System;
using System.Collections.Generic;

namespace TAXI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Дмитрий", "Даненков", "4450236011227799");
            List<Vehicle> TaxiVehicles = new List<Vehicle>
            {
                new Car ("Peugeot Alcantara", 12,"5777 HA-7", 8d),
                new Car ("Honda Accord", 6,"5222 HA-2", 5d),
                new Car ("Volkswagen Passat B5", 5,"5222 HA-7", 6d),
               new Motorbike ("AIST ULTRAMOTOR", 3,"5421 HA-5", 2d),
                new Motorbike ("BMW R700", 4,"666", 4d),
                 new Motorbike ("Honda RX2", 4,"777", 4d),
                new Helicopter ("STREKOZA", 130, "STRELA-01", 20d),
                 new Helicopter ("KA-52 AKULA", 145, "WARRIOR-7", 25d),
                 new Helicopter ("TURBOCOPTER", 200, "LuxuryBort", 80d),

            };


            string menu = string.Empty;


            while (true)
            {
                string identifyCardName, cardName, paymentMethod = string.Empty;
                double moneyAmmount = 0;
                bool parseStatus = false, paymentStatus = false;
                int vehicleType = 0;

                Console.Clear();
                Console.WriteLine("Добро пожаловать в Такси-Сервис : До Дома." +Environment.NewLine+
                    "Выберите действие из предложенных:"+Environment.NewLine+
                    "1 - Добавить карту"+Environment.NewLine+
                    "2 - Пополнить карту" + Environment.NewLine +
                    "3 - Пополнить наличку" + Environment.NewLine +
                    "4 - Показать все методы оплаты "+ Environment.NewLine +
                    "5 - Совершить поездку"+ Environment.NewLine +
                    "6 - Закрыть программу");

                menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":

                        Console.WriteLine("Введите ваш номер карты");
                        identifyCardName = Console.ReadLine();
                        Console.WriteLine("Введите систему, по которой действует карта (напр. Виза Голд)");
                        cardName = Console.ReadLine();
                        while (!parseStatus)
                        {
                            Console.WriteLine("Введите ваше количество денег");
                            parseStatus = double.TryParse(Console.ReadLine(), out moneyAmmount);
                        }

                        user.AddCard(identifyCardName, new Card(cardName, moneyAmmount));
                        Console.WriteLine("Ваша карта идентифицирована. Enter, чтобы продолжить");
                        Console.ReadKey();
                        break;



                    case "2":
                        Console.WriteLine("Введите ваш номер карты");
                        identifyCardName = Console.ReadLine();
                        while (!parseStatus || moneyAmmount < 0)
                        {
                            Console.WriteLine("Введите ваше количество денег");
                            parseStatus = double.TryParse(Console.ReadLine(), out moneyAmmount);
                        }
                        user.TopUpCard(moneyAmmount, identifyCardName);
                        Console.WriteLine("Ваша карта Пополнена. Введите Enter, чтобы продолжить");
                        Console.ReadKey();
                        break;



                    case "3":
                        while (!parseStatus || moneyAmmount < 0)
                        {
                            Console.WriteLine("Введите количество наличных денег");
                            parseStatus = double.TryParse(Console.ReadLine(), out moneyAmmount);
                        }
                        user.TopUpCash(moneyAmmount);
                        Console.WriteLine("Наличка для поездки в нашем приложении пополнена. Для продолжения нажмите Enter");
                        Console.ReadKey();
                        break;



                    case "4":
                        user.ShowAvailablePaymentMethods();
                        Console.WriteLine("Выше выданы все методы оплаты. Чтобы продолжить нажмите Enter");
                        Console.ReadKey();
                        break;



                    case "5":
                        while (!parseStatus || vehicleType < 0 || vehicleType > 6)
                        {
                            Console.WriteLine("Выберите ваше средство передвижения для поездки");
                            for (int i = 0; i < TaxiVehicles.Count; i++)
                            {
                                Console.WriteLine($"{i} - {TaxiVehicles[i].ToString()}");
                            }
                            parseStatus = int.TryParse(Console.ReadLine(), out vehicleType);
                        }
                        
                        while (!paymentStatus)
                        {
                            Console.WriteLine("Выберите вариант платежа (Enter \"Cash\" - наличка, \"Points\" - очки или Номер вашей карты для оплаты картой)");
                            user.ShowAvailablePaymentMethods();
                            paymentMethod = Console.ReadLine();
                            paymentStatus = user.isPaymentExist(paymentMethod);
                        }
                        Console.WriteLine();
                        paymentStatus = user.Payment(paymentMethod, TaxiVehicles[vehicleType].GetPriceOfRide());

                        if (paymentStatus)
                        {
                            TaxiVehicles[vehicleType].MakeRide(user);
                            user.AddPoints(5);
                        }
                        Console.WriteLine("Введите Enter");
                        Console.ReadKey();
                        break;




                    case "6":
                        Console.WriteLine("Ждём вас снова в Сервисе: ТАКСИ ДО ДОМА =)");
                        return;




                    default:
                        break;
                }
            }
        }
    }
}
