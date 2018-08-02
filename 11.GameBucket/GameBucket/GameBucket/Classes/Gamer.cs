using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GameBucket.Interfaces;

namespace GameBucket.Classes
{
    class Gamer
    {
        public string GamerName { get; set; }

        public int[] CurrentGamerResults { get; set; }

        public GamerTypes GamerType;

        public Gamer(string gamerName, int[] currentGamerResults, GamerTypes gamerType)
        {
            GamerName = gamerName;
            CurrentGamerResults = currentGamerResults;
            GamerType = gamerType;
        }

        public virtual void Guessing(int [] array, int numMin, int numMax, int counter )
        {
            Console.Clear();
            Console.WriteLine("...guessing...");
            Random  rnd = new Random();
            Thread.Sleep(100);
            array[counter] = rnd.Next(numMin, numMax);
        }

        public enum GamerTypes
        {
            ordinary,
            notepad,
            uber,
            cheeter,
            uberCheeter
        }
    }
}
