using System;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public interface IPaymentByCase
   {
      string PMTDATE { get; set; }

      decimal PMTAMT { get; set; }

      string DBTDESC { get; set; }

      string PMTSRC { get; set; }

      string DSTTYPE { get; set; }
   }
}
