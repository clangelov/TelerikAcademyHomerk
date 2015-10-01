// Task 05
// Write a program, which using XmlReader extracts all song titles from catalog.xml.
namespace Task05.ExtractsSongTitles
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractSongTitles
    {
        public static void Main()
        {
            Console.WriteLine("Extracting all unique song titles: ");

            var songs = new HashSet<string>();

            using (XmlReader reader = XmlReader.Create("../../../Task01.GenerateXML/catalogue.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        var song = reader.ReadElementString();
                        songs.Add(song);
                    }
                }
            }

            foreach (var item in songs)
            {
                Console.WriteLine(item);
            }            
        }
    }
}
