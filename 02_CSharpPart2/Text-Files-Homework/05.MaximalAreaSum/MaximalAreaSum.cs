/*
 * Problem 5. Maximal area sum
 * Write a program that reads a text file containing a square matrix of numbers.
 * Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
 * The first line in the input file contains the size of matrix N.
 * Each of the next N lines contain N numbers separated by space.
 * The output should be a single number in a separate text file.
*/
using System;
using System.IO;
class MaximalAreaSum
{
    static void Main()
    {
        string inputFile = @"..\..\inputMatrix.txt";
        // string inputFile = @"..\..\inputMatrix-2.txt";

        string outputFile = @"..\..\result.txt";

        int matrixSize = int.MaxValue;

        using (StreamReader readInput = new StreamReader(inputFile))
        {
            string line = readInput.ReadLine();
            matrixSize = int.Parse(line);

            int[,] matrix = new int[matrixSize, matrixSize];

            int rows = 0;
            int bestStum = int.MinValue;

            while (line != null)
            {                 
                line = readInput.ReadLine();
                if (line != null)
                {
                    string[] str = line.Split(' ');

                    for (int i = rows; i <= rows; i++)
                    {
                        for (int j = 0; j < matrixSize; j++)
                        {
                            matrix[i, j] = Int32.Parse(str[j]);
                        }
                    }
                    rows++;
                }                
            }

            for (int row = 0; row < matrixSize - 1; row++)
            {
                for (int col = 0; col < matrixSize - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row + 1, col] + 
                        matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (sum > bestStum)
                    {
                        bestStum = sum;
                    }
                }
            }

            using (StreamWriter printResult = new StreamWriter(outputFile))
            {
                Console.WriteLine("The final result can be found at the 05.MaximalAreaSum main directory");
                Console.WriteLine("as result.txt");
                printResult.WriteLine(bestStum);
            }            
        }
    }
}

