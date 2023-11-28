using board;
namespace chess
{
	public class ChessMatch
	{
		public Board board { get; private set; }
		public int turn { get; private set; }
		public Color currentPlayer { get; private set; }
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

		public void makesMove(Position origin, Position dest)
		{
			executMoviment(origin, dest);
			turn++;
			changePlayer();
		}

		public void originPositionValidation(Position pos)
		{
			Console.WriteLine("");
			if (board.piece(pos) == null)
			{
				throw new BoardException("Doesn't exist a piece in this position.");
			}
			if (currentPlayer != board.piece(pos).Color)
			{
				throw new BoardException("This piece is not yours.");
			}
			if (board.piece(pos).possibleMovimentsExist() == false)
			{
				throw new BoardException("This piece has no possible moviment");
			}
		}

		public void destinationPositionValidation(Position origin, Position dest)
		{
			if (board.piece(origin).canMoveTo(dest) == false)
			{
				throw new BoardException("Destination position invalid");
			}
		}

		private void changePlayer()
		{
			if (currentPlayer == Color.White)
			{
				currentPlayer = Color.Black;
			}
			else
			{
				currentPlayer = Color.White;
			}
		}

		private void insertPieces()
		{
            board.InsertPiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('d', 1).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('f', 2).toPosition());
            board.InsertPiece(new Rook(board, Color.White), new ChessPosition('c', 1).toPosition());





            board.InsertPiece(new King(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.InsertPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.InsertPiece(new Rook(board, Color.Black), new ChessPosition('a', 5).toPosition());


        }
    }
}

