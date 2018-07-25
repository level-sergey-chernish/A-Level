using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public struct UserDummy
    {
        public string Username;
        public string Password;
        public bool StarterPassword;
        public UserType UserType;
        public int WrongPasswordAttempts;
        public bool IsBlocked;
        public int UserBill;

        public UserDummy(UserType uType,
            string uName,
            string uPassword = "0000",
            bool sPassword = true,
            bool isBlocked = false,
            int wrongPasswordAttempts = 3,
            int uBill = 0
            )
        {
            Username = uName;
            Password = uPassword;
            StarterPassword = sPassword; 
            UserType = uType;
            IsBlocked = isBlocked;
            WrongPasswordAttempts = wrongPasswordAttempts;
            UserBill = uBill;
        }
    }
    public enum UserType
    {
        admin,
        user
    }
}
