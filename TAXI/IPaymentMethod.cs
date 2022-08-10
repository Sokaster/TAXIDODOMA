using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal interface IPaymentMethod
    {
        public bool IsPaymentPossible(double amountOfMoney);
        public void MakePayment(double amountOfMoney);
        public void AddMoney(double amountOfMoney);
        public void BalanceCheck();
    }
}
