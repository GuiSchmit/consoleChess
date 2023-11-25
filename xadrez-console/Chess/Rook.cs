using System;
using board;
namespace xadrez_console.Chess
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color, Position position) : base(board, color, position)
        {
        }


        public override string ToString()
        {
            return "R";
        }
    }
}
