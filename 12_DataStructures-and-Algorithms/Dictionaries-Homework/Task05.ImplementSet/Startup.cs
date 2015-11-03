namespace Task05.ImplementSet
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var firstSet = new MyHashSet<int>();
            var secondSet = new MyHashSet<int>();

            for (int i = 0; i < 15; i++)
            {
                int valueToAdd = i * 5;
                firstSet.Add(valueToAdd);
                if (i % 3 == 0)
                {
                    secondSet.Add(valueToAdd);
                }
            }

            secondSet.Add(13);
            secondSet.Add(19);

            Console.WriteLine("First set count of elements = {0}", firstSet.Count);

            firstSet.Remove(20);
            firstSet.Remove(5);
            Console.WriteLine("First set count of elements = {0}", firstSet.Count);

            int ten = firstSet.Find(10);
            Console.WriteLine("Is ten in the first set {0}", ten == 10 ? "YES" : "NO");

            Console.WriteLine("First set = {0}", firstSet);
            Console.WriteLine("Second set = {0}", secondSet);

            var unionSet = firstSet.Union(secondSet);
            Console.WriteLine("Union set = {0}", unionSet);

            var intersectSet = firstSet.Intersect(secondSet);
            Console.WriteLine("Intersect set = {0}", intersectSet);
        }
    }
}
