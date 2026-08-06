using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class BlockedAccountException : Exception
   {
      public BlockedAccountException()
         : base()
      {
      }

      public BlockedAccountException(string message)
         : base(message)
      {
      }

      public BlockedAccountException(string message, Exception innerException)
         : base(message, innerException)
      {
      }
   }
}
