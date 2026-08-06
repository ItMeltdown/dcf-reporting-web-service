using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class NotAuthorizedFunctionAccessException : Exception
   {
      public NotAuthorizedFunctionAccessException()
         : base()
      {
      }

      public NotAuthorizedFunctionAccessException(string message)
         : base(message)
      {
      }

      public NotAuthorizedFunctionAccessException(string message, Exception innerException)
         : base(message, innerException)
      {
      }
   }
}
