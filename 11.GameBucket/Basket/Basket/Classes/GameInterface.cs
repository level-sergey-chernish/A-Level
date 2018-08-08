using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Classes
{
    class GameInterface
    {

        internal static void MainMenu(ref List<Gamer> gamerList,
            ref List<GamerNotepad> notepadGamerList,
            ref List<GamerUber> gamerUberList,
            ref List<GamerCheeter> gamerCheeterList,
            ref List<GamerUberCheeter> gamerUberCheeterList)
        {
            List<Gamer> GamerList = gamerList;
            List<GamerNotepad> NotepadGamerList = notepadGamerList;
            List<GamerUber> GamerUberList = gamerUberList;
            List<GamerCheeter> GamerCheeterList = gamerCheeterList;
            List<GamerUberCheeter> GamerUberCheeterList = gamerUberCheeterList;

            bool menuExit = false;
            string caseSwitch;
            Console.Clear();
            do
            {
                MenuHeader("You have a basket with random weight.");
                MenuHeader("You have to add some types of the gamers which " +
                    "have to guess the weight.\n");
                MenuHeader(" TYPES OF THE GAMERS:");
                MenuHeader("Ordinary Gamer - guesses the numbers by accident. Any logic");
                MenuHeader("Gamer-Notepad - guesses the numbers by accident but never " +
                    "repeats personal previous results");
                MenuHeader("Gamer-Uber - guesses like \"gethers duck in the row\" ");
                MenuHeader("Gamer-Cheeter - guesses the numbers by accident but " +
                    "skip previous results of all gamers");
                MenuHeader("Gamer-Uber-Cheeter - \"gethers duck in the row\" but " +
                    "skip previous results of all gamers");
                MenuHeader("\n MAKE YOUR CHOISE:");
                MenuChoise("1 - add gamer\n2 - start guessing\n\nq - quit");
                Console.Write(">>:");
                caseSwitch = Console.ReadLine().ToLower();
                switch (caseSwitch)
                {
                    case "1":
                        Console.Clear();
                        menuExit = true;
                        ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                        break;
                    case "2":
                        Console.Clear();
                        StartGuessing(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                        menuExit = true;
                        break;
                    case "q":
                        menuExit = true;
                        break;
                    default:
                        Console.Clear();
                        menuExit = true;
                        Alert("WHAT?! - Have You been reading menu, bastard?! ");
                        Thread.Sleep(200);
                        MainMenu(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList); ;
                        break;
                }
            } while (!menuExit);
        }

        private static void ChooseGamerType(ref List<Gamer> gamerList,
            ref List<GamerNotepad> notepadGamerList,
            ref List<GamerUber> gamerUberList,
            ref List<GamerCheeter> gamerCheeterList,
            ref List<GamerUberCheeter> gamerUberCheeterList)
        {
            List<Gamer> GamerList = gamerList;
            List<GamerNotepad> NotepadGamerList = notepadGamerList;
            List<GamerUber> GamerUberList = gamerUberList;
            List<GamerCheeter> GamerCheeterList = gamerCheeterList;
            List<GamerUberCheeter> GamerUberCheeterList = gamerUberCheeterList;

            bool menuExit = false;
            string caseSwitch;
            Console.Clear();

            MenuHeader("\n MAKE YOUR CHOISE:");
            MenuChoise("1 - add Ordinary Gamer\n2 - add Gamer-Notepad\n" +
                "3 - add Gamer-Uber\n4 - add Gamer-Cheeter\n5 - add Gamer-User-Cheeter\n\n" +
                "r - return to previos menu");
            Console.Write(">>:");
            caseSwitch = Console.ReadLine().ToLower();
            switch (caseSwitch)
            {
                case "1":
                    Console.Clear();
                    GamerList.Add(new Gamer(AddGamerName(), new List<int>(), Gamer.GamersType.ordinary));
                    ChooseGamerType(ref GamerList,
                                   ref NotepadGamerList,
                                   ref GamerUberList,
                                   ref GamerCheeterList,
                                   ref GamerUberCheeterList);
                    menuExit = true;
                    break;
                case "2":
                    Console.Clear();
                    GamerList.Add(new Gamer(AddGamerName(), new List<int>(), Gamer.GamersType.notepad));
                    ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    menuExit = true;
                    break;
                case "3":
                    Console.Clear();
                    GamerList.Add(new Gamer(AddGamerName(), new List<int>() { Game.BasketScoreMin - 1 },
                        Gamer.GamersType.uber));
                    ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    menuExit = true;
                    break;
                case "4":
                    Console.Clear();
                    GamerList.Add(new Gamer(AddGamerName(), new List<int>(), Gamer.GamersType.cheeter));
                    ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    menuExit = true;
                    break;
                case "5":
                    Console.Clear();
                    GamerList.Add(new Gamer(AddGamerName(), new List<int>(), Gamer.GamersType.uberCheeter));
                    ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    menuExit = true;
                    break;
                case "r":
                    Console.Clear();
                    menuExit = true;
                    MainMenu(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    break;
                default:
                    Console.Clear();
                    menuExit = true;
                    Alert("WHAT?! - Have U read the menu, bastard?! ");
                    Thread.Sleep(200);
                    ChooseGamerType(ref GamerList,
                            ref NotepadGamerList,
                            ref GamerUberList,
                            ref GamerCheeterList,
                            ref GamerUberCheeterList);
                    break;
            } while (!menuExit) ;
        }

        private static string AddGamerName()
        {
            string gamerName;
            Console.Clear();
            do
            {
                MenuHeader("Input Gamer name for identification (should be not empty, or spacebar!)");
                Console.Write(">>:");
                gamerName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(gamerName))
                {
                    break;
                }
                Thread.Sleep(200);
                Alert("WHAT?! - Have U read the menu, bastard?! ");
                Console.Clear();
            } while (true);

            return gamerName;
        }

        private static void StartGuessing(ref List<Gamer> gamerList,
            ref List<GamerNotepad> notepadGamerList,
            ref List<GamerUber> gamerUberList,
            ref List<GamerCheeter> gamerCheeterList,
            ref List<GamerUberCheeter> gamerUberCheeterList)
        {
            List<Gamer> GamerList = gamerList;
            List<GamerNotepad> NotepadGamerList = notepadGamerList;
            List<GamerUber> GamerUberList = gamerUberList;
            List<GamerCheeter> GamerCheeterList = gamerCheeterList;
            List<GamerUberCheeter> GamerUberCheeterList = gamerUberCheeterList;

            int attempts = 1;
            while (attempts < Game.AttempsToToGuess)
            {
                Console.Clear();
                Notify($"Guessing...attempts: {attempts}");

                for (var i = 0; i < GamerList.Count; i++)
                {
                    GamerList.ElementAt(i).Guessing();
                    if (Game.ScoreChecker(GamerList.ElementAt(i).GamerGuessingResults.Last(), Game.GuessedNumber))
                    {
                        Alert($"{GamerList.ElementAt(i).GamerType} " +
                            $"{GamerList.ElementAt(i).GamerName} won! He has guessed " +
                            $"{GamerList.ElementAt(i).GamerGuessingResults.Last()}");
                        attempts = Game.AttempsToToGuess;
                    }
                }

                for (var i = 0; i < NotepadGamerList.Count; i++)
                {
                    NotepadGamerList.ElementAt(i).Guessing();
                    if (Game.ScoreChecker(NotepadGamerList.ElementAt(i).GamerGuessingResults.Last(), Game.GuessedNumber))
                    {
                        Alert($"{NotepadGamerList.ElementAt(i).GamerType} " +
                            $"{NotepadGamerList.ElementAt(i).GamerName} won! He has guessed " +
                            $"{NotepadGamerList.ElementAt(i).GamerGuessingResults.Last()}");
                        attempts = Game.AttempsToToGuess;
                    }
                }

                for (var i = 0; i < GamerUberList.Count; i++)
                {
                    GamerUberList.ElementAt(i).Guessing();
                    if (Game.ScoreChecker(GamerUberList.ElementAt(i).GamerGuessingResults.Last(), Game.GuessedNumber))
                    {
                        Alert($"{GamerUberList.ElementAt(i).GamerType} " +
                            $"{GamerUberList.ElementAt(i).GamerName} won! He has guessed " +
                            $"{GamerUberList.ElementAt(i).GamerGuessingResults.Last()}");
                        attempts = Game.AttempsToToGuess;
                    }
                }

                for (var i = 0; i < GamerCheeterList.Count; i++)
                {
                    GamerCheeterList.ElementAt(i).Guessing();
                    if (Game.ScoreChecker(GamerCheeterList.ElementAt(i).GamerGuessingResults.Last(), Game.GuessedNumber))
                    {
                        Alert($"{GamerCheeterList.ElementAt(i).GamerType} " +
                            $"{GamerCheeterList.ElementAt(i).GamerName} won! He has guessed " +
                            $"{GamerCheeterList.ElementAt(i).GamerGuessingResults.Last()}");
                        attempts = Game.AttempsToToGuess;
                    }
                }

                for (var i = 0; i < GamerUberCheeterList.Count; i++)
                {
                    GamerUberCheeterList.ElementAt(i).Guessing();
                    if (Game.ScoreChecker(GamerUberCheeterList.ElementAt(i).GamerGuessingResults.Last(), Game.GuessedNumber))
                    {
                        Alert($"{GamerUberCheeterList.ElementAt(i).GamerType} " +
                            $"{GamerUberCheeterList.ElementAt(i).GamerName} won! He has guessed " +
                            $"{GamerUberCheeterList.ElementAt(i).GamerGuessingResults.Last()}");
                        attempts = Game.AttempsToToGuess;
                    }
                }

                attempts++;
            }
        }

        private static void MenuHeader(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void Alert(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void Notify(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void MenuChoise(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
