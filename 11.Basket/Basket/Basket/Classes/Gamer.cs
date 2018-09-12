using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;
using Basket.Interfaces;

namespace Basket.Classes
{
    class Gamer : IGamer
    {
        internal string GamerName { get; set; }

        internal List<int> GamerGuessingResults { get; set; }

        internal GamersType GamerType;

        internal Gamer(string gamerName, List<int> gamerGuessingResults, GamersType gamerType)
        {
            GamerName = gamerName;
            GamerGuessingResults = gamerGuessingResults;
            GamerType = gamerType;
        }

        public virtual void Guessing()
        {
            GamerGuessing();
        }


        /// <summary>
        /// Guessing randomly between Game.BasketScoreMin - Game.BasketScoreMax
        /// </summary>
        protected virtual void GamerGuessing()
        {
            int guessAttempt = Game.Randomizer(Game.BasketScoreMin, Game.BasketScoreMax);
            GamerGuessingResults.Add(guessAttempt);
            Game.CommonGuessingResults.Add(guessAttempt);
        }

        internal enum GamersType
        {
            ordinary,
            notepad,
            uber,
            cheeter,
            uberCheeter
        }
    }
}
