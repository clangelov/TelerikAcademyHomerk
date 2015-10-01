// Task 07
// In a text file we are given the name, address and phone number of given person (each at a single line).
// Write a program, which creates new XML document, which contains these data in structured XML format.
namespace Task07.GenerateXMLDocument
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class GenerateXML
    {
        public static void Main()
        {
            string[] data = File.ReadAllLines("../../persons.txt");

            XElement root = new XElement("persons");

            for (int i = 0; i < data.Length; i += 3)
            {
                var person = new XElement("person",
                    new XElement("name", data[i]),
                    new XElement("phone", data[i + 1]),
                    new XElement("addres", data[i + 2]));

                root.Add(person);
            }

            Console.WriteLine("Genereted result.xml in the main directory of the project");

            root.Save("../../result.xml");            
        }
    }
}
