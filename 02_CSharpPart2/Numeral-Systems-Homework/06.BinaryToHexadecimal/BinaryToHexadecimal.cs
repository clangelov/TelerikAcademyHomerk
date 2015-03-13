/*
 * Problem 6. binary to hexadecimal
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
using System;
using System.Linq;
using System.Text;
class BinaryToHexadecimal
{
    static void Main()
    {
        Console.Write("Enter a Binary number: ");
        string binary = Console.ReadLine();

        // This solution will work only with 32 bit int numbers
        binary = binary.PadLeft(32, '0');

        StringBuilder hexadecimal = new StringBuilder();

        for (int i = binary.Length - 1; i >= 3; i-=4)
        {
            int index = 0;
            
            // creating a string that holds 4 Binary digits
            string temp = binary.Substring(i-3, 4);
            
            switch (temp)
            {
                case "0000": hexadecimal.Insert(index, "0");
                    break;
                case "0001": hexadecimal.Insert(index, "1");
                    break;
                case "0010": hexadecimal.Insert(index, "2");
                    break;
                case "0011": hexadecimal.Insert(index, "3");
                    break;
                case "0100": hexadecimal.Insert(index, "4");
                    break;
                case "0101": hexadecimal.Insert(index, "5");
                    break;
                case "0110": hexadecimal.Insert(index, "6");
                    break;
                case "0111": hexadecimal.Insert(index, "7");
                    break;
                case "1000": hexadecimal.Insert(index, "8");
                    break;
                case "1001": hexadecimal.Insert(index, "9");
                    break;
                case "1010": hexadecimal.Insert(index, "A");
                    break;
                case "1011": hexadecimal.Insert(index, "B");
                    break;
                case "1100": hexadecimal.Insert(index, "C");
                    break;
                case "1101": hexadecimal.Insert(index, "D");
                    break;
                case "1110": hexadecimal.Insert(index, "E");
                    break;
                case "1111": hexadecimal.Insert(index, "F");
                    break;
                default: Console.WriteLine("Eror");
                    break;
            }

            temp = "";
            index++;
        }

        string result = Convert.ToString(hexadecimal);

        // finding the position of the firts symbol from the Hexadecimal numerical system
        int firstOne = result.IndexOfAny
            (new char[] { '1', '2', '3','4','5','6','7','8','9','A','B','C','D','E', 'F'});

        // removing all leading zeros
        result = result.Remove(0, firstOne);

        Console.WriteLine("The result is: {0}", result);
    }
}

