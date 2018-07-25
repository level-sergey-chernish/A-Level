using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1;
            string num2;
            float a, b;
            float res;
            bool stop = false;

            num1 = GetUserParameters("a");

            a = Convert.ToSingle(num1);
            num2 = GetUserParameters("b");
            b = Convert.ToSingle(num2);
            do
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Choose your math action with numbers a and b:\n" +
                    "1 - Add\n2 - Sub\n3 - Mult\n4 - Div\nq - Quit");
                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        res = Add(a, b);
                        Console.WriteLine($"Add result: {a}+{b}={res}");
                        break;
                    case "2":
                        res = Sub(a, b);
                        Console.WriteLine($"Sub result: {a}-{b}={res}");
                        break;
                    case "3":
                        res = Mult(a, b);
                        Console.WriteLine($"Mult result: {a}*{b}={res}");
                        break;
                    case "4":
                        res = Div(a, b);
                        Console.WriteLine($"Div result: {a}-{b}={res}");
                        break;
                    case "q":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Choose your math action with numbers a and b:");
                        break;
                }
            } while (!stop);

        }
        public static string GetUserParameters(string paramName)
        {
            Console.WriteLine($"Type first number (can be float): {paramName}");
            string value = Console.ReadLine();
            return value;
        }
        public static float Add(float a, float b)
        {
            float value = a + b;
            return value;
        }

        public static float Sub(float a, float b)
        {
            float value = a - b;
            return value;
        }

        public static float Mult(float a, float b)
        {
            float value = a * b;
            return value;
        }

        public static float Div(float a, float b)
        {
            float value = a / b;
            return value;
        }
    }

}
