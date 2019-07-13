using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Model;

namespace Chess.Controller
{
    public class GameController
    {
        private IPiece[] blackPieces;
        private IPiece[] whitePieces;
        private MainWindow Window;
        private Square CurrentSelectedSquare;

        public GameController(MainWindow Window)
        {
            this.Window = Window;
        }

        public void StartGame()
        {

        }

        public void SetupGame()
        {
            // setup board
            Square[,] board = new Square[8, 8];
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                {
                    board[i, j] = new Square(i, j);
                    Window.ClearSquare(board[i, j].Name);
                }

            SquareUtils.board = board;

            // setup pieces
            blackPieces = PlaceBlackPieces(board);
            whitePieces = PlaceWhitePieces(board);
        }

        private IPiece[] PlaceBlackPieces(Square [,] board)
        {
            return new IPiece []
            {
                PlacePiece(new Bishop(PieceColor.Black), board[2, 3])
            };
        }

        private IPiece[] PlaceWhitePieces(Square[,] board)
        {
            return new IPiece []
            {
                PlacePiece(new Bishop(PieceColor.White), board[6, 5])
            };
        }

        private IPiece PlacePiece(IPiece piece, Square square)
        {
            square.Piece = piece;
            Window.DrawPiece(piece, square.Name);
            return piece;
        }

        public void SelectSquare(string squareName)
        {
            var NewSelection = SquareUtils.GetSquareFromName(squareName);

            if (CurrentSelectedSquare == null)
            {
                Window.SelectSquare(NewSelection.Name);
                CurrentSelectedSquare = NewSelection;
            }
            else if (CurrentSelectedSquare.Name != NewSelection.Name)
            {
                if (CurrentSelectedSquare.Piece == null)
                {
                    Window.UnselectSquare(CurrentSelectedSquare.Name);
                    Window.SelectSquare(NewSelection.Name);
                    CurrentSelectedSquare = NewSelection;
                }
                else if (CurrentSelectedSquare.Piece.GetValidMoves(CurrentSelectedSquare).Where(x => x.Name == NewSelection.Name).Count() > 0)
                {
                    //move
                    MovePiece(CurrentSelectedSquare, NewSelection, CurrentSelectedSquare.Piece);
                    CurrentSelectedSquare = null;
                }
                else
                {
                    Window.UnselectSquare(CurrentSelectedSquare.Name);
                    CurrentSelectedSquare = null;
                }
            }

        }

        private void MovePiece(Square from, Square to, IPiece piece)
        {
            Window.UnselectSquare(from.Name);
            Window.ClearSquare(from.Name);
            from.Piece = null;
            to.Piece = piece;
            Window.DrawPiece(piece, to.Name);
        }
    }
}
