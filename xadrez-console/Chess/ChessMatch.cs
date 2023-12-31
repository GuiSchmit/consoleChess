﻿using board;
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
		public bool Check { get; private set; }
		public bool promotion = false;


		public ChessMatch()
		{
			board = new Board(8, 8);
			turn = 1;
			currentPlayer = Color.White;
			end = false;
			Check = false;
			pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            insertPieces();
		}

		public Piece executMoviment(Position origin, Position dest)
		{
			Piece p = board.RemovePiece(origin);
			p.increaseMovimentsQty();
			Piece capturedPiece = board.RemovePiece(dest);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            board.InsertPiece(p, dest);

            //Promotion
            if (p is Pawn)
            {
                if (((Pawn)p).Color == Color.White && ((Pawn)p).Position.Line == 0)
                {
                    Piece aux = new Queen(board, Color.White);
                    board.RemovePiece(dest);
                    captured.Add(p);
                    insertNewPieceWithPos(dest, aux);
                    promotion = true;

                }
                else if (((Pawn)p).Color == Color.Black && ((Pawn)p).Position.Line == 7)
                {
                    Piece aux = new Queen(board, Color.Black);
                    board.RemovePiece(dest);
                    captured.Add(p);
                    insertNewPieceWithPos(dest, aux);
                    promotion = true;

                }

                promotion = false;

            }

            //EN PASSANT
            if (p is Pawn && ((Pawn)p).doingEnpassant == true && dest.Column != origin.Column)
			{
				if (p.Color == Color.White)
				{
					Position capturedPos = new Position(dest.Line + 1, dest.Column);
                    capturedPiece = board.RemovePiece(capturedPos);
                    captured.Add(capturedPiece);
                }
				else
				{
                    Position capturedPos = new Position(dest.Line - 1, dest.Column);
                    capturedPiece = board.RemovePiece(capturedPos);
                    captured.Add(capturedPiece);
                }
            }

            //SMALL CASTLE
            if (p is King && dest.Column == origin.Column + 2)
			{
				Position rookOrigin = new Position(origin.Line, origin.Column + 3);
				Position rookDest = new Position(origin.Line, origin.Column + 1);
				Piece r = board.RemovePiece(rookOrigin);
				r.increaseMovimentsQty();
				board.InsertPiece(r, rookDest);
			}

			//BIG CASTLE
			if (p is King && dest.Column == origin.Column - 2)
			{
				Position rookOrigin = new Position(origin.Line, origin.Column - 4);
				Position rookDest = new Position(origin.Line, origin.Column - 1);
				Piece r = board.RemovePiece(rookOrigin);
				r.increaseMovimentsQty();
				board.InsertPiece(r, rookDest);
			}

            return capturedPiece;
		}

		public void undoMoviment(Position origin, Position dest, Piece capturedPiece)
		{
			Piece p = board.RemovePiece(dest);
			p.decreaseMovimentQty();
			if (capturedPiece != null)
			{

                //Promotion
                if (promotion)
                {
					if (((Queen)p).Color == Color.White && ((Queen)p).Position.Line == 0)
					{
						captured.Remove(capturedPiece);
						Piece aux = new Pawn(board, Color.White);
						insertNewPieceWithPos(origin, aux);

					}
					else if (((Queen)p).Color == Color.Black && ((Queen)p).Position.Line == 7)
					{
						captured.Remove(capturedPiece);
						Piece aux = new Pawn(board, Color.Black);
                        insertNewPieceWithPos(origin, aux);
                    }

                    return;
                }

                //EN PASSANT
                if (p is Pawn && ((Pawn)p).doingEnpassant == true && dest.Column != origin.Column)
                {
                    if (p.Color == Color.White)
                    {
                        Position pos = new Position(dest.Line + 1, dest.Column);
                        board.InsertPiece(capturedPiece, pos);
                        captured.Remove(capturedPiece);
                    }
                    else
                    {
                        Position pos = new Position(dest.Line - 1, dest.Column);
                        board.InsertPiece(capturedPiece, pos);
                        captured.Remove(capturedPiece);
                    }
                    board.InsertPiece(p, origin);
                    return;
                }

                board.InsertPiece(capturedPiece, dest);
				captured.Remove(capturedPiece);
			}

			board.InsertPiece(p, origin);

           

            //SMALL CASTLE
            if (p is King && dest.Column == origin.Column + 2)
			{
				Position rookOrigin = new Position(origin.Line, origin.Column + 3);
				Position rookDest = new Position(origin.Line, origin.Column + 1);
				Piece r = board.RemovePiece(rookDest);
				r.decreaseMovimentQty();
				board.InsertPiece(r, rookOrigin);
			}

			//BIG CASTLE
			if (p is King && dest.Column == origin.Column - 2)
			{
				Position rookOrigin = new Position(origin.Line, origin.Column - 4);
				Position rookDest = new Position(origin.Line, origin.Column - 1);
				Piece r = board.RemovePiece(rookDest);
				r.decreaseMovimentQty();
				board.InsertPiece(r, rookOrigin);
			}
		}

		public void makesMove(Position origin, Position dest)
		{
            Piece capturedPiece = executMoviment(origin, dest);

            if (check(currentPlayer) == true)
			{
				undoMoviment(origin, dest, capturedPiece);
				throw new BoardException("You can't put yourself in check.");
			}


            if (check(oppnentColor(currentPlayer)) == true)
			{
				Check = true;
			}
			else
			{
				Check = false;
			}

			if (testCheckmate(oppnentColor(currentPlayer)) == true)
			{
				end = true;
			}
			else
			{
                turn++;
                changePlayer();
            }



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
			if (board.piece(origin).possibleMoviment(dest) == false)
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

		private Piece king(Color color)
		{
			foreach (Piece x in piecesInGame(color))
			{
				if (x is King)
				{
					return x;
				}
			}
			return null;
		}

		private Color oppnentColor(Color color)
		{
			if (color == Color.White)
			{
				return Color.Black;
			}
			return Color.White;
		}

		public bool check(Color color)
		{
			Piece k = king(color);
			if (k == null)
			{
                end = true;
                throw new BoardException("Wait, what!? Theres no " + color + " king on the board. I think the game is over...");
			}

			foreach (Piece p in piecesInGame(oppnentColor(color)))
			{
				bool[,] mat = p.possibleMoviments();
				if (mat[k.Position.Line, k.Position.Column] == true)
				{
					return true;
				}
			}
            return false;
        }

		public bool testCheckmate(Color color)
		{
			if (check(color) == false)
			{
				return false;
			}

			foreach (Piece p in piecesInGame(color))
			{
				bool[,] mat = p.possibleMoviments();

				for (int i = 0; i<board.Line; i++)
				{
					for (int j = 0; j<board.Column; j++)
					{
						if (mat[i, j] == true)
						{
							Position origin = p.Position;
							Position dest = new Position(i, j);
							Piece capturedPiece = executMoviment(origin, dest);
							bool testCheck = check(color);
							undoMoviment(origin, dest, capturedPiece);
							if (testCheck == false)
							{
								return false;
							}
						}
					}
				}
			}
			return true;
		}

        public void insertNewPiece(char column, int line, Piece piece)
		{
			board.InsertPiece(piece, new ChessPosition(column, line).toPosition());
			pieces.Add(piece);
		}
        public void insertNewPieceWithPos(Position pos, Piece piece)
        {
            board.InsertPiece(piece, pos);
            pieces.Add(piece);
        }

        private void insertPieces()
		{
            //White pieces
            insertNewPiece('a', 2, new Pawn(board, Color.White));
            insertNewPiece('b', 2, new Pawn(board, Color.White));
            insertNewPiece('c', 2, new Pawn(board, Color.White));
            insertNewPiece('d', 2, new Pawn(board, Color.White));
            insertNewPiece('e', 2, new Pawn(board, Color.White));
            insertNewPiece('f', 2, new Pawn(board, Color.White));
            insertNewPiece('g', 2, new Pawn(board, Color.White));
            insertNewPiece('h', 2, new Pawn(board, Color.White));

            insertNewPiece('a', 1, new Rook(board, Color.White));
            insertNewPiece('b', 1, new Knight(board, Color.White));
            insertNewPiece('c', 1, new Bishop(board, Color.White));
            insertNewPiece('d', 1, new Queen(board, Color.White));
            insertNewPiece('e', 1, new King(board, Color.White, this));
            insertNewPiece('f', 1, new Bishop(board, Color.White));
            insertNewPiece('g', 1, new Knight(board, Color.White));
            insertNewPiece('h', 1, new Rook(board, Color.White));


            //Black pieces
            insertNewPiece('a', 7, new Pawn(board, Color.Black));
            insertNewPiece('b', 7, new Pawn(board, Color.Black));
            insertNewPiece('c', 7, new Pawn(board, Color.Black));
            insertNewPiece('d', 7, new Pawn(board, Color.Black));
            insertNewPiece('e', 7, new Pawn(board, Color.Black));
            insertNewPiece('f', 7, new Pawn(board, Color.Black));
            insertNewPiece('g', 7, new Pawn(board, Color.Black));
            insertNewPiece('h', 7, new Pawn(board, Color.Black));

            insertNewPiece('a', 8, new Rook(board, Color.Black));
            insertNewPiece('b', 8, new Knight(board, Color.Black));
            insertNewPiece('c', 8, new Bishop(board, Color.Black));
            insertNewPiece('d', 8, new Queen(board, Color.Black));
            insertNewPiece('e', 8, new King(board, Color.Black, this));
            insertNewPiece('f', 8, new Bishop(board, Color.Black));
            insertNewPiece('g', 8, new Knight(board, Color.Black));
            insertNewPiece('h', 8, new Rook(board, Color.Black));
        }
    }
}

