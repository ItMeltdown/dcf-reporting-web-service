using Dcf.Kids.Framework.Data;
using Dcf.Kids.WiKids.Data.Models.Participant;
using System.Collections.Generic;

namespace Dcf.Kids.WiKids.Data.Accessors.Participant
{
   public interface IGetMailingAddress : IDataAccessor<IMailingAddressRequest, IEnumerable<IMailingAddress>>
   {
   }
}
