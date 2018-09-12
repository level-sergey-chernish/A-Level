using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;

namespace Basket
{
    class GamerCheeter : Gamer
    {
        internal GamerCheeter(string gamerName, List<int> gamerGuessingResults, GamersType gamerType) :
            base(gamerName, gamerGuessingResults, gamerType)
        {

        }

        /// <summary>
        /// Guessing randomly between Game.BasketScoreMin - Game.BasketScoreMax
        /// but but skip used results of other gamers
        /// </summary>
        protected override void GamerGuessing()
        {
            int guessAttempt;
            bool exist;
            do
            {
                exist = false;
                guessAttempt = Game.Randomizer(Game.BasketScoreMin, Game.BasketScoreMax);
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
