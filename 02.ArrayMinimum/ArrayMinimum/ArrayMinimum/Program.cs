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

            //Range of int random
            int rndMin = 10;
            int rndMax = 50;

            //Minimums quantity
            int minQ = 10;

            //Size of Arrays
            byte ArrSize = 10;

            //Counters (iterrators)
            byte i, j, q;

            //Initial Array 5X5
            int[,] initArray = new int[ArrSize, ArrSize];

            //Minimum value in initArray
            int min;

            //Fill initArray with random integers in 0-100
            Console.WriteLine($"ARRAY {ArrSize}X{ArrSize} OF INTEGERS:");
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


            //Find Minimums q minimums in initArray
            Console.WriteLine($"\n{ArrSize} minimums in initArray:");
            q = 1;
            while (q <= minQ)
            {
                min = initArray[0, 0];
                for (i = 0; i <= initArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= initArray.GetUpperBound(1); j++)
                    {
                        if (initArray[i, j] < min)
                        {
                            min = initArray[i, j];
                        }
                    }
                }
                for (i = 0; i <= initArray.GetUpperBound(0); i++)
                {
                    for (j = 0; j <= initArray.GetUpperBound(1); j++)
                    {
                        if (initArray[i, j] == min)
                        {
                            Console.Write($"minValue #{q}:index[{i},{j}], value:{min}\n");
                            initArray[i, j] = rndMax;
                        }
                    }
                }
                q++;
            }
            Console.WriteLine();
        }
    }
}
