/*
 * Write a program that removes from a text file all words listed in given another text file.
 * Handle all possible exceptions in your methods.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class RemoveWords
{
    static void Main()
    {
        string fileInputName = @"..\..\news.txt";
        string adresWordToRaplce = @"..\..\words.txt";
        string fileOutputName = @"..\..\result.txt";

        List<string> wordReplace = new List<string>();

        try
        {
           using (StreamReader readWordsReplace = new StreamReader(adresWordToRaplce))
           {                
                while (!readWordsReplace.EndOfStream)
                {
                    string line = readWordsReplace.ReadLine();
                    // creating an list with the words which will be repalced
                    wordReplace.Insert(0, line);                    
                }
            }

            using (StreamReader readNews = new StreamReader(fileInputName))
            {
                using (StreamWriter writeResult = new StreamWriter(fileOutputName))
                {
                    while (!readNews.EndOfStream)
                    {
                        // making each line to be an array
                        //.Where(x => !wordReplace.Contains(x)) excludes all words which meet the given criteria
                        string[] wordsOnLine = readNews.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => !wordReplace.Contains(x))
                            .ToArray();
                                                
                        writeResult.WriteLine(string.Join(" ", wordsOnLine));
                    }
                }
            }

            Console.WriteLine("The final result can be found at the 12.RemoveWords main directory");
            Console.WriteLine("as result.txt");
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileLoadException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (EndOfStreamException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (IOException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }            
    }       
}


