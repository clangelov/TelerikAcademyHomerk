// Task 12
// Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
// Use LINQ query.
namespace Task12.ExtractPricesLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractPriceWithLinq
    {
        public static void Main()
        {
            XDocument catalogue = XDocument.Load("../../../Task01.GenerateXML/catalogue.xml");
            
            var albums =
                from album in catalogue.Descendants("album")
                where int.Parse(album.Element("year").Value) < 2010
                select new
                {
                    Name = album.Element("name").Value,
                    Year = int.Parse(album.Element("year").Value),
                    Price = double.Parse(album.Element("price").Value)
                };

            foreach (var album in albums)
            {
                Console.WriteLine("Album {0} was released in {1} costs {2:C2}", album.Name, album.Year, album.Price);
            }
        }
    }
}
