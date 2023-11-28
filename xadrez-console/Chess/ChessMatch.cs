using board;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace chess
{
	public class ChessMatch
	{
		public Board board { get; private set; }
		public int turn { get; private set; }
		public Color currentPlayer { get; private set; }
		public bool end { get; private set; }
		private HashSet<Piece> pieces;
        private HashSet<Piece> captured;


        public ChessMatch()
		{
			board = new Board(8, 8);
			turn = 1;
			currentPlayer = Color.White;
			end = false;
			pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            insertPieces();
		}

		public void executMoviment(Position origin, Position dest)
		{
			Piece p = board.RemovePiece(origin);
			p.increaseMovimentsQty();
			Piece capturedPiece = board.RemovePiece(dest);
			board.InsertPiece(p, dest);
			if (capturedPiece != null)
			{
				captured.Add(capturedPiece);
			}
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

		public HashSet<Piece> capturedPieces(Color color)
		{
			HashSet<Piece> aux = new HashSet<Piece>();
			foreach (Piece x in captured)
			{
				if (x.Color == color)
				{
					aux.Add(x);
                }
            }
            return aux;
		}


        public HashSet<Piece> piecesInGame(Color color)
		{
           HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
			aux.ExceptWith(capturedPieces(color));
            return aux;
        }

		public void insertNewPiece(char column, int line, Piece piece)
		{
			board.InsertPiece(piece, new ChessPosition(column, line).toPosition());
			pieces.Add(piece);
		}

		private void insertPieces()
		{
			//White pieces
			insertNewPiece('e', 1, new King(board, Color.White));
            insertNewPiece('a', 1, new Rook(board, Color.White));
			insertNewPiece('h', 1, new Rook(board, Color.White));


			//Black pieces
            insertNewPiece('e', 8, new King(board, Color.Black));
            insertNewPiece('a', 8, new Rook(board, Color.Black));
			insertNewPiece('h', 8, new Rook(board, Color.Black));
        }
    }
}

