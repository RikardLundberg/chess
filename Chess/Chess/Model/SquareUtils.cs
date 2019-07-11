using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public static class SquareUtils
    {
        public static Square[,] board { get; set; }

        public static Square[] GetDiagonals(Square CurrentPosition)
        {
            throw new NotImplementedException();
        }

        public static Square[] GetStraights(Square CurrentPosition)
        {
            throw new NotImplementedException();
        }

        public static Square[] GetKnightSquares(Square CurrentPosition)
        {
            throw new NotImplementedException();
        }


        public static Square GetSquareFromName(string name)
        {
            char[] characters = name.ToCharArray();
            int column = 0;
            switch (characters[0])
            {
                case 'A': column = 0; break;
                case 'B': column = 1; break;
                case 'C': column = 2; break;
                case 'D': column = 3; break;
                case 'E': column = 4; break;
                case 'F': column = 5; break;
                case 'G': column = 6; break;
                case 'H': column = 7; break;
            }
            int row = Int32.Parse(characters[1].ToString());
            return board[column, row];
        }
    }
}
