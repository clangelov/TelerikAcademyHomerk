/*
 * Problem 1. Fill the matrix
 * Write a program that fills and prints a matrix of size (n, n) as shown below:
 *  a)	                b)	                c)	                d)*
 *  1	5	9	13      1	8	9	16      7	11	14	16      1	12	11	10
 *  2	6	10	14      2	7	10	15      4	8	12	15      2	13	16	9
    3	7	11	15      3	6	11	14      2	5	9	13      3	14	15	8
    4	8	12	16      4	5	12	13      1	3	6	10      4	5	6	7
*/
using System;
class FillTheMatrix
{
    // Creating a method who will print the result
    static void PrintMatrix(int[,] matrix, int size)
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write("{0,-4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', 30));
    }
    static void Main()
    {
        Console.Write("Please enter the size of the matrix: ");
        int size = int.Parse(Console.ReadLine());
        int number = 1;

        int[,] matrix = new int[size, size];

        Console.WriteLine("Option A: ");
        for (int col = 0; col < size; col++)
        {
            for (int row = 0; row < size; row++)
            {
                matrix[row, col] = number + row;
            }
            number += size;

        }
        // Print the matrix
        PrintMatrix(matrix, size);
        
        Console.WriteLine("Option B: ");
        // setting back number to 1;
        number = 1;

        for (int col = 0; col < size; col++)
        {
            if (col % 2 == 0) // Using this logic for collums 0,2,4.... 
            {
                for (int row = 0; row < size; row++)
                {
                    matrix[row, col] = number + row;
                }            
            }

            number += size;

            if (col % 2 != 0) // Reversed logic for collums 1,3,5.... 
            {
                for (int row = size-1; row >= 0; row--)
                {
                    matrix[row, col] = number - row-1;
                } 
            }              
        }
        // Print the matrix
        PrintMatrix(matrix, size);

        Console.WriteLine("Option C: ");
        // setting back number to 1;
        number = 1;
        matrix[size - 1, 0] = 1;
        for (int row = size - 2; row >= 0; row--)
        {
            matrix[row, 0] = matrix[row + 1, 0] + number;
            int newRow = row;
            for (int diagonal = 1; diagonal <= number; diagonal++)
            {
                matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                newRow++;
            }
            number++;
        }
        matrix[0, size - 1] = size * size;
        int diagonalLength = 2;
        int posX = 1;
        int posY = size - 1;
        int prevX = 0;
        int prevY = size - 1;

        for (int i = 1; i < number - 1; i++)
        {
            for (int j = 1; j <= diagonalLength; j++)
            {
                matrix[posX, posY] = matrix[prevX, prevY] - 1;
                prevX = posX;
                prevY = posY;
                posX--;
                posY--;
            }
            diagonalLength++;
            posX = i + 1;
            posY = size - 1;
        }
        // Print the matrix
        PrintMatrix(matrix, size);

        Console.WriteLine("Option D: ");
               
        int column = 0;         // I use column, row and lenght to navigate thru the matrix
        int roww = 0;
        int length = size;
        number = size * size;
        int currentNumber = 1;

        while (currentNumber <= number)
        {

            for (int i = 0; i < length; i++)
            {
                matrix[roww, column] = currentNumber;
                currentNumber++;
                roww++;
            }
            column++;
            roww--;
            length--;

            for (int i = 0; i < length; i++)
            {
                matrix[roww, column] = currentNumber;
                currentNumber++;
                column++;
            }

            roww--;
            column--;            

            for (int i = 0; i < length; i++)
            {
                matrix[roww, column] = currentNumber;
                currentNumber++;
                roww--;
            }
            column--;
            roww++;
            length--;

            for (int i = 0; i < length; i++)
            {
                matrix[roww, column] = currentNumber;
                currentNumber++;
                column--;
            }
            roww++;
            column++;            

        }
        // Print the matrix
        PrintMatrix(matrix, size);

    }
}

