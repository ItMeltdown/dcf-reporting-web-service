using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public interface IPaymentByCaseRequest
   {
      string Case { get; set; }

      DateTime DateFrom { get; set; }

      DateTime DateTo { get; set; }
   }
}