using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();

            // add reflexion
            Type calcType = calc.GetType(); //call get type on instance

           MethodInfo[] methodInfos = Type.GetType("Reflexion.Calc")
                           .GetMethods(BindingFlags.Public | BindingFlags.Instance);
            for (var i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(methodInfos[i]);
            }

            MethodInfo method = calcType.GetMethod("Add"); //now we can get method

            var param = new object[] { 6, 7 };
            
            Console.WriteLine(method?.Invoke(calc, param));




            Person p = new Person()
            {
                Age = 21,
                CardInfo = new BankCardInfo()
                {
                    CardName = "Name",
                    CardNumber = "3334 4215 1231 3213"
                },
                Email = "some@some.com",
                FirstName = "Tim",
                LastName = "R",
                Password = "password1"
            };

            foreach (var prop in p.GetType().GetProperties())
            {
                Console.WriteLine($"PropertyName: {prop.Name}, " +
                    $"PropertyType: {prop.PropertyType.Name}," +
                    $" PropertyValue: {prop.GetValue(p)}");
            }

            Console.WriteLine(Sum<int>(1, 2));
            Console.WriteLine(Sum<double>(1.1, 2.2));

            ReadObj<Person>(p);
        }

       

        private static bool Sum<T>(T oper1, T oper2)// where T : Person // can bestruct, class, new object (etc. Person)
        {
            return oper1.Equals(oper2);
        }

        private static void ReadObj<T>(T obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.PropertyType.IsPrimitive ||
                    prop.PropertyType == typeof(string) ||
                    prop.PropertyType.IsEnum ||
                    prop.PropertyType == typeof(DateTime))
                {
                    Console.WriteLine($"PropertyName: {prop.Name}, " +
                        $"PropertyType: {prop.PropertyType.Name}," +
                        $" PropertyValue: {prop.GetValue(obj)}");
                }
                else
                {
                    var propValue = prop.GetValue(obj, null);
                    ReadObj(propValue);
    }
            }
        }

    }
}
