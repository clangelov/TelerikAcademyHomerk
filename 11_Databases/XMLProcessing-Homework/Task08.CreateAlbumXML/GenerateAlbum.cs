// Task 08
// Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, 
// in which stores in appropriate way the names of all albums and their authors.
namespace Task08.CreateAlbumXML
{
    using System;
    using System.Text;
    using System.Xml;

    public class GenerateAlbum
    {
        public static void Main()
        {
            string fileName = "../../album.xml";
            Encoding encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (XmlReader reader = XmlReader.Create("../../../Task01.GenerateXML/catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {                            
                            if (reader.Name == "name")
                            {
                                writer.WriteStartElement("album");
                                var album = reader.ReadElementString();
                                writer.WriteElementString("name", album);
                            }

                            if (reader.Name == "artist")
                            {
                                var artist = reader.ReadElementString();
                                writer.WriteElementString("artist", artist);
                                writer.WriteEndElement();
                            }                            
                        }
                    }
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("Genereted album.xml in the main directory of the project");
        }
    }
}
