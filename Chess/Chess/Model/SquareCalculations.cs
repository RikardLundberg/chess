using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public static class SquareCalculations
    {
        public static Square GetSquareFromName(Square[,] board, string name)
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
