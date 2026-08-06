using Dcf.Kids.Framework.Core;
using Dcf.Kids.WiKids.Data.Models.Coupons;
using Dcf.Kids.WiKids.Data.Utilities;
using Dcf.Kids.WiKids.Utility;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Accessors.Coupons
{
   public class GetPaymentCouponByMe : IGetPaymentCouponByMe
   {

      private readonly IDbContext _dbContext;

      public GetPaymentCouponByMe()
      { }

      /// <summary>
      /// Initializes a new instance of the <see cref="GetPaymentCouponByCase"/> class.
      /// </summary>
      /// <param name="dbContext">The database context.</param>
      public GetPaymentCouponByMe(IDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Executes the specified database request for Payment by Case.
      /// </summary>
      /// <param name="request">The Payment By Case request.</param>
      /// <returns>A list of rows returned from the store procedure.</returns>
      public IEnumerable<IPaymentByMe> Execute(IPaymentByMeRequest request)
      {
         var parameters = new DbParameter[]
        {
            new KidsDbParameter()
            {
               ParameterName = "pin",
               Value = request.Pin.TrimNullable(),
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            },
            new KidsDbParameter()
            {
               ParameterName = "dtfrom",
               Value = request.DateFrom,
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            },
            new KidsDbParameter()
            {
               ParameterName = "dtto",
               Value = request.DateTo,
               DbType = DbType.String,
               Direction = ParameterDirection.Input
            }

        };

         var commandText = string.Format("{0}.fkkaspfm", WiKidsConfig.DbOwnerPrefix);
         var results = _dbContext.Execute<PaymentByMe>(commandText, parameters, CommandType.StoredProcedure);

         return results;
      }
   }
}
