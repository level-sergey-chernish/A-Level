using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;

namespace Basket
{
    class GamerNotepad : Gamer
    {
        internal GamerNotepad(string gamerName, List<int> gamerGuessingResults, GamersType gamerType) : base(gamerName, gamerGuessingResults, gamerType)
        {

        }

        /// <summary>
        /// Guessing randomly between Game.BasketScoreMin - Game.BasketScoreMax
        /// but doesn't repeat personal previouse results
        /// </summary>
        protected override void GamerGuessing()
        {
            int guessAttempt;
            bool exist;
            do
            {
                exist = false;
                guessAttempt = Game.Randomizer(Game.BasketScoreMin, Game.BasketScoreMax);
                for (var i = 0; i < GamerGuessingResults.Count; i++)
                {
                    if (guessAttempt == GamerGuessingResults.ElementAt(i))
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
