using board;
using chess;
using xadrez_console;

try
{
   
    ChessMatch match = new ChessMatch();
    while (match.end == false)
    {
        try
        {
            Console.Clear();
            Screen.printMatch(match);
            
            Console.Write("Please enter the origin position: ");

            Position origin = Screen.readChessPosition().toPosition();

            match.originPositionValidation(origin);

            bool[,] possiblePositions = match.board.piece(origin).possibleMoviments();

            Console.Clear();
            Screen.PrintBoard(match.board, possiblePositions);

            Console.WriteLine("");
            Console.WriteLine("Turn: " + match.turn + " (Waiting for " + match.currentPlayer + ")");
            Console.WriteLine("");
            Console.Write("Please enter the destination position: ");
            Position dest = Screen.readChessPosition().toPosition();
            match.destinationPositionValidation(origin, dest);

            match.makesMove(origin, dest);


        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Press ENTER to continue: ");
            Console.ReadLine();
        }
    }

    Console.Clear();
    Screen.printMatch(match);

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
