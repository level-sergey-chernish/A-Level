using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Memmorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial Size of memmorizer
            int contactRange = 20;
            //Init start records of contact names (flag name - TRUE)
            string[] contactName = InitContactArray(true, contactRange);
            //Init start records of phone numbers (flag phone -  FALSE)
            string[] contactNumber = InitContactArray(false, contactRange);
            MainMenu(contactName, contactNumber, contactRange);
        }
        private static void MainMenu(string[] contactNameArray, string[] contactNumberArray, int contactRange)
        {
            bool menuExit = false;
            string[] contactName = contactNameArray;
            string[] contactNumber = contactNumberArray;
            string tableHeader = String.Empty;
            int range = contactRange;
            byte i;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Choose Your action:\n" +
                    "___________________\n" +
                    "1 - Manage contacts\n2 - Show contacts\nq - Quit\n" +
                    "-------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">>:");
                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        //Manage contacts
                        ManageContact(contactName, contactNumber, contactRange);
                        menuExit = true;
                        break;
                    case "2":
                        //Show contacts
                        tableHeader = $"|{Spaces(1)}ID{Spaces(1)}|{Spaces(4)}" +
                            $"Contact Name{Spaces(4)}|{Spaces(2)}Phone{Spaces(2)}|\n";
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(tableHeader);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        for (i = 0; i < contactRange; i++)
                        {
                            if ((ShowContactArraysRecord(contactName, i) != null) &
                                (ShowContactArraysRecord(contactNumber, i) != null))
                            {
                                Console.Write($"|{Spaces(Convert.ToInt32(4 - 1 - Math.Floor(Math.Log10(i + 1) + 1)))}{i+1}{Spaces(1)}|" +
                                    $"{ShowContactArraysRecord(contactName, i)}{Spaces(20 - ShowContactArraysRecord(contactName, i).Length)}|" +
                                    $" {ShowContactArraysRecord(contactNumber, i)}{Spaces(8 - ShowContactArraysRecord(contactNumber, i).Length)}|\n");
                            }
                            
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press \"Enter\" to continue...");
                        Console.ReadLine();
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

        private static void ManageContact(string[] contactNameArray, string[] contactNumberArray, int contactRange)
        {
            bool menuExit = false;
            string[] contactName = contactNameArray;
            string[] contactNumber = contactNumberArray;
            int range = contactRange;
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Choose Your action:\n" +
                    "___________________\n" +
                    "1 - Add contact\n2 - Delete contact\nq - Exit to previous menu\n" +
                    "-------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">>:");
                string caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "1":
                        //Array.Resize<char>(ref arr, 6);
                        Console.WriteLine(Validation());
                        Array.Resize<string>(ref contactName, contactName.Length + 1);
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine($"Delete contact:");
                        break;
                    case "q":
                        Console.WriteLine($"Exit to previous menu:");
                        menuExit = true;
                        MainMenu(contactName, contactNumber, contactRange);
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

        private static String[] InitContactArray(bool contFieldFlag, int contArraySize)
        {
            bool isName = contFieldFlag;
            string[] initContactArray = new string[contArraySize];
            if (!isName)
            {
                initContactArray[0] = "79998321";
                initContactArray[1] = "09928341";
                initContactArray[2] = "3678236";
                initContactArray[15] = "03768236";
            }
            if (isName)
            {
                initContactArray[0] = "Ivan Petrovich Izmay";
                initContactArray[1] = "Sergey Fedorovich Ka";
                initContactArray[2] = "Moisey Goldrikhovich";
                initContactArray[15] = "Vasya Ferdinandovich";
            }
            return initContactArray;
        }

        private static string ShowContactArraysRecord(string[] contactInfoArray, int indexOfArray)
        {
            string[] contactArray = contactInfoArray;
            string arrayValue = contactArray[indexOfArray];
            return arrayValue;
        }

        private static string Spaces(int n)
        {
            return new string(' ', n);
        }

        private static string Validation()
        {
            string dialogString = String.Empty;
            string contactNewData = String.Empty;
            bool isName = true;
            if (isName)
            {
                dialogString += "Please, input contact name.\n Contact name must contain only,\n" +
                        "letters by length 2 - 20!\n";
                Console.WriteLine(dialogString);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">>:");
                contactNewData = Console.ReadLine();
                Regex regEx = new Regex(@"^[A-Za-z ]{2,20}\b$");
                if (!regEx.IsMatch(contactNewData))
                {
                    contactNewData = "Not valid data!!!\n Contact name must contain only,\n" +
                        "letters by length 2 - 20!\n" +
                        "Press \"Enter\" to repeat!";
                    Console.WriteLine(contactNewData);
                    contactNewData = "BAD";
                }
                else
                {
                    isName = false;
                }
 
            }            
            if (!isName)
            {
                dialogString = "Please, input contact phone number.\n Contact phone number must contain only,\n" +
                    "digits by length 3 - 8!\n";
                Console.WriteLine(dialogString);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(">>:");
                contactNewData = Console.ReadLine();
                Regex regEx = new Regex(@"^[0-9]{3,8}$");
                if (!regEx.IsMatch(contactNewData))
                {
                    contactNewData = "Not valid data!!!\n Telephone number must be only numeric,\n" +
                        " by length 3 - 8!\n" +
                        "Press \"Enter\" to repeat!";
                    contactNewData = "BAD";
                }
            }

            return contactNewData;
        }
    }

}
