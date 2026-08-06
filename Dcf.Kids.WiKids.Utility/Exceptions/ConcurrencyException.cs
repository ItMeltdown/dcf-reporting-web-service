using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class ConcurrencyException : Exception
   {
      public ConcurrencyException(string message)
         : base(message) { }
   }
}
