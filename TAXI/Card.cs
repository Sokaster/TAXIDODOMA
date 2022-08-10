using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Card : IPaymentMethod
    {
        

        private double _amountOfCardMoney;


        public Card(string cardNumber, double amountOfMoney)
        {
            cardNumber = CardNumber;
            amountOfMoney = CardAmountOfMoney;
        }

        public string CardNumber { get; set; }

        
        public double CardAmountOfMoney
        {
            get { return _amountOfCardMoney; }
            set
            {
                if (value < 0)
                {
                    _amountOfCardMoney = 0;
                }
                else
                {
                    _amountOfCardMoney = value;
                }
            }
        }


        public void AddMoney(double amountOfMoney)
        {
           CardAmountOfMoney = CardAmountOfMoney + amountOfMoney;
            Console.WriteLine($"Успешно! Вам начислено {amountOfMoney} р. на вашу карту {CardNumber},ваш баланс: {CardAmountOfMoney}");
        }

        public bool IsPaymentPossible(double amountOfMoney)
        {
            if (CardAmountOfMoney >= amountOfMoney)
            {
                return true;
                Console.WriteLine("Средств на поездку достаточно. Платеж возможен.");
            }
            else
            {
                return false;
                Console.WriteLine("Недостаточно средств.");
            }
        }

        public void MakePayment(double amountOfMoney)
        {
            if (IsPaymentPossible(amountOfMoney))
            {
                CardAmountOfMoney = CardAmountOfMoney - amountOfMoney;
                Console.WriteLine($"Платеж совершен! Ваш остаток: {CardAmountOfMoney} ");
                {
                    Console.WriteLine($"Ошибка, недостаточно средств для поездки");
                }
            }
        }
            public void BalanceCheck()
            {
                Console.Write($"Баланс (карта): {CardAmountOfMoney}");
            }

            public override string ToString()
        {
            return $"card {CardNumber}";
        }
    }
}
