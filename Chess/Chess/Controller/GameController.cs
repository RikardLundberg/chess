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
        private static MainWindow window;

        public static void StartGame()
        {

        } 

        public static void SetupGame(MainWindow Window)
        {
            window = Window;
            board = new Square[8, 8];
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                    board[i, j] = new Square(i, j);

            blackPieces = new IPiece[] { new Bishop(board[2, 3], PieceColor.Black) };
            whitePieces = new IPiece[] { new Bishop(board[6, 5], PieceColor.White) };
            foreach (IPiece piece in blackPieces)
                window.DrawPiece(piece);
            foreach (IPiece piece in whitePieces)
                window.DrawPiece(piece);
        }

        private static void MovePiece(Square from, Square to, IPiece piece)
        {

        }
    }
}
