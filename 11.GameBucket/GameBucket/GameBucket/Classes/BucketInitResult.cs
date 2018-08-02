using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBucket.Classes
{
    class BucketInitResult
    {
        public int BacketScore { get; set; }

        public int Attempts { get; set; }

        public int [] CurrentCommonResult { get; set; }


        public void CheckWinScore()
        {
            for (var i = 0; i < CurrentCommonResult.Length; i++)
            {
                if (CurrentCommonResult[i] == BacketScore)
                {
                    Console.WriteLine($"YOU ARE GUESS! - " +
                        $"Bucket weight is {CurrentCommonResult[i]} pounds");
                    break;
                }
            }
        }

        public static int CheckAttemptLimitScore(int[] arr, ref int num)
        {
            int value;
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = Math.Abs(num - arr[i]);
            }
            value = arr.Min();
            return value;
        }
    }
}
