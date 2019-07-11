using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Square
    {
        public string Name { get { return GetSquareName(); } }
        public IPiece Piece { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public Square(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public string GetSquareName()
        {
            string name = "";
            switch (Column)
            {
                case 0: name += "A"; break;
                case 1: name += "B"; break;
                case 2: name += "C"; break;
                case 3: name += "D"; break;
                case 4: name += "E"; break;
                case 5: name += "F"; break;
                case 6: name += "G"; break;
                case 7: name += "H"; break;
            }
            name += Row + 1;
            return name;
        }
    }
}
