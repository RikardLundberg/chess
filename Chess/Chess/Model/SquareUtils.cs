using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public static class SquareUtils
    {
        public static Square[,] board { get; set; }

        public static Square[] GetDiagonals(Square CurrentPosition, PieceColor FriendlyColor)
        {
            GetColAndRowFromName(CurrentPosition.Name, out int column, out int row);
            var ValidSquares = new List<Square>();

            bool FoundSW = false, FoundSE = false, FoundNW = false, FoundNE = false;

            for (int i = row-1; i >= 0; --i)
            {
                if (column - Math.Abs(row - i) >= 0 && !FoundSW) {
                    Square SW = GetSquareFromName(GetSquareNameFromColAndRow(column - Math.Abs(row - i), i));
                    if (SW.Piece == null)
                        ValidSquares.Add(SW);
                    else {
                        FoundSW = true;
                        if (SW.Piece.Color != FriendlyColor)
                            ValidSquares.Add(SW);
                    }
                }

                if(column + Math.Abs(row - i) < 8 && !FoundSE)
                {
                    Square SE = GetSquareFromName(GetSquareNameFromColAndRow(column + Math.Abs(row - i), i));
                    if (SE.Piece == null)
                        ValidSquares.Add(SE);
                    else
                    {
                        FoundSE = true;
                        if (SE.Piece.Color != FriendlyColor)
                            ValidSquares.Add(SE);
                    }
                }
            }

            for (int i = row+1; i < 8; ++i)
            {
                if (column - Math.Abs(row - i) >= 0 && !FoundNW)
                {
                    Square NW = GetSquareFromName(GetSquareNameFromColAndRow(column - Math.Abs(row - i), i));
                    if (NW.Piece == null)
                        ValidSquares.Add(NW);
                    else
                    {
                        FoundNW = true;
                        if (NW.Piece.Color != FriendlyColor)
                            ValidSquares.Add(NW);
                    }
                }

                if (column + Math.Abs(row - i) < 8 && !FoundNE)
                {
                    Square NE = GetSquareFromName(GetSquareNameFromColAndRow(column + Math.Abs(row - i), i));
                    if (NE.Piece == null)
                        ValidSquares.Add(NE);
                    else
                    {
                        FoundNE = true;
                        if (NE.Piece.Color != FriendlyColor)
                            ValidSquares.Add(NE);
                    }
                }
            }
            return ValidSquares.ToArray();
        }

        public static Square[] GetKingSquares(Square CurrentPosition, PieceColor FriendlyColor)
        {
            var ValidSquares = new List<Square>();
            if (CurrentPosition.Column + 1 < 8)
                ValidSquares.AddRange(AddRowsOnKingsColumn(CurrentPosition.Column + 1, CurrentPosition.Row, FriendlyColor));

            if(CurrentPosition.Column - 1 >= 0)
                ValidSquares.AddRange(AddRowsOnKingsColumn(CurrentPosition.Column - 1, CurrentPosition.Row, FriendlyColor));

            if (CurrentPosition.Row + 1 < 8)
            {
                Square square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, CurrentPosition.Row + 1));
                if (square.Piece == null || square.Piece.Color != FriendlyColor)
                    ValidSquares.Add(square);
            }

            if (CurrentPosition.Row - 1 >= 0)
            {
                Square square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, CurrentPosition.Row - 1));
                if (square.Piece == null || square.Piece.Color != FriendlyColor)
                    ValidSquares.Add(square);
            }
            return ValidSquares.ToArray();
        }

        private static List<Square> AddRowsOnKingsColumn(int column, int midRow, PieceColor FriendlyColor)
        {
            var ValidSquares = new List<Square>();

            Square midSquare = GetSquareFromName(GetSquareNameFromColAndRow(column, midRow));
            if (midSquare.Piece == null || midSquare.Piece.Color != FriendlyColor)
                ValidSquares.Add(midSquare);

            if (midRow + 1 < 8)
            {
                Square square = GetSquareFromName(GetSquareNameFromColAndRow(column, midRow+1));
                if (square.Piece == null || square.Piece.Color != FriendlyColor)
                    ValidSquares.Add(square);
            }

            if (midRow - 1 >= 0)
            {
                Square square = GetSquareFromName(GetSquareNameFromColAndRow(column, midRow - 1));
                if (square.Piece == null || square.Piece.Color != FriendlyColor)
                    ValidSquares.Add(square);
            }
            return ValidSquares;
        }

        private static bool AddOnFriendlyCondition(Square square, List<Square> validSquares, PieceColor FriendlyColor)
        {
            bool continueExecution = true;
            if (square.Piece == null)
                validSquares.Add(square);
            else
            {
                if (square.Piece.Color != FriendlyColor)
                    validSquares.Add(square);
                continueExecution = false;
            }
            return continueExecution;
        }

        public static Square[] GetStraights(Square CurrentPosition, PieceColor FriendlyColor)
        {
            var validSquares = new List<Square>();

            var i = CurrentPosition.Row - 1;
            while (true)
            {
                if(i < 0) break;
                var square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, i));
                if (!AddOnFriendlyCondition(square, validSquares, FriendlyColor)) break;
                --i;
            }

            i = CurrentPosition.Row + 1;
            while (true)
            {
                if (i > 7) break;
                var square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, i));
                if (!AddOnFriendlyCondition(square, validSquares, FriendlyColor)) break;
                ++i;
            }

            i = CurrentPosition.Column - 1;
            while (true)
            {
                if (i < 0) break;
                var square = GetSquareFromName(GetSquareNameFromColAndRow(i, CurrentPosition.Row));
                if (!AddOnFriendlyCondition(square, validSquares, FriendlyColor)) break;
                --i;
            }

            i = CurrentPosition.Column + 1;
            while (true)
            {
                if (i > 7) break;
                var square = GetSquareFromName(GetSquareNameFromColAndRow(i, CurrentPosition.Row));
                if (!AddOnFriendlyCondition(square, validSquares, FriendlyColor)) break;
                ++i;
            }

            return validSquares.ToArray();
        }

        public static Square[] GetKnightSquares(Square CurrentPosition)
        {
            throw new NotImplementedException();
        }

        public static Square[] GetPawnMoveSquares(Square CurrentPosition, Pawn pawn)
        {
            //todo: en passant

            var oneStepRow = CurrentPosition.Row + pawn.MovingDirection;
            var twoStepsRow = CurrentPosition.Row + (pawn.MovingDirection * 2);
            var attackLeftCol = CurrentPosition.Column - 1;
            var attackRightCol = CurrentPosition.Column + 1;
            var validSquares = new List<Square>(); 

            if (pawn.StartPosition == CurrentPosition)
            {
                if (twoStepsRow < 8 && twoStepsRow >= 0)
                {
                    var square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, twoStepsRow));
                    if(square.Piece == null)
                        validSquares.Add(square);
                }
            }

            if (oneStepRow < 8 && oneStepRow >= 0)
            {
                var square = GetSquareFromName(GetSquareNameFromColAndRow(CurrentPosition.Column, oneStepRow));
                if(square.Piece == null)
                    validSquares.Add(square);

                if(attackLeftCol >= 0)
                {
                    square = GetSquareFromName(GetSquareNameFromColAndRow(attackLeftCol, oneStepRow));
                    if (square.Piece != null && square.Piece.Color != pawn.Color)
                        validSquares.Add(square);
                }

                if (attackRightCol < 8)
                {
                    square = GetSquareFromName(GetSquareNameFromColAndRow(attackRightCol, oneStepRow));
                    if (square.Piece != null && square.Piece.Color != pawn.Color)
                        validSquares.Add(square);
                }
            }

            return validSquares.ToArray();
        }

        public static string GetSquareNameFromColAndRow(int column, int row)
        {
            string name = "";
            switch (column)
            {
                case 0: name += "A"; break;
                case 1: name += "B"; break;
                case 2: name += "C"; break;
                case 3: name += "D"; break;
                case 4: name += "E"; break;
                case 5: name += "F"; break;
                case 6: name += "G"; break;
                case 7: name += "H"; break;
            }
            name += row + 1;
            return name;
        }

        public static Square GetSquareFromName(string name)
        {
            /*int column = 0;
            switch (characters[0])
            {
                case 'A': column = 0; break;
                case 'B': column = 1; break;
                case 'C': column = 2; break;
                case 'D': column = 3; break;
                case 'E': column = 4; break;
                case 'F': column = 5; break;
                case 'G': column = 6; break;
                case 'H': column = 7; break;
            }
            int row = Int32.Parse(characters[1].ToString());*/
            GetColAndRowFromName(name, out int column, out int row);
            return board[column, row];
        }

        private static void GetColAndRowFromName(string name, out int column, out int row)
        {
            char[] characters = name.ToCharArray();
            column = 0;
            switch (characters[0])
            {
                case 'A': column = 0; break;
                case 'B': column = 1; break;
                case 'C': column = 2; break;
                case 'D': column = 3; break;
                case 'E': column = 4; break;
                case 'F': column = 5; break;
                case 'G': column = 6; break;
                case 'H': column = 7; break;
            }
            row = Int32.Parse(characters[1].ToString()) -1;
        }
    }
}
