/*
 * Problem 9. Delete odd lines
 * Write a program that deletes from given text file all odd lines.
 * The result should be in the same file.
*/
using System;
using System.IO;
using System.Collections.Generic;
class DeleteOddLines
{
    static void Main()
    {
        string fileName = @"..\..\news.txt";

        // saving the text to a List
        List<string> inputText = new List<string>();

        using (StreamReader streamReader = new StreamReader(fileName))
        {
            int index = 0;

            string line = streamReader.ReadLine();

            while (line != null)
            {

                inputText.Insert(index, line);

                index++;

                line = streamReader.ReadLine();
            }
        }

        using (StreamWriter writeText = new StreamWriter(fileName))
        {
            // writing only the odd lines
            for (int i = 1; i < inputText.Count; i+=2)
            {
                writeText.WriteLine(inputText[i].ToString());
            }
        }

        Console.WriteLine("The final result can be found at the 08.ReplaceWholeWord main directory");
        Console.WriteLine("as news.txt");
    }
}

