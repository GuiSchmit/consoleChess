using board;
namespace chess
{
    public class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
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

            
            //Diagonal 1
            pos.defineValues(this.Position.Line - 1, this.Position.Column - 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 1;
            }

            //Diagonal 2
            pos.defineValues(this.Position.Line - 1, this.Position.Column + 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 1;
            }

            //Diagonal 3
            pos.defineValues(this.Position.Line + 1, this.Position.Column + 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 1;
            }

            //Diagonal 4
            pos.defineValues(this.Position.Line + 1, this.Position.Column - 1);
            while (Board.PositionValid(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;

                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }

    }
}

