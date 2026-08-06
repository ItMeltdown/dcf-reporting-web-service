using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public interface IPaymentToMe
   {
      string DSBDATE { get; set; }

      decimal DSBAMT { get; set; }

      string LNAME { get; set; }

      string FNAME { get; set; }

      string CRTCASE { get; set; }

      string DSBSRC { get; set; }
   }
}
