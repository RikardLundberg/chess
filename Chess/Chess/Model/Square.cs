using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Square
    {
        public string Name { get; set; }
        public IPiece Piece { get; set; }

        public static Square GetSquare()
        {
            var square = new Square() { Name = "" };
            return square;
        }

    }
}
