
namespace board
{
	public class Board
	{
        public int Column { get; set; }
        public int Line { get; set; }
		private Piece[,] pieces;

        //Construtor
        public Board(int line, int column)
        {
            Column = column;
            Line = line;
            pieces = new Piece[line, column];
        }

    
        //Methodos para obter peça de determinada posicao
        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.Line, pos.Column];
        }


        //Se a posicao desejada existir, e nela uma peca, retornara verdadeiro
        //caso contrario retorna falso.
        public bool PieceExist(Position pos)
        {
            PositionValidation(pos);

            //     peca(pos) NÃO É nulo?
            return piece(pos) != null;
        }


        //Insere uma peca na posicao desejada caso ela exista
        public void InsertPiece(Piece p, Position pos)
        {
            if (PieceExist(pos))
            {
                throw new BoardException("Piece already exist in this position."); 
            }
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            else
            {
                Piece aux = piece(pos);
                aux.Position = null;
                pieces[pos.Line, pos.Column] = null;
                return aux;
            }
        }


        //Testa se a posicao nao ultrapassa os limites do tabuleiro
        public bool PositionValid(Position pos)
        {
            if (pos.Line<0 || pos.Line > 7 || pos.Column < 0 || pos.Column > 7)
            {
                return false;
            }
            return true;
        }


        //Methodo para usar no progam.cs e testar a posicao.
        //Retorna uma excessao se for o caso
        public void PositionValidation(Position pos)
        {
            if (!PositionValid(pos))
            {
                throw new BoardException("Invalid position.");
            }
        }

    }
}

