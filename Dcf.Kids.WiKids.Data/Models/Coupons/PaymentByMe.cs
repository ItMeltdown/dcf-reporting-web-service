using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public class PaymentByMe : IPaymentByMe
   {
      private string _tranDate;

      public string TRNDATE
      {
         get { return DateTime.Parse(_tranDate).ToString("MM/dd/yyyy"); }
         set { _tranDate = value; }
      }

      public decimal TRNAMT { get; set; }

      public string TRNSRC { get; set; }
   }
}
