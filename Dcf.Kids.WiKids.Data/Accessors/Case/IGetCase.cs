using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.Case;
using System.Collections.Generic;

namespace Dcf.Kids.WiKids.Data.Accessors.Case
{
   public interface IGetCase : IDataAccessor<ICaseRequest, IEnumerable<ICase>>
   {
   }
}
