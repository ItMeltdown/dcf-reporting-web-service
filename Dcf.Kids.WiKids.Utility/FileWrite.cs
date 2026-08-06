using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Dcf.Kids.WiKids.Utility
{
   public static class FileWrite
   {
      public static void WriteObjectToFile<T> (object objectToWrite, string filePath)
      {
         XmlSerializer xmlObj = new XmlSerializer(typeof(T));

         var xml = "";

         using (var sww = new Utf8StringWriter())
         {
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
               xmlObj.Serialize(writer,objectToWrite);
               xml = sww.ToString(); // Your XML

               File.WriteAllText(filePath, xml);
            }
         }
      }

      public class Utf8StringWriter : StringWriter
      {
         public override Encoding Encoding
         {
            get { return new UTF8Encoding(false); }
         }
      }
   }
}
