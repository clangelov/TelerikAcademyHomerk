/*
 * Problem 6. binary to hexadecimal
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
using System;
using System.Text;
using System.Linq;
class HexadecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter a Hexadecimal number: ");
        string hexadec = Console.ReadLine();
        
        hexadec = hexadec.ToUpper();

        // Easy Solution with Supported bases 2, 8, 10 and 16
        // int fromBase = 16;
        // int toBase = 2;
        // String result = Convert.ToString(Convert.ToInt32(hexadec, fromBase), toBase);
        // Console.WriteLine("The result is: {0}", result);

        StringBuilder binary = new StringBuilder();

        for (int i = hexadec.Length - 1; i >= 0; i--)
        {
            int index = 0;

            switch (hexadec[i])
            {
                case '0': binary.Insert(index, "0000");
                    break;
                case '1': binary.Insert(index, "0001");
                    break;
                case '2': binary.Insert(index, "0010");
                    break;
                case '3': binary.Insert(index, "0011");
                    break;
                case '4': binary.Insert(index, "0100");
                    break;
                case '5': binary.Insert(index, "0101");
                    break;
                case '6': binary.Insert(index, "0110");
                    break;
                case '7': binary.Insert(index, "0111");
                    break;
                case '8': binary.Insert(index, "1000");
                    break;
                case '9': binary.Insert(index, "1001");
                    break;
                case 'A': binary.Insert(index, "1010");
                    break;
                case 'B': binary.Insert(index, "1011");
                    break;
                case 'C': binary.Insert(index, "1100");
                    break;
                case 'D': binary.Insert(index, "1101");
                    break;
                case 'E': binary.Insert(index, "1110");
                    break;
                case 'F': binary.Insert(index, "1111");
                    break;
                default: Console.WriteLine("Eror");
                    break;
            }
            index++;           
        }        

        string result = Convert.ToString(binary);

        // finding the position of the firts 1
        int firstOne = result.IndexOf('1');

        // removing all leading zeros, staring from index 0 with lenght the first position of 1
        result = result.Remove(0, firstOne);

        // or use simple .TrimStart('0')
        
        Console.WriteLine("The result is: {0}", result);
    }
}

