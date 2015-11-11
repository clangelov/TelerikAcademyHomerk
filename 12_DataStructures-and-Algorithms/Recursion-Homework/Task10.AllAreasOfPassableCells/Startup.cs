namespace Task10.AllAreasOfPassableCells
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private const char FreeCell = ' ';
        private const char PassableCell = '@';
        private const char BlockedPath = '*';

        private static char[,] matrix =
        {
            { ' ', ' ', '*', ' ', '*', ' ', ' ' },
            { '*', ' ', '*', ' ', '*', '*', ' ' },
            { ' ', ' ', '*', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', '*', ' ' },
        };

        private static int finalLongest = 0;
        private static HashSet<Cell> finalAnswer = new HashSet<Cell>();

        public static void Main()
        {
            FindSolution();
        }

        private static void FindSolution()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == FreeCell)
                    {
                        Solve(row, col, 0);
                    }
                }
            }

            Console.WriteLine("Longest connected Area is of {0} elements!", finalLongest);

            PrintMatrix();
        }

        private static void Solve(int row, int col, int currentCount)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == FreeCell)
            {
                finalAnswer.Add(new Cell(row, col));
                finalLongest++;

                matrix[row, col] = BlockedPath;

                Solve(row + 1, col, currentCount + 1);
                Solve(row - 1, col, currentCount + 1);
                Solve(row, col + 1, currentCount + 1);
                Solve(row, col - 1, currentCount + 1);
            }
        }

        private static void PrintMatrix()
        {
            foreach (var item in finalAnswer)
            {
                matrix[item.Row, item.Col] = PassableCell;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
