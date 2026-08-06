using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.SystemAccount;
using System.Collections.Generic;

namespace Dcf.Kids.WiKids.Data.Accessors.SystemAccount
{
   public interface IGetSystemAccount : IDataAccessor<ISystemAccountRequest, IEnumerable<ISystemAccount>>
   {
   }
}
