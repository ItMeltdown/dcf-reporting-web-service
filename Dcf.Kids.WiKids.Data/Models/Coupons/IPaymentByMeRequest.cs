using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public interface IPaymentByMeRequest
   {
      string Pin { get; set; }

      DateTime DateFrom { get; set; }

      DateTime DateTo { get; set; }
   }
}