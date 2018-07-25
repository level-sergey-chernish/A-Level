using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalendarSruct
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuExit = false;
            byte i;
            int days, minTemperature, maxTemperature;
            string userInput = string.Empty;
            int[] dayNum;
            int[] temperatureInDay;
            Random rnd = new Random();
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Choose Your action:\n" +
                    "___________________\n" +
                    "1 - Generate Calendar\nq - Quit\n" +
                    "-------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">>:");
                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Input quantity of the days:");
                        userInput = Console.ReadLine();
                        try
                        {
                            days = Convert.ToInt32(userInput);
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please, input only digits!\n");
                            goto case "1";
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Input minimum temperature:");
                        userInput = Console.ReadLine();
                        try
                        {
                            minTemperature = Convert.ToInt32(userInput);
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please, input only digits!\n");
                            goto case "1";
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Input maximum temperature:");
                        userInput = Console.ReadLine();
                        try
                        {
                            maxTemperature = Convert.ToInt32(userInput);
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please, input only digits!\n");
                            goto case "1";
                        }
                        if (minTemperature > maxTemperature)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Max temperature can't" +
                                " be greater min temperature!!!\n");
                            goto case "1";
                        }
                        temperatureInDay = new int[days];
                        dayNum = new int[days];
                        Structs.Days[] daysRange = new Structs.Days[days];
                        for (i = 0; i < days; i++)
                        {
                            daysRange[i].MinTemperature = minTemperature;
                            daysRange[i].MaxTemperature = maxTemperature;
                            dayNum[i] = daysRange[i].Day = i;
                            temperatureInDay[i] = daysRange[i].Temperature = daysRange[i].GenData();
                        }
                        DaysInfo(temperatureInDay, dayNum);
                        Console.WriteLine($"Total days:{temperatureInDay.Length}");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        Console.WriteLine("Do You want add new day with temperature?(y)");
                        userInput = Console.ReadLine();
                        userInput = userInput.ToLower();
                        if (userInput == "y")
                        {
                            Console.WriteLine("Input temperature:");
                            userInput = Console.ReadLine();
                            try
                            {
                                minTemperature = Convert.ToInt32(userInput);
                            }
                            catch
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please, input only digits!\n");
                                goto case "1";
                            }
                            temperatureInDay = DaysInfoAdd(temperatureInDay, minTemperature);
                            daysRange[temperatureInDay.Length - 1].Day = temperatureInDay.Length;
                            daysRange[temperatureInDay.Length - 1].Temperature = minTemperature;
                            Console.WriteLine(daysRange[temperatureInDay.Length - 1].Day);
                            Console.WriteLine(d
                                aysRange[temperatureInDay.Length - 1].Temperature);
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case "q":
                        menuExit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You made wronge choise." +
                            "Press any key to repeat.");
                        Console.ReadLine();
                        break;
                }
            } while (!menuExit);
        }
        public static void DaysInfo(int[] someArray, int[] numDay)
        {
            byte i;
            int[] temperatureInDay;
            int[] dayNum;
            dayNum = numDay;
            temperatureInDay = someArray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Minimum temperature was {temperatureInDay.Min()}" +
                $" in next days:");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (i = 0; i < temperatureInDay.Length; i++)
            {
                if (temperatureInDay[i] == temperatureInDay.Min())
                {
                    Console.WriteLine($"Day number:{dayNum[i]}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Maximum temperature was {temperatureInDay.Max()}" +
                $" in next days:");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (i = 0; i < temperatureInDay.Length; i++)
            {
                if (temperatureInDay[i] == temperatureInDay.Max())
                {
                    Console.WriteLine($"Day number:{dayNum[i]}");
                }
            }
        }
        public static int[] DaysInfoAdd(int[] someArray, int someTemperature)
        {
            int temperature;
            int[] temperatureInDay;
            temperatureInDay = someArray;
            temperature = someTemperature;
            Array.Resize<int>(ref temperatureInDay, temperatureInDay.Length + 1);
            temperatureInDay[temperatureInDay.Length - 1] = temperature;
            return temperatureInDay;
        }
    }
}
