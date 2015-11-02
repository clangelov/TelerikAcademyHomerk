namespace Task01.Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            IList<Node<int>> allNodes = ReadInput();

            var rootNode = FindTheRootNode(allNodes);

            FindAllMiddleNodes(allNodes);

            FindTheLeafNodes(allNodes);

            FindLongestPath(rootNode);
        }

        private static void FindLongestPath(Node<int> root)
        {
            var firstPath = new List<Node<int>>();
            var secondPath = new List<Node<int>>();

            foreach (var child in root.Children)
            {
                var currentPath = MaxPathNodeToLeaf(child);
                if (currentPath.Count > secondPath.Count)
                {
                    if (currentPath.Count > firstPath.Count)
                    {
                        secondPath = firstPath;
                        firstPath = currentPath;
                    }
                    else
                    {
                        secondPath = currentPath;
                    }
                }
            }

            var longestPath = new List<int>();

            for (int i = secondPath.Count - 1; i >= 0; i--)
            {
                longestPath.Add(secondPath[i].Value);
            }

            longestPath.Add(root.Value);

            foreach (var item in firstPath)
            {
                longestPath.Add(item.Value);
            }

            Console.WriteLine("Thelongest path has length of {0}", longestPath.Count);
            Console.WriteLine(string.Join(" -> ", longestPath));
        }

        private static List<Node<int>> MaxPathNodeToLeaf(Node<int> root)
        {
            var longestPath = new List<Node<int>>();

            var path = new List<Node<int>>();
            path.Add(root);

            var stack = new Stack<List<Node<int>>>();
            stack.Push(path);

            while (stack.Count != 0)
            {
                var currentPath = stack.Pop();
                var lastNode = currentPath[currentPath.Count - 1];

                foreach (var child in lastNode.Children)
                {
                    var newPath = new List<Node<int>>(currentPath);
                    newPath.Add(child);
                    stack.Push(newPath);
                }

                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            return longestPath;
        }

        private static void FindAllMiddleNodes(IList<Node<int>> allNodes)
        {
            var middleNodes = allNodes
                .Where(n => n.Parent != null && n.Children.Count > 0)
                .ToList();

            Console.WriteLine("In the given tree there are {0} middle nodes", middleNodes.Count);
            int counter = 1;
            foreach (var item in middleNodes)
            {
                Console.WriteLine("{0}. leaf = {1}", counter, item.Value);
                counter++;
            }
        }

        private static void FindTheLeafNodes(IList<Node<int>> allNodes)
        {
            var leafs = allNodes
                .Where(c => c.Children.Count == 0)
                .ToList();

            Console.WriteLine("In the given tree there are {0} leafs", leafs.Count);
            int counter = 1;
            foreach (var item in leafs)
            {
                Console.WriteLine("{0}. leaf = {1}", counter, item.Value);
                counter++;
            }
        }

        private static Node<int> FindTheRootNode(IList<Node<int>> allNodes)
        {
            var root = allNodes
                .Where(r => r.Parent == null)
                .FirstOrDefault();

            Console.WriteLine("The root of the given tree has value of {0}", root.Value);

            return root;
        }

        private static IList<Node<int>> ReadInput()
        {
            SetInConsole();

            var resultNodes = new List<Node<int>>();

            int elementsLength = int.Parse(Console.ReadLine());

            for (int i = 0; i < elementsLength - 1; i++)
            {
               int[] currentLine = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToArray();

                int parentElementValue = currentLine[0];
                var parentNode = resultNodes.FirstOrDefault(x => x.Value == parentElementValue);

                if (parentNode == null)
                {
                    parentNode = new Node<int>(parentElementValue);
                    resultNodes.Add(parentNode);
                }

                int childElementValue = currentLine[1];
                var childNode = resultNodes.FirstOrDefault(x => x.Value == childElementValue);

                if (childNode == null)
                {
                    childNode = new Node<int>(childElementValue);
                    resultNodes.Add(childNode);
                }

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            return resultNodes;
        }

        private static void SetInConsole()
        {
            Console.SetIn(new StringReader(@"7
2 4
3 2
5 0
3 5
5 6
5 1"));
        }
    }
}
