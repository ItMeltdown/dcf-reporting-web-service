using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class DatabaseTimeoutException : Exception
   {
      public DatabaseTimeoutException(string message)
         : base(message)
      {
      }

   }
}
