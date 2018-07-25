using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            //New Object "Random"
            Random rnd = new Random();

            //Counters (iterrators)
            byte i, j;

            //Size of Arrays
            byte ArrSizeX2D = 2;
            byte ArrSizeY2D = 3;
            byte ArrSizeX1D = 5;

            //Initial 2D Array of size (ArrSizeX X ArrSizeY)
            int[,] initArray2D = new int[ArrSizeX2D, ArrSizeY2D];

            //Initial 1D Array of size ArrSizeX1D
            int[] initArray1D = new int[ArrSizeX1D];

            //odd and even sums;
            int odd = 0;
            int even = 0;

            //Mod division flag
            bool isEven;

            //Fill initArray2D with random integers in 0-100
            for (i = 0; i <= initArray2D.GetUpperBound(0); i++)
            {
                Console.Write("[");
                for (j = 0; j <= initArray2D.GetUpperBound(1); j++)
                {
                    initArray2D[i, j] = rnd.Next(0, 100);
                    if (j == initArray2D.GetUpperBound(1))
                    {
                        Console.Write($"{initArray2D[i, j]}");
                    }
                    else
                    {
                        Console.Write($"{initArray2D[i, j]}, ");
                    }
                    isEven = Convert.ToBoolean(initArray2D[i, j] % 2);
                    if (isEven)
                    {
                        even += initArray2D[i, j];
                    }
                    else
                    {
                        odd += initArray2D[i, j];
                    }

                }
                Console.Write("]\n");
            }
            Console.WriteLine($"even: {odd}\nodd: {even}\n");

            //Fill initArray1D with random integers in 0-100
            Console.Write("[");
            even = 0;
            odd = 0;
            for (i = 0; i < initArray1D.Length; i++)
            {
                initArray1D[i] = rnd.Next(0, 100);
                if (i == (initArray1D.Length - 1))
                {
                    Console.Write($"{initArray1D[i]}");
                }
                else
                {
                    Console.Write($"{initArray1D[i]}, ");
                }
                isEven = Convert.ToBoolean(initArray1D[i] % 2);
                if (isEven)
                {
                    even += initArray1D[i];
                }
                else
                {
                    odd += initArray1D[i];
                }
            }
            Console.Write("]\n");
            Console.WriteLine($"even: {odd}\nodd: {even}\n");
        }
    }
}
