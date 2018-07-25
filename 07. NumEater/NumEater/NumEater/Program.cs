using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NumEater
{
    class Program
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            int fieldSize = 15;
            GameField gameField = new GameField(fieldSize, new string[fieldSize, fieldSize]);

            Entity cursor = new Entity(0, 1, 1, KeyType.NoKey);

            bool letsGame = true;

            Entity target = new Entity(Rnd(-9, 9), Rnd(1, gameField.FieldArr.GetUpperBound(0) - 1),
                Rnd(1, gameField.FieldArr.GetUpperBound(1) - 1), KeyType.NoKey);
            
            do
            {
                ReDraw(ref gameField.FieldArr, ref gameField.FieldStyle, ref gameField.BorderStyle,
                    ref cursor.InitValue, ref cursor.CoordX, ref cursor.CoordY,
                    ref target.InitValue, ref target.CoordX, ref target.CoordY,
                    ref cursor.KeyType);
                cursor.KeyType = KeyPressed(Console.ReadKey(), KeyType.NoKey);
                Console.Clear();
                switch (cursor.KeyType)
                {
                    case KeyType.Left:
                        cursor.CoordY = Movement(cursor.CoordY - 1, fieldSize - 1);

                        break;
                    case KeyType.Right:
                        cursor.CoordY = Movement(cursor.CoordY + 1, fieldSize - 1);
                        break;
                    case KeyType.Up:
                        cursor.CoordX = Movement(cursor.CoordX - 1, fieldSize - 1);
                        break;
                    case KeyType.Down:
                        cursor.CoordX = Movement(cursor.CoordX + 1, fieldSize - 1);
                        break;
                    case KeyType.Esc:
                        Console.Clear();
                        Console.WriteLine("BYE-BYE, DUDE");
                        letsGame = false;
                        break;
                }                
            } while(letsGame);
            
        }
        /// <summary>
        /// Pseudo randomizer
        /// </summary>
        /// <param name="rndMin"></param>
        /// <param name="rndMax"></param>
        /// <returns></returns>
        private static int Rnd(int rndMin, int rndMax)
        {
            int rndValue;
            int rMin = rndMin;
            int rMax = rndMax;
            Random rnd = new Random();
            rndValue = rnd.Next(rMin, rMax);
            return rndValue;
        }

        /// <summary>
        /// Generate array of entities:
        /// gamefield (FiedlArray), cursor (cursor) and target (target)
        /// </summary>
        /// <param name="fArray"></param>
        /// <param name="fStyle"></param>
        /// <param name="bStyle"></param>
        /// <param name="cValue"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="tValue"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        /// <returns></returns>
        private static string [,] FieldArray(string[,] fArray, string fStyle, string bStyle,
            int cValue, int cX, int cY, int tValue, int tX, int tY)
        {
            string[,] fieldArray = fArray;
            string fieldStyle = fStyle;
            string borderStyle = bStyle;
            int cursorValue = cValue;
            int cursorX = cX;
            int cursorY = cY;
            int targetValue = tValue;
            int targetX = tX;
            int targetY = tY;
            string[,] arr = new string [fieldArray.GetUpperBound(0), fieldArray.GetUpperBound(1)];
            for (var i = 0; i <= fieldArray.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= fieldArray.GetUpperBound(1); j++)
                {
                    fieldArray[i,j] = fieldStyle;
                    if (i == 0 ||
                        i == fieldArray.GetUpperBound(0) ||
                        j == 0 ||
                        j == fieldArray.GetUpperBound(1))
                    {
                        fieldArray[i, j] = borderStyle;
                        fieldArray[cursorX, cursorY] = Convert.ToString(cursorValue);
                        fieldArray[targetX, targetY] = Convert.ToString(targetValue);
                    }


                }
            }
            return fieldArray;
        }

        /// <summary>
        /// stdOut of thearray of entities:
        /// gamefield (FiedlArray), cursor (cursor) and target (target)
        /// </summary>
        /// <param name="fArray"></param>
        /// <param name="cValue"></param>
        /// <param name="tValue"></param>
        private static void Draw(string[,] fArray, int cValue, int tValue)
        {
            string cursorValue = Convert.ToString(cValue);
            string targetValue = Convert.ToString(tValue);
            string[,] fieldArray = fArray;
            for (var i = 0; i <= fieldArray.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= fieldArray.GetUpperBound(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (fieldArray[i, j] == cursorValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    if (fieldArray[i, j] == targetValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(fieldArray[i, j]);
                    
                    if (fieldArray[i, j].Length > 1)
                    {
                        j += fieldArray[i, j].Length - 1;
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Intercept pressed key arrows
        /// </summary>
        /// <param name="kPressed"></param>
        /// <param name="kType"></param>
        /// <returns></returns>
        private static KeyType KeyPressed(ConsoleKeyInfo kPressed, KeyType kType)
        {
            KeyType keyType = kType;
            ConsoleKeyInfo keyPreseed = kPressed;
            if (keyPreseed.Key == ConsoleKey.LeftArrow)
            {
                keyType = KeyType.Left;
            }
            if (keyPreseed.Key == ConsoleKey.RightArrow)
            {
                keyType = KeyType.Right;
            }
            if (keyPreseed.Key == ConsoleKey.UpArrow)
            {
                keyType = KeyType.Up;
            }
            if (keyPreseed.Key == ConsoleKey.DownArrow)
            {
                keyType = KeyType.Down;
            }
            if (keyPreseed.Key == ConsoleKey.Escape)
            {
                keyType = KeyType.Esc;
            }
            return keyType;
        }

        /// <summary>
        /// Shift cursor to opositesideofthegame field
        /// if it ison borderside of the game field
        /// </summary>
        /// <param name="sCoord"></param>
        /// <param name="fSize"></param>
        /// <returns></returns>
        private static int Movement(int sCoord, int fSize)
        {
            int shiftCoordinate = sCoord;
            int fieldSize = fSize;

            if (shiftCoordinate == fSize)
            {
                shiftCoordinate = 1;
            }
            if (shiftCoordinate == 0)
            {
                shiftCoordinate = fSize - 1;
            }
            return shiftCoordinate;
        }

        /// <summary>
        /// This is full tresh - just experiment with ref out vras in methods
        /// Fuctional can be implemeted by Draw(...). Just refunction
        /// </summary>
        /// <param name="fArray"></param>
        /// <param name="fStyle"></param>
        /// <param name="bStyle"></param>
        /// <param name="cValue"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        /// <param name="tValue"></param>
        /// <param name="tX"></param>
        /// <param name="tY"></param>
        /// <param name="kType"></param>
        private static void ReDraw(ref string[,] fArray, ref string fStyle, ref string bStyle,
            ref int cValue, ref int cX, ref int cY, ref int tValue, ref int tX, ref int tY, ref KeyType kType)
        {
            if ((cX == tX) && (cY == tY))
            {
                Console.Beep();
                cValue += tValue;
                tValue = Rnd(-9, 9);
                tX = Rnd(1, fArray.GetUpperBound(0) - 1);
                Thread.Sleep(10);
                tY = Rnd(1, fArray.GetUpperBound(1) - 1);
            }
            Draw(FieldArray(fArray, fStyle, bStyle, cValue, cX, cY, tValue, tX, tY),
                            cValue, tValue);
            Console.Write($"Pressed key:{kType}\nCursor coordinates: [{cX},{cY}]\nCursor value:{cValue}\n" +
                $"Target coordinates: [{tX},{tY}]\nTarget value:{tValue}\n" +
                $"Press Esc to quit");
        }

    }
}
