using Dcf.Kids.Framework.Core;
using Dcf.Kids.WiKids.Data.Models.Case;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Accessors.Case
{
   public class GetCase : IGetCase
   {
      private readonly IDbContext _dbContext;

      public GetCase()
      { }

      /// <summary>Initializes a new instance of the <see cref="GetParticipant"/> class.</summary>
      /// <param name="dbContext">The database context.</param>
      public GetCase(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Executes the specified request.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public IEnumerable<ICase> Execute(ICaseRequest request)
      {
         var parameters = new DbParameter[]
         {
            new KidsDbParameter()
            {
               ParameterName = "Case",
               Value = request.CaseNumber.TrimNullable(),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            }
         };

         var commandText = "SELECT DISTINCT TRIM(C.NB_CASE_CRT) CourtCaseNumber, TRIM(CNTY.NM_CNTY) County, TRIM(CT.DE_CASE_TYPE) CaseTypeDescription, PC.ID_PART PayeeParticipantId,";
         commandText += $" PCO.ID_PART PayerParticipantId FROM {WiKidsConfig.DbOwnerPrefix}.TCASE C INNER JOIN {WiKidsConfig.DbOwnerPrefix}.TPART_CASE PC ON C.NB_CASE = PC.NB_CASE AND PC.CD_CASE_RELSHP = 'CP'";
         commandText += $" INNER JOIN {WiKidsConfig.DbOwnerPrefix}.TPART_CASE PCO ON C.NB_CASE = PCO.NB_CASE AND PCO.CD_CASE_RELSHP = 'NCP' AND PCO.CD_PART_STAT = 'A'";
         commandText += $" INNER JOIN {WiKidsConfig.DbOwnerPrefix}.TCD_CASE_TYPE CT ON C.CD_CASE_TYPE = CT.CD_CASE_TYPE";
         commandText += $" LEFT OUTER JOIN {WiKidsConfig.DbOwnerPrefix}.TCOUNTY CNTY ON C.CD_FIPS_CASE = CNTY.ID_3PTY AND CNTY.CD_3PTY_TYPE = 'AGCY'";
         commandText += $" WHERE C.NB_CASE = @Case AND PC.ID_PART<> PCO.ID_PART WITH UR";

         var results = _dbContext.Execute<Models.Case.Case>(commandText, parameters, CommandType.Text);

         return results;
      }
   }
}
