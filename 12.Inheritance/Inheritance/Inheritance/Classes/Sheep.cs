using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    public class Sheep : Animal
    {
        public new string SoundsLike()
        {
            return "Beh beh";
        }
    }
}
