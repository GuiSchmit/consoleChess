
namespace board
{
	public abstract class Piece
	{
		public Board Board { get; set; }
		public Color Color { get; set; }
		public Position Position { get; set; }
		public int MovimentsQty { get; set; }
		
		public Piece()
		{
		}

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
        }

        public Piece(Board board, Color color, Position position)
        {
            Board = board;
            Color = color;
            Position = position;
            this.MovimentsQty = 0;
        }

        public void increaseMovimentsQty()
        {
            MovimentsQty++;
        }

        public bool possibleMovimentsExist()
        {
            bool[,] mat = possibleMoviments();
            for (int i = 0; i<Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            if (possibleMoviments()[pos.Line, pos.Column] == true)
            {
                return true;
            }
            return false;
        }

        public abstract bool[,] possibleMoviments();
        
                

    }
}

