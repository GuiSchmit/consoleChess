using board;
using chess;
using xadrez_console;

try
{
    Board board = new Board(8, 8);

    board.InsertPiece(new King(board, Color.White), new Position(3, 5));
    board.InsertPiece(new King(board, Color.Black), new Position(3, 2));
    board.InsertPiece(new Rook(board, Color.Black), new Position(2, 5));
    board.InsertPiece(new Rook(board, Color.White), new Position(3, 0));





    Screen.PrintBoard(board);
}
catch (BoardException e)
{
    Console.WriteLine(e.Message);
}
