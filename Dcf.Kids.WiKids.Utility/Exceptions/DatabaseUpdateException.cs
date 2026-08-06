using Dcf.Kids.WiKids.Utility.Enumerations;
using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class DatabaseUpdateException : Exception
   {
      public DatabaseUpdateException(string message)
         : base(message) { }

      public DatabaseUpdateException(string message, StoredProcedureStatusCode reasonCode)
         : base($"ReasonCode: {reasonCode.ToString()} {Environment.NewLine} {message}")
      {
         ReasonCode = reasonCode;
      }

      public StoredProcedureStatusCode ReasonCode
      {
         get;
      }
   }
}
