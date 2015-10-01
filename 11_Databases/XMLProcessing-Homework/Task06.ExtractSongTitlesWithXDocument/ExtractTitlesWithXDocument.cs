// Task 06
// Rewrite the same from Task 05 using XDocument and LINQ query.
namespace Task06.ExtractSongTitlesWithXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractTitlesWithXDocument
    {
        public static void Main()
        {
            XDocument catalogue = XDocument.Load("../../../Task01.GenerateXML/catalogue.xml");

            var songs =
                from song in catalogue.Descendants("song")
                select song.Element("title").Value;

            Console.WriteLine("Found {0} songs:", songs.Count());

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
