﻿
/* Problem 5. Maximal increasing sequence
 * Write a program that finds the maximal increasing sequence in an array.
 * Example:
 * Input: 3, 2, 3, 4, 2, 2, 4 Result: 2, 3, 4
*/
using System;

class MaximalIncreasingSequence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter N numbers separated by space or coma: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] array = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            array[i] = Convert.ToInt32(numbers[i]);
        }

        int counter = 1;
        int longestSequence = 0;
        string sequenceNums = "";
        string maxSequenceNums = "";
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                counter++;
                sequenceNums += array[i] + " ";
            }
            else
            {
                if (longestSequence < counter)
                {
                    longestSequence = counter;
                    sequenceNums += array[i] + " ";
                    maxSequenceNums = sequenceNums;
                }
                counter = 1;
                sequenceNums = "";
            }
        }

        if (longestSequence < counter)
        {
            sequenceNums += array[array.Length - 1];
            maxSequenceNums = sequenceNums;
        }

        Console.WriteLine("The longest increasing sequence is of {0} elements: {1}", longestSequence,maxSequenceNums);
        
    }
}