using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Classes;

namespace CarShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[2];
            for (var i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car(string.Empty, string.Empty, 0);
            }

            Lorry[] lorries = new Lorry[2];
            for (var i = 0; i < lorries.Length; i++)
            {
                lorries[i] = new Lorry(string.Empty, string.Empty, 0,
                    0, 0, string.Empty);
            }

            Minivan[] minivans = new Minivan[2];
            for (var i = 0; i < minivans.Length; i++)
            {
                minivans[i] = new Minivan(string.Empty, string.Empty, 0, 0);
            }

            cars[0].Model = "Pegeout 107";
            cars[0].Color = "Blue";
            cars[0].Price = 12400.5;
            cars[0].Discount = 10;
            cars[0].Discount = cars[0].ShowDiscount(cars[0].Discount);

            lorries[0].Model = "MAN 2000 TDX";
            lorries[0].Color = "Green";
            lorries[0].Price = 75000;
            lorries[0].Discount = 0;
            lorries[0].Milleage = 150000;
            lorries[0].Insurance = "Gree Card";
            lorries[0].Discount = lorries[0].ShowDiscount(lorries[0].Discount);

            minivans[0].Model = "Volkswagen Multivan T7";
            minivans[0].Color = "Black";
            minivans[0].Price = 100000;
            minivans[0].Seats = 9;
            minivans[0].Discount = 10;
            minivans[0].Discount = minivans[0].ShowDiscount(minivans[0].Discount);

            Console.WriteLine("---CAR EXAMPLE---");
            Console.WriteLine($"Model:{cars[0].Model}");
            Console.WriteLine($"Color:{cars[0].Color}");
            Console.WriteLine($"Discount Price:{cars[0].Price}$\n");

            Console.WriteLine("---LORRY EXAMPLE---");
            Console.WriteLine($"Model:{lorries[0].Model}");
            Console.WriteLine($"Color:{lorries[0].Color}");
            Console.WriteLine($"Milleage:{lorries[0].Milleage}");
            Console.WriteLine($"Insurance:{lorries[0].Insurance}");
            Console.WriteLine($"Discount Price:{lorries[0].Price}$");

            Console.WriteLine("---MINIVAN EXAMPLE---");
            Console.WriteLine($"Model:{minivans[0].Model}");
            Console.WriteLine($"Color:{minivans[0].Color}");
            Console.WriteLine($"Seats:{minivans[0].Seats}");
            Console.WriteLine($"Discount Price:{minivans[0].Price}$\n");
        }
    }
}
