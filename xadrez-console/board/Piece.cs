
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

        public abstract bool[,] possibleMoviments();
        


    }
}

