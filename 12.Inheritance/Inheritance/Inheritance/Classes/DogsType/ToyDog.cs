using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes.DogsType
{
    public class ToyDog : Dog
    {
        public override string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Run()
        {
            Console.WriteLine("Slow");
        }

 //       public class ServiceOrientedDog : Dog
 //       {
            //private string color;

            //public override string Color
            //{
            //    get
            //    {
            //        return color;
            //    }
            //    set
            //    {
            //        color = value;
            //    }
            //}
 //      }
    }
}
