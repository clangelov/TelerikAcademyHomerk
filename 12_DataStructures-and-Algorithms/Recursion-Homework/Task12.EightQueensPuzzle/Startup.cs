namespace Task12.EightQueensPuzzle
{
    using System;

    public class Startup
    {
        private const int Size = 8;
        private static int[] queens = new int[Size];
        private static bool[] usedCols = new bool[Size];
        private static bool[] usedDiagFirst = new bool[2 * Size];
        private static bool[] usedDiagSecond = new bool[2 * Size];

        public static void Main()
        {
            QueensSolver(0);
        }

        private static void QueensSolver(int row)
        {
            for (int col = 0; col < Size; col++)
            {
                if (!usedCols[col] && !usedDiagFirst[row + col] && !usedDiagSecond[row - col + Size])
                {
                    queens[row] = col;
                    usedCols[col] = usedDiagFirst[row + col] = usedDiagSecond[row - col + Size] = true;

                    if (row == Size - 1)
                    {
                        PrintResult();
                        return;
                    }
                    else
                    {
                        QueensSolver(row + 1);
                    }

                    usedCols[col] = usedDiagFirst[row + col] = usedDiagSecond[row - col + Size] = false;
                }
            }
        }

        private static void PrintResult()
        {
            Console.Clear();
            for (int row = 0; row < Size; row++)
            {
                int queenCol = queens[row];
                for (int col = 0; col < Size; col++)
                {
                    Console.BackgroundColor = ((row + col) % 2 == 0) ? ConsoleColor.Gray : Console.BackgroundColor;
                    Console.ForegroundColor = ((row + col) % 2 == 0) ? ConsoleColor.Black : Console.ForegroundColor;

                    Console.Write(col == queenCol ? " Q" : "  ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}
