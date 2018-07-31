using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Interfaces;

namespace CarShop.Classes
{
    public class Car : IDiscount
    {
        public double Discount { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public Car(string model, string color, double price)
        {
            Model = model;
            Color = color;
            Price = price;
        }

        protected virtual void SetDiscount(double discount = 0)
        {
            Price -= (discount / 100) * Price;
        }

        public double ShowDiscount(double num)
        {
            SetDiscount(num);
            return Price;
        }

    }
}
