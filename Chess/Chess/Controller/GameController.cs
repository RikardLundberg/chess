﻿using System;
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
                    board[i, j] = new Square(i, j);

            SquareUtils.board = board;

            // setup pieces
            blackPieces = new IPiece[] { new Bishop(board[2, 3], PieceColor.Black) };
            whitePieces = new IPiece[] { new Bishop(board[6, 5], PieceColor.White) };
            foreach (IPiece piece in blackPieces)
                Window.DrawPiece(piece);
            foreach (IPiece piece in whitePieces)
                Window.DrawPiece(piece);
        }

        public void SelectSquare(string squareName)
        {
            var NewSelection = SquareUtils.GetSquareFromName(squareName);

            if (CurrentSelectedSquare == null)
                Window.SelectSquare(NewSelection.Name);
            else if (CurrentSelectedSquare.Name != NewSelection.Name)
            {
                if (CurrentSelectedSquare.Piece.GetValidMoves().Where(x => x.Name == NewSelection.Name).Count() > 0)
                {
                    //move
                }
            }

        }

        private void MovePiece(Square from, Square to, IPiece piece)
        {

        }
    }
}
