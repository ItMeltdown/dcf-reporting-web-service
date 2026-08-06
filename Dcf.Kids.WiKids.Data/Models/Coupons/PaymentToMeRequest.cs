using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public class PaymentToMeRequest : IPaymentToMeRequest
   {
      public string Pin { get; set; }

      public DateTime DateFrom { get; set; }

      public DateTime DateTo { get; set; }
   }
}
