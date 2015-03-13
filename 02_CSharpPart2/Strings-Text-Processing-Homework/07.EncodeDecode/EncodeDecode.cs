/*
 * Problem 7. Encode/decode
 * Write a program that encodes and decodes a string using given encryption key (cipher).
 * The key consists of a sequence of characters.
 * The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
*/
using System;
class EncodeDecode
{
    static void Main()
    {
        Console.WriteLine("Eneter some text to be encoded: ");
        string text = Console.ReadLine();
        
        Console.WriteLine("Enter the key: ");
        string key = Console.ReadLine();

        char[] charArr = text.ToCharArray();

        for (int i = 0; i < charArr.Length; i++)
        {
            charArr[i] ^= key[i % key.Length];
        }

        text = new string(charArr);

        Console.WriteLine("Encoded text: ");
        Console.WriteLine(text);

        char[] newCharArr = text.ToCharArray();

        for (int i = 0; i < text.Length; i++)
        {
            newCharArr[i] ^= key[i % key.Length];
        }

        text = new string(newCharArr);

        Console.WriteLine("Decoded text: ");
        Console.WriteLine(text);
    }
}

