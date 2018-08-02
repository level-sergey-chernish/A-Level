using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameBucket.Classes
{
    class GamerNotepad : Gamer
    {

        public GamerNotepad(string gamerName, int[] currentGamerResults, GamerTypes gamerType) : base(gamerName, currentGamerResults, gamerType)
        {

        }

        public override void Guessing(int[] array, int numMin, int numMax, int counter)
        {
            {
                
                Console.Clear();
                Console.WriteLine("...guessing...");
                Random rnd = new Random();
                bool exit = true;

                Thread.Sleep(100);
                while (exit)
                {
                    exit = true;
                    array[counter] = rnd.Next(numMin, numMax);
                    for (var i = 0; i < array.Length; i++)
                    {
                        if (array[i] == array[counter])
                        {
                            exit = false;
                        }
                    }                   
                }
            }
        }
    }
}
