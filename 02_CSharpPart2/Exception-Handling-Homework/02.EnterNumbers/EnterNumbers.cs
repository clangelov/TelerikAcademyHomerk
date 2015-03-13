/*
 * Problem 2. Enter numbers
 * Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
 * If an invalid number or non-number text is entered, the method should throw an exception
 * Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
using System;
class EnterNumbers
{
    public static int START = 1;
    public static int END = 100;     
    
    static int[] ReadNumber(int start, int end)
    {
        int[] tenNumbers = new int[10];        
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter number {0}: ", i);
                tenNumbers[i] = int.Parse(Console.ReadLine());
                if (tenNumbers[i] < START || tenNumbers[i] > END )
                {
                    throw new ArgumentOutOfRangeException(); 
                }
                else if (i > 0 && tenNumbers[i] < tenNumbers[i-1])
                {
                    throw new ArgumentOutOfRangeException(); 
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");       
        }

        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }

        return tenNumbers;
         
    }
    static void Main()
    { 
        
        int[] tenNumbers = new int[10];

        Console.WriteLine("You should enter 10 numbers in the range [1...100]");
        Console.WriteLine("All numbers should be in increasing oreder");
        
        ReadNumber(START,END);

        Console.WriteLine(string.Join(", ", tenNumbers));
        
    }
}

