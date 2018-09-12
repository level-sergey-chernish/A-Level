using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    public abstract class Dog : Animal
    {
        public override string SoundsLike()
        {
            return "Woof";
        }

        public abstract string Color { get; set; }

        public abstract void Run();


    }
}
