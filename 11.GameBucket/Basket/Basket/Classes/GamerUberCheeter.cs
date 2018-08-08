using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;

namespace Basket
{
    class GamerUberCheeter : Gamer
    {
        internal GamerUberCheeter(string gamerName, List<int> gamerGuessingResults, GamersType gamerType) :
            base(gamerName, gamerGuessingResults, gamerType)
        {

        }

        /// <summary>
        /// Guessing by stack from Game.BasketScoreMin to Game.BasketScoreMax
        /// but skip used result of other gamers
        /// </summary>
        protected override void GamerGuessing()
        {
            int guessAttempt = GamerGuessingResults.Last();
            bool exist;

            do
            {
                exist = false;
                guessAttempt++;
                for (var i = 0; i < Game.CommonGuessingResults.Count; i++)
                {
                    if (guessAttempt == Game.CommonGuessingResults.ElementAt(i))
                    {
                        exist = true;
                    }
                }
            } while (exist);

            GamerGuessingResults.Add(guessAttempt);
            Game.CommonGuessingResults.Add(guessAttempt);
        }
    }
}
