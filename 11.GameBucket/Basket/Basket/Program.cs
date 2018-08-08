using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Basket.Classes;

namespace Basket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Gamer> GamerList = new List<Gamer>();
            List<GamerNotepad> NotepadGamerList = new List<GamerNotepad>();
            List<GamerUber> GamerUberList = new List<GamerUber>();
            List<GamerCheeter> GamerCheeterList = new List<GamerCheeter>();
            List<GamerUberCheeter> GamerUberCheeterList = new List<GamerUberCheeter>();

            GameInterface.MainMenu(ref GamerList,
                    ref NotepadGamerList,
                    ref GamerUberList,
                    ref GamerCheeterList,
                    ref GamerUberCheeterList);
        }
    }
}
