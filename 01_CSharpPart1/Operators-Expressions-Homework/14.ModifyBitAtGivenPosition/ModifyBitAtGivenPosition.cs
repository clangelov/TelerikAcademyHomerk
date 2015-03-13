using System;

class ModifyBitAtGivenPosition
{
    /* Problem 14. Modify a Bit at Given Position
     * We are given an integer number n, a bit value v (v=0 or 1) and a position p.
     * Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n.
    */
    static void Main()
    {
        int number, position, value, mask, result;
       
        Console.Write("Please enter a number: ");
        number = int.Parse(Console.ReadLine());
        Console.Write("Enter Bit Position: ");
        position = int.Parse(Console.ReadLine());
        Console.Write("Enter Bit Value: ");
        value = int.Parse(Console.ReadLine());
       
        if (value == 0)
        {
            mask = ~(1 << position);
            result = number & mask;
            Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
            Console.WriteLine("The result is: {0}", result);
        }
        else
        {
            mask = 1 << position;          
            result = number | mask;      
            Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
            Console.WriteLine("The result is: {0}", result);
        }
    }
}

