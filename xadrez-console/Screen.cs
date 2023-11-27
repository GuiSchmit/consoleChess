using board;
using chess;

namespace xadrez_console
{
	public class Screen
	{

		public static void PrintBoard(Board board)
		{

			for (int i = 0; i < board.Column; i++)
			{
				Console.Write(8-i + " ");

				for (int j = 0; j < board.Line; j++)
				{
                    if (board.piece(i, j) == null)
                    {

                        Console.Write("- ");
                    }
                    else
                    {
						PrintPiece(board.piece(i, j));
						Console.Write(" ");
                    }

                }
				Console.WriteLine("");
			}
			Console.WriteLine("  a b c d e f g h");
		}

		public static void PrintPiece(Piece piece)
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
		}


		public static ChessPosition readChessPosition()
		{
			string s = Console.ReadLine();
			char column = s[0];
			int line = int.Parse(s[1]+"");
			return new ChessPosition(column, line);
		}

	}
}

