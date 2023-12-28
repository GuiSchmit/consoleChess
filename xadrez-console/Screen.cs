using board;
using chess;

namespace xadrez_console
{
	public class Screen
	{

        public static void printMatch(ChessMatch match)
        {
            PrintBoard(match.board);
            Console.WriteLine("");
            printCapturedPieces(match);
            Console.WriteLine("");
            Console.WriteLine("Turn: " + match.turn);

            if (match.end == false)
            {
                Console.WriteLine("Waiting for " + match.currentPlayer + "...");

                if (match.Check == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("CHECK!");
                }
            } else
            {
                Console.WriteLine("Checkmate!!!");
                Console.WriteLine("");
                Console.WriteLine("The winner is: " + match.currentPlayer);
            }

            
            Console.WriteLine("");

        }

		public static void PrintBoard(Board board)
		{

			for (int i = 0; i < board.Column; i++)
			{
				Console.Write(8-i + " ");

				for (int j = 0; j < board.Line; j++)
				{
					PrintPiece(board.piece(i, j));
                }
				Console.WriteLine("");
			}
			Console.WriteLine("  a b c d e f g h");
		}

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePositions[i, j] == true)
                    {
                        Console.BackgroundColor = changedBackground;
                    } else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;

                }
                Console.WriteLine("");
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
		{
			if (piece == null)
			{
                Console.Write("- ");
			}
			else
			{
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine("");
        }

        public static void printSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece p in set)
            {
                Console.Write(p + ", ");
            }

            Console.Write("]");
        }

        public static ChessPosition readChessPosition()
		{
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

	}
}

