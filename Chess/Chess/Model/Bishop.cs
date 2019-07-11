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
        public Square Position { get; set; }

        public Bishop(Square position)
        {
            Position = position;
            IsAlive = true;
        }

        public Square[] GetValidMoves()
        {
            throw new NotImplementedException();
        }
    }
}
