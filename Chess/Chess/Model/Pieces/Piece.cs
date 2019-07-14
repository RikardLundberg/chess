using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public enum PieceType { Bishop }
    public enum PieceColor { Black, White}

    public abstract class Piece
    {
        public abstract bool IsAlive { get; set; }
        public abstract Square[] GetValidMoves();
        public abstract Square Square { get; set; }
        public abstract PieceType Type { get; }
        public abstract PieceColor Color { get; set; }
        public abstract override string ToString();
    }
}
