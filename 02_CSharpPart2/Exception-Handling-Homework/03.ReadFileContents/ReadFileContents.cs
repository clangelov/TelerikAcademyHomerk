/*
 * Problem 3. Read file contents
 * Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console.
 * Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
*/
using System;
using System.IO;
class ReadFileContents
{
    static void ReadFile(string filePath)
    {
        try
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine("Printing the content: ");
            Console.WriteLine(fileContent);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The directory in which the file is located is missing.");
            Console.WriteLine("Try again");
            Main();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Could not find file");
            Console.WriteLine("Try again");
            Main();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Zero-length strings are invalid");
            Console.WriteLine("Try again");
            Main();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The entered path to the file is too long");
            Console.WriteLine("Try again");
            Main();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have a permission to access this file");
            Console.WriteLine("Try again");
            Main();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The text format is not supported by this programm");
            Console.WriteLine("Try again");
            Main();
        }
        catch (IOException)
        {
            Console.WriteLine("This programm can't handle your request");
            Console.WriteLine("Try again");
            Main();
        }
    }
    static void Main()
    {
        // C:\Windows\win.ini
        Console.WriteLine("Enter the full path to a file:");
        string filePath = Console.ReadLine();

        ReadFile(filePath);
    }
}

