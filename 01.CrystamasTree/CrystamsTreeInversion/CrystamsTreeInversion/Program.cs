using System;

namespace CrystmasTreeInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Size of the base of the pyramid
            byte maxLength = 9;
            byte maxHeight = Convert.ToByte(maxLength*2/3);
            //Cycle counters
            byte x, y;
            //Meddle of the string
            byte mediana = Convert.ToByte(maxLength / 2); ;
            //Strings of the output results
            string s1 = String.Empty;

            System.Console.WriteLine("MAGIC HERE:\n\n\noutput:");

            // Using "Fibonachi" algo for finding dots between asterisks
            for (x = 0; x < maxHeight; x++)
            {
                for (y = 0; y < maxLength; y++)
                {
                    if ((y > (mediana - x)) &
                        (y < (mediana + x)) &
                        (x != (maxHeight - 1)))
                    {
                        s1 += ".";
                    }
                    else
                    {
                        s1 += "*";
                    }
                     
                }
                System.Console.WriteLine(s1);
                s1 = String.Empty;
            }

            Console.ReadLine();
        }
    }
}
