using System;
using board;
namespace xadrez_console.Chess
{
	public class King : Piece
	{
		public King(Board board, Color color, Position position) : base(board, color, position)
		{
		}


        public override string ToString()
        {
            return "K";
        }
    }
}

