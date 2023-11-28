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

        Console.WriteLine(origin);
        Console.WriteLine(origin.Line);
        Console.WriteLine(origin.Column);
        Console.WriteLine(match.board.piece(origin));

        bool[,] possiblePositions = match.board.piece(origin).possibleMoviments();


        Console.Clear();
        Screen.PrintBoard(match.board, possiblePositions);

        Console.Write("Destino: ");
        Position dest = Screen.readChessPosition().toPosition();

        match.executMoviment(origin, dest);
    }

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
