using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;

namespace Basket
{
    class GamerUber : Gamer
    {
        internal GamerUber(string gamerName, List<int> gamerGuessingResults, GamersType gamerType) :
            base(gamerName, gamerGuessingResults, gamerType)
        {

        }

        /// <summary>
        /// Guessing by stack from Game.BasketScoreMin to Game.BasketScoreMax
        /// </summary>
        protected override void GamerGuessing()
        {
            int guessAttempt = GamerGuessingResults.Last() + 1;
            GamerGuessingResults.Add(guessAttempt);
            Game.CommonGuessingResults.Add(guessAttempt);
        }
    }
}
