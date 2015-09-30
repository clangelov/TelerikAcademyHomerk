# XML Basics - Homework
- - - -
## Task 01.
### What does the XML language represent? What is it used for?
Extensible Markup Language (XML) is a markup language that defines a set of rules for encoding documents in a format which is both human-readable and machine-readable.

The design goals of XML emphasize simplicity, generality and usability across the Internet. There are hundreds of document formats using XML syntax including RSS, Atom, SOAP, and XHTML. XML-based formats have become the default for many office-productivity tools, including Microsoft Office (Office Open XML), OpenOffice.org and LibreOffice (OpenDocument), and Apple's iWork. XML has also been employed as the base language for communication protocols, such as XMPP. Applications for the Microsoft .NET Framework use XML files for configuration. 
- - - -
## Task02.
### Create XML document students.xml, which contains structured description of students.
* For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).

see file students.xml
- - - -
## Task 03.
### What do namespaces represent in an XML document? What are they used for?
XML namespaces are used for providing uniquely named elements and attributes in an XML document. They are defined in a W3C recommendation.An XML instance may contain element or attribute names from more than one XML vocabulary. If each vocabulary is given a namespace, the ambiguity between identically named elements or attributes can be resolved.

A simple example would be to consider an XML instance that contained references to a customer and an ordered product. Both the customer element and the product element could have a child element named id. References to the id element would therefore be ambiguous; placing them in different namespaces would remove the ambiguity.

XML Namespaces provide a method to avoid element name conflicts and the namespace declaration has the following syntax. xmlns:prefix="URI".
- - - -
## Task 04.
###  Learn more about URI, URN and URL definitions.
Done!
- - - -
## Task 05.
### Add default namespace for students "urn:students".
see file studentsAndNamespace.xml
- - - -
## Task 06.
### Create XSD Schema for students.xml document.
* Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.

see file studentsSchema.xsd
the file is based on studentsNewData.xml
- - - -
## Task 07. 
### Write an XSL stylesheet to visualize the students as HTML.
* Test it in your favourite browser.

works fine in IE 11
open the file students.xml
the stylesheet is students.xsl