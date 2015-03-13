/*
 * Problem 11. Adding polynomials
 * Write a method that adds two polynomials.
 * Represent them as arrays of their coefficients.
*/
using System;
using System.Linq;
class AddingPolynomials
{
    static void PrintPolynom(int[] pol)
    {
        Console.Write("The Result is ");
        for (int i = pol.Length - 1; i > 0; i--)
        {
            if (pol[i] != 0)
                Console.Write("{0}*x^{1} + ", pol[i], i);
        }
        Console.WriteLine(pol[0]);

        Console.Write("Result as Array: {");
        Console.Write(String.Join(", ", pol));
        Console.WriteLine("}");               
    }

    static void AddPolynom(string first, string second)
    {
        int resLen;
        int indexOut;
        string tmp;//points to largest array
        if (first.Length >= second.Length) // derminates how many numbers to add from each array
        {
            resLen = first.Length;
            indexOut = second.Length;
            tmp = first;
        }
        else
        {
            resLen = second.Length;
            indexOut = first.Length;
            tmp = second;
        }

        int[] result = new int[resLen];
        for (int i = 0; i < indexOut; i++)
        {
            result[i] = (first[i] - '0') + (second[i] - '0');
        }
        for (int j = indexOut; j < result.Length; j++) // adding numbers from the larger array
        {
            result[j] = (tmp[j] - '0');
        }

        PrintPolynom(result);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter polynomials as a sequance of their coefficiens from the lowest power(x^0).");
        
        Console.Write("First: ");
        string firstPol = Console.ReadLine();
        
        Console.Write("Second: ");
        string secondPol = Console.ReadLine();
        Console.WriteLine();

        AddPolynom(firstPol, secondPol);
        Console.WriteLine();
    }
}


