using Dcf.Kids.Framework.Core;
using Dcf.Kids.WiKids.Data.Models.Participant;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Accessors.Participant
{
   public class GetParticipant : IGetParticipant
   {
      private readonly IDbContext _dbContext;

      public GetParticipant()
      { }

      /// <summary>Initializes a new instance of the <see cref="GetParticipant"/> class.</summary>
      /// <param name="dbContext">The database context.</param>
      public GetParticipant(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Executes the specified request.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public IEnumerable<IParticipant> Execute(IParticipantRequest request)
      {
         var parameters = new DbParameter[]
        {
            new KidsDbParameter()
            {
               ParameterName = "Id",
               Value = request.ParticipantId.TrimNullable(),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            }
        };

         var commandText = "SELECT TRIM(NM_PART_F) FirstName, TRIM(NM_PART_L) LastName, TRIM(NM_PART_SFX) Suffix, TO_DATE(NULLIF(TRIM(DT_BRTH), ''), 'YYYYMMDD') DateOfBirth";
         commandText += $" FROM {WiKidsConfig.DbOwnerPrefix}.TPARTICIPANT WHERE ID_PART = @Id WITH UR";

         var results = _dbContext.Execute<Models.Participant.Participant>(commandText, parameters, CommandType.Text);

         return results;
      }
   }
}
