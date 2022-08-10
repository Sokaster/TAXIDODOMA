using System;
using System.Collections.Generic;
using System.Text;

namespace TAXI
{
    internal interface ITaxi
    {
        public void MakeRide(User user);
        public double GetPriceOfRide();
    }
}
