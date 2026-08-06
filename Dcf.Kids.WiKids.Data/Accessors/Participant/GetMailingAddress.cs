using Dcf.Kids.Framework.Core;
using Dcf.Kids.WiKids.Data.Models.Participant;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Accessors.Participant
{
   /// <summary>
   /// Retrieve the verified mailing address for the request participant
   /// </summary>
   public class GetMailingAddress : IGetMailingAddress
   {
      private readonly IDbContext _dbContext;

      public GetMailingAddress()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="GetMailingAddress"/> class.
      /// </summary>
      /// <param name="dbContext">The database context.</param>
      public GetMailingAddress(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Get the verified mailing address
      /// </summary>
      /// <param name="input">Input parameters</param>
      /// <returns></returns>
      public IEnumerable<IMailingAddress> Execute(IMailingAddressRequest input)
      {
         var parameters = new DbParameter[]
         {
            new KidsDbParameter()
            {
               ParameterName = "participantId",
               Value = input.ParticipantId.TrimNullable(),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            },
         };

         var commandText = string.Format("{0}.fkkasadh", WiKidsConfig.DbOwnerPrefix);
         var results = _dbContext.Execute<MailingAddress>(commandText, parameters, CommandType.StoredProcedure);

         // Clean up the values returned from the stored procedure
         foreach (var result in results)
         {
            result.Address1 = result.Address1.TrimNullable();
            result.Address2 = result.Address2.TrimNullable();
            result.Address3 = result.Address3.TrimNullable();
            result.Address4 = result.Address4.TrimNullable();
            result.Address5 = result.Address5.TrimNullable();
         }

         return results;
      }
   }
}
