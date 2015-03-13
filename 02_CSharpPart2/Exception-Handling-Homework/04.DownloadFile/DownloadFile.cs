/*
 * Problem 4. Download file
 * Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
 * Find in Google how to download files in C#.
 * Be sure to catch all exceptions and to free any used resources in the finally block.
*/
using System;
using System.IO;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        try
        {
            WebClient webCilend = new WebClient();

            // feel free to change the adress
            string url = "http://telerikacademy.com/Content/Images/news-img01.png";
            string fileName = "TelerikNinja.png";

            webCilend.DownloadFile(url, fileName);
            Console.WriteLine("The picture is saved at {0}.", Directory.GetCurrentDirectory());
        }
        catch (UnauthorizedAccessException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (NotSupportedException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (WebException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

