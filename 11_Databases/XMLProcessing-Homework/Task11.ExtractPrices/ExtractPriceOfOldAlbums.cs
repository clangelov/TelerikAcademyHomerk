// Task 11
// Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
// Use XPath query.
namespace Task11.ExtractPrices
{
    using System;
    using System.Xml;

    public class ExtractPriceOfOldAlbums
    {
        public static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../Task01.GenerateXML/catalogue.xml");

            string xPathQuery = "/catalogue/album";

            XmlNodeList albumList = catalogue.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumList)
            {
                int year = int.Parse(node.SelectSingleNode("year").InnerText);                

                if (year < 2010)
                {
                    double price = double.Parse(node.SelectSingleNode("price").InnerText);
                    string name = node.SelectSingleNode("name").InnerText;
                    Console.WriteLine("Album {0} was released in {1} costs {2:C2}", name, year, price);
                }                
            }
        }
    }
}
