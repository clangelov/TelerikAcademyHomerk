/*
 * Problem 7. Replace sub-string
 * Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
 * Ensure it will work with large files (e.g. 100 MB).
*/
using System;
using System.IO;
using System.Text.RegularExpressions;
class ReplaceSubString
{
    static void Main()
    {
        string inputFile = @"..\..\inputString.txt";

        string outputFile = @"..\..\result.txt";

        string replaceWords = string.Empty;

        string wordToRepce = "start";
        string wordInsert = "finish";

        using (StreamReader readText = new StreamReader(inputFile))
        {
            replaceWords = readText.ReadToEnd().ToString();
        }

        // Regex.Replace search the replaceWords for all occurances of wordToRepce, 
        // and replace them with wordInsert
        replaceWords = Regex.Replace(replaceWords, wordToRepce, wordInsert);

        using (StreamWriter printText = new StreamWriter(outputFile))
        {
            printText.Write(replaceWords);
        }

        Console.WriteLine("The final result can be found at the 07.ReplaceSubString main directory");
        Console.WriteLine("as result.txt");

    }
}

