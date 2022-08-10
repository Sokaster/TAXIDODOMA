using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal class Cash : IPaymentMethod
    {

        private double _cashAmountOfMoney;

        public Cash(double amountOfMoney)
        {
            amountOfMoney = CashAmountOfMoney;
        }
       
     
        public double CashAmountOfMoney
        {
            get 
            {
                return _cashAmountOfMoney; 
            }
            set 
            {
                if (value < 0)
                {
                    _cashAmountOfMoney = 0;
                }
                else
                {
                    _cashAmountOfMoney = value;
                }
            }
        }



        public void AddMoney (double amountOfMoney)
        {
            CashAmountOfMoney = CashAmountOfMoney +amountOfMoney;
            Console.WriteLine($"Пополнение прошло успешно!Вам начислено {amountOfMoney} р., сейчас у вас {CashAmountOfMoney}");
        }
        //amount of money need for pay

        public bool IsPaymentPossible(double amountOfMoney)
        {
            if (CashAmountOfMoney >= amountOfMoney)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MakePayment(double amountOfMoney)
        {
            if (IsPaymentPossible(amountOfMoney))
            {
                CashAmountOfMoney -= amountOfMoney;
                Console.WriteLine($"Платеж сделан. Ваш остаток: {CashAmountOfMoney}");
            }
            else
            {
                Console.WriteLine($"У вас недостаточно средств. Ваш баланс : {CashAmountOfMoney}");
            }
        }
        //отняли деньги 
        public void BalanceCheck()
        {
            Console.Write($"Баланс (наличные): {CashAmountOfMoney}");
        }

        public override string ToString()
        {
            return "Cash";
        }


    }
}
