using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Queen : Piece
    {
        public override string ToString()
        {
            return Color == PieceColor.White ? "♕" : "♛";
        }
        public override PieceType Type => PieceType.Bishop;

        public override bool IsAlive { get; set; }
        public override Square Square { get; set; }
        public override PieceColor Color { get; set; }

        public Queen(Square position, PieceColor color)
        {
            Square = position;
            IsAlive = true;
            Color = color;
        }

        public override Square[] GetValidMoves()
        {
            var squares = SquareUtils.GetDiagonals(Square, Color);
            return squares.Concat(SquareUtils.GetStraights(Square, Color)).ToArray();
        }
    }
}
