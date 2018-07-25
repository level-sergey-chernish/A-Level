using System;

namespace CrystmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Size of the base of the pyramid
            byte maxLength = 6;
            //Cycle counters
            byte x, y, z;
            //Strings of the output results
            string s1 = "";
            string s2 = string.Empty;

            /* Logic: in every cycle form two string s1 and s2. s1-length on every step of the cycle
            decrease on 1, s2-length on every step of the cycle increase on 1 and concatenate s1 and s2 with deletion of
            the last symbol */
            System.Console.WriteLine("MAGIC HERE:\n\n\noutput:");
            for (x = maxLength; x > 0; x--)
            {
                for (y = x; y > 1; y--)
                {
                    s1 += " ";
                }
                for (z = 0; z <= (maxLength - x); z++)
                {
                    s2 += "*.";
                }
                Console.WriteLine((s1 + s2).Remove(((s1 + s2).Length - 1), 1));
                s1 = String.Empty;
                s2 = String.Empty;
            }
        }
    }
}
