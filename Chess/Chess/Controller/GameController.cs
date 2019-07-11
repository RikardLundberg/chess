using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Model;

namespace Chess.Controller
{
    public static class GameController
    {
        private static Square[,] board;
        private static IPiece[] blackPieces;
        private static IPiece[] whitePieces;

        public static void StartGame()
        {

        } 

        public static void SetupGame()
        {
            board = new Square[8, 8];
            blackPieces = new IPiece[] { new Bishop(board[2, 3]) };
            whitePieces = new IPiece[] { new Bishop(board[6, 5]) };
        }

        private static void MovePiece(Square from, Square to, IPiece piece)
        {

        }
    }
}
