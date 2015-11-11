namespace Task10.AllAreasOfPassableCells
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Cell)obj;

            if (this.Row == other.Row && this.Col == other.Col)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Row.GetHashCode() ^ this.Col.GetHashCode();
        }
    }
}
