
namespace board
{
	public class Board
	{
        public int Column { get; set; }
        public int Line { get; set; }
		public Piece[,] pieces;

        public Board(int column, int line)
        {
            Column = column;
            Line = line;
            pieces = new Piece[column, line];
        }
    }
}

