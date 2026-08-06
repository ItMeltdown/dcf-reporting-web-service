using Dcf.Kids.WiKids.Data.Models.ThirdParties;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Accessors.ThirdParties
{
   /// <summary>
   /// This is a Data Accessor object to interact with the database to retrieve Third Party data.
   /// </summary>
   /// <seealso cref="Dcf.Kids.WiKids.Data.Accessors.ThirdParties.IGetThirdPartyPhone" />
   public class GetThirdPartyPhone : IGetThirdPartyPhone
   {
      private readonly IDbContext _dbContext;

      public GetThirdPartyPhone()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="GetThirdPartyPhone"/> class.
      /// </summary>
      /// <param name="dbContext">The database context.</param>
      public GetThirdPartyPhone(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Executes the specified third party phone request.
      /// </summary>
      /// <param name="thirdPartyPhoneRequest">The third party phone request.</param>
      /// <returns>A list of rows returned from the query.</returns>
      public IEnumerable<IThirdPartyPhone> Execute(IThirdPartyPhoneRequest thirdPartyPhoneRequest)
      {
         var parameters = new DbParameter[]
         {
            new KidsDbParameter()
            {
               ParameterName = "Id",
               Value = thirdPartyPhoneRequest.ThirdPartyId.PadLeft(10, '0'),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            }
         };

         var commandText = $"SELECT TPART_PHONE.ID_PART, TPART_PHONE.CD_TEL_TYPE, TPART_PHONE.NB_TEL_ACD, TPART_PHONE.NB_TEL_EXC, TPART_PHONE.NB_TEL_LN";
         commandText += $" FROM {WiKidsConfig.DbOwnerPrefix}.TPART_PHONE TPART_PHONE WHERE TPART_PHONE.ID_PART = @Id";
         commandText += $" AND(TPART_PHONE.CD_TEL_TYPE = 'CELL' OR TPART_PHONE.CD_TEL_TYPE = 'HOME') ORDER BY TPART_PHONE.ID_PART, TPART_PHONE.CD_TEL_TYPE";

         return _dbContext.Execute<ThirdPartyPhone>(commandText, parameters, CommandType.Text);
      }
   }
}
