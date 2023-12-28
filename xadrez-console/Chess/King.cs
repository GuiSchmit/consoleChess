using board;

namespace chess
{
	public class King : Piece
	{
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
		{
            this.match = match;
		}

        private bool canMove(Position pos)
        {
            Piece p = Board.piece(pos);

            return p == null || p.Color != this.Color;
        }

        private bool castle(Position pos)
        {
            if (Board.PositionValid(pos))
            {
                Piece p = Board.piece(pos);

                return MovimentsQty == 0 && p != null && p is Rook && p.MovimentsQty == 0 && p.Color == Color;
            }

            return false;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);


            //N (norte)
            pos.defineValues(this.Position.Line - 1, this.Position.Column);
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

            //SMALL CASTLE
            pos.defineValues(this.Position.Line, this.Position.Column + 3);
            if (castle(pos) && !match.Check)
            {
                Position aux1 = new Position(Position.Line, Position.Column + 1);
                Position aux2 = new Position(Position.Line, Position.Column + 2);
                if (Board.piece(aux1) == null && Board.piece(aux2) == null)
                {
                        pos.defineValues(this.Position.Line, this.Position.Column + 2);
                        mat[pos.Line, pos.Column] = true;
                }
            }
            
                

           //BIG CASTLE
           pos.defineValues(this.Position.Line, this.Position.Column - 4);
           if (castle(pos) && !match.Check)
           {
                Position aux1 = new Position(Position.Line, Position.Column - 1);
                Position aux2 = new Position(Position.Line, Position.Column - 2);
                Position aux3 = new Position(Position.Line, Position.Column - 3);

                if (Board.piece(aux1) == null && Board.piece(aux2) == null && Board.piece(aux3) == null)
                {
                    pos.defineValues(this.Position.Line, this.Position.Column - 2);
                    if (Board.PositionValid(pos) && canMove(pos))
                    {
                        mat[pos.Line, pos.Column] = true;
                    }
                }
                
           }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}

