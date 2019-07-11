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
        public Square Square { get; set; }
        private PieceColor color { get; set; }
        public PieceColor Color => color;

        public Bishop(Square position, PieceColor color)
        {
            Square = position;
            IsAlive = true;
            this.color = color;
        }

        public Square[] GetValidMoves()
        {
            throw new NotImplementedException();
        }
    }
}
