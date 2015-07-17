namespace Task02._3.BishopPathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BishopPathFinder
    {
        public static void Main()
        {
            int[] matrixSize = ReadMatrixSize();

            int[,] matrix = FillMatrixWithNumbers(matrixSize[0], matrixSize[1]);

            int numberOfCommands = int.Parse(Console.ReadLine());

            // storing all commands and their repetion number in two lists on the same position
            List<string> commands = new List<string>(numberOfCommands);
            List<int> repeatCommand = new List<int>(numberOfCommands);
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                commands.Add(input[0]);
                repeatCommand.Add(int.Parse(input[1]));
            }

            long finalResult = FindSolution(matrix, commands, repeatCommand, matrixSize);

            Console.WriteLine(finalResult);
        }

        private static int[] ReadMatrixSize()
        {
            int[] matrixSize = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            return matrixSize;
        }

        private static long FindSolution(int[,] matrix, List<string> commands, List<int> repeatCommand, int[] matrixSize)
        {
            int maxRow = matrixSize[0] - 1;
            int maxCol = matrixSize[1] - 1;
            int minRowColPosition = 0;

            // setting the start position to bottom left corner
            int[] nextPosition = new int[] { maxRow, 0 };
            bool[,] visited = new bool[matrixSize[0], matrixSize[1]];

            long maxSum = 0;
            for (int i = 0; i < commands.Count; i++)
            {
                int repeatMove = 0;

                if (commands[i] == "RU" || commands[i] == "UR")
                {
                    // checking how many times I need to repeat the comand
                    repeatMove = repeatCommand[i];
                    for (int j = 1; j < repeatMove; j++)
                    {
                        // setting the next position
                        nextPosition[0] -= 1;
                        nextPosition[1] += 1;

                        // checking if it's not outside the matrix
                        if (IsPositionOutsideMatrix(nextPosition[0], nextPosition[1], maxRow, maxCol, minRowColPosition))
                        {
                            // returning the bishop to the matrix, so that other commands can be executed
                            nextPosition[0] += 1;
                            nextPosition[1] -= 1;
                            break;
                        }

                        if (!visited[nextPosition[0], nextPosition[1]])
                        {
                            // if the cell is not visited addig it's value to the sum
                            maxSum += matrix[nextPosition[0], nextPosition[1]];
                            visited[nextPosition[0], nextPosition[1]] = true;
                        }
                    }
                }

                if (commands[i] == "LU" || commands[i] == "UL")
                {
                    repeatMove = repeatCommand[i];
                    for (int j = 1; j < repeatMove; j++)
                    {
                        nextPosition[0] -= 1;
                        nextPosition[1] -= 1;

                        if (IsPositionOutsideMatrix(nextPosition[0], nextPosition[1], maxRow, maxCol, minRowColPosition))
                        {
                            nextPosition[0] += 1;
                            nextPosition[1] += 1;
                            break;
                        }

                        if (!visited[nextPosition[0], nextPosition[1]])
                        {
                            maxSum += matrix[nextPosition[0], nextPosition[1]];
                            visited[nextPosition[0], nextPosition[1]] = true;
                        }
                    }
                }

                if (commands[i] == "DL" || commands[i] == "LD")
                {
                    repeatMove = repeatCommand[i];
                    for (int j = 1; j < repeatMove; j++)
                    {
                        nextPosition[0] += 1;
                        nextPosition[1] -= 1;

                        if (IsPositionOutsideMatrix(nextPosition[0], nextPosition[1], maxRow, maxCol, minRowColPosition))
                        {
                            nextPosition[0] -= 1;
                            nextPosition[1] += 1;
                            break;
                        }

                        if (!visited[nextPosition[0], nextPosition[1]])
                        {
                            maxSum += matrix[nextPosition[0], nextPosition[1]];
                            visited[nextPosition[0], nextPosition[1]] = true;
                        }
                    }
                }

                if (commands[i] == "DR" || commands[i] == "RD")
                {
                    repeatMove = repeatCommand[i];
                    for (int j = 1; j < repeatMove; j++)
                    {
                        nextPosition[0] += 1;
                        nextPosition[1] += 1;

                        if (IsPositionOutsideMatrix(nextPosition[0], nextPosition[1], maxRow, maxCol, minRowColPosition))
                        {
                            nextPosition[0] -= 1;
                            nextPosition[1] -= 1;
                            break;
                        }

                        if (!visited[nextPosition[0], nextPosition[1]])
                        {
                            maxSum += matrix[nextPosition[0], nextPosition[1]];
                            visited[nextPosition[0], nextPosition[1]] = true;
                        }
                    }
                }
            }

            return maxSum;
        }

        private static bool IsPositionOutsideMatrix(int nextPositionRow, int nextPositionCol, int maxRow, int maxCol, int minPosition)
        {
            if (nextPositionRow < minPosition || minPosition > nextPositionCol)
            {
                return true;
            }

            if (nextPositionRow > maxRow || nextPositionCol > maxCol)
            {
                return true;
            }

            return false;
        }

        private static int[,] FillMatrixWithNumbers(int sizeOfRows, int sizeOfCols)
        {
            int[,] matrix = new int[sizeOfRows, sizeOfCols];
            int sum = 0;

            // filing col[0] starting from the bottom  
            for (int i = sizeOfRows - 1; i >= 0; i--)
            {
                matrix[i, 0] = sum;
                sum += 3;
            }

            sum = matrix[0, 0];

            // filing row[0] starting left to right
            for (int i = 0; i < sizeOfCols; i++)
            {
                matrix[0, i] = sum;
                sum += 3;
            }

            // filling all other cells
            for (int row = 1; row < sizeOfRows; row++)
            {
                for (int col = 1; col < sizeOfCols; col++)
                {
                    int add = matrix[row - 1, col] - 3;
                    matrix[row, col] = add;
                }
            }

            return matrix;
        }
    }
}
