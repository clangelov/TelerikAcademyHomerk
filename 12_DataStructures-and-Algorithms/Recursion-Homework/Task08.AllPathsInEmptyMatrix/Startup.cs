namespace Task08.AllPathsInEmptyMatrix
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private const char PassablePath = ' ';
        private const char UnpassablePath = '0';
        private const char MatrixExit = 'e';

        private static char[,] matrix;
        private static Queue<Cell> queue = new Queue<Cell>();
        private static int[,] directions = new int[,] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
        private static int moves = 0;

        public static void Main()
        {
            GenerateMatrix(100, 100);
            FindPathInAMatrix(0, 0);
        }

        private static void FindPathInAMatrix(int row, int col)
        {
            matrix[row, col] = UnpassablePath;
            queue.Enqueue(new Cell(row, col));
            moves++;
            bool solutionFound = false;
             
            while (queue.Count != 0 && !solutionFound)
            {
                var currentCell = queue.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    var nextCell = new Cell(currentCell.Row + directions[i, 0], currentCell.Col + directions[i, 1]);

                    if (PositionIsValid(nextCell))
                    {
                        if (matrix[nextCell.Row, nextCell.Col] == MatrixExit)
                        {
                            solutionFound = true;
                            break;
                        }

                        matrix[nextCell.Row, nextCell.Col] = UnpassablePath;
                        queue.Enqueue(nextCell);
                        moves++;
                    }
                }
            }

            PrintPath(moves);
        }

        private static bool PositionIsValid(Cell nextCell)
        {
            bool isValid = true;

            if ((nextCell.Row < 0 || nextCell.Row >= matrix.GetLength(0)) ||
               (nextCell.Col < 0 || nextCell.Col >= matrix.GetLength(1)))
            {
                isValid = false;
                return isValid;
            }

            if (matrix[nextCell.Row, nextCell.Col] == UnpassablePath)
            {
                isValid = false;
                return isValid;
            }

            return isValid;
        }

        private static void GenerateMatrix(int rowCount, int colCount)
        {
            matrix = new char[rowCount, colCount];

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    matrix[row, col] = PassablePath;

                }
            }

            matrix[rowCount - 1, colCount - 1] = MatrixExit;
        }

        private static void PrintPath(int moves)
        {
            Console.WriteLine("Solution Found in {0} steps!", moves);
        }
    }
}
