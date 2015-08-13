namespace Matrix
{
    using System;

    public class WalkInMatrix
    {
        private const int InitialStartRow = 0;
        private const int InitialStartCol = 0;

        private static int[,] matrix;
        private static int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };       

        public static int[,] FillMatrix(int matrixSize)
        {
            matrix = new int[matrixSize, matrixSize];
            int numberToAdd = 1;
            var position = PositionInMatrix.Instace;
            position.CurrenRow = InitialStartRow;
            position.CurrentCol = InitialStartCol;

            while (TryGetEmptyCell(position))
            {
                matrix[position.CurrenRow, position.CurrentCol] = numberToAdd++;
                int currentDir = 0;

                while (IsNextToEmptyCell(position))
                {
                    currentDir = GetNewDirection(position, currentDir);

                    while (CanGoInThisDirection(position, currentDir))
                    {
                        position.CurrenRow += directionsRow[currentDir];
                        position.CurrentCol += directionsCol[currentDir];
                        matrix[position.CurrenRow, position.CurrentCol] = numberToAdd++;
                    }
                }
            }

            return matrix;
        }

        private static int GetNewDirection(PositionInMatrix position, int currrentDir)
        {
            while (!CanGoInThisDirection(position, currrentDir))
            {
                currrentDir = (currrentDir == 7) ? 0 : currrentDir + 1;
            }

            return currrentDir;
        }

        private static bool CanGoInThisDirection(PositionInMatrix position, int currentDir)
        {
            int nextRow = position.CurrenRow + directionsRow[currentDir];
            int nextCol = position.CurrentCol + directionsCol[currentDir];
            var result =
                IsInsideMatrix(nextRow, nextCol) &&
                matrix[nextRow, nextCol] == 0;
            return result;
        }

        private static bool IsInsideMatrix(int row, int col)
        {
            var isInside =
                row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
            return isInside;
        }

        private static bool IsNextToEmptyCell(PositionInMatrix position)
        {
            int row;
            int col;

            for (int i = 0; i < directionsRow.Length; i++)
            {
                row = position.CurrenRow + directionsRow[i];
                col = position.CurrentCol + directionsCol[i];
                if (IsInsideMatrix(row, col) && matrix[row, col] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TryGetEmptyCell(PositionInMatrix position)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        position.CurrenRow = row;
                        position.CurrentCol = col;
                        return true;
                    }
                }
            }

            position.CurrenRow = 0;
            position.CurrentCol = 0;
            return false;
        }      
    }
}
