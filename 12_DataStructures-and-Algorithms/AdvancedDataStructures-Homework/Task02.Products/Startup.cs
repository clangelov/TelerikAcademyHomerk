namespace Task02.Products
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private const int NumberOfProducst = 500000;
        private const int PriceSearches = 10000;
        private const int ProductsCountPerSearch = 20;

        private static readonly Random Rand = new Random();

        public static void Main()
        {
            OrderedBag<Product> productsList = GenerateProducts();

            Console.WriteLine("Total number of products {0}", productsList.Count);

            PerformTaskSearches(productsList);
        }

        private static void PerformTaskSearches(OrderedBag<Product> productsList)
        {
            decimal fromPrice = 0M;
            decimal toPrice = 2M;

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < PriceSearches; i++)
            {
                var range = GetProductsInRange(productsList, fromPrice, fromPrice);
                fromPrice += 2M;
                toPrice += 2M;
            }

            sw.Stop();
            Console.WriteLine("{0} searches in {1} products done in {2} milliseconds.", PriceSearches, NumberOfProducst, sw.ElapsedMilliseconds);
        }

        private static IEnumerable<Product> GetProductsInRange(OrderedBag<Product> productsList, decimal fromPrice, decimal toPrice)
        {
            var range = productsList.Range(new Product() { Name = "Test", Price = fromPrice }, true, new Product() { Name = "Test", Price = toPrice }, true).Take(ProductsCountPerSearch);

            return range;
        }

        private static OrderedBag<Product> GenerateProducts()
        {
            Console.WriteLine("Genereting Products...");
            OrderedBag<Product> result = new OrderedBag<Product>();

            for (int i = 0; i < NumberOfProducst; i++)
            {
                result.Add(new Product
                {
                    Name = "Product" + i,
                    Price = Rand.Next(0, 20000)
                });

                if (i % 100000 == 0)
                {
                    Console.Write(".");
                }
            }

            return result;
        }
    }
}
