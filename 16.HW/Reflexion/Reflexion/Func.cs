using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexion
{
    internal class Func
    {
        internal static void PrintObjProperties<T>(T obj)
        {

            Console.WriteLine(new string('-', 82));

            Console.WriteLine("| {0, -20} | {1, -20} | {2, -32} |", "Type", "Name", "Value");

            Console.WriteLine(new string('-', 82));

            foreach (var property in obj.GetType().GetProperties())
            {
              
                Console.WriteLine("| {0, -20} | {1, -20} | {2, -32} |", 
                    property.PropertyType.Name, property.Name, property.GetValue(obj));

            }

            Console.WriteLine(new string('-', 82));
        }

    }
}
