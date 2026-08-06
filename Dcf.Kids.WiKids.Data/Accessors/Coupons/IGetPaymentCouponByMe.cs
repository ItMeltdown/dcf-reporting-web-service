using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.Coupons;
using Dcf.Kids.WiKids.Data.Models.ThirdParties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dcf.Kids.WiKids.Data.Accessors.Coupons
{
   public interface IGetPaymentCouponByMe : IDataAccessor<IPaymentByMeRequest, IEnumerable<IPaymentByMe>>
   {
   }
}
