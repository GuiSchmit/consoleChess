
namespace board
{
	public class Position
	{
		public char Column { get; set; }
        public int Line { get; set; }

        public Position(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position()
		{
		}


        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}

