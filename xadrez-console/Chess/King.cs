using board;

namespace chess
{
	public class King : Piece
	{
		public King(Board board, Color color) : base(board, color)
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

            //N (norte)
            pos.defineValues(this.Position.Line - 1 , this.Position.Column);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //NE
            pos.defineValues(this.Position.Line - 1, this.Position.Column + 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //L
            pos.defineValues(this.Position.Line, this.Position.Column + 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //SE
            pos.defineValues(this.Position.Line + 1, this.Position.Column + 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //S
            pos.defineValues(this.Position.Line + 1, this.Position.Column);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //SO
            pos.defineValues(this.Position.Line + 1, this.Position.Column - 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //O
            pos.defineValues(this.Position.Line, this.Position.Column - 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //NO
            pos.defineValues(this.Position.Line - 1, this.Position.Column - 1);
            if (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}

