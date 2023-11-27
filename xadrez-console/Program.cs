using board;
using chess;
using xadrez_console;

try
{
    ChessMatch match = new ChessMatch();

    while (match.end == false)
    {
        Console.Clear();

        Screen.PrintBoard(match.board);

        Console.WriteLine("");
        Console.Write("Origem: ");
        Position origin = Screen.readChessPosition().toPosition();
        Console.Write("Destino: ");
        Position dest = Screen.readChessPosition().toPosition();

        match.executMoviment(origin, dest);
    }


}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
