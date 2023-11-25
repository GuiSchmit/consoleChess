
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

    }
}

