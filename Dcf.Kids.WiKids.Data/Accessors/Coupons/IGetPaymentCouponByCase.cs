using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.Coupons;
using System.Collections.Generic;

namespace Dcf.Kids.WiKids.Data.Accessors.Coupons
{
   public interface IGetPaymentCouponByCase : IDataAccessor<IPaymentByCaseRequest, IEnumerable<IPaymentByCase>>
   {
   }
}
