using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Total users int ATM
            int totalUsers = 10;
            //Counter
            byte i;


            //Create ATM humsters from constructor
            UserDummy[] users = new UserDummy[totalUsers];
            for (i = 0; i < users.Length; i++)
            {
                users[i] = new UserDummy(UserType.user, "");
            }

            //ATM God of heap of humsters
            users[0].Username = "admin";
            users[0].Password = "1111";
            users[0].StarterPassword = false;
            users[0].UserType = UserType.admin;
            users[0].IsBlocked = false;
            users[0].WrongPasswordAttempts = 3;
            users[0].UserBill = 0;

            //Create first ATM humster from constructor
            users[8] = new UserDummy(UserType.user, "humster");
            users[8].UserBill = 100;

            InitialScreen(users);


        }

        private static void InitialScreen(UserDummy[] usersArray)
        {
            //Flag for cycle exit
            bool menuExit = false;
            //Dialog Case
            string caseSwitch;
            UserDummy[] users = usersArray;
            Console.Clear();
            do
            {
                MenuHeader($"HELLO. MAKE YOUR CHOISE");
                MenuChoise("1 - LOGIN\nq - QUIT");
                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        menuExit = true;
                        LoginInputScreen(users);
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
        private static void MenuHeader(string uString)
        {
            string userString = uString;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userString);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void Alert(string uString)
        {
            string userString = uString;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userString);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void Notify(string uString)
        {
            string userString = uString;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(userString);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void MenuChoise(string uString)
        {
            string userString = uString;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(userString);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void LoginInputScreen(UserDummy[] usersArray)
        {
            string userName;
            string userPassword = null;
            UserDummy[] users = usersArray;
            Console.Clear();
            MenuHeader("INPUT YOUR LOGIN NAME\n(case sensative!)");
            Console.Beep();
            Console.Write(">>:");
            userName = Console.ReadLine();
            Console.Clear();
            MenuHeader("INPUT YOUR PASSWORD\n(case sensative!)");
            Console.Write(">>:");
            while (true)
            {
                var userKey = System.Console.ReadKey(true);
                Console.Beep();
                Console.Write("*");
                if (userKey.Key == ConsoleKey.Enter)
                {
                    break;
                }
                userPassword += userKey.KeyChar;
            }
            UserValidation(userName, userPassword, users);
        }
        private static void UserValidation(string uName, string uPassword, UserDummy[] usersArray)
        {
            UserDummy[] users = usersArray;
            byte i;
            byte userID = Convert.ToByte(users.Length + 1);
            string userName = uName;
            string userPassword = uPassword;

            for (i = 0; i < users.Length; i++)
            {
                if ((userName == users[i].Username) &
                    (userName != ""))
                {
                    userID = i;
                    i = Convert.ToByte(users.Length);
                }
            }
            if (userID == Convert.ToByte(users.Length + 1))
            {
                Console.Clear();
                Alert($"WRONG AUTHORIZATION!\n Press Enter to repeat");
                Console.ReadLine();
                Console.Clear();
                InitialScreen(users);
            }
            else
            {
                if ((userPassword != users[userID].Password))
                {
                    Console.Clear();
                    if (users[userID].WrongPasswordAttempts <= 0)
                    {
                        users[userID].IsBlocked = true;
                        Alert($"YOUR ID IS BLOCKED!\nContact Bank\n" +
                            $"Press Enter to return to main menu");
                        Console.ReadLine();
                        Console.Clear();
                        InitialScreen(users);
                    }
                    else
                    {
                        users[userID].WrongPasswordAttempts = --users[userID].WrongPasswordAttempts;
                        Alert($"WRONG PASSWORD!\nAttempts remaining:{users[userID].WrongPasswordAttempts}\n" +
                            $"Press Enter to repeat");
                        Console.ReadLine();
                        Console.Clear();
                        InitialScreen(users);
                    }
                }
                else
                {
                    if (users[userID].IsBlocked == true)
                    {
                        Alert($"YOUR ID IS BLOCKED!\nContact Bank\n" +
                            $"Press Enter to return to main menu");
                        Console.ReadLine();
                        Console.Clear();
                        InitialScreen(users);
                    }
                    else
                    {
                        users[userID].WrongPasswordAttempts = 3;
                        if (users[userID].StarterPassword)
                        {
                            ChangePassword(users, userID);
                            InitialScreen(users);
                        }
                        else
                        {
                            MenuSelector(users, userID);
                        }
                        
                    }
                }
            }
        }
        private static void MenuSelector(UserDummy[] usersArray, byte uID)
        {
            UserDummy[] users = usersArray;
            byte userID = uID;
            if (users[userID].UserType == UserType.admin)
            {
                MenuAdmin(users, userID);
            }
            else
            {
                MenuUser(users, userID);
            }
        }
        private static void MenuAdmin(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            int userAccountID;
            string userString;
            bool result;
            UserDummy[] users = usersArray;
            //Flag for cycle exit
            bool menuExit = false;
            //Dialog Case
            string caseSwitch;
            Console.Clear();
            do
            {
                MenuHeader($"HELLO, {users[userID].Username}!");
                MenuChoise("1 - Change Your Password\n" +
                    "2 - Show all accounts\n" +
                    "3 - Enable account\n" +
                    "4 - Add account\n" +
                    "5 - Remove account\n" +
                    "q - Logout");
                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        ChangePassword(users, userID);
                        MenuAdmin(users, userID);
                        menuExit = true;
                        break;
                    case "2":
                        ShowAllUsers(users, userID);
                        MenuAdmin(users, userID);
                        menuExit = true;
                        break;
                    case "3":
                        Console.Clear();
                        MenuHeader("Input user account ID and press Enter:");
                        Console.Write(">>:");
                        userString = Console.ReadLine();
                        result = Int32.TryParse(userString, out userAccountID);
                        if (result)
                        {
                            if (Convert.ToByte(userString) <= users.Length)
                            {
                                EnableAccount(users, userID, Convert.ToByte(userString));
                            }
                            else
                            {
                                Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                            Console.ReadLine();
                        }
                        MenuAdmin(users, userID);
                        menuExit = true;
                        break;
                    case "4":
                        AddAccount(users, userID);
                        MenuAdmin(users, userID);
                        menuExit = true;
                        break;
                    case "5":
                        Console.Clear();
                        MenuHeader("Input user account ID and press Enter:");
                        Console.Write(">>:");
                        userString = Console.ReadLine();
                        result = Int32.TryParse(userString, out userAccountID);
                        if (result)
                        {
                            if (Convert.ToByte(userString) <= users.Length)
                            {
                                RemoveAccount(users, userID, Convert.ToByte(userString));
                            }
                            else
                            {
                                Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                            Console.ReadLine();
                        }
                        MenuAdmin(users, userID);
                        menuExit = true;
                        break;
                    case "q":
                        menuExit = true;
                        InitialScreen(users);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (!menuExit);
        }
        private static void MenuUser(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            UserDummy[] users = usersArray;
            //Flag for cycle exit
            bool menuExit = false;
            //Dialog Case
            string caseSwitch;
            Console.Clear();
            do
            {
                MenuHeader($"HELLO, {users[userID].Username}!");
                MenuChoise("1 - Change Your Password\n" +
                    "2 - Show Balance\n" +
                    "3 - Withdraw\n" +
                    "4 - Replenish\n" +
                    "q - Logout");
                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        ChangePassword(users, userID);
                        MenuUser(users, userID);
                        menuExit = true;
                        break;
                    case "2":
                        ShowBalance(users, userID);
                        MenuUser(users, userID);
                        menuExit = true;
                        break;
                    case "3":
                        Withdraw(users, userID);
                        MenuUser(users, userID);
                        menuExit = true;
                        break;
                    case "4":
                        Replenish(users, userID);
                        MenuUser(users, userID);
                        menuExit = true;
                        break;
                    case "q":
                        menuExit = true;
                        InitialScreen(users);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (!menuExit);
        }
        private static void ShowAllUsers(UserDummy[] usersArray, byte uID)
        {
            byte i;
            byte userID = uID;
            UserDummy[] users = usersArray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-".PadRight(36, '-'));
            Console.WriteLine("ID Username  Blocked   PA Amount  ");
            Console.WriteLine("-".PadRight(36, '-'));
            Console.ForegroundColor = ConsoleColor.Gray;
            for (i = 0; i < users.Length; i++)
            {
                if (users[i].Username != "")
                {
                    Console.Write(i.ToString().PadRight(3, ' '));
                    Console.Write(users[i].Username.PadRight(10, ' '));
                    Console.Write(users[i].IsBlocked.ToString().PadRight(10, ' '));
                    Console.Write(users[i].WrongPasswordAttempts.ToString().PadRight(3, ' '));
                    Console.Write(users[i].UserBill.ToString().PadRight(10, ' '));
                    Console.WriteLine();
                }
            }
            Notify("Press Enter to return to previous menu");
            Console.ReadLine();
        }
        private static void ChangePassword(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            string userPassword = null;
            UserDummy[] users = usersArray;
            Console.Clear();
            MenuHeader("INPUT YOUR NEW PASSWORD AND PRESS ENTER\nIt must be 4 digits ONLY!");
            Console.Write(">>:");
            while (true)
            {
                var userKey = System.Console.ReadKey(true);
                Console.Write("*");
                if (userKey.Key == ConsoleKey.Enter)
                {
                    break;
                }
                userPassword += userKey.KeyChar;
            }
            Regex regEx = new Regex(@"^^[0-9]{4}$");
            if ((String.IsNullOrEmpty(userPassword)) ||
                !regEx.IsMatch(userPassword))
            {
                Alert("\nFAILURE!\n Password does not match the requirements");
                Notify("Press Enter to return to previous menu");
                Console.ReadLine();
            }
            else
            {
                users[userID].Password = userPassword;
                users[userID].StarterPassword = false;
                Notify("\nSUCCESS!");
                Notify("Press Enter to return to previous menu");
                Console.ReadLine();
            }
        }
        private static void EnableAccount(UserDummy[] usersArray, byte uID, byte uaID)
        {
            byte userID = uID;
            byte userAccountID = uaID;
            UserDummy[] users = usersArray;
            users[userAccountID].IsBlocked = false;
            Notify("SUCCESS\nVerify account status from menu \"Show all accounts\"\n Press Enter to continue");
            Console.ReadLine();
        }
        private static void AddAccount(UserDummy[] usersArray, byte uID)
        {
            byte i;
            UserDummy[] users = usersArray;
            byte userID = uID;
            string newUserName;
            byte userAccountID = Convert.ToByte(users.Length + 1);
            for (i = 0; i < users.Length; i++)
            {
                if ((users[i].Username == "") &
                    (users[i].Password == "0000") &
                    (users[i].IsBlocked == false) &
                    (users[i].WrongPasswordAttempts == 3) &
                    (users[i].UserBill == 0))
                {
                    userAccountID = i;
                    i = Convert.ToByte((users.Length + 1));
                }
            }
            if (userAccountID == Convert.ToByte(users.Length + 1))
            {
                Console.Clear();
                Alert("ATM USER STACK IS FULL!\n" +
                    "Delete some user or buy new ATM!\n" +
                    "Press Enter to return to previous menu");
            }
            else
            {
                Console.Clear();
                Notify("INPUT NEW USERNAME\n New username must be 4-8 letters length\n");
                Console.Write(">>:");
                newUserName = Console.ReadLine();
                Regex regEx = new Regex(@"^[a-zA-Z]{4,8}$");
                if (!regEx.IsMatch(newUserName))
                {
                    Alert("\nFAILURE!\n Username does not match the requirements");
                    Notify("Press Enter to return to previous menu");
                    Console.ReadLine();
                }
                else
                {
                    for (i = 0; i < users.Length; i++)
                    {
                        if (newUserName == users[i].Username)
                        {
                            i = Convert.ToByte((users.Length + 1));
                        }
                    }
                    if (i == Convert.ToByte(users.Length + 2))
                    {
                        Alert("\nFAILURE!\n User exists");
                        Notify("Press Enter to return to previous menu");
                        Console.ReadLine();
                    }
                    else
                    {
                        users[userAccountID] = new UserDummy(UserType.user, newUserName);
                        users[userAccountID].UserBill = 100;
                        Notify("\nSUCCESS!");
                        Notify("Press Enter to return to previous menu");
                        Console.ReadLine();
                    }

                }
            }
        }
        private static void RemoveAccount(UserDummy[] usersArray, byte uID, byte uaID)
        {
            byte userID = uID;
            byte userAccountID = uaID;
            UserDummy[] users = usersArray;
            if (users[userAccountID].UserType == UserType.user)
            {
                users[userAccountID] = new UserDummy(UserType.user, "");
                users[userAccountID].UserBill = 0;
                Notify("SUCCESS\n Press Enter to continue");
                Console.ReadLine();
            }
            else
            {
                Alert("Admin account can not be deleted!\nPress Enter to return to previous menu");
                Console.ReadLine();
            }
        }
        private static void ShowBalance(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            UserDummy[] users = usersArray;
            Console.Clear();
            MenuHeader($"YOUR BALACE IS:\n{users[userID].UserBill}$");
            Notify("Press Enter to return to previous menu");
            Console.ReadLine();
        }
        private static void Withdraw(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            string userString;
            bool result;
            int amount;
            UserDummy[] users = usersArray;
            Console.Clear();
            MenuHeader($"INPUT AMOUNT FOR WITHDRAW\n");
            Console.Write(">>:");
            userString = Console.ReadLine();
            result = Int32.TryParse(userString, out amount);
            if (result)
            {
                if (Convert.ToInt32(userString) > users[userID].UserBill)
                {
                    Alert("The requested amount can not be issued!\n Insufficient funds\n");
                    Notify("Press Enter to return to previous menu");
                    Console.ReadLine();
                }
                else
                {
                    users[userID].UserBill = users[userID].UserBill - Convert.ToInt32(userString);
                    Notify($"SUCCESS.\n Current balance now is:\n" +
                        $"{users[userID].UserBill}$\nPress Enter to return to previous menu");
                    Console.ReadLine();
                }
            }
            else
            {
                Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                Console.ReadLine();
            }
        }
        private static void Replenish(UserDummy[] usersArray, byte uID)
        {
            byte userID = uID;
            string userString;
            bool result;
            int amount;
            UserDummy[] users = usersArray;
            Console.Clear();
            MenuHeader($"INPUT AMOUNT FOR REPLENISH\n");
            Console.Write(">>:");
            userString = Console.ReadLine();
            result = Int32.TryParse(userString, out amount);
            if (result)
            {
                users[userID].UserBill = users[userID].UserBill + Convert.ToInt32(userString);
                Notify($"SUCCESS.\n Current balance now is:\n" +
                    $"{users[userID].UserBill}$\nPress Enter to return to previous menu");
                Console.ReadLine();
            }
            else
            {
                Alert("WRONG INPUT!\n Press Enter to retur to previos menu");
                Console.ReadLine();
            }
        }
    }
}