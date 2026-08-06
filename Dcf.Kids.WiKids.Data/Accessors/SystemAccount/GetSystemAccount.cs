using Dcf.Kids.Framework.Core;
using Dcf.Kids.WiKids.Data.Models.SystemAccount;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dcf.Kids.WiKids.Data.Accessors.SystemAccount
{
   public class GetSystemAccount : IGetSystemAccount
   {
      private readonly IDbContext _dbContext;

      public GetSystemAccount()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="GetSystemAccount"/> class.
      /// </summary>
      /// <param name="dbContext">The database context.</param>
      public GetSystemAccount(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Executes the specified request.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public IEnumerable<ISystemAccount> Execute(ISystemAccountRequest request)
      {
          var parameters = new DbParameter[]
         {
            new KidsDbParameter()
            {
               ParameterName = "Id",
               Value = request.SystemAccountId.TrimNullable(),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            }
         };

         var commandText = $"SELECT TRIM(NM_SYST_ACCT) Name FROM {WiKidsConfig.DbOwnerPrefix}.TCD_SYST_ACCT WHERE CD_SYST_ACCT = @Id WITH UR";

         var results = _dbContext.Execute<Models.SystemAccount.SystemAccount>(commandText, parameters, CommandType.Text);

         return results;
      }
   }
}
