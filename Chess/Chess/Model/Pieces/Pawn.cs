using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Pawn : Piece
    {
        public override string ToString()
        {
            return Color == PieceColor.White ? "♙" : "♟";
        }
        public override PieceType Type => PieceType.Bishop;

        public override bool IsAlive { get; set; }
        public override Square Square { get; set; }
        public Square StartPosition { get; set; }
        public int MovingDirection { get; set; }
        public override PieceColor Color { get; set; }

        public Pawn(Square position, PieceColor color)
        {
            Square = position;
            StartPosition = position;
            MovingDirection = color == PieceColor.White ? 1 : -1;
            IsAlive = true;
            Color = color;
        }

        public override Square[] GetValidMoves()
        {
            return SquareUtils.GetPawnMoveSquares(Square, this);
        }
    }
}
