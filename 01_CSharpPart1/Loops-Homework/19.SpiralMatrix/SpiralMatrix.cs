
/* Problem 19.** Spiral Matrix
 * Write a program that reads from the console a positive integer number n (1 = n = 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.
*/

using System;
class SpiralMatrix
{
    static void Main()
    {
        Console.Write("n = ");
        int side = int.Parse(Console.ReadLine());
        int[,] matrix = new int[side, side];

        int column = 0;
        int row = 0;        
        int length = side;        
        int number = side * side;
        int currentNumber = 1;

        while (currentNumber <= number)
        {            
            for (int i = 0; i < length; i++)
            {
                matrix[row, column] = currentNumber;
                currentNumber++;
                column++;
            }
            
            row++;
            column--;            
            length--;

            for (int i = 0; i < length; i++)
            {
                matrix[row, column] = currentNumber;
                currentNumber++;
                row++;
            }
            column--;
            row--;

            for (int i = 0; i < length; i++)
            {
                matrix[row, column] = currentNumber;
                currentNumber++;
                column--;
            }
            row--;
            column++;            
            length--;

            for (int i = 0; i < length; i++)
            {
                matrix[row, column] = currentNumber;
                currentNumber++;
                row--;
            }
            column++;
            row++;
        }
        
        for (int r = 0; r < side; r++)
        {
            Console.WriteLine();
            for (int c = 0; c < side; c++)
            {
                Console.Write("{0,3}", matrix[r, c]);
            }
        }
        
        Console.WriteLine();
        Console.WriteLine();
    }
}

