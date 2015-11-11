namespace Task09.FindTheLargestConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        private const char FreeCell = ' ';
        private const char LargestArea = '@';
        private const char BlockedPath = '*';

        private static char[,] matrix =
        {
            { ' ', ' ', '*', ' ', '*', ' ', ' ' },
            { '*', '*', '*', ' ', '*', '*', '*' },
            { ' ', ' ', '*', ' ', ' ', '*', ' ' },
            { ' ', '*', '*', '*', ' ', '*', ' ' },
            { ' ', '*', ' ', '*', ' ', '*', ' ' },
        };

        private static int currLongest = 0;
        private static List<Cell> currAnswer = new List<Cell>();

        private static int finalLongest = 0;
        private static List<Cell> finalAnswer = new List<Cell>();

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
                        var cellList = new List<Cell>();
                        cellList.Add(new Cell(row, col));

                        FindAllCellThatCanBeAccessed(row, col, 0, cellList);

                        if (currLongest > finalLongest)
                        {
                            finalLongest = currLongest;
                            finalAnswer = new List<Cell>(currAnswer);
                        }
                    }

                    currAnswer.Clear();
                    currLongest = 0;
                }
            }

            Console.WriteLine("Longest connected Area is of {0} elements!", finalLongest);

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var item in finalAnswer)
            {
                matrix[item.Row, item.Col] = LargestArea;
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

        private static void FindAllCellThatCanBeAccessed(int row, int col, int currentCount, List<Cell> visited)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || 
                col >= matrix.GetLength(1))
            {
                return;
            }

            if (currentCount > currLongest)
            {
                currLongest = currentCount;
                currAnswer = new List<Cell>(visited);
            }

            if (matrix[row, col] == FreeCell)
            {
                visited.Add(new Cell(row, col));

                MarkCurrentAsVisited(row, col);

                FindAllCellThatCanBeAccessed(row + 1, col, currentCount + 1, visited);
                FindAllCellThatCanBeAccessed(row - 1, col, currentCount + 1, visited);
                FindAllCellThatCanBeAccessed(row, col + 1, currentCount + 1, visited);
                FindAllCellThatCanBeAccessed(row, col - 1, currentCount + 1, visited);

                UnMarkCurrentAsVisited(row, col);
                visited.RemoveAt(visited.Count - 1);
            }
        }

        private static void UnMarkCurrentAsVisited(int row, int col)
        {
            matrix[row, col] = FreeCell;
        }

        private static void MarkCurrentAsVisited(int row, int col)
        {
            matrix[row, col] = BlockedPath;
        }
    }
}
