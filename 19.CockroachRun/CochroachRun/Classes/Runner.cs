using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CockroachRun.Classes
{
    public  abstract class Runner
    {
        public static object _lock = new object();
        private char _appearence;

        /// <summary>
        /// What appearence has your insect? :-)
        /// Char which indicate runner (can't be emptyspace or null)
        /// </summary>
        internal char Appearence
        {
            get => _appearence;

            set
            {
                if (!char.IsWhiteSpace(value) &&
                    value != '\0')
                {
                    _appearence = value;
                }
                else
                {
                    throw new Exception("Property Runner.Approach must be char, not empty, not null");
                }
            }
        }

        /// <summary>
        /// Run is cycle from 0 to GameFuncs.distance value. On each interration
        /// makes freeze on Game.Funcs.Randomizer(int min, int max) time
        /// (See GameFuncs.cs)
        /// </summary>
        /// <param name="distance">Distance for runners (number of interations of the cycle)</param>
        /// <param name="appearence">Char which indicate runner (can't be emptyspace or null)</param>
        /// <param name="treadmilNumber">Number of line of stdout to screen</param>
        internal virtual void Race(int treadmilNumber, int distance, char appearence)
        {
            int i = 0;
            while (true)
            {
                lock (_lock)
                {
                    Console.SetCursorPosition(0, treadmilNumber + 1);
                    var str = new String('-', i);
                    str += appearence;
                    Console.Write(str);
                }
                i++;
                Thread.Sleep(GameFuncs.Randomizer(GameFuncs.MinTimeFreeze, GameFuncs.MaxTimeFreeze));
            }
        }

        /// <summary>
        /// Runner constructor
        /// </summary>
        /// <param name="appearence">Char which indicate runner (can't be emptyspace or null)</param>
        internal Runner(char appearence)
        {
            Appearence = appearence;
        }
    }    
}
