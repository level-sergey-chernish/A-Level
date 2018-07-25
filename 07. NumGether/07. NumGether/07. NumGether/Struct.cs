using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumEater
{
    public struct GameField
    {
        public int FieldSize;
        public string BorderStyle;
        public string FieldStyle;
        public string[,] FieldArr;

        public GameField(
            int fSize,
            string[,] fArr,
            string bStyle = "█",
            string fStyle = "▒"
            )
        {
            FieldSize = fSize;
            FieldArr = fArr;
            BorderStyle = bStyle;
            FieldStyle = fStyle;
        }
    }

    public struct Entity
    {
        public int InitValue;
        public int CoordX;
        public int CoordY;
        public KeyType KeyType;

        public Entity(
            int iValue,
            int cX,
            int cY,
            KeyType kType)
        {
            InitValue = iValue;
            CoordX = cX;
            CoordY = cY;
            KeyType = kType;
        }
    }

    public enum KeyType
    {
        NoKey,
        Up,
        Down,
        Left,
        Right,
        Esc
    }
}
