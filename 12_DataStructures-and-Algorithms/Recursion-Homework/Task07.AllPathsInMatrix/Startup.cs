namespace Task07.AllPathsInMatrix
{
    using System;

    public class Startup
    {
        private const char PassablePath = ' ';
        private const char UnpassablePath = '0';
        private const char BlockedPath = '*';
        private const char MatrixExit = 'e';

        private static char[,] matrix =
        {
            { ' ', ' ', '*', ' ', ' ', ' ', ' ' },
            { '*', ' ', '*', ' ', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        public static void Main()
        {
            FindAllPathsInAMatrix(0, 0);
        }

        private static void FindAllPathsInAMatrix(int row, int col)
        {
            if ((row < 0 || row >= matrix.GetLength(0)) || 
                (col < 0 || col >= matrix.GetLength(1)))
            {
                return;
            }

            if (matrix[row, col] == UnpassablePath ||
                matrix[row, col] == BlockedPath)
            {
                return;
            }

            if (matrix[row, col] == MatrixExit)
            {
                PrintPath();
                return;
            }

            MarkCurrentAsVisited(row, col);

            // UP
            FindAllPathsInAMatrix(row - 1, col);

            // RIGTH
            FindAllPathsInAMatrix(row, col + 1);

            // DOWN
            FindAllPathsInAMatrix(row + 1, col);

            // LEFT
            FindAllPathsInAMatrix(row, col - 1);

            UnMarkCurrentAsVisited(row, col);
        }

        private static void UnMarkCurrentAsVisited(int row, int col)
        {
            matrix[row, col] = PassablePath;
        }

        private static void MarkCurrentAsVisited(int row, int col)
        {
            matrix[row, col] = UnpassablePath;
        }

        private static void PrintPath()
        {
            Console.WriteLine("Solution: ");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
