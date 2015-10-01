// Tasks 04
// Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
namespace Task04.DeleteExpensiveAlbums
{
    using System;
    using System.Xml;

    public class DeleteAlbums
    {
        private const double MaxPrice = 20;

        public static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../Task01.GenerateXML/catalogue.xml");

            foreach (XmlNode node in catalogue.DocumentElement)
            {
                double price = double.Parse(node["price"].InnerText);

                if (price > MaxPrice)
                {
                    var albumName = node["name"].InnerText;
                    var artistName = node["artist"].InnerText;
                    Console.WriteLine("Removing {0} album from {1}, valued at {2:C2}", albumName, artistName, price);
                    node.RemoveAll();
                }
            }

            Console.WriteLine("The final result is recoreded in withRemovedExpensiveAlbums.xml");
            catalogue.Save("../../withRemovedExpensiveAlbums.xml");
        }
    }
}
