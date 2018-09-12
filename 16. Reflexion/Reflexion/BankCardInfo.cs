using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
    class BankCardInfo
    {
        [SecureData]
        public string Cvv { get; set; }

        [SecureData]
        public string Pin { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }
    }
}
