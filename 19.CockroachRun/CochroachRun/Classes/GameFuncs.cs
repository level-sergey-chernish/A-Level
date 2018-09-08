using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CockroachRun.Classes
{
    /// <summary>
    /// Common methods,vars and consts
    /// </summary>
    internal static class GameFuncs
    {
        /// <summary>
        /// Distance for runners (number of interations of the cycle)
        /// </summary>
        internal static int Distance = 10;

        /// <summary>
        /// Minimal freeze of time after each step of run of interation
        /// </summary>
        internal static int MinTimeFreeze = 500;

        /// <summary>
        /// Maximal freeze of time after each step of run of interation
        /// </summary>
        internal static int MaxTimeFreeze = 1000;

        /// <summary>
        /// Return random int value between int min and int max values
        /// </summary>
        /// <param name="min">Minimal freeze of time after each step of run of interation (integer value)</param>
        /// <param name="max">Maximal freeze of time after each step of run of interation (integer value)</param>
        /// <returns>Random value between min and max</returns>
        internal static int Randomizer(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
