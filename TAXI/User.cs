using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TAXI
{
    internal class User
    {
        private Dictionary<string, IPaymentMethod> paymentMethods = new Dictionary<string, IPaymentMethod>();

        public User(string name, string surname, string phoneNumber)
        {
            Name = name;
            Surname = surname;  
            PhoneNumber = phoneNumber;
            paymentMethods.Add("Cash", new Cash(0));
            paymentMethods.Add("Points", new Points(0));
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public void ShowAvailablePaymentMethods()
        {
            foreach (var payment in paymentMethods)
            {
                payment.Value.BalanceCheck();
                if (payment.Key == "Cash" || payment.Key == "Points")
                {
                    Console.WriteLine($" on {payment.Key}");
                }
                else
                {
                    Console.WriteLine($" on \"{payment.Key}\" card ({payment.Value} system)");
                }
            }
        }

        


        public bool isPaymentExist(string paymentType)
        {
            if (paymentMethods.ContainsKey(paymentType))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool Payment(string paymentMethod, double amountOfMoney)
        {
            if (paymentMethods.ContainsKey(paymentMethod) && paymentMethods[paymentMethod].IsPaymentPossible(amountOfMoney))
            {
                paymentMethods[paymentMethod].MakePayment(amountOfMoney);
                return true;
            }
            else
            {
                Console.WriteLine("Payment failed! Check if you have enough money and if you have chosen the correct payment method");
                return false;
            }

        }


        public void AddPoints(int points)
        {
            paymentMethods["Points"].AddMoney(points);
        }



        public void TopUpCash(double amountOfMoney)
        {
            paymentMethods["Cash"].AddMoney(amountOfMoney);
        }

        public void TopUpCard(double amountOfMoney, string cardName)
        {
            if (paymentMethods.ContainsKey(cardName) && cardName != "Cash" && cardName != "Points")
            {
                paymentMethods[cardName].AddMoney(amountOfMoney);
            }
            else
            {
                Console.WriteLine("This card is not existing");
            }
        }

        public void AddCard(string cardName, Card card)
        {
            if (!paymentMethods.ContainsKey(cardName))
            {
                paymentMethods[cardName] = card;
                Console.WriteLine($"Success! Added new card \"{cardName}\"");
            }
            else
            {
                Console.WriteLine("This payment type is already exist");
            }
        }

    }
}
