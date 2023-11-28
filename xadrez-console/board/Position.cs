
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

        public override string ToString()
        {
            return Line + ", " + Column;
        }

        public void defineValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }
    }
}

