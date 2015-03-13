/*
 * Problem 2. Maximal sum
 * Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
*/
using System;
class MaximalSum
{
    static void Main()
    {
        Console.WriteLine("This will create random generated matrix");

        Console.Write("Enter side N of the matrix: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter side M > N: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];
        
        Random random = new Random();

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                // this random.Next(0, 9) gives the range of the numbers which will be genarated 
                // feel free to change them
                matrix[row, col] = random.Next(0, 9);
            }
        }

        // Print the matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("{0,-4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', 30));

        // Solution
        int maxSum = int.MinValue;
        int bestRow = 0;    // this will give the starting point for printing the best platform
        int bestCol = 0;

        for (int row = 0; row < n - 2; row++)
        {
            for (int col = 0; col < m - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2]; 
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        
        Console.WriteLine("The best 3x3 platform is: ");
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0,-4}", matrix[bestRow+i,bestCol+j]);
            }
            Console.WriteLine();
            
        }
        
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("The sum is {0}",maxSum);
    }
}

