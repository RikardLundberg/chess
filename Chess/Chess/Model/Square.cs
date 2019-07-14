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
        public Piece Piece { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }

        public Square(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public string GetSquareName()
        {
            return SquareUtils.GetSquareNameFromColAndRow(Column, Row);
        }
    }
}
