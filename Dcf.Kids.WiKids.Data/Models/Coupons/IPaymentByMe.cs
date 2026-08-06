using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public interface IPaymentByMe
   {
      string TRNDATE { get; set; }

      decimal TRNAMT { get; set; }

      string TRNSRC { get; set; }
   }
}
