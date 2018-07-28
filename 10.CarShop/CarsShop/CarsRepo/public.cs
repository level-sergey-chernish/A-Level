using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CarsShop
{
    public partial class CarsRepo
    {
        public double Price
        {
            get => _price;
            set
            {
                bool result = double.TryParse(Convert.ToString(value), out value);
                if (result)
                {
                    _price = value;
                }
                else
                {
                    Console.WriteLine("Wrong data!\nThe price must be in numeric format\n" +
                        "Please, press any key to repeat input");
                    _price = -1;
                }
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                bool result = StringValidation(value, false);
                if (result)
                {
                    _color = value;
                }
                else
                {
                    Console.WriteLine("Wrong data!\nThe color must contains " +
                        "only letters and spaces and contains 3 - 10 symbols\n" +
                        "Please, press any key to repeat input");
                    _color = null;
                }
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                bool result = StringValidation(value, true);
                if (result)
                {
                    _model = value;
                }
                else
                {
                    Console.WriteLine("Wrong data!\nThe model must contains " +
                        "only letters, numbers, signs -._ and contains 2 - 15 symbols\n" +
                        "Please, press any key to repeat input");
                    _model = null;
                }
            }
        }

        public double ShowDiscount(string str)
        {
            double value;
            string percent = str;
            bool result = double.TryParse(percent, out value);
            if (result)
            {
                value = Discount(Convert.ToDouble(value));
            }
            else
            {
                Console.WriteLine("Wrong data!\nThe discount percent must be in numeric format\n" +
                    "Please, press any key to repeat input");
                value = -1;
            }
            return value;
        }

    }
}
