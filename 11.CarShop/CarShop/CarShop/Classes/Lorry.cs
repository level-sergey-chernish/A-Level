using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Classes
{
    class Lorry : Car
    {
        public double Carrying { get; set; }

        public double Milleage {get; set; }

        public string Insurance { get; set; }

        public Lorry(string model, string color, double price,
            double carrying, double milleage,
            string insurance) : base(model, color, price)
        {
            Carrying = carrying;
            Milleage = milleage;
            Insurance = insurance;
        }

        protected override void SetDiscount(double discount = 0)
        {
            base.SetDiscount();
            Price *= 0.7;
        }
    }
}
