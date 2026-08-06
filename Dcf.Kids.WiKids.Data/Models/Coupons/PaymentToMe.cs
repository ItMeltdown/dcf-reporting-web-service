using System;
using System.Xml.Serialization;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{

   public class PaymentToMe : IPaymentToMe
   {
      private string _dsbDate;

      public string DSBDATE
      {
         get { return DateTime.Parse(_dsbDate).ToString("MM/dd/yyyy"); }
         set { _dsbDate = value; }
      }

      public decimal DSBAMT { get; set; }

      public string LNAME { get; set; }

      public string FNAME { get; set; }

      public string CRTCASE { get; set; }

      public string DSBSRC { get; set; }
   }
}
