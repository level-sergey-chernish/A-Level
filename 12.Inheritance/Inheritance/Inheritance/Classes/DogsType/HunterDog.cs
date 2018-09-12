using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes.DogsType
{
    public class HunterDog : Dog
    {
        public override string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Run()
        {
            Console.WriteLine("Very Fast");
        }
    }
}
