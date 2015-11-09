namespace Task02.ArticlesInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private const int NumberOfProducts = 500;
        private const string TitleOfArticle = "Beer";
        private const int InitalBarCode = 1000000000;

        private static readonly string[] Vendors = new string[] { "Fullers", "BrewDog", "Mikkeller", "Duvel", "Chimay", "White Stork" };
        private static Random rand = new Random();

        public static void Main()
        {
            OrderedMultiDictionary<decimal, Article> allArticels = GenerateProducts();

            FindProductsInRange(allArticels, 4, 5);
        }

        private static void FindProductsInRange(OrderedMultiDictionary<decimal, Article> allArticels, int startPrice, int endPrice)
        {
            var productsInRage = allArticels.Range(startPrice, true, endPrice, true);

            foreach (var item in productsInRage)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static OrderedMultiDictionary<decimal, Article> GenerateProducts()
        {
            var result = new OrderedMultiDictionary<decimal, Article>(true);

            for (int i = 0; i < NumberOfProducts; i++)
            {
                var productToAdd = new Article
                {
                    BarCode = InitalBarCode + i,
                    Vendor = Vendors[rand.Next(0, Vendors.Length)],
                    Title = TitleOfArticle,
                    Price = (decimal)RandomPriceInRange(2, 15)
                };

                result.Add(productToAdd.Price, productToAdd);
            }

            return result;
        }

        private static double RandomPriceInRange(double start, double end)
        {
            double result = start + rand.NextDouble() * (end - start);
            return Math.Round(result, 2);
        }
    }
}
