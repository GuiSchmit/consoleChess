
namespace board
{
	public class Position
	{
		public int Column { get; set; }
        public int Line { get; set; }

        public Position(int line, int column)
        {
            Column = column;
            Line = line;
        }

        public Position()
		{
		}


        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}

