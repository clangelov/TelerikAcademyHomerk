/*
 * Problem 8. Replace whole word
 * Modify the solution of the previous problem to replace only whole words (not strings).
*/
using System;
using System.IO;
using System.Text.RegularExpressions;
class ReplaceWholeWord
{
    static void Main()
    {
        string inputFile = @"..\..\inputString.txt";

        string outputFile = @"..\..\result.txt";

        string replaceWords = string.Empty;

        // we have a whole word when there is a whitespace at the beginning and at the end
        string wordToRepce = " sTart ";
        string wordInsert = " finish ";

        using (StreamReader readText = new StreamReader(inputFile))
        {
            replaceWords = readText.ReadToEnd().ToString();
        }

        // RegexOptions.IgnoreCase = case-insensitive string replacement
        replaceWords = Regex.Replace(replaceWords, wordToRepce, wordInsert, RegexOptions.IgnoreCase);

        using (StreamWriter printText = new StreamWriter(outputFile))
        {
            printText.Write(replaceWords);
        }

        Console.WriteLine("The final result can be found at the 08.ReplaceWholeWord main directory");
        Console.WriteLine("as result.txt");
    }
}

