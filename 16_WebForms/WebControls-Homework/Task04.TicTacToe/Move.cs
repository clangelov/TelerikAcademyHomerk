namespace Task04.TicTacToe
{
    public class Move
    {
        public int iCol;
        public int iRow;
        public int iRank;

        public Move(int col, int row)
        {
            iCol = col;
            iRow = row;
            iRank = 0;
        }
    }
}