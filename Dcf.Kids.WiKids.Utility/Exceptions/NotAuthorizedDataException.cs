using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class NotAuthorizedDataException : Exception
   {
      public NotAuthorizedDataException()
         : base()
      {
      }

      public NotAuthorizedDataException(string message)
         : base(message)
      {
      }

      public NotAuthorizedDataException(string message, Exception innerException)
         : base(message, innerException)
      {
      }
   }
}