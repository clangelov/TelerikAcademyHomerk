/*
 * Problem 6. Save sorted names
 * Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
 *  input.txt	output.txt
 *  Ivan        George
    Peter       Ivan     
    Maria       Maria
    George      Peter 
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class SaveSortedNames
{
    static void Main()
    {
        string inputFile = @"..\..\inputName.txt";
        // string inputFile = @"..\..\inputName2.txt";
        string outputFile = @"..\..\result.txt";

        List<string> names = new List<string>();

        using (StreamReader readFile = new StreamReader(inputFile))
        {
            int lineNumber = 0;
            string line = readFile.ReadLine();
            while (line != null)
            {
                lineNumber++;

                names.Add(line);
                
                line = readFile.ReadLine();
            }
        }
                
        var sortedNames = names.OrderBy(x => x);

        using (StreamWriter saveResult = new StreamWriter(outputFile))
        {
            Console.WriteLine("The final result can be found at the 06.SaveSortedNames main directory");
            Console.WriteLine("as result.txt");
            foreach (var item in sortedNames)
            {                
                saveResult.WriteLine(item);
            }
        }
    }
}

