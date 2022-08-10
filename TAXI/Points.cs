using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Points : IPaymentMethod
    {
        

        public Points(double amountOfPoints)
        {
           AmountOfPoints = amountOfPoints;
        }
        public double AmountOfPoints { get; private set; } = 0;
        
        public void AddPoints(double points)
        {
            AmountOfPoints += points;
           
            Console.WriteLine($"Вы заработали {points} баллов");
        }


        public void AddMoney(double money)
        {
            
            AmountOfPoints += money * 3;
            
            Console.WriteLine($"Вам добавлено {money * 3} очков");
        }

        public bool IsPaymentPossible(double money)
        {
            if (AmountOfPoints < money * 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void MakePayment(double money)
        {
            
                if (IsPaymentPossible(money))
                {
                    AmountOfPoints -= money * 3;
                    
                    Console.WriteLine($"Вы потратили {money * 3} балла(oв)");
                }
                else
                {
                    Console.WriteLine($"Неудачно. Недостаточно {money * 3} бонусных баллов.");
                }   
        }

        public void BalanceCheck()
        {
            Console.Write($"Баланс (очки): {AmountOfPoints}");
        }

        public override string ToString()
        {
            return "Points";
        }
    }
}
