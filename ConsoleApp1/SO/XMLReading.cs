using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp1.SO
{
    public class XMLReading
    {
        public class Hello
        {
            public IList<string> HellosList { get; set; }
        }

        public static void ReadXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            var nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", "urn:oasis:names:tc:evs:schema:eml");

            XmlNode testNode = doc.SelectSingleNode("/ns:EML/ns:EMLHeader/ns:ManagingAuthority/ns:Description", nsmgr);
            if (testNode != null)
            {
                Console.WriteLine(testNode.InnerText);
            }
        }

        public static void CommentOutXML(string fileName, string outFileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            // Get the target node using XPath
            System.Xml.XmlNode elementToComment = doc.SelectSingleNode("/configuration/system.web/customErrors");

            // Get the XML content of the target node
            String commentContents = elementToComment.OuterXml;

            // Create a new comment node
            // Its contents are the XML content of target node
            System.Xml.XmlComment commentNode = doc.CreateComment(commentContents);

            // Get a reference to the parent of the target node
            System.Xml.XmlNode parentNode = elementToComment.ParentNode;

            // Replace the target node with the comment
            parentNode.ReplaceChild(commentNode, elementToComment);

            doc.Save(outFileName);
        }
    }
}
