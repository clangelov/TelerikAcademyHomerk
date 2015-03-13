/*
 * Problem 10. Extract text from XML
 * Write a program that extracts from given XML file all the text without the tags.
*/
using System;
using System.IO;
class ExtractTextFromXML
{
    static void Main()
    {
        string fileName = @"..\..\someInput.txt";

        using (StreamReader streamReader = new StreamReader(fileName))
        {
            string line = streamReader.ReadLine();

            string extractWord = string.Empty;

            while (line != null)
            {
                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i - 1] == '>')
                    {
                        while (line[i] != '<')
                        {
                            extractWord += line[i];
                            i++;
                        }
                        if (extractWord != "")
                        {
                            Console.WriteLine(extractWord.TrimStart(' '));
                            extractWord = "";
                        }
                    }
                }
                line = streamReader.ReadLine();
            }
        }
    }
}

