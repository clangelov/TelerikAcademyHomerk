// Task 03
// Write program that extracts all different artists which are found in the catalog.xml.
// For each author you should print the number of albums in the catalogue.
// Use XPath and a hash-table.
namespace Task03.ExtractArtistsXPath
{
    using System;
    using System.Collections;
    using System.Xml;

    public class ReadXmlWithXPath
    {
        public static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../Task01.GenerateXML/catalogue.xml");

            string xPathQuery = "/catalogue/album";

            XmlNodeList artistList = catalogue.SelectNodes(xPathQuery);

            Hashtable artists = new Hashtable();

            GetArtistsAndNumberOfAlbums(artistList, artists);

            PrintArtistsToConsole(artists);
        }

        private static void GetArtistsAndNumberOfAlbums(XmlNodeList artistList, Hashtable artists)
        {
            foreach (XmlNode node in artistList)
            {
                string artistName = node.SelectSingleNode("artist").InnerText;

                if (!artists.ContainsKey(artistName))
                {
                    artists.Add(node["artist"].InnerText, 1);
                }
                else
                {
                    var lastvalue = (int)artists[artistName];
                    artists[artistName] = ++lastvalue;
                }
            }
        }

        private static void PrintArtistsToConsole(Hashtable artists)
        {
            foreach (var item in artists.Keys)
            {
                Console.WriteLine("Artist {0} has {1} albums", item, artists[item]);
            }
        }
    }
}
