using System;
using System.Text;

class ASCIITable
{
    /* Problem 14.* Print the ASCII Table
     * Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
    */
    static void Main()
    {
        Console.OutputEncoding = Encoding.ASCII;
        Console.OutputEncoding = Encoding.UTF8;
        Console.BufferHeight = 257;

        for (int i = 0; i < 256; i++)
        {
            char symbol = (char)i;
            Console.WriteLine("{0}: {1}", i, symbol);
        }
    }
}

