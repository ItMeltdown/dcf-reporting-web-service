using System;
using System.Xml.Serialization;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public class PaymentByCase : IPaymentByCase
   {
      private string _pmtDate;

      public string PMTDATE 
         {
         get { return DateTime.Parse(_pmtDate).ToString("MM/dd/yyyy"); }
         set { _pmtDate = value; }
      }

      public decimal PMTAMT { get; set; }

      public string DBTDESC { get; set; }

      public string PMTSRC { get; set; }

      public string DSTTYPE { get; set; }
   }
}
