/*
 * Problem 3. Correct brackets
 * Write a program to check if in a given expression the brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).
*/
using System;
class CorrectBrackets
{
    static void Main()
    {
        Console.Write("Eneter an math expresssion: ");
        string input = Console.ReadLine();

        int bracketCount = 0;
        bool correctExpression = true;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                ++bracketCount;
            }
            else if (input[i] == ')')
            {
                --bracketCount;
            }
            if (bracketCount < 0)
            {
                correctExpression = false;
                break;
            }
        }

        if (bracketCount != 0)
        {
            correctExpression = false;
        }

        Console.WriteLine("The brakets in {0} are put correctly: {1}!", input, correctExpression);

    }
}

