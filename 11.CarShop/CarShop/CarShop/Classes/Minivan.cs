using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Classes
{
    class Minivan : Car
    {
        public int Seats { get; set; }
        public Minivan(string model, string color, double price,
            int seats) : base(model, color, price)
        {
            Seats = seats;
        }

        protected override void SetDiscount(double discount = 0)
        {
            double month;
            DateTime localDate = DateTime.Now;
            month = Convert.ToDouble(localDate.Month);
            if (month == 1)
            {
                discount += 2;
            }
            if (month == 12)
            {
                discount += 24;
            }
            base.SetDiscount(discount);
            Price -= (discount / 100) * Price;
        }
    }
}
