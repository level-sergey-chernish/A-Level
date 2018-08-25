using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reflexion
{
    internal class Func
    {
        internal static string PrintObjProperties<T>(T obj)
        {            
            string str = new string('-', 65) + "\n";
            Console.WriteLine(new string('-', 65));

            str += string.Format("| {0, -15} | {1, -15} | {2, -25} |", "Type", "Name", "Value") + "\n";
            Console.WriteLine("| {0, -15} | {1, -15} | {2, -25} |", "Type", "Name", "Value");

            str += new string('-', 65) + "\n";
            Console.WriteLine(new string('-', 65));

            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.PropertyType.IsPrimitive ||
                    property.PropertyType == typeof(string) ||
                    property.PropertyType.IsEnum ||
                    property.PropertyType == typeof(DateTime))
                {
                    str += string.Format("| {0, -15} | {1, -15} | {2, -25} |",
                        property.PropertyType.Name, property.Name, property.GetValue(obj)) + "\n";
                    Console.WriteLine("| {0, -15} | {1, -15} | {2, -25} |",
                        property.PropertyType.Name, property.Name, property.GetValue(obj));
                }
                else
                {
                    var propertyValue = property.GetValue(obj, null);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("| {0, -15} | {1, -15} | {2, -25} |",
                        property.PropertyType.Name, property.Name, property.GetValue(obj));
                    PrintObjProperties(propertyValue);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            str += new string('-', 65) + "\n";
            Console.WriteLine(new string('-', 65));
            return str;
        }

        internal static void WriteToFile(string str)
        {
            string pathToFile = @"d:\propertiesInfo.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(pathToFile, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
