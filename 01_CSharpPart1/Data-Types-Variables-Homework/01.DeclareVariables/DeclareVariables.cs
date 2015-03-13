using System;


class DeclareVariables
{
    /* Problem 1. Declare Variables
     * Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000
     * Choose a large enough type for each number to ensure it will fit in it. Try to compile the code
    */
    static void Main()
    {
        ushort numberOne = 52130;
        Console.WriteLine(numberOne);
        sbyte numberTwo = -115;
        Console.WriteLine(numberTwo);
        int numberThree = 4825932;
        Console.WriteLine(numberThree);
        byte numberFour = 97;
        Console.WriteLine(numberFour);
        short numberFive = -10000;
        Console.WriteLine(numberFive);
        
    }
}

