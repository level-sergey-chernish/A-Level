using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CalendarSruct
{
    class Structs
    {
        /// <summary>
        /// Contain 2 methods:
        /// 1 - GenData - get numbers off the days and generate
        /// array of random integers (temperature per day)
        /// 2 - AddData - extend GetData.Array with manually added value (temperature)
        /// Contain 2 int value:
        /// 1 - min generated value
        /// 2 - max generated value
        /// </summary>
        public struct Days
        {
            public int MinTemperature { get; set; }
            public int MaxTemperature { get; set; }
            public int Day;
            public int Temperature;

            public Days(int day, int temperature)
                : this()
            {
                Day = day;
                Temperature = temperature;
            }

            public int GenData()
            {
                int genData;
                Random rnd = new Random();
                Thread.Sleep(10);
                genData = rnd.Next(MinTemperature, MaxTemperature);
                return genData;
            }
        }
        
    }
}
