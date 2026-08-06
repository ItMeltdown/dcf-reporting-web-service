using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dcf.Kids.WiKids.Data.Models.Coupons
{
   public class PaymentByCaseRequest : IPaymentByCaseRequest
   {
      public string Case { get; set; }

      public DateTime DateFrom { get; set; }

      public DateTime DateTo { get; set; }
   }
}
