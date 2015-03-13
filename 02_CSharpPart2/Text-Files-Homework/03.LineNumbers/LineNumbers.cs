/*
 * Problem 3. Line numbers
 * Write a program that reads a text file and inserts line numbers in front of each of its lines.
 * The result should be written to another text file.
*/
using System;
using System.IO;
class LineNumbers
{
    static void Main()
    {
        string fileName = @"..\..\news.txt";
        string output = "resulted.txt";
         
        using (StreamWriter writeLines = new StreamWriter(output))
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                int lineNumber = 0;

                string line = streamReader.ReadLine();
                
                while (line != null)
                {
                    lineNumber++;

                    writeLines.WriteLine("Line {0}: {1}", lineNumber, line);                    

                    line = streamReader.ReadLine();
                }
            }
        }

        Console.WriteLine("The Result File can be found at \n02.03.LineNumbers\\bin\\Debug");
    }
}

