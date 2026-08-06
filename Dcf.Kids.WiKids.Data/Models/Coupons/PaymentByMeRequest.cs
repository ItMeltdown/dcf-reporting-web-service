using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public class PaymentByMeRequest : IPaymentByMeRequest
   {
      public string Pin { get; set; }

      public DateTime DateFrom { get; set; }

      public DateTime DateTo { get; set; }
   }
}
