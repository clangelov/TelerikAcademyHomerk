namespace Task01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var line = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int n = line[0];
            int m = line[1];

            var graph = Enumerable.Range(0, n)
                .Select(i => new List<Node>())
                .ToArray();

            var hospitals = new HashSet<int>(Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x) - 1));

            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int from = input[0] - 1;
                int to = input[1] - 1;
                int weigth = input[2];

                graph[from].Add(new Node(to, weigth));
                graph[to].Add(new Node(from, weigth));
            }

            var minDist = int.MaxValue;

            foreach (var position in hospitals)
            {
                minDist = Math.Min(minDist, Dijkstra(graph, position).Where((dist, i) => !hospitals.Contains(i)).Sum());
            }                

            Console.WriteLine(minDist);
        }

        private static int[] Dijkstra(List<Node>[] graph, int position)
        {
            var queue = new Queue<int>();
            queue.Enqueue(position);

            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[position] = 0;

            while (queue.Count != 0)
            {
                int currentNodeId = queue.Dequeue();
                foreach (var neighbour in graph[currentNodeId])
                {
                    int newDistance = distances[currentNodeId] + neighbour.Weight;
                    if (newDistance < distances[neighbour.ToNode])
                    {
                        distances[neighbour.ToNode] = newDistance;
                        queue.Enqueue(neighbour.ToNode);
                    }
                }
            }

            return distances;
        }
    }
}
