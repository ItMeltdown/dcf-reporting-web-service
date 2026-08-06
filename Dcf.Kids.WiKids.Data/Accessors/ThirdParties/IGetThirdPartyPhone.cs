using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.ThirdParties;
using System.Collections.Generic;

namespace Dcf.Kids.WiKids.Data.Accessors.ThirdParties
{
   public interface IGetThirdPartyPhone : IDataAccessor<IThirdPartyPhoneRequest, IEnumerable<IThirdPartyPhone>>
   {
   }
}
