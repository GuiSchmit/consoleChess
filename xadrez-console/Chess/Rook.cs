using board;

namespace chess
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
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
            pos.defineValues(this.Position.Line - 1, this.Position.Column);

            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }

                pos.Line = pos.Line - 1;
            }

            //S
            pos.defineValues(this.Position.Line + 1, this.Position.Column);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }

                pos.Line = pos.Line + 1;
            }

            //L
            pos.defineValues(this.Position.Line, this.Position.Column + 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column = pos.Column + 1;
            }

            //O
            pos.defineValues(this.Position.Line, this.Position.Column - 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }

                pos.Column = pos.Column - 1;
            }
            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
