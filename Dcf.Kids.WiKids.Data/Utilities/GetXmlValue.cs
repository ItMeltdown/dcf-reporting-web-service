using System;
using System.IO;
using System.Xml.XPath;

namespace Dcf.Kids.WiKids.Data.Utilities
{
   /// <summary>
   /// This utility gets the value of an XML node selected by XPath.
   /// </summary>
   public static class GetXmlValue
   {
      /// <summary>
      /// Returns the value for the XPath in the XML file location passed in as input.
      /// </summary>
      /// <param name="fileLocation">The filelocation parameter indicates where the file is located</param>
      /// <param name="xPath">The xPath parameter indicates which node the desired value resides in</param>
      /// <returns>String value selected by xPath expression</returns>
      public static string Execute(string fileLocation, string xPath)
      {
         if (fileLocation == null) throw new ArgumentNullException("fileLocation");
         if (xPath == null) throw new ArgumentNullException("xPath");
         if (!File.Exists(fileLocation)) throw new Exception("Missing XML File");

         var doc = new XPathDocument(fileLocation);
         return GetNodeValue(doc, xPath);
      }

      /// <summary>
      /// Returns the value for the XPath in the XML stream passed in as input.
      /// </summary>
      /// <param name="xmlStream">The stream containing XML</param>
      /// <param name="xPath">The xPath parameter indicates which node the desired value resides in</param>
      /// <returns>String value selected by xPath expression</returns>
      public static string Execute(Stream xmlStream, string xPath)
      {
         if (xmlStream == null) throw new ArgumentNullException("xmlStream");
         if (xPath == null) throw new ArgumentNullException("xPath");

         var doc = new XPathDocument(xmlStream);
         return GetNodeValue(doc, xPath);
      }

      /// <summary>
      /// Returns the value for the XPath in the XPathDocument passed in as input
      /// </summary>
      /// <param name="xPathDocument">The XML document</param>
      /// <param name="xPath">The xPath parameter indicates which node the desired value resides in</param>
      /// <returns>String value selected by xPath expression</returns>
      private static string GetNodeValue(XPathDocument xPathDocument, string xPath)
      {
         var node = xPathDocument.CreateNavigator().SelectSingleNode(xPath);
         return node == null ? null : node.Value;
      }
   }
}
