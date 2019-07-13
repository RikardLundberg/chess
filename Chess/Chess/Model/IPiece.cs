using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public enum PieceType { Bishop }
    public enum PieceColor { Black, White}

    public interface IPiece
    {
        bool IsAlive { get; set; }
        Square[] GetValidMoves(Square square);
        //Square Square { get; set; }
        PieceType Type { get; }
        PieceColor Color { get; }
    }
}
