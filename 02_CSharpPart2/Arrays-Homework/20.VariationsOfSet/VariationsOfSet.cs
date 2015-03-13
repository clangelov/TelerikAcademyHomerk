
/* Problem 20.* Variations of set 
 * Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
 * N	K	result
    3	2	{1, 1} 
            {1, 2} 
            {1, 3} 
            {2, 1} 
            {2, 2} 
            {2, 3} 
            {3, 1} 
            {3, 2} 
            {3, 3}
*/
using System;
class VariationsOfSet
{
    static int combinations;
    static int numbers;
    static int[] loops;
        static void NestedLoops(int currentLoop)
        {
            if (currentLoop == combinations)
            {
                PrintLoops();
                return;
            }
            for (int index = 1; index <= numbers; index++)
            {
                loops[currentLoop] = index;
                NestedLoops(currentLoop + 1);
            }
        }
        static void PrintLoops()
        {
            Console.Write("{");
            Console.Write(String.Join(", ", loops));
            Console.WriteLine("}");
        }
        static void Main()
        {
            Console.Write("Numbers 1 to N = ");
            numbers = int.Parse(Console.ReadLine());
            Console.Write("Combinations K = ");
            combinations = int.Parse(Console.ReadLine());
                                    
            loops = new int[combinations];
            NestedLoops(0);
        }        
}