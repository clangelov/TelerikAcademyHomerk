/*
 * Problem 4. Compare text files
 * Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
 * Assume the files have equal number of lines.
*/
using System;
using System.IO;
class CompareTextFiles
{
    static void Main()
    {
        string firstFile = @"..\..\news.txt";
        string secondFile = @"..\..\news2.txt";

        using (StreamReader readNews = new StreamReader(firstFile))
        {
            using (StreamReader readOtherNews = new StreamReader(secondFile))
            {
                int lineNumber = 0;

                string lineFirstInput = readNews.ReadLine();
                string lineSecondInput = readOtherNews.ReadLine();

                while (lineFirstInput != null && lineSecondInput != null)
                {
                    lineNumber++;

                    bool equal = true;

                    if (lineFirstInput == lineSecondInput) // checking if the lines are equal    
                    {
                        Console.WriteLine("Lines {0} Are Equal {1}", lineNumber, equal);
                    }
                    else
                    {
                        Console.WriteLine("Lines {0} Are Equal {1}", lineNumber, !equal);
                    }

                    lineFirstInput = readNews.ReadLine();
                    lineSecondInput = readOtherNews.ReadLine();
                }
            }
        }
    }
}

