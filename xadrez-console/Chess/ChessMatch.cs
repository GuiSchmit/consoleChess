using board;
namespace chess
{
	public class ChessMatch
	{
		public Board board { get; private set; }
		private int turn;
		private Color currentPlayer;
		public bool end { get; private set; }

		 
		public ChessMatch()
		{
			board = new Board(8, 8);
			turn = 1;
			currentPlayer = Color.White;
			end = false;
			insertPieces();
		}

		public void executMoviment(Position origin, Position dest)
		{
			Piece p = board.RemovePiece(origin);
			p.increaseMovimentsQty();
			Piece capturedPiece = board.RemovePiece(dest);
			board.InsertPiece(p, dest);
		}

		private void insertPieces()
		{
            board.InsertPiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('a', 2).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('h', 1).toPosition());

            board.InsertPiece(new King(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.InsertPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.InsertPiece(new Rook(board, Color.Black), new ChessPosition('a', 5).toPosition());


        }
    }
}

