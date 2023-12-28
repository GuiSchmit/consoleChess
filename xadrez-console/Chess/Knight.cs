using board;
namespace chess
{
    public class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        private bool canMove(Position pos)
        {
            Piece p = Board.piece(pos);

            return p == null || p.Color != this.Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);

            //North right
            pos.defineValues(this.Position.Line - 2, this.Position.Column + 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //North left 
            pos.defineValues(this.Position.Line - 2, this.Position.Column - 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Right north
            pos.defineValues(this.Position.Line - 1, this.Position.Column + 2);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Right south
            pos.defineValues(this.Position.Line + 1, this.Position.Column + 2);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //South right
            pos.defineValues(this.Position.Line + 2, this.Position.Column + 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //South left 
            pos.defineValues(this.Position.Line + 2, this.Position.Column - 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Left north
            pos.defineValues(this.Position.Line - 1, this.Position.Column - 2);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //Left south
            pos.defineValues(this.Position.Line + 1, this.Position.Column - 2);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            return mat;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}

