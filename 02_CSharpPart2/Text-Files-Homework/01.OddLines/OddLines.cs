/*
 * Problem 1. Odd lines
 * Write a program that reads a text file and prints on the console its odd lines.
*/
using System;
using System.IO;
class OddLines
{
    static void Main()
    {
        string fileName = @"..\..\OddLines.cs";

        Console.WriteLine("All odd lines are:");

        using (StreamReader streamReader = new StreamReader(fileName))
        {
            int lineNumber = 0;
            string line = streamReader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0) // checking if the line is odd      
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                }
                line = streamReader.ReadLine();
            }
        }
    }
}

