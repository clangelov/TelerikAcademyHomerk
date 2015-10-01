// Task 02
// Write program that extracts all different artists which are found in the catalog.xml.
// For each author you should print the number of albums in the catalogue.
// Use the DOM parser and a hash-table.
namespace Task02.ExtractArtistsDOMParser
{
    using System;
    using System.Collections;
    using System.Xml;

    public class ReadXmlWithDomParser
    {
        public static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load("../../../Task01.GenerateXML/catalogue.xml");
            
            Hashtable artists = new Hashtable();

            XmlNode rootNode = catalogue.DocumentElement;

            GetArtistsAndNumberOfAlbums(rootNode, artists);

            PrintArtistsToConsole(artists);
        }

        private static void GetArtistsAndNumberOfAlbums(XmlNode rootNode, Hashtable artists)
        {
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artistName = node["artist"].InnerText;
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
