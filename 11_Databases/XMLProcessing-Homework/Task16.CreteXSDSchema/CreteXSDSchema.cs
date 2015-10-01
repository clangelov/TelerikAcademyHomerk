// Task 16
// Using Visual Studio generate an XSD schema for the file catalog.xml.
// Write a C# program that takes an XML file and an XSD file (schema) and validates the XML file against the schema.
// Test it with valid XML catalogs and invalid XML catalogs.
namespace Task16.CreteXSDSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class CreteXSDSchema
    {
        public static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(null, "../../catalogueSchema.xsd");

            var catalogue = XDocument.Load("../../../Task01.GenerateXML/catalogue.xml");

            ValidateXMLAgainstSchema(catalogue, schema);

            var invalidCatalogue = XDocument.Load("../../invalidCatalogue.xml");

            ValidateXMLAgainstSchema(invalidCatalogue, schema);
        }

        private static void ValidateXMLAgainstSchema(XDocument xmlDoc, XmlSchemaSet schema)
        {
            bool errors = false;

            xmlDoc.Validate(schema, (o, ev) =>
            {
                Console.WriteLine(ev.Message);
                errors = true;
            });

            Console.WriteLine("the xml file {0} against catalogueSchema.xsd", errors ? "did not validate" : "validated");
        }
    }
}
