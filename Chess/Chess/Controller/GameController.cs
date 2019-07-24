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
        private Piece[] blackPieces;
        private Piece[] whitePieces;
        private MainWindow Window;
        private Square CurrentSelectedSquare;
        private PieceColor CurrentPlayer;

        public GameController(MainWindow Window)
        {
            this.Window = Window;
        }

        public void StartGame()
        {
            CurrentPlayer = PieceColor.White;
            Window.UpdateCurrentPlayerLabel(CurrentPlayer.ToString());

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

        private Piece[] PlaceBlackPieces(Square[,] board)
        {
            return new Piece[]
            {
                PlacePiece(new Bishop(board[2, 7], PieceColor.Black)),
                PlacePiece(new Bishop(board[5, 7], PieceColor.Black)),

                PlacePiece(new Pawn(board[0, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[1, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[2, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[3, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[4, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[5, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[6, 6], PieceColor.Black)),
                PlacePiece(new Pawn(board[7, 6], PieceColor.Black)),

                PlacePiece(new Knight(board[1, 7], PieceColor.Black)),
                PlacePiece(new Knight(board[6, 7], PieceColor.Black)),

                PlacePiece(new Rook(board[0, 7], PieceColor.Black)),
                PlacePiece(new Rook(board[7, 7], PieceColor.Black)),

                PlacePiece(new Queen(board[3, 7], PieceColor.Black)),

                PlacePiece(new King(board[4, 7], PieceColor.Black))

            };
        }

        private Piece[] PlaceWhitePieces(Square[,] board)
        {
            return new Piece[]
            {
                PlacePiece(new Bishop(board[2, 0], PieceColor.White)),
                PlacePiece(new Bishop(board[5, 0], PieceColor.White)),

                PlacePiece(new Pawn(board[0, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[1, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[2, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[3, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[4, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[5, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[6, 1], PieceColor.White)),
                PlacePiece(new Pawn(board[7, 1], PieceColor.White)),

                PlacePiece(new Knight(board[1, 0], PieceColor.White)),
                PlacePiece(new Knight(board[6, 0], PieceColor.White)),

                PlacePiece(new Rook(board[0, 0], PieceColor.White)),
                PlacePiece(new Rook(board[7, 0], PieceColor.White)),

                PlacePiece(new Queen(board[3, 0], PieceColor.White)),

                PlacePiece(new King(board[4, 0], PieceColor.White))

            };
        }

        private Piece PlacePiece(Piece piece)
        {
            piece.Square.Piece = piece;
            Window.DrawPiece(piece, piece.Square.Name);
            return piece;
        }

        public void SelectSquare(string squareName)
        {
            var NewSelection = SquareUtils.GetSquareFromName(squareName);
            Window.UpdateWarning("");

            if (CurrentSelectedSquare == null) // no preselection
            {
                if (NewSelection.Piece != null && NewSelection.Piece.Color != CurrentPlayer)
                {
                    Window.UpdateWarning("Piece cannot move this turn");
                    return;
                }

                Window.SelectSquare(NewSelection.Name);
                CurrentSelectedSquare = NewSelection;
                if (NewSelection.Piece != null)
                {
                    Window.HighlightSquares(NewSelection.Piece.GetValidMoves().Select(x => x.Name).ToArray());
                }
            }
            else if (CurrentSelectedSquare.Name != NewSelection.Name) // found preselection
            {

                if (CurrentSelectedSquare.Piece != null)
                    Window.UnHighlightSquares(CurrentSelectedSquare.Piece.GetValidMoves().Select(x => x.Name).ToArray());

                if (CurrentSelectedSquare.Piece == null)
                {
                    Window.UnselectSquare(CurrentSelectedSquare.Name);
                    Window.SelectSquare(NewSelection.Name);
                    CurrentSelectedSquare = NewSelection;
                }
                else if (CurrentSelectedSquare.Piece.GetValidMoves().Where(x => x.Name == NewSelection.Name).Count() > 0)
                {
                    //move
                    MovePiece(CurrentSelectedSquare, NewSelection, CurrentSelectedSquare.Piece);
                    CurrentSelectedSquare = null;
                    CurrentPlayer = CurrentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
                    Window.UpdateCurrentPlayerLabel(CurrentPlayer.ToString());
                }
                else
                {
                    Window.UnselectSquare(CurrentSelectedSquare.Name);
                    CurrentSelectedSquare = null;
                }
            }

        }

        private void MovePiece(Square from, Square to, Piece piece)
        {
            Window.UnselectSquare(from.Name);
            Window.ClearSquare(from.Name);
            from.Piece = null;
            to.Piece = piece;
            piece.Square = to;
            Window.DrawPiece(piece, to.Name);
        }
    }
}
