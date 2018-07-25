using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoDimensionalArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //New Object "Random"
            Random rnd = new Random();

            //Random int range
            int rndMin = 0;
            int rndMax = 100;

            //Counters (iterrators)
            byte i, j;

            //Size of Arrays
            byte ArrSize = 5;

            //Initial Array (ArrSize)X(ArrSize)
            int[,] initArray = new int[ArrSize, ArrSize];

            //Sums for each columns of Array (ArrSize)X(ArrSize) to Array (ArrSize)X(ArrSize)
            int[] sumArray = new int[ArrSize];

            //Fill initArray with random integers in 0-100
            for (i = 0; i <= initArray.GetUpperBound(0); i++)
            {
                Console.Write("[");
                for (j = 0; j <= initArray.GetUpperBound(1); j++)
                {
                    initArray[i, j] = rnd.Next(rndMin, rndMax);
                    if (j == initArray.GetUpperBound(1))
                    {
                        Console.Write($"{initArray[i, j]}");
                    }
                    else
                    {
                        Console.Write($"{initArray[i, j]}, ");
                    }

                }
                Console.Write("]");
                Console.WriteLine();
            }

            //Fill sumArray by sums of collums of initArray
            for (j = 0; j <= initArray.GetUpperBound(1); j++)
            {
                for (i = 0; i <= initArray.GetUpperBound(0); i++)
                {
                    sumArray[j] += initArray[i, j];
                }

            }

            //Find Maximums in sumArray
            Console.WriteLine($"Max sum value in columns is: {sumArray.Max()}");
            for (i = 0; i < sumArray.Length; i++)
            { 
                if (sumArray[i] == sumArray.Max())
                {
                    Console.Write($"Max sum in column #{i + 1}\n");
                }
            }
        }
    }
}
