using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            CarsRepo[] cars = new CarsRepo[3];
            for (var i = 0; i < cars.Length; i++)
            {
                cars[i] = new CarsRepo();
            }
            InitScreen(ref cars);
        }

        private static void InitScreen(ref CarsRepo[] cars)
        {
            bool menuExit = false;
            string caseSwitch;
            Console.Clear();
            do
            {
                StringHeader("CHOISE ACTION:");
                StringNotify("1 - Add Car Info\n2 - Show Cars\nq - Quit");
                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        menuExit = true;
                        Console.Clear();
                        AddCarInfo(ref cars);
                        break;

                    case "2":
                        menuExit = true;
                        Console.Clear();
                        ShowCarsInfo(ref cars);
                        break;
                    case "q":
                        menuExit = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (!menuExit);
        }

        private static void AddCarInfo(ref CarsRepo[] cars)
        {
            int i;
            string str = null;
            StringHeader("Please, input slot #:");
            Console.Write(">>:");
            str = Console.ReadLine();
            i = NumValidation(str, ref cars);
            if (i == -1)
            {
                AddCarInfo(ref cars);
            }
            else
            {
                Console.Clear();
                StringHeader($"You are in slot #{str} now");
                StringInfo("Input car model");
                Console.Write(">>:");
                cars[i - 1].Model = Console.ReadLine();
                if (cars[i - 1].Model == null)
                {
                    AddCarInfo(ref cars);
                }
                else
                {
                    StringInfo("Input car color");
                    Console.Write(">>:");
                    cars[i - 1].Color = Console.ReadLine();
                    if (cars[i - 1].Color == null)
                    {
                        AddCarInfo(ref cars);
                    }
                    else
                    {
                        StringInfo("Input car price");
                        Console.Write(">>:");
                        str = Console.ReadLine();
                        double num;
                        bool result = double.TryParse(Convert.ToString(str), out num);
                        if (result && Convert.ToDouble(str) > 0)
                        {
                            cars[i - 1].Price = Convert.ToDouble(str);
                        }
                        else
                        {
                            Console.WriteLine("Wrong data!\nThe price must be in numeric format\n" +
                                "Please, press any key to repeat input");
                            cars[i - 1].Price = -1;
                        }
                        if (cars[i - 1].Price == -1)
                        {
                            AddCarInfo(ref cars);
                        }
                    }
                }
            }
            InitScreen(ref cars);
        }

        private static void ShowCarsInfo(ref CarsRepo[] cars)
        {
            bool quantity = false;
            for (var i = 0; i < cars.Length; i++)
            {
                if (cars[i].Model != null &&
                    cars[i].Model != string.Empty)
                {
                    quantity = true;
                    StringHeader($"---------------------------" +
                        $"Information of the car in solt #{i}" +
                        $"---------------------------");
                    StringInfo($"Model:{cars[i].Model}");
                    StringInfo($"Color:{cars[i].Color}");
                    StringInfo($"Full Price:{cars[i].Price}");
                    Console.WriteLine();
                }
            }
            if (!quantity)
            {
                StringInfo("Your staff of the cars is empty yet");
            }
            StringNotify("Press Enter to return to previouse menu");
            Console.ReadLine();
            InitScreen(ref cars);
        }

        private static void StringHeader(string str)
        {
            string strVol = str;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(strVol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void StringInfo(string str)
        {
            string strVol = str;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(strVol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void StringNotify(string str)
        {
            string strVol = str;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(strVol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static int NumValidation(string str, ref CarsRepo[] cars)
        {
            int value;
            string num = str;
            bool result = int.TryParse(num, out value);
            if (result)
            {
                value = Convert.ToInt32(num);
                if (value < 1 ||
                    value > cars.Length)
                {
                    Console.WriteLine($"Wrong slot #!\nThe value must be " +
                        $"in diapasone 1 - {cars.Length}\n" +
                        $"Please, press Enter to repeat input");
                    Console.ReadLine();
                    value = -1;
                }
            }
            else
            {
                Console.WriteLine("Wrong data!\nThe value must be integer number\n" +
                    "Please, press Enter to repeat input");
                Console.ReadLine();
                value = -1;
            }
            return value;
        }
    }
}
