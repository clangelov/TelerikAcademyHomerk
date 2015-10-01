// Task 14
// Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class
namespace Task14.ApplyXSLTStylesheet
{
    using System;
    using System.Xml.Xsl;

    public class ApplyStylesheet
    {
        public static void Main()
        {
            // Warning CS0618  'XslTransform' is obsolete: 'This class has been deprecated. 
            // Please use System.Xml.Xsl.XslCompiledTransform instead. http://go.microsoft.com/fwlink/?linkid=14202'  

            var myXslTransform = new XslCompiledTransform();

            myXslTransform.Load("../../../Task13.CreateXSLStylesheet/catalogue.xsl");

            myXslTransform.Transform("../../../Task01.GenerateXML/catalogue.xml", "../../result.html");

            Console.WriteLine("Genereted result.html in the main directory of the project");
        }
    }
}
