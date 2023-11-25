using board;


namespace xadrez_console
{
	public class Screen
	{

		public static void PrintBoard(Board board)
		{

			for (int i = 0; i < board.Column; i++)
			{
				for (int j = 0; j < board.Line; j++)
				{
					if (board.piece(i, j) == null)
					{
						Console.Write("- ");
					}
					else
					{
                        Console.Write(board.piece(i, j) + " ");

                    }
                }
				Console.WriteLine("");
			}
		}



	}
}

