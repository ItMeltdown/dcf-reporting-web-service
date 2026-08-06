using Dcf.Kids.Framework.Core;
using Dcf.Kids.Framework.Xml;
using System;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Dcf.Kids.WiKids.Utility
{
   public static class ParameterString
   {
      private const string Environment = "SERVER";
      private const string DebugOff = "DEBUG-OFF";
      private const string DebugOn = "DEBUG-ON";

      public static string FormatFkka5500(string requestId, string callType, string debugIndicator, string callProcess, int resultsetCount)
      {
         var debug = string.Equals(debugIndicator.TrimNullable(), Constants.BooleanIndicator.True, System.StringComparison.OrdinalIgnoreCase) ? DebugOn : DebugOff;
          
         return string.Concat(
            requestId.PadRight(30),
            callType.PadRight(8),
            Environment.PadRight(9),
            debug.PadRight(9),
            callProcess.PadRight(30), 
            resultsetCount.ToString("00")
         );
      }

      public static string FormatFkka5500KeyValueFromXml(string inputXml)
      {
         var xslt = new StringBuilder();

         xslt.Append("<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"><xsl:output method=\"text\"/>");
         xslt.Append("<xsl:template match=\"*/*\">");
         xslt.Append("<xsl:value-of select=\"concat('|',name(@*), '=',@*)\"/>");
         xslt.Append("</xsl:template></xsl:stylesheet>");

         var xmlTransformer = new XmlTransformer();

         return xmlTransformer.TransformToXml(xslt.ToString(), inputXml);
      }

      public static string FormatFkka5500KeyValueFromXmlAttributes(object input, params string[] excludedAttributes)
      {
         var keyValueParameter = new StringBuilder();

         foreach(PropertyInfo property in input.GetType().GetPublicProperties())
         {
            var xmlAttributeAttribute = property.GetCustomAttribute<System.Xml.Serialization.XmlAttributeAttribute>();
            if (xmlAttributeAttribute != null)
            {
               var key = xmlAttributeAttribute.AttributeName;
               var value = property.GetValue(input) ?? "";

               if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrEmpty(value.ToString()) && !excludedAttributes.Contains(key))
                  keyValueParameter.Append(key + "=" + value + "|");
            }
         }

         return keyValueParameter.ToString();
      }
   }
}