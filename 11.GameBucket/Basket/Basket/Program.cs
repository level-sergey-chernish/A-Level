using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.Classes;

namespace Basket
{
    class Program
    {
        static void Main(string[] args)
        {
            int attempts = 1;
            Game.BasketScoreMin = 40;
            Game.BasketScoreMax = 140;
            Game.GuessedNumber = Game.Randomizer(Game.BasketScoreMin, Game.BasketScoreMax);
            Game.AttempsToToGuess = 100;

            Gamer ordGamer = new Gamer("Vasya", new List<int>(), Gamer.GamersType.ordinary);
            Gamer notepadGamer = new GamerNotepad("Petya", new List<int>(), Gamer.GamersType.notepad);
            Gamer gamerUber = new GamerUber("Kolya", new List<int>() { Game.BasketScoreMin - 1 }, Gamer.GamersType.uber);
            Gamer gamerCheeter = new GamerCheeter("Sasha", new List<int>(), Gamer.GamersType.cheeter);
            Gamer gamerUberCheeter = new GamerUberCheeter("Vitya", new List<int>() { Game.BasketScoreMin - 1 }, Gamer.GamersType.uberCheeter);

            while (attempts < Game.AttempsToToGuess)
            {
                Console.Clear();
                Console.WriteLine("Guessing...{0}", attempts);

                ordGamer.Guessing();
                if (Game.ScoreChecker(ordGamer.GamerGuessingResults.Last(), Game.GuessedNumber))
                {
                    Console.WriteLine($"{ordGamer.GamerName} Win! His guess score {ordGamer.GamerGuessingResults.Last()}");
                    break;
                }

                notepadGamer.Guessing();
                if (Game.ScoreChecker(notepadGamer.GamerGuessingResults.Last(), Game.GuessedNumber))
                {
                    Console.WriteLine($"{notepadGamer.GamerName} Win! His guess score {notepadGamer.GamerGuessingResults.Last()}");
                    break;
                }

                gamerUber.Guessing();
                if (Game.ScoreChecker(gamerUber.GamerGuessingResults.Last(), Game.GuessedNumber))
                {
                    Console.WriteLine($"{gamerUber.GamerName} Win! His guess score {gamerUber.GamerGuessingResults.Last()}");
                    break;
                }

                gamerCheeter.Guessing();
                if (Game.ScoreChecker(gamerCheeter.GamerGuessingResults.Last(), Game.GuessedNumber))
                {
                    Console.WriteLine($"{gamerCheeter.GamerName} Win! His guess score {gamerCheeter.GamerGuessingResults.Last()}");
                    break;
                }

                gamerUberCheeter.Guessing();
                if (Game.ScoreChecker(gamerUberCheeter.GamerGuessingResults.Last(), Game.GuessedNumber))
                {
                    Console.WriteLine($"{gamerUberCheeter.GamerName} Win! His guess score {gamerUberCheeter.GamerGuessingResults.Last()}");
                    break;
                }
                attempts++;
            }
            Console.WriteLine($"Guessed weight of the basket is {Game.GuessedNumber}");
        }
    }
}
