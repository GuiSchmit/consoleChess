
namespace board
{
	public class Board
	{
        public int Column { get; set; }
        public int Line { get; set; }
		private Piece[,] pieces;

        public Board(int line, int column)
        {
            Column = column;
            Line = line;
            pieces = new Piece[line, column];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }

        public bool PieceExist(Position pos)
        {
            PositionValidation(pos);

            return piece(pos) != null;
        }

        public void InsertPiece(Piece p, Position pos)
        {
            if (PieceExist(pos))
            {
                throw new BoardException("Piece already exist in this position."); 
            }
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool PositionValid(Position pos)
        {
            if (pos.Line<0 || pos.Line > 7 || pos.Column < 0 || pos.Column > 7)
            {
                return false;
            }
            return true;
        }

        public void PositionValidation(Position pos)
        {
            if (!PositionValid(pos))
            {
                throw new BoardException("Invalid position.");
            }
        }

    }
}

