using Inheritance.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance.Classes.DogsType;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[4];

            var shawn = new Cat();
            Console.WriteLine(shawn.SoundsLike());
            animals[0] = shawn;

            var ilwehr = new ServiceOrientedDog();
            Console.WriteLine(ilwehr.SoundsLike());
            animals[1] = ilwehr;

            var cow = new Cow();
            Console.WriteLine(cow.SoundsLike());
            animals[2] = cow;

            var sheep = new Sheep();
            Console.WriteLine(sheep.SoundsLike());
            animals[3] = sheep;

            Console.WriteLine("... |||| ....");

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.SoundsLike());
            }
        }
    }
}
