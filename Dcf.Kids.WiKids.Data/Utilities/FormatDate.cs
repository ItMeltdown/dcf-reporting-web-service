using Dcf.Kids.Framework.Core;
using System;
using System.Globalization;

namespace Dcf.Kids.WiKids.Data.Utilities
{
   /// <summary>
   /// The FormatDate method accepts a date as a string, formats and returns it as a DateTime type.
   /// </summary>
   public static class FormatDate
   {
      /// <summary>
      /// The Execute method accepts a date as a string, formats and returns it as a DateTime type.
      /// </summary>
      /// <param name="inDate">The incoming date to be formatted</param>
      /// <returns>DateTime value for the outgoing date.</returns>
      public static DateTime Execute(string inDate)
      {
         if (!string.IsNullOrEmpty(inDate.TrimNullable()))
         {
            string dateFormat = string.Empty;
            if (inDate.TrimNullable().Length == 10)
               dateFormat = "yyyy-MM-dd";
            else
               dateFormat = "yyyyMMdd";

            DateTime outDate;
            if (DateTime.TryParseExact(inDate.TrimNullable(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
               return outDate;
         }

         return new DateTime();
      }
      /// <summary>
      /// The Execute method accepts a date and a time as two separate strings, formats and returns
      /// it as a DateTime type with milliseconds.
      /// </summary>
      /// <param name="inDate"></param>
      /// <param name="inTime"></param>
      /// <returns>DateTime value</returns>
      public static DateTime Execute (string inDate, string inTime)
      {
         if (!string.IsNullOrEmpty(inDate.TrimNullable()))
         {
            var dateTimeFormat = "yyyyMMddHHmmssff";
            DateTime outDate;
            var pad = '0';

            if (inTime.TrimNullable().Length < 8)
               inTime = inTime.TrimNullable().PadRight(8, pad);

            if (DateTime.TryParseExact(inDate.TrimNullable() + inTime.TrimNullable(), dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out outDate))
               return outDate;
         }


         return new DateTime();
      }
   }
}
