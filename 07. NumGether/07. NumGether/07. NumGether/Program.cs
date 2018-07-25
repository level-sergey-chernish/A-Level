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
            int fieldSize = 16;

            GameField gameField = new GameField(fieldSize, new string[fieldSize, fieldSize]);

            Entity cursor = new Entity(0, fieldSize - 2, 1, KeyType.NoKey);

            bool letsGame = true;

            Entity target = new Entity(Rnd(-9, 9), 0,
                Rnd(1, gameField.FieldArr.GetUpperBound(1) - 1), KeyType.NoKey);

            gameField.FieldArr = FieldArray(gameField.FieldArr, gameField.FieldStyle, gameField.BorderStyle,
                cursor.InitValue, cursor.CoordX, cursor.CoordY, target.InitValue, target.CoordX, target.CoordY);
            Draw(gameField.FieldArr, cursor.InitValue, target.InitValue);

            do
            {
                Console.Clear();
                gameField.FieldArr = filterArray(gameField.FieldArr, gameField.FieldStyle, gameField.BorderStyle,
                    ref cursor.InitValue, cursor.CoordX, cursor.CoordY, target.InitValue, target.CoordX, target.CoordY);
                Draw(gameField.FieldArr, cursor.InitValue, target.InitValue);
                cursor.KeyType = KeyPressed(Console.ReadKey(), KeyType.NoKey);
                                switch (cursor.KeyType)
                                {
                                    case KeyType.Left:
                                        cursor.CoordY = Movement(cursor.CoordY - 1, fieldSize - 1);
                                        break;

                                    case KeyType.Right:
                                        cursor.CoordY = Movement(cursor.CoordY + 1, fieldSize - 1);
                                        break;

                                    case KeyType.Esc:
                                        Console.Clear();
                                        Console.WriteLine("BYE-BYE, DUDE");
                                        letsGame = false;
                                        break;
                                } 
            } while (letsGame);

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
        private static string[,] FieldArray(string[,] fArray, string fStyle, string bStyle,
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
            string[,] arr = new string[fieldArray.GetUpperBound(0), fieldArray.GetUpperBound(1)];

            for (var i = 0; i <= fieldArray.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= fieldArray.GetUpperBound(1); j++)
                {
                    fieldArray[i, j] = fieldStyle;
                    if (i == fieldArray.GetUpperBound(0) ||
                        j == 0 ||
                        j == fieldArray.GetUpperBound(1))
                    {
                        fieldArray[i, j] = borderStyle;
                    }
                }
            }
            fieldArray[cursorX, cursorY] = Convert.ToString(cursorValue);
            fieldArray[targetX, targetY] = Convert.ToString(targetValue);
            return fieldArray;
        }

        private static string[,] filterArray(string[,] fArray, string fStyle, string bStyle,
            ref int cValue, int cX, int cY, int tValue, int tX, int tY)
        {
            string[,] fieldArray = fArray;
            string fieldStyle = fStyle;
            string borderStyle = bStyle;
            int cursorX = cX;
            int cursorY = cY;
            int targetValue = tValue;
            int targetX = tX;
            int targetY = tY;

            for (var j = 0; j <= fieldArray.GetUpperBound(1); j++)
            {
                    fieldArray[0, j] = fieldArray[(fieldArray.GetUpperBound(0) - 1), j] = fieldStyle;
                    if (j == 0 || j == fieldArray.GetUpperBound(1))
                    {
                        fieldArray[0, j] = fieldArray[(fieldArray.GetUpperBound(0) - 1), j] = borderStyle;
                    }
            }

            targetValue = Rnd(-9, 9);
            targetX = 0;
            targetY = Rnd(1, fArray.GetUpperBound(1) - 1);
            try
            {
                cValue += Convert.ToInt32(fieldArray[cursorX - 1, cursorY]);
            }
            catch
            {
            }
            fieldArray[cursorX, cursorY] = Convert.ToString(cValue);
            fieldArray[targetX, targetY] = Convert.ToString(targetValue);

            for (var i = (fieldArray.GetUpperBound(0) - 2); i > 0; i--)
            {
                for (var j = (fieldArray.GetUpperBound(1) - 1); j > 1; j--)
                {
                    fieldArray[i, j] = fieldArray[i - 1, j];
                    fieldArray[i - 1, j] = fieldStyle;
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
            Console.Write($"Cursor value:{cursorValue}\n" +
                $"Press Esc to quit");
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
        

    }
}
