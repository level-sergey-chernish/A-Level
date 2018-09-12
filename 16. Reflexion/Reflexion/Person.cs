using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public BankCardInfo CardInfo  { get; set; }

        [SecureData]  //Obfuscation Flag
        public string Password { get; set; }
    }
}
