namespace Task01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var products = GetProducts();
            int capacity = 100;

            var result = GetItems(products, capacity);

            Console.WriteLine("Total weight: {0}", result.Sum(i => i.Weight));
            Console.WriteLine("Highest cost: {0}", result.Sum(i => i.Cost));
            Console.WriteLine("Take items: {0}", string.Join(", ", result.Select(i => i.Name).OrderBy(x => x)));
        }

        private static IEnumerable<Product> GetItems(List<Product> products, int capacity)
        {
            // Fill table
            int[,] table = new int[products.Count + 1, capacity + 1];
            for (int row = 1; row <= products.Count; row++)
            {
                var item = products[row - 1];
                for (int col = 0; col <= capacity; col++)
                {
                    if (item.Weight > col)
                    {
                        table[row, col] = table[row - 1, col];
                    }
                    else
                    {
                        table[row, col] = Math.Max(
                            table[row - 1, col],
                            table[row - 1, col - item.Weight] + item.Cost);
                    }
                }
            }

            // Find which items to take from the table
            var result = new List<Product>();
            for (int row = products.Count, col = capacity; row > 0; row--)
            {
                if (table[row, col] != table[row - 1, col])
                {
                    result.Add(products[row - 1]);
                    col -= products[row - 1].Weight;
                }
            }

            return result;
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>() {
                new Product("Vodaka", 8, 12),
                new Product("Beer", 3, 2),
                new Product("Cheese", 4, 5),
                new Product("Nuts", 1, 4),
                new Product("Ham", 3, 2),
                new Product("Whiskey", 8, 13),
                new Product("Apple", 39, 40),
                new Product("Banana", 27, 60),
                new Product("Book", 30, 10),
                new Product("Camera", 32, 30),
                new Product("Cheese", 4, 5),
                new Product("Chocolate Bar", 15, 60),
                new Product("Compass", 13, 35),
                new Product("Jeans", 48, 10),
                new Product("Map", 9, 150),
                new Product("Notebook", 22, 80),
                new Product("Sandwich", 50, 160),
                new Product("Sunglasses", 7, 20),
                new Product("T-Shirt", 24, 15),
                new Product("Towel", 18, 12),
                new Product("Water", 13, 17)
            };
        }
    }
}
