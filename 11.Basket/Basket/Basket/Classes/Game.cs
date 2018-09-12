using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Basket.Classes;

namespace Basket
{
    class Game
    {
        internal static int BasketScoreMin = 40;

        internal static int BasketScoreMax = 140;

        internal static int GuessedNumber = Randomizer(Game.BasketScoreMin, Game.BasketScoreMax);

        internal static int AttempsToToGuess = 100;

        internal static List<int> CommonGuessingResults = new List<int>();

        /// <summary>
        /// Pseudo-randomizer. Return int value between minNum - maxNum
        /// </summary>
        /// <param name="minNum">minimum value</param>
        /// <param name="maxNum">maximum value</param>
        /// <returns></returns>
        internal static int Randomizer(int minNum, int maxNum)
        {
            int min = minNum;
            int max = maxNum;
            Random rnd = new Random();
            Thread.Sleep(50);
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Comparator of the result of gamer and common result of all gamers
        /// </summary>
        /// <param name="comparedNum">result of the gamer</param>
        /// <param name="comparatorNum">result of the gamers</param>
        /// <returns></returns>
        internal static bool ScoreChecker(int comparedNum, int comparatorNum)
        {
            return (comparedNum == comparatorNum);
        }
    }
}
