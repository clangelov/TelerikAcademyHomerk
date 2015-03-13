/*
 * Problem 2. Concatenate text files
 * Write a program that concatenates two text files into another text file.
*/
using System;
using System.IO;
class ConcatenateTextFiles
{
    static void Main()
    {
        string firstFile = @"..\..\newsHonda.txt";
        string secondFile = @"..\..\newsHonda2.txt";
        string output = "result.txt";

        string inputOne = string.Empty;
        string inputTwo = string.Empty;

        // reading text one and two and adding it to string
        using (StreamReader streamReaderOne = new StreamReader(firstFile))
        {
            inputOne = streamReaderOne.ReadToEnd();
        }

        using (StreamReader streamReaderTwo = new StreamReader(secondFile))
        {
            inputTwo = streamReaderTwo.ReadToEnd();
        }

        // concatenate the two strings
        using (StreamWriter concatenateText = new StreamWriter(output))
        {
            concatenateText.WriteLine(inputOne);
            concatenateText.WriteLine(inputTwo);
        }

        Console.WriteLine("The Concatenate Text File can be found at \n02.ConcatenateTextFiles\\bin\\Debug");
    }
}

