using board;
namespace chess
{
    public class Pawn : Piece
    {
        public bool doingEnpassant = false;

        public Pawn(Board board, Color color) : base(board, color)
        {
            MovimentsQty = 0;
        }
        private bool canMove(Position pos)
        {
            Piece p = Board.piece(pos);

            return p == null;
        }

        private bool canCapture(Position pos)
        {
            Piece p = Board.piece(pos);

            return p != null && p.Color != this.Color;
        }

        private bool isPassant(Position pos)
        {
            Piece p = Board.piece(pos);

            if (p.Color == Color.White)
            {
                return p.Color != Color && pos.Line == 4 && p.MovimentsQty == 1;
            }
            else
            {
                return p.Color != Color && pos.Line == 3 && p.MovimentsQty == 1;
            }

        }

        private bool enpassant(Position pos)
        {
            Piece p = Board.piece(pos);

            return p is Pawn && isPassant(pos);
            
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);

          
            //PEOES BRANCOS
            if (Color == Color.White)
            {
                //N (norte)
                pos.defineValues(this.Position.Line - 1, this.Position.Column);
                if (Board.PositionValid(pos) && canMove(pos))
                {
                    if (MovimentsQty == 0)
                    {
                        pos.defineValues(this.Position.Line - 2, this.Position.Column);
                        if (Board.PositionValid(pos) && canMove(pos))
                        {
                            mat[pos.Line, pos.Column] = true;
                            pos.defineValues(this.Position.Line - 1, this.Position.Column);
                        }
                    }
                    mat[pos.Line, pos.Column] = true;
                }

                //NO
                pos.defineValues(this.Position.Line - 1, this.Position.Column - 1);
                if (Board.PositionValid(pos) && canCapture(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //NE
                pos.defineValues(this.Position.Line - 1, this.Position.Column + 1);
                if (Board.PositionValid(pos) && canCapture(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //Left ENPASSANT
                pos.defineValues(this.Position.Line , this.Position.Column - 1);
                if (Board.PositionValid(pos) && enpassant(pos))
                {
                    mat[pos.Line - 1, pos.Column] = true;
                    doingEnpassant = true;
                }

                //Right ENPASSANT
                pos.defineValues(this.Position.Line, this.Position.Column + 1);
                if (Board.PositionValid(pos) && enpassant(pos))
                {
                    mat[pos.Line - 1, pos.Column] = true;
                    doingEnpassant = true;
                }
            }

            //PEOES PRETOS
            else
            {
                //S (sul)
                pos.defineValues(this.Position.Line + 1, this.Position.Column);
                if (Board.PositionValid(pos) && canMove(pos))
                {
                    if (MovimentsQty == 0)
                    {
                        pos.defineValues(this.Position.Line + 2, this.Position.Column);
                        if (Board.PositionValid(pos) && canMove(pos))
                        {
                            mat[pos.Line, pos.Column] = true;
                            pos.defineValues(this.Position.Line + 1, this.Position.Column);
                        }
                    }
                    mat[pos.Line, pos.Column] = true;
                }

                //NO
                pos.defineValues(this.Position.Line + 1, this.Position.Column - 1);
                if (Board.PositionValid(pos) && canCapture(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //NE
                pos.defineValues(this.Position.Line + 1, this.Position.Column + 1);
                if (Board.PositionValid(pos) && canCapture(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //Left ENPASSANT
                pos.defineValues(this.Position.Line, this.Position.Column - 1);
                if (Board.PositionValid(pos) && enpassant(pos))
                {
                    mat[pos.Line + 1, pos.Column] = true;
                    doingEnpassant = true;
                }

                //Right ENPASSANT
                pos.defineValues(this.Position.Line, this.Position.Column + 1);
                if (Board.PositionValid(pos) && enpassant(pos))
                {
                    mat[pos.Line + 1, pos.Column] = true;
                    doingEnpassant = true;
                }
            }

            return mat;
        }

        

        public override string ToString()
        {
            return "P";
        }
    }
}

