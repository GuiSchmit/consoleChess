using board;
using chess;
using xadrez_console;


try
{
    Board test = new Board(8, 8);

    test.InsertPiece(new King(test, Color.Black), new Position(0, 9));
    test.InsertPiece(new Rook(test, Color.Black), new Position(0, 2));

    Screen.PrintBoard(test);

}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}



