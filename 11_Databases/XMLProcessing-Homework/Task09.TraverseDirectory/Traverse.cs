// Task 09
// Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
// Use tags<file> and<dir> with appropriate attributes.
// For the generation of the XML document use the class XmlWriter.
namespace Task09.TraverseDirectory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class Traverse
    {
        public static void Main()
        {            
            string fileName = "../../result.xml";
            Encoding encoding = Encoding.UTF8;

            Console.WriteLine("Startig to traverse... Please Wait");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directory");
                TraverseDirectories(writer, "../../");
                writer.WriteEndDocument();
            }

            Console.WriteLine("Genereted result.xml in the main directory of the project");
        }

        private static void TraverseDirectories(XmlTextWriter writer, string dir)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                TraverseDirectories(writer, directory);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileName(file));
                writer.WriteEndElement();
            }
        }
    }
}
