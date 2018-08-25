using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person()
            {
                FirstName = "Axell",

                LastName = "Havoc",

                Age = 38,

                Email = "Axell@orient.suo",

                Password = "Axell'sPassword",

                CardInfo = new BankCardInfo()
                {
                    Cvv = "132",

                    Pin = "354",

                    CardName = "Axell Havoc",

                    CardNumber = "1234 5678 0987 6543"
                }
            };

            Func.PrintObjProperties(person);
        }


    }
}
