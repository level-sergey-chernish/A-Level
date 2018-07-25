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

            //Counters (iterrators)
            byte i;

            //Size of Arrays
            byte ArrSize = 6;

            //Sorted or not Sorted (boolean Shakespeare)
            bool isSorted = false;

            //buffer for vise versa
            int buffer;

            //initial array
            int[] unsortedArray = new int[ArrSize];

            //Fill initArray with random integers in 0-100
            Console.Write("[");
            for (i = 0; i < unsortedArray.Length; i++)
            {

                unsortedArray[i] = rnd.Next(0, 100);
                if (i == (unsortedArray.Length - 1))
                {
                    Console.Write($"{unsortedArray[i]}");
                }
                else
                {
                   Console.Write($"{unsortedArray[i]}, ");
                }
            }
            Console.Write("]\n");

            //Bubble sort
            while (!isSorted)
            {
                isSorted = true;
                for (i = 0; i < unsortedArray.Length - 1; i++)
                {
                    if (unsortedArray[i] > unsortedArray[i + 1])
                    {
                        isSorted = false;
                        buffer = unsortedArray[i + 1];
                        unsortedArray[i + 1] = unsortedArray[i];
                        unsortedArray[i] = buffer;
                    }

                }
            }
            Console.Write("[");
            for (i = 0; i < unsortedArray.Length; i++)
            {
                if (i == (unsortedArray.Length - 1))
                {
                    Console.Write($"{unsortedArray[i]}");
                }
                else
                {
                    Console.Write($"{unsortedArray[i]}, ");
                }
            }
            Console.Write("]\n");

        }
    }
}
