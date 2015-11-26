namespace Task03.TVCompany
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int[,] adjMatrix;

        public static void Main()
        {
            string[] input = GenerateInput();

            BuildGraph(input);

            SolveWithPrim(adjMatrix);
        }

        private static void SolveWithPrim(int[,] adjMatrix)
        {
            Console.WriteLine("Edges in the minimum spanning tree (using Prim):");

            int n = adjMatrix.GetLength(0);
            var used = new bool[n];
            var previous = new int[n];
            var minCostCache = new int[n];

            used[0] = true; // Select initial vertex at random
            for (int i = 0; i < n; i++)
            {
                minCostCache[i] = (adjMatrix[0, i] != 0) ? adjMatrix[0, i] : int.MaxValue;
            }                

            int totalCost = 0;
            for (int k = 0; k < n - 1; k++)
            {
                // Search next edge with minimum weight
                int minCost = int.MaxValue;
                int j = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && minCostCache[i] < minCost)
                    {
                        minCost = minCostCache[i];
                        j = i;
                    }
                }

                used[j] = true;
                Console.Write("({0}, {1}) ", previous[j] + 1, j + 1);
                totalCost += minCost;

                // Update the min cost edge for the current vertex
                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && adjMatrix[j, i] != 0 && minCostCache[i] > adjMatrix[j, i])
                    {
                        minCostCache[i] = adjMatrix[j, i];

                        // Store the predecessor
                        previous[i] = j;
                    }
                }
            }

            Console.WriteLine("\nThe cost of the minimum spanning tree is {0}.", totalCost);
        }

        private static void BuildGraph(string[] input)
        {
            int n = int.Parse(input[0]);

            adjMatrix = new int[n, n];

            for (int i = 1; i < input.Length; i++)
            {
                var line = input[i].Split(' ').Select(int.Parse).ToArray();

                var from = line[0] - 1;
                var to = line[1] - 1;
                var cost = line[2];

                adjMatrix[from, to] = cost;
                adjMatrix[to, from] = cost;
            }
        }

        private static string[] GenerateInput()
        {
            // Considering the input as sequence of pairs of houses and cost between them
            return new string[]
            {
                "8",
                "1 2 12",
                "2 3 32",
                "1 4 18",
                "3 7 22",
                "1 5 15",
                "6 7 12",
                "3 4 99",
                "5 3 12",
                "8 1 32",
                "4 7 12",
                "3 8 22"
            };
        }
    }
}
