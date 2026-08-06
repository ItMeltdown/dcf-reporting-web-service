using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class InvalidRowCountException : Exception
   {
      public InvalidRowCountException(string message)
         : base(message)
      {
      }

      public InvalidRowCountException(string message, Exception innerException)
         : base(message, innerException)
      {
      }
   }
}
