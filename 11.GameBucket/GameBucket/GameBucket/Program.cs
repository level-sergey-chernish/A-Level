using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBucket.Classes;

namespace GameBucket
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamerQuantity = 5;
            int bucketScoreMin = 40;
            int bucketScoreMax = 45;
            BucketInitResult gameBucket = new BucketInitResult();
            Random rnd = new Random();
            gameBucket.BacketScore = rnd.Next(bucketScoreMin, bucketScoreMax);
            gameBucket.CurrentCommonResult = new int[gamerQuantity * (bucketScoreMax - bucketScoreMin + 1)];

            Gamer ordGamer = new Gamer("Vasya", new int[bucketScoreMax - bucketScoreMin + 1], Gamer.GamerTypes.ordinary);
             
            Gamer notepadGamer = new GamerNotepad("Petya", new int[bucketScoreMax - bucketScoreMin + 1], Gamer.GamerTypes.notepad);

            var i = 0;
            var j = 0;
            while( i < bucketScoreMax - bucketScoreMin + 1)
            {
                ordGamer.Guessing(ordGamer.CurrentGamerResults, bucketScoreMin, bucketScoreMax, i);
                gameBucket.CurrentCommonResult[j] = ordGamer.CurrentGamerResults[i];
                notepadGamer.Guessing(notepadGamer.CurrentGamerResults, bucketScoreMin, bucketScoreMax, i);
                gameBucket.CurrentCommonResult[j + 1] = notepadGamer.CurrentGamerResults[i];
                i++;
                j += (gamerQuantity);
            }

            for (i = 0; i < notepadGamer.CurrentGamerResults.Length; i++)
            {
                Console.Write(notepadGamer.CurrentGamerResults[i] + " ");
            }
            Console.WriteLine();
            for (i = 0; i < gameBucket.CurrentCommonResult[i]; i++)
            {
                Console.Write(gameBucket.CurrentCommonResult[i] + " ");
            }
        }
    }
}
