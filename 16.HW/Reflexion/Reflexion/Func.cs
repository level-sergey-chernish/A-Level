using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Reflexion
{
    internal class Func
    {
        internal static void PrintObjProperties<T>(T obj, bool toFile)
        {
            if (toFile)
            {
                ToFile(obj);
            }
            else
            {
                ToConsole(obj);
            }
        }

        private static void ToConsole<T>(T obj)
        {
            Console.WriteLine("Property Full Name: " + obj.GetType().FullName);

            Console.WriteLine(new string('-', 65));

            Console.WriteLine("|      {0, -10} |      {1, -10} |           {2, -15} |",
                "Type", "Name", "Value");

            Console.WriteLine(new string('-', 65));

            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.PropertyType.IsPrimitive ||

                    property.PropertyType == typeof(string) ||

                    property.PropertyType.IsEnum ||

                    property.PropertyType == typeof(DateTime))
                {
                    Console.WriteLine("| {0, -15} | {1, -15} | {2, -25} |",
                        property.PropertyType.Name, property.Name, property.GetValue(obj));
                }
                else
                {
                    try
                    {
                        var propertyValue = property.GetValue(obj, null);

                        Console.ForegroundColor = ConsoleColor.Cyan;

                        Console.WriteLine("| {0, -15} | {1, -15} | {2, -25} |",
                            property.PropertyType.Name, property.Name, property.GetValue(obj));

                        ToConsole(propertyValue);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine(new string('-', 65));
        }

        private static void ToFile<T>(T obj)
        {
            const string br = "\r\n";

            string str = string.Empty;

            foreach (var property in obj.GetType().GetProperties())
            {
                if (property.PropertyType.IsPrimitive ||

                    property.PropertyType == typeof(string) ||

                    property.PropertyType.IsEnum ||

                    property.PropertyType == typeof(DateTime))
                {
                    str +=
                        $"{property.PropertyType.Name}|{property.Name}|{property.GetValue(obj)}|{br}";
                }
            }

            var env = Environment.GetEnvironmentVariable("%USERPROFILE%");

            var pathToFile =
                $"{env}{Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\propertiesInfo.txt")}";

            try
            {
                using (var file = new StreamWriter(pathToFile, false, System.Text.Encoding.UTF8))
                {
                    file.WriteLine(str);

                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var process = new Process
            {
                StartInfo =
                {
                    FileName = "notepad.exe",

                    Arguments = pathToFile
                }
            };

            process.Start();
        }

        internal static List<string> ParseStringsFromFile()
        {
            var env = Environment.GetEnvironmentVariable("%USERPROFILE%");

            var pathToFile =
                $"{env}{Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Desktop\\propertiesInfo.txt")}";

            List<string> propertiesList = new List<string>();

            try
            {
                using (StreamReader file = new StreamReader(pathToFile, System.Text.Encoding.UTF8))
                {
                    string stringOfFile;

                    while((stringOfFile = file.ReadLine()) != null)
                    {
                        string[] words = Regex.Split(stringOfFile, "\\|");

                        for (var i = 0; i < words.Length - 1; i++)
                        {
                            propertiesList.Add(words[i]);
                        }
                    }

                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return propertiesList;
        }

        internal static void CreateObjFromFile(List<string> propertiesList)
        {

            Person anotherPerson = new Person();

            foreach (var property in anotherPerson.GetType().GetProperties())
            {
                for (var i = 0; i < propertiesList.Count; i += 3)
                {
                    if (property.PropertyType.Name == propertiesList.ElementAt(i) &&
                        property.Name == propertiesList.ElementAt(i + 1))
                    {
                        if (property.PropertyType.Name == "Int32")
                        {
                            property.SetValue(anotherPerson, Convert.ToInt32(propertiesList.ElementAt(i + 2)));
                        }
                        else
                        {
                            property.SetValue(anotherPerson, propertiesList.ElementAt(i + 2));
                        }
                    }
                    
                }

            }

            Console.WriteLine();
            Console.WriteLine("Object from File");
            ToConsole(anotherPerson);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("P.S. Dude, don't forget to delete trash-file" +
                              " from your desktop (filename is propertiesInfo.txt)");
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}
