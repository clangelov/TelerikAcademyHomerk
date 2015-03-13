/*
 * Problem 7. One system to any other
 * Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).
*/
using System;
using System.Text;
class OneSystemToAnyOther
{
    private static long InputSToDec(string inputS, int baseS)
    {
        long decimalNum = 0;
        int curentIndex = inputS.Length - 1;
        int power = 0;

        while (curentIndex >= 0)
        {
            int stepNumber = inputS[curentIndex] - 48;

            if (stepNumber > 9)
            {
                stepNumber -= 7;
            }
            decimalNum += stepNumber * (int)Math.Pow(baseS, power++);
            curentIndex--;
        }
        return decimalNum;
    }

    private static string DecToBaseD(long decNum, int baseD)
    {
        StringBuilder numberBaseD = new StringBuilder();


        while (decNum > 0)
        {
            int index = 0;
            char numberBaseDValue = '0';

            if (((decNum % baseD) >= 0) && ((decNum % baseD <= 9)))
            {
                numberBaseDValue = (char)((decNum % baseD) + 48);
                numberBaseD.Insert(index, numberBaseDValue);
            }
            else
            {
                numberBaseDValue = (char)((decNum % baseD) + 55);
                numberBaseD.Insert(index, numberBaseDValue);
            }
            decNum = decNum / baseD;
            index++;
        }

        string result = Convert.ToString(numberBaseD);
        return result;
    }
    static void Main()
    {
        Console.Write("Enter the base of the numberical system: ");
        int baseS = int.Parse(Console.ReadLine());

        Console.Write("Transform to numerical system with base D = ");
        int baseD = int.Parse(Console.ReadLine());

        if ((baseS > 16 || baseS < 2) || (baseD > 16 || baseD < 2))
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        Console.WriteLine("Enter number in {0} numerical system: ", baseS);
        string inputS = Console.ReadLine();
        
        inputS = inputS.ToUpper();

        if (inputS == "0")
        {
            Console.WriteLine("The result in numerical system with base {0} is:", baseD);
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine("The result in numerical system with base {0} is:", baseD);
            Console.WriteLine(DecToBaseD(InputSToDec(inputS, baseS), baseD));
        }
    }    
}

