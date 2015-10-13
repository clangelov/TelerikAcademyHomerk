namespace Task03.CategoriesAndProductNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class RetrieveCategoriesAndProductNames
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.;Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCategoriesAndProductsNames = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON p.CategoryID = c.CategoryID ORDER BY c.CategoryName", dbCon);
                SqlDataReader reader = cmdCategoriesAndProductsNames.ExecuteReader();

                using (reader)
                {
                    var categoriesAndProducts = new Dictionary<string, List<string>>();

                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];
                        if (!categoriesAndProducts.Keys.Contains(categoryName))
                        {
                            categoriesAndProducts.Add(categoryName, new List<string>());
                            categoriesAndProducts[categoryName].Add(productName);
                        }
                        else
                        {
                            categoriesAndProducts[categoryName].Add(productName);
                        }
                    }

                    DisplayResult(categoriesAndProducts);
                }
            }
        }

        private static void DisplayResult(Dictionary<string, List<string>> categoriesAndProducts)
        {
            int counter = 1;
            foreach (var category in categoriesAndProducts.Keys)
            {
                Console.WriteLine("{0}. {1} has {2} Products: ", counter, category, categoriesAndProducts[category].Count);
                Console.WriteLine("--- {0}", string.Join(", ", categoriesAndProducts[category]));
                counter++;
            }
        }
    }
}
