using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Bishop : IPiece
    {
        public PieceType Type => PieceType.Bishop;

        public bool IsAlive { get; set; }
        //public Square Square { get; set; }
        public PieceColor Color { get; private set; }

        public Bishop(/*Square position,*/ PieceColor color)
        {
            //Square = position;
            IsAlive = true;
            Color = color;
        }

        public Square[] GetValidMoves(Square square)
        {
            return SquareUtils.GetDiagonals(square, Color);
        }
    }
}
